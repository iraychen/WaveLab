using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;
using WaveLab.Service.Utility;

namespace WaveLab.Web
{
    public partial class SPCTxPowerManualGroup : CommonPage
    {
        private const string ACTION = "SPCTxPowerUCL_CL";

        private ISPCTxPowerItemService SPCTxPowerItemService;
        private ISPCTxPowerService SPCTxPowerService;
        private ISYSRoleService RoleService;

        private Hashtable hashTable = new Hashtable();
        private string type, mode, ch, pw;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCTxPowerItemService = (ISPCTxPowerItemService)cxt.GetObject("SV.SPCTxPowerItemService");
            SPCTxPowerService = (ISPCTxPowerService)cxt.GetObject("SV.SPCTxPowerService");
            RoleService = (ISYSRoleService)cxt.GetObject("SV.SYSRoleService");

            type = Request.QueryString["type"];
            mode = Request.QueryString["mode"];
            ch = Request.QueryString["ch"];
            pw = Request.QueryString["pw"];

            if (!Page.IsPostBack)
            {
                SPCTxPowerItemInfo item = new SPCTxPowerItemInfo()
                {
                    Type = type,
                    Mode = mode,
                    CH = ch,
                    PW = pw
                };
                if (SPCTxPowerItemService.CheckExists(item) == false)
                {
                    this.TabPanelAuto.Visible = false;
                }
                if (SPCTxPowerItemService.CheckExists(item) == false) { this.TabPanelAuto.Visible = false; }

                this.tbxDateFrom.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                this.tbxDateTo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.ltlType.Text = type;
                this.ltlMode.Text = mode;
                this.ltlCH.Text = ch;
                this.ltlPW.Text = pw;

                this.tblLCL_UCL.Visible = RoleService.GetActionACRight(User.Identity.Name, ACTION);
            }
        }

        protected void lbtAutoTitle_Click(object sender, EventArgs e)
        {
            Response.Redirect("SPCTxPowerAutoGroup.aspx?1=1&type=" + type + "&mode=" + mode + "&ch=" + ch + "&pw=" + pw);
        }

        private void GetParas()
        {
            if (string.IsNullOrEmpty(type) == false)
            {
                hashTable.Add("type", type);
            }
            if (string.IsNullOrEmpty(mode) == false)
            {
                hashTable.Add("mode", mode);
            }
            if (string.IsNullOrEmpty(ch) == false)
            {
                hashTable.Add("ch", ch);
            }
            if (string.IsNullOrEmpty(pw) == false)
            {
                hashTable.Add("pw", pw);
            }
            if (this.tbxDateFrom.Text.Trim().Length > 0)
            {
                hashTable.Add("date_from", this.tbxDateFrom.Text.Trim());
            }
            if (this.tbxDateTo.Text.Trim().Length > 0)
            {
                hashTable.Add("date_to", this.tbxDateTo.Text.Trim());
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ViewState["sortby"] == null)
            {
                ViewState["sortby"] = "a.end_time";
            }
            if (ViewState["orderby"] == null)
            {
                ViewState["orderby"] = "desc";
            }
            this.BindResult();
        }

        private void BindResult()
        {
            GetParas();
            IList<SPCTxPowerDetail> items = SPCTxPowerService.GetGroupData_Manual(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "noRecordsMsg").ToString();

                this.GVItems.Visible = false;
                this.tblGrouping.Visible = false;
                
            }
            else
            {
                this.lblRecCount.Visible = false;

                this.GVItems.Visible = true;
                this.GVItems.DataSource = items;
                this.GVItems.DataBind();

                this.tblGrouping.Visible = true;
                this.lblItemsCount.Text = this.GetLocalResourceObject("totalMsg").ToString()+items.Count.ToString() +this.GetLocalResourceObject("RecordsMsg").ToString() ;
                
            }

            this.GVGroupItems.Visible = false;
            this.tblSubmit.Visible = false;
        }

        protected void GVItems_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["sortby"].ToString() == e.SortExpression)
            {
                if (ViewState["orderby"].ToString() == "asc")
                {
                    ViewState["orderby"] = "desc";
                }
                else
                {
                    ViewState["orderby"] = "asc";
                }
            }
            else
            {
                ViewState["sortby"] = e.SortExpression;
            }
            this.BindResult();
        }

        protected void btnRanGroup_Click(object sender, EventArgs e)
        {
            int count = this.GVItems.Rows.Count;
            IList<SPCTxPowerDetail> items = new List<SPCTxPowerDetail>();
            int total=0;
            for (int i = 0; i < count; i++)
            {
                CheckBox chx = (CheckBox)this.GVItems.Rows[i].FindControl("chxSelect");
                if (chx.Checked == true)
                {
                    SPCTxPowerDetail item = new SPCTxPowerDetail();
                    item.SerialNo = this.GVItems.Rows[i].Cells[0].Text.Trim();
                    item.EndTime = Convert.ToDateTime(this.GVItems.Rows[i].Cells[1].Text.Trim());
                    item.OutPutPower = this.GVItems.Rows[i].Cells[2].Text.Trim();
                    items.Add(item);
                    total++;
                }
            }

            int groupingNo = int.Parse(this.tbxGroupingNo.Text.Trim());
            int groupCount = (int)System.Math.Floor((double)total / groupingNo);

            IList<SPCTxPowerDetail> GroupedItems = new List<SPCTxPowerDetail>();

            for (int i = 1; i <= groupCount; i++)
            {
                for (int j = 1; j <= groupingNo; j++)
                {
                    Random random = new Random();
                    int min = 0, max = total - 1;
                    int index = random.Next(min, max);

                    items[index].GroupNo = i;
                    GroupedItems.Add(items[index]);
                    items.Remove(items[index]);

                    total--;
                }
            }

            this.GVGroupItems.Visible = true;
            this.GVGroupItems.DataSource = GroupedItems;
            this.GVGroupItems.DataBind();

            this.tblSubmit.Visible = true;
            this.lblGroupCount.Text = this.GetLocalResourceObject("GroupTotalMsg").ToString() + groupCount.ToString() + this.GetLocalResourceObject("GroupMsg").ToString();
            this.lblGroupItemsCount.Text =this.GetLocalResourceObject("totalMsg").ToString()+ GroupedItems.Count.ToString()  + this.GetLocalResourceObject("RecordsMsg").ToString();

            this.tbxLCL_X.Text = "";
            this.tbxUCL_X.Text = "";
            this.tbxLCL_R.Text = "";
            this.tbxUCL_R.Text = "";
            this.tbxUSL.Text = "";
            this.tbxLSL.Text = "";
            
        }

        protected void btnSequenceGroup_Click(object sender, EventArgs e)
        {
            int count = this.GVItems.Rows.Count;
            IList<SPCTxPowerDetail> items = new List<SPCTxPowerDetail>();
            int total = 0;
            for (int i = 0; i < count; i++)
            {
                CheckBox chx = (CheckBox)this.GVItems.Rows[i].FindControl("chxSelect");
                if (chx.Checked == true)
                {
                    SPCTxPowerDetail item = new SPCTxPowerDetail();
                    item.SerialNo = this.GVItems.Rows[i].Cells[0].Text.Trim();
                    item.EndTime = Convert.ToDateTime(this.GVItems.Rows[i].Cells[1].Text.Trim());
                    item.OutPutPower = this.GVItems.Rows[i].Cells[2].Text.Trim();
                    items.Add(item);
                    total++;
                }
            }

            int groupingNo = int.Parse(this.tbxGroupingNo.Text.Trim());
            int groupCount = (int)System.Math.Floor((double)total / groupingNo);

            IList<SPCTxPowerDetail> GroupedItems = new List<SPCTxPowerDetail>();

            int index = 0;
            for (int i = 1; i <= groupCount; i++)
            {
                for (int j = 1; j <= groupingNo; j++)
                {
                    items[index].GroupNo = i;
                    GroupedItems.Add(items[index]);
                    index++;
                }
            }

            this.GVGroupItems.Visible = true;
            this.GVGroupItems.DataSource = GroupedItems;
            this.GVGroupItems.DataBind();

            this.tblSubmit.Visible = true;
            this.lblGroupCount.Text = this.GetLocalResourceObject("GroupTotalMsg").ToString() + groupCount.ToString() + this.GetLocalResourceObject("GroupMsg").ToString();
            this.lblGroupItemsCount.Text = this.GetLocalResourceObject("totalMsg").ToString() + GroupedItems.Count.ToString() + this.GetLocalResourceObject("RecordsMsg").ToString();
            this.tbxLCL_X.Text = "";
            this.tbxUCL_X.Text = "";
            this.tbxLCL_R.Text = "";
            this.tbxUCL_R.Text = "";
            this.tbxUSL.Text = "";
            this.tbxLSL.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool pass = true;
            string LSL = this.tbxLSL.Text.Trim(), USL = this.tbxUSL.Text.Trim();
            if (this.chxAutoInputTarget.Checked == true)
            {
                if (SPCTxPowerService.LastestTargetCount(type, mode, ch, pw) > 0)
                {
                    SPCTxPowerInfo entity = SPCTxPowerService.GetLatestTarget(type, mode, ch, pw);
                    if (entity.LSL != null)
                    {
                        LSL = entity.LSL.ToString();
                    }
                    if (entity.USL != null)
                    {
                        USL = entity.USL.ToString();
                    }
                }
                else
                {
                    pass = false;
                }
            }
            if (pass == true)
            {
                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                builder.Append("SPCTxPowerCompute.aspx?1=1");
                builder.Append("&type=" + type);
                builder.Append("&mode=" + mode);
                builder.Append("&ch=" + ch);
                builder.Append("&pw=" + pw);
                builder.Append("&datefrom=" + this.tbxDateFrom.Text.Trim());
                builder.Append("&dateto=" + this.tbxDateTo.Text.Trim());
                builder.Append("&groupingno=" + this.tbxGroupingNo.Text.Trim());
                builder.Append("&lcl_x=" + this.tbxLCL_X.Text.Trim());
                builder.Append("&ucl_x=" + this.tbxUCL_X.Text.Trim());
                builder.Append("&lcl_r=" + this.tbxLCL_R.Text.Trim());
                builder.Append("&ucl_r=" + this.tbxUCL_R.Text.Trim());
                builder.Append("&lsl=" + LSL);
                builder.Append("&usl=" + USL);
                builder.Append("&backlink=SPCTxPowerManualGroup.aspx");

                IList<SPCTxPowerDetail> items = new List<SPCTxPowerDetail>();
                for (int i = 0; i < this.GVGroupItems.Rows.Count; i++)
                {
                    SPCTxPowerDetail item = new SPCTxPowerDetail();
                    item.SerialNo = this.GVGroupItems.Rows[i].Cells[0].Text.Trim();
                    item.EndTime = Convert.ToDateTime(this.GVGroupItems.Rows[i].Cells[1].Text.Trim());
                    item.OutPutPower = this.GVGroupItems.Rows[i].Cells[2].Text.Trim();
                    item.GroupNo = Convert.ToInt32(this.GVGroupItems.Rows[i].Cells[3].Text.Trim());
                    items.Add(item);
                }
                if (Session["SPCTxPowerOriginal"] != null)
                {
                    Session.Remove("SPCTxPowerOriginal");
                }
                Session.Add("SPCTxPowerOriginal", items);
                Response.Redirect(builder.ToString());
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Tip", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("TargetNotExistsMsg") + "');</script>");
            }
        }

       
    }
}

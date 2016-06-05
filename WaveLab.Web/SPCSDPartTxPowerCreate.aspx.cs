using System;
using System.Collections;
using System.Collections.Generic;
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

using WaveLab.Model;
using WaveLab.IService;
using Spring.Context;
using Spring.Context.Support;

namespace WaveLab.Web
{
    public partial class SPCSDPartTxPowerCreate : CommonPage
    {
        private ISPCSDPartTxPowerService SPCSDPartTxPowerService;

        private string StationNo, CHNo, Mode, SerialNo;
        private Hashtable hashTable = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCSDPartTxPowerService = (ISPCSDPartTxPowerService)cxt.GetObject("SV.SPCSDPartTxPowerService");

            if (!Page.IsPostBack)
            {
                foreach (string item in SPCSDPartTxPowerService.GetStationItems())
                {
                    this.ddlStationNo.Items.Add(new ListItem(item, item));
                }
                foreach (string item in SPCSDPartTxPowerService.GetCHNoItems())
                {
                    this.ddlCHNo.Items.Add(new ListItem(item, item));
                }

               
                //this.BindResult();
            }
        }
        private void GetParas()
        {
            if (ViewState["sortby"] == null)
            {
                ViewState["sortby"] = "mode";
            }

            if (ViewState["orderby"] == null)
            {
                ViewState["orderby"] = "asc";
            }
            if (this.ddlStationNo.SelectedValue.Length > 0) { hashTable.Add("Station_No", this.ddlStationNo.SelectedValue); }

            if (this.chxDivide.Checked == true)
            {
                hashTable.Add("Divide", "Y");
                if (this.ddlCHNo.SelectedValue.Length > 0) { hashTable.Add("CH_No", this.ddlCHNo.SelectedValue.Trim()); }
            }
            else
            {
                hashTable.Add("Divide", "N");
            }
            if (this.ddlMode.SelectedValue.Length > 0) { hashTable.Add("Mode", this.ddlMode.SelectedValue); }
            if (this.tbxSerialNo.Text.Trim().Length > 0) { hashTable.Add("Serial_No", this.tbxSerialNo.Text.Trim()); }
        }

        private void BindResult()
        {
            GetParas();
            IList<SPCSDPartTxPowerInfo> items = SPCSDPartTxPowerService.Query(hashTable ,ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.GVList.Visible = false;
                this.TabContainerTarget.Visible = false;
                this.btnSave.Visible = false;
                this.btnCancel.Visible = false;

                this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "noRecordsMsg").ToString();
            }
            else
            {
                this.lblRecCount.Visible = false;
                this.GVList.Visible = true;
                this.TabContainerTarget.Visible = true;
                this.btnSave.Visible = true;
                this.btnCancel.Visible = true;

                this.GVList.DataSource = items;
                this.GVList.DataBind();
            }
        }

        protected void GVList_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.BindResult();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SPCSDPartTxPowerInfo entity = new SPCSDPartTxPowerInfo();
            for (int i = 0; i < this.GVList.Rows.Count; i++)
            {
                CheckBox chxSelect = (CheckBox)this.GVList.Rows[i].FindControl("chxSelect");
                if (chxSelect.Checked == true)
                {
                    entity.StationNo = Convert.ToString(this.GVList.DataKeys[i].Values["StationNo"]);
                    entity.Divide = Convert.ToChar(this.GVList.DataKeys[i].Values["Divide"]);
                    entity.CHNo = Convert.ToString(this.GVList.DataKeys[i].Values["CHNo"]);
                    entity.Mode = Convert.ToString(this.GVList.DataKeys[i].Values["Mode"]);
                    entity.CH = Convert.ToString(this.GVList.DataKeys[i].Values["CH"]);
                    entity.PW = Convert.ToString(this.GVList.DataKeys[i].Values["PW"]);
                    entity.SerialNo = Convert.ToString(this.GVList.DataKeys[i].Values["SerialNo"]);
                }
            }
            if (SPCSDPartTxPowerService.CheckExists(entity.StationNo, entity.Divide,entity.CHNo, entity.Mode,entity.CH,entity.PW,entity.SerialNo) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("ExistsMsg") + "');</script>");
                return;
            }

            if (this.tbxLSL.Text.Trim().Length == 0)
            {
                entity.LSL = null;
            }
            else
            {
                entity.LSL = Convert.ToDouble(this.tbxLSL.Text.Trim());
            }
            if (this.tbxUSL.Text.Trim().Length == 0)
            {
                entity.USL = null;
            }
            else
            {
                entity.USL = Convert.ToDouble(this.tbxUSL.Text.Trim());
            }
            entity.Enable = 'Y';
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            try
            {
                SPCSDPartTxPowerService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }

       
    }
}

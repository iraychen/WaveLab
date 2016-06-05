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

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class SPCSDPartMAMCreate : CommonPage
    {
        private ISPCSDPartMAMService SPCSDPartMAMService;

       
        private Hashtable hashTable = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCSDPartMAMService = (ISPCSDPartMAMService)cxt.GetObject("SV.SPCSDPartMAMService");


            if (!Page.IsPostBack)
            {
                foreach (string item in SPCSDPartMAMService.GetStationItems())
                {
                    this.ddlStationNo.Items.Add(new ListItem(item, item));
                }
        
               
                //this.BindResult();
            }
        }
        private void GetParas()
        {
            if (ViewState["sortby"] == null)
            {
                ViewState["sortby"] = "MB_Serial_No";
            }

            if (ViewState["orderby"] == null)
            {
                ViewState["orderby"] = "asc";
            }
            if (this.ddlStationNo.SelectedValue.Length > 0) { hashTable.Add("Station_No", this.ddlStationNo.SelectedValue); }

            if (this.tbxSerialNo.Text.Trim().Length > 0) { hashTable.Add("MB_Serial_No", this.tbxSerialNo.Text.Trim()); }
        }

        private void BindResult()
        {
            GetParas();
            IList<SPCSDPartMAMInfo> items = SPCSDPartMAMService.Query(hashTable ,ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
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
            SPCSDPartMAMInfo entity = new SPCSDPartMAMInfo();
            for (int i = 0; i < this.GVList.Rows.Count; i++)
            {
                CheckBox chxSelect = (CheckBox)this.GVList.Rows[i].FindControl("chxSelect");
                if (chxSelect.Checked == true)
                {
                    entity.StationNo = Convert.ToString(this.GVList.DataKeys[i].Values["StationNo"]);
                   
                    entity.SerialNo = Convert.ToString(this.GVList.DataKeys[i].Values["SerialNo"]);
                }
            }
            if (SPCSDPartMAMService.CheckExists(entity.StationNo,  entity.SerialNo) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("ExistsMsg") + "');</script>");
                return;
            }

            if (this.tbxLSL_TxLoPower.Text.Trim().Length == 0)
            {
                entity.LSL_TxLoPower = null;
            }
            else
            {
                entity.LSL_TxLoPower = Convert.ToDouble(this.tbxLSL_TxLoPower.Text.Trim());
            }
            if (this.tbxUSL_TxLoPower.Text.Trim().Length == 0)
            {
                entity.USL_TxLoPower = null;
            }
            else
            {
                entity.USL_TxLoPower = Convert.ToDouble(this.tbxUSL_TxLoPower.Text.Trim());
            }

            if (this.tbxLSL_RxAGC.Text.Trim().Length == 0)
            {
                entity.LSL_RxAGC = null;
            }
            else
            {
                entity.LSL_RxAGC = Convert.ToDouble(this.tbxLSL_RxAGC.Text.Trim());
            }
            if (this.tbxUSL_RxAGC.Text.Trim().Length == 0)
            {
                entity.USL_RxAGC = null;
            }
            else
            {
                entity.USL_RxAGC = Convert.ToDouble(this.tbxUSL_RxAGC.Text.Trim());
            }
            entity.Enable = 'Y';
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            try
            {
                SPCSDPartMAMService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }

       
    }
}

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

namespace WaveLab.Web
{
    public partial class SMTModelFileInduceIndex : CommonPage
    {
        private Hashtable hashTable = new Hashtable();
       private ISMTModelFileInduceService SMTModelFileInduceService;
       private ISYSModuleTypeService SYSModuleTypeService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");
            SMTModelFileInduceService = (ISMTModelFileInduceService)cxt.GetObject("SV.SMTModelFileInduceService");
          
            if (!Page.IsPostBack)
            {
                LoadCriteria();
                BindResult();
            }
        }

        private void LoadCriteria()
        {
           
            this.ddlSYSModuleType.DataSource = SYSModuleTypeService.GetItems();
            this.ddlSYSModuleType.DataValueField = "ModuleTypeId";
            this.ddlSYSModuleType.DataTextField = "ModuleTypeDesc";
            this.ddlSYSModuleType.DataBind();
            this.ddlSYSModuleType.Items.Insert(0, new ListItem("", ""));

            if (string.IsNullOrEmpty(Request.QueryString["module_type_id"]) == false)
            {
                this.ddlSYSModuleType.SelectedValue = Request.QueryString["module_type_id"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["Bill_Serial_Number"]) == false)
            {
                this.tbxBillSerialNumber.Text = Request.QueryString["Bill_Serial_Number"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["Module_Desc"]) == false)
            {
                this.tbxModuleDesc.Text = Request.QueryString["Module_Desc"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["pcb"]) == false)
            {
                this.tbxPCB.Text= Request.QueryString["pcb"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["sb"]) == false)
            {
                ViewState["sortby"] = Request.QueryString["sb"].ToString();
            }
            else
            {
                ViewState["sortby"] = "module_type_desc";
            }

            if (string.IsNullOrEmpty(Request.QueryString["ob"]) == false)
            {
                ViewState["orderby"] = Request.QueryString["ob"].ToString();
            }
            else
            {
                ViewState["orderby"] = "asc";
            }
        }

        private void GetParas()
        {
            if (this.ddlSYSModuleType.SelectedValue.Trim().Length > 0)
            {
                hashTable.Add("module_type_id", this.ddlSYSModuleType.SelectedValue.Trim());
            }
            if (this.tbxBillSerialNumber.Text.Trim().Length > 0)
            {
                hashTable.Add("Bill_Serial_Number", this.tbxBillSerialNumber.Text.Trim());
            }

            if (this.tbxModuleDesc.Text.Trim().Length > 0)
            {
                hashTable.Add("Module_Desc", this.tbxModuleDesc.Text.Trim());
            }

            if (this.tbxPCB.Text.Trim().Length > 0)
            {
                hashTable.Add("pcb", this.tbxPCB.Text.Trim());
            }
        }

        private void BindResult()
        {

            GetParas();
            int recCount = 0;
            if (ViewState["recCount"] == null)
            {
                recCount = SMTModelFileInduceService.Query(hashTable);
                ViewState["recCount"] = recCount;
            }
            else
            {
                recCount = (int)ViewState["recCount"];
            }
            if (recCount == 0)
            {
                this.lblRecCount.Visible = true;
                this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "noRecordsMsg").ToString();
                this.GVList.Visible = false;
                this.PagerNavigator.Visible = false;
            }
            else
            {
                this.lblRecCount.Visible = false;
                this.GVList.Visible = true;
                this.PagerNavigator.Visible = true;

                this.PagerNavigator.RecordCount = recCount;

                if (!Page.IsPostBack && string.IsNullOrEmpty(Request.QueryString["page"]) == false)
                {
                    this.PagerNavigator.CurrentPageIndex = int.Parse(Request.QueryString["page"]);
                }
                IList<SMTModelFileInduceInfo> items = SMTModelFileInduceService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString(), this.PagerNavigator.CurrentPageIndex, this.PagerNavigator.PageSize);
                this.GVList.DataSource = items;
                this.GVList.DataBind();



            }

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("SMTModelFileInduceIndex.aspx?1=1");
            foreach (DictionaryEntry item in hashTable)
            {
                builder.Append("&" + item.Key + "=" + item.Value);
            }
            builder.Append("&sb=" + ViewState["sortby"]);
            builder.Append("&ob=" + ViewState["orderby"]);
            this.hfdCurLink.Value = System.Web.HttpUtility.UrlEncode(builder.ToString());
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbtEdit = (LinkButton)e.Row.FindControl("lbtEdit");
                lbtEdit.Attributes.Add("onclick", "return redirect('Edit','" +
                    Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "FileInducePK")) + "')");

                LinkButton lbtDelete = (LinkButton)e.Row.FindControl("lbtDelete");
                lbtDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
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

        protected void GVList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int FileInducePK = int.Parse(this.GVList.DataKeys[e.RowIndex].Values["FileInducePK"].ToString());
            SMTModelFileInduceInfo entity = SMTModelFileInduceService.GetDetail(FileInducePK);
            try
            {
                SMTModelFileInduceService.Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');</script>");

            ViewState["recCount"] = null;
            this.BindResult();
        }

        protected void PagerNavigator_PageChanged(object sender, EventArgs e)
        {
            this.BindResult();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["recCount"] = null;

            this.PagerNavigator.CurrentPageIndex = 1;
            this.BindResult();
        }
    }
}

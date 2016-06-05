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
using System.IO;

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class SMTModelConsignProcess : CommonPage
    {
        private Hashtable hashTable = new Hashtable();
        private ISMTModelFileInduceService SMTModelFileInduceService;
        private ISYSModuleTypeService SYSModuleTypeService;
        private ISMTCPTemplateService SMTCPTemplateService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");
            SMTModelFileInduceService = (ISMTModelFileInduceService)cxt.GetObject("SV.SMTModelFileInduceService");
            SMTCPTemplateService = (ISMTCPTemplateService)cxt.GetObject("SV.SMTCPTemplateService");

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
            IList<SMTModelFileInduceInfo> items = SMTModelFileInduceService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            
            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "noRecordsMsg").ToString();
                this.GVList.Visible = false;
              
            }
            else
            {
                this.lblRecCount.Visible = false;
                this.GVList.Visible = true;
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

        

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindResult();
        }

        protected void GVList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (string.Equals(e.CommandName.ToUpper(), "EXPORT") == true)
            {
                //check Template
                SMTCPTemplateInfo template = SMTCPTemplateService.GetExportTemplate();
                if (template == null)
                {
                    this.ShowMessage(this.GetLocalResourceObject("templateNotExistsMsg").ToString());
                    return;
                }

                int FileInducePK = int.Parse(e.CommandArgument.ToString());
                SMTModelFileInduceInfo entity = SMTModelFileInduceService.GetDetail(FileInducePK);

                MemoryStream ms = SMTModelFileInduceService.Export(template.DocumentPath, entity);
                Response.ClearHeaders();
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.BinaryWrite(ms.GetBuffer());
                Response.End();
            }
        }

        private void ShowMessage(string message)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script type='text/javascript'>alert('" + message + "');</script>");
        }
    }
}

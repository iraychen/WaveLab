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
using System.Text;

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class CPBatchUpdateComents : CommonPage
    {
       private ISYSModuleTypeService SYSModuleTypeService;
       private ISMTFileInduceService SMTFileInduceService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");
            SMTFileInduceService = (ISMTFileInduceService)cxt.GetObject("SV.SMTFileInduceService");
          
            if (!Page.IsPostBack)
            {
                this.ddlSYSModuleType.DataSource = SYSModuleTypeService.GetItems();
                this.ddlSYSModuleType.DataValueField = "ModuleTypeId";
                this.ddlSYSModuleType.DataTextField = "ModuleTypeDesc";
                this.ddlSYSModuleType.DataBind();

                this.tblCP.Visible = false;
                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"] = "material_code";
                }

                if (ViewState["orderby"] == null)
                {
                    ViewState["orderby"] = "asc";
                }
            }
        }

        private void BindResult()
        {
            IList<SMTFileInduceInfo> items = SMTFileInduceService.Query(ViewState["ModuleTypeId"].ToString(), ViewState["PCB"].ToString(), ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.tblCP.Visible = false;
                this.lblRecCount.Text = this.GetLocalResourceObject("noRecordsMsg").ToString();

            }
            else
            {
                this.lblRecCount.Visible = false;
                this.tblCP.Visible = true;

                this.GVList.DataSource = items;
                this.GVList.DataBind();

                string ModuleTypeId = this.ddlSYSModuleType.SelectedValue.Trim();
                SYSModuleTypeInfo SYSModuleTypeInfo = SYSModuleTypeService.GetDetail(ModuleTypeId);
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
            ViewState.Add("ModuleTypeId", this.ddlSYSModuleType.SelectedValue);
            ViewState.Add("PCB", this.tbxPCB.Text.Trim());
            BindResult();

            this.tbxComments.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int count = this.GVList.Rows.Count;
            IList<SMTFileInduceInfo> items = new List<SMTFileInduceInfo>();
            for (int i = 0; i < count; i++)
            {
                SMTFileInduceInfo item = new SMTFileInduceInfo();
                item.MaterialCode=this.GVList.DataKeys[i].Values["MaterialCode"].ToString();
                item.MaterialDesc=this.GVList.DataKeys[i].Values["MaterialDesc"].ToString();
                item.PCB = this.GVList.DataKeys[i].Values["PCB"].ToString();
                
                CheckBox cbxSelect = (CheckBox)this.GVList.Rows[i].FindControl("cbxSelect");
                if (cbxSelect.Checked == true)
                {
                   items.Add(item);
                }
 
                item.LastUpdateDate = DateTime.Now;
                item.LastUpdatedBy = Page.User.Identity.Name;
            }
            try
            {
                //SMTFileInduceService.UpdateComentsBatch(ViewState["ModuleTypeId"].ToString(), ViewState["PCB"].ToString(), this.tbxComments.Text.Trim());

                SMTFileInduceService.UpdateComentsBatch(items, this.tbxComments.Text.Trim());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "tip", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("updateSuccessMsg") + "');</script>");
            this.BindResult();

            this.tbxComments.Text = "";
        }


    }
}

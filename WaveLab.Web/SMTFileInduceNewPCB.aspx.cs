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
    public partial class SMTFileInduceNewPCB : CommonPage
    {
        private string ModuleTypeId,PCB;
        private ISYSModuleTypeService SYSModuleTypeService;
        private ISMTFileInduceService SMTFileInduceService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");
            SMTFileInduceService = (ISMTFileInduceService)cxt.GetObject("SV.SMTFileInduceService");

            PCB = Request.QueryString["pcb"];
            ModuleTypeId = Request.QueryString["ModuleTypeId"];
            if (!Page.IsPostBack)
            {
                this.lblPCBInfo.Text = PCB;
                this.lblSYSModuleTypeInfo.Text = SYSModuleTypeService.GetDetail(ModuleTypeId).ModuleTypeDesc;
                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"] = "material_code";
                }

                if (ViewState["orderby"] == null)
                {
                    ViewState["orderby"] = "asc";
                }
                BindResult();
            }
        }

        private void BindResult()
        {
            IList<SMTFileInduceInfo> items = SMTFileInduceService.Query(ModuleTypeId, PCB, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.GVList.Visible = false;
                this.tableNewPCB.Visible = false;
                this.btnPreView.Visible = false;
                this.btnReset.Visible = false;
                this.lblNewPCB.Visible = false;
                this.lblRecCount.Text = this.GetLocalResourceObject("noRecordsMsg").ToString();

            }
            else
            {
                this.lblRecCount.Visible =false;
                this.GVList.Visible = true;
                this.tableNewPCB.Visible = true ;
                this.btnPreView.Visible = true;
                this.btnReset.Visible = true;

                this.GVList.DataSource = items;
                this.GVList.DataBind();
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

        protected void btnPreView_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SMTFileInduceNewPCBSubmit.aspx?1=1");
            builder.Append("&ModuleTypeId="+ModuleTypeId);
            builder.Append("&pcb="+PCB);
            builder.Append("&newpcb=" + this.tbxNewPCB.Text.Trim());
            builder.Append("&comments=" + this.tbxComments.Text.Trim());
            builder.Append("&backlink=" + System.Web.HttpUtility.UrlEncode(Request.QueryString["backlink"].ToString()));
            Response.Redirect(builder.ToString());
        }
    }
}

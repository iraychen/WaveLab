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

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class SMTFileInducePCB : CommonPage
    {
        private ISYSModuleTypeService SYSModuleTypeService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");
  
            if (!Page.IsPostBack)
            {
                this.ddlSYSModuleType.DataSource = SYSModuleTypeService.GetItems();
                this.ddlSYSModuleType.DataValueField = "ModuleTypeId";
                this.ddlSYSModuleType.DataTextField = "ModuleTypeDesc";
                this.ddlSYSModuleType.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("SMTFileInduceNewPCB.aspx?ModuleTypeId=" + this.ddlSYSModuleType.SelectedValue.Trim() + "&pcb=" + this.tbxPCB.Text.Trim());
            builder.Append("&backlink=" + System.Web.HttpUtility.UrlEncode( Request.QueryString["backlink"].ToString()));
            Response.Redirect(builder.ToString());
        }
    }
}

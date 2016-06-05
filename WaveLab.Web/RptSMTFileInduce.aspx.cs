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
    public partial class RptSMTFileInduce : CommonPage
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

                this.ddlSYSModuleType.Items.Insert(0, new ListItem("", ""));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("RptSMTFileInduceList.aspx?1=1");
            if (this.ddlSYSModuleType.SelectedValue.Trim().Length > 0)
            {
                builder.Append("&ModuleTypeId=" + this.ddlSYSModuleType.SelectedValue.Trim());
            }
            if (this.tbxMaterialCode.Text.Trim().Length > 0)
            {
                builder.Append("&materialcode=" + this.tbxMaterialCode.Text.Trim());
            }
            if (this.tbxMaterialDesc.Text.Trim().Length > 0)
            {
                builder.Append("&materialdesc=" + this.tbxMaterialDesc.Text.Trim());
            }
            if (this.tbxPCB.Text.Trim().Length > 0)
            {
                builder.Append("&pcb=" + this.tbxPCB.Text.Trim());
            }
            Response.Redirect(builder.ToString());
        }
    }
}

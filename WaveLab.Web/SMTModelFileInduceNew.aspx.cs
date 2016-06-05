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
    public partial class SMTModelFileInduceNew : CommonPage
    {
        private ISMTModelFileInduceService SMTModelFileInduceService;
        private ISYSModuleTypeService SYSModuleTypeService;


        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");
            SMTModelFileInduceService = (ISMTModelFileInduceService)cxt.GetObject("SV.SMTModelFileInduceService");

            if (!Page.IsPostBack)
            {
                this.ddlSYSModuleType.DataSource = SYSModuleTypeService.GetItems();
                this.ddlSYSModuleType.DataValueField = "ModuleTypeId";
                this.ddlSYSModuleType.DataTextField = "ModuleTypeDesc";
                this.ddlSYSModuleType.DataBind();
                this.ddlSYSModuleType.Items.Insert(0, new ListItem("", ""));

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            SMTModelFileInduceInfo entity = new SMTModelFileInduceInfo();
            entity.ModuleTypeId = this.ddlSYSModuleType.SelectedValue.Trim().ToUpper();
            entity.BillSerialNumber = this.tbxBillSerialNumber.Text.Trim().ToUpper();
            entity.ModuleDesc = this.tbxModuleDesc.Text.Trim().ToUpper();
            entity.PCB = this.tbxPCB.Text.Trim().ToUpper();
            entity.SerialNumber = this.tbxSerialNumber.Text.Trim().ToUpper();
            entity.Version = this.tbxVersion.Text.Trim().ToUpper();
            entity.SpeBoard = this.tbxSpeBoard.Text.Trim().ToUpper();
            entity.SpeBoardDN = this.tbxSpeBoardDN.Text.Trim().ToUpper();
            entity.SpeBoardDVS = this.tbxSpeBoardDVS.Text.Trim().ToUpper();
            entity.FabricationDN = this.tbxFabricationDN.Text.Trim().ToUpper();
            entity.FabricationDVS = this.tbxFabricationDVS.Text.Trim().ToUpper();
            entity.SteelMesh = this.tbxSteelMesh.Text.Trim().ToUpper();
            entity.CoorPattern = this.tbxCoorPattern.Text.Trim().ToUpper();
            entity.Comments = this.tbxComments.Text.Trim().ToUpper();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name.ToUpper();

            if (SMTModelFileInduceService.CheckExists(entity) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg") + "');</script>");
                return;
            }

            try
            {
                SMTModelFileInduceService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');goBack();</script>");
        }
    }
}

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
    public partial class SMTFileInduceNew : CommonPage
    {
        private ISMTFileInduceService SMTFileInduceService;
        private ISYSModuleTypeService SYSModuleTypeService;


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
                this.ddlSYSModuleType.Items.Insert(0, new ListItem("", ""));

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SMTFileInduceService.CheckExists(this.tbxMaterialCode.Text.Trim(), this.tbxMaterialDesc.Text.Trim(), this.tbxPCB.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg") + "');</script>");
                return;
            }

            SMTFileInduceInfo entity = new SMTFileInduceInfo();

            SYSModuleTypeInfo ModuleTypeItem = new SYSModuleTypeInfo();
            ModuleTypeItem.ModuleTypeId= this.ddlSYSModuleType.SelectedValue.Trim().ToUpper();

           

            entity.MaterialCode= this.tbxMaterialCode.Text.Trim().ToUpper();
            entity.MaterialDesc = this.tbxMaterialDesc.Text.Trim().ToUpper();
            entity.PCB = this.tbxPCB.Text.Trim().ToUpper();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name.ToUpper();
            entity.CreationDate = DateTime.Now;
            entity.CreatedBy = Page.User.Identity.Name;
            entity.ModuleTypeItem = ModuleTypeItem;
            
            entity.GenBoard = this.tbxGenBoard.Text.Trim().ToUpper();
            entity.GenBoardDN = this.tbxGenBoardDN.Text.Trim().ToUpper();
            entity.GenBoardDVS = this.tbxGenBoardDVS.Text.Trim().ToUpper();
            entity.SpeBoard = this.tbxSpeBoard.Text.Trim().ToUpper();
            entity.SpeBoardDN = this.tbxSpeBoardDN.Text.Trim().ToUpper();
            entity.SpeBoardDVS = this.tbxSpeBoardDVS.Text.Trim().ToUpper();
            entity.SMTFabricationDN = this.tbxSMTFabricationDN.Text.Trim().ToUpper();
            entity.SMTFabricationDVS = this.tbxSMTFabricationDVS.Text.Trim().ToUpper();

            entity.ComponentPart = this.tbxComponentPart.Text.Trim().ToUpper();
            entity.ComponentPartDN = this.tbxComponentPartDN.Text.Trim().ToUpper();
            entity.ComponentPartDVS = this.tbxComponentPartDVS.Text.Trim().ToUpper();
            entity.GroupPart = this.tbxGroupPart.Text.Trim().ToUpper();
            entity.GroupPartDN = this.tbxGroupPartDN.Text.Trim().ToUpper();
            entity.GroupPartDVS = this.tbxGroupPartDVS.Text.Trim().ToUpper();
            entity.BondingFabricationDN = this.tbxBondingFabricationDN.Text.Trim().ToUpper();
            entity.BondingFabricationDVS = this.tbxBondingFabricationDVS.Text.Trim().ToUpper();

            entity.Comments = this.tbxComments.Text.Trim().ToUpper();
            entity.Explanation = this.tbxExplanation.Text.Trim().ToUpper();

            try
            {
                SMTFileInduceService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');goBack();</script>");
        }
    }
}

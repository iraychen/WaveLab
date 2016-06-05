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
    public partial class SMTFileInduceEdit : CommonPage
    {
        string materialCode, materialDesc, PCB;
        private ISMTFileInduceService SMTFileInduceService;
        private ISYSModuleTypeService SYSModuleTypeService;
        private SMTFileInduceInfo entity;
        private SYSModuleTypeInfo SYSModuleTypeEntity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");
            SMTFileInduceService = (ISMTFileInduceService)cxt.GetObject("SV.SMTFileInduceService");
          
            materialCode = Request.QueryString["materialcode"];
            materialDesc = Request.QueryString["materialdesc"];
            PCB = Request.QueryString["pcb"];
            entity = SMTFileInduceService.GetDetail(materialCode, materialDesc, PCB);
           
            if (!Page.IsPostBack)
            {
                //this.ddlSYSModuleType.DataSource = SYSModuleTypeService.GetItems();
                //this.ddlSYSModuleType.DataValueField = "ModuleTypeId";
                //this.ddlSYSModuleType.DataTextField = "ModuleTypeDesc";
                //this.ddlSYSModuleType.DataBind();
                //this.ddlSYSModuleType.Items.Insert(0, new ListItem("", ""));
                LoadInfo();
                this.btnDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
            }
        }

        private void LoadInfo()
        {
            this.lblMaterialCodeInfo.Text = entity.MaterialCode;
            this.lblMaterialDescInfo.Text = entity.MaterialDesc;
            this.lblPCBInfo.Text = entity.PCB;
            this.lblSYSModuleTypeInfo.Text = entity.ModuleTypeItem.ModuleTypeDesc;

            SYSModuleTypeEntity = SYSModuleTypeService.GetDetail(entity.ModuleTypeItem.ModuleTypeId);

            if (SYSModuleTypeEntity.HasGenBoard != 'Y')
            {
                this.trGenBoard.Disabled = true;
                this.tbxGenBoard.Enabled = false;
                this.tbxGenBoardDN.Enabled = false;
                this.tbxGenBoardDVS.Enabled = false;
            }
            else
            {
                this.tbxGenBoard.Text = entity.GenBoard;
                this.tbxGenBoardDN.Text = entity.GenBoardDN;
                this.tbxGenBoardDVS.Text = entity.GenBoardDVS;
            }

            if (SYSModuleTypeEntity.HasSpeBoard != 'Y')
            {
                this.trSpeBoard.Disabled = true;
                this.tbxSpeBoard.Enabled = false;
                this.tbxSpeBoardDN.Enabled = false;
                this.tbxSpeBoardDVS.Enabled = false;
            }
            else
            {
                this.tbxSpeBoard.Text = entity.SpeBoard;
                this.tbxSpeBoardDN.Text = entity.SpeBoardDN;
                this.tbxSpeBoardDVS.Text = entity.SpeBoardDVS;
            }

            if (SYSModuleTypeEntity.HasSMTFabrication != 'Y')
            {
                this.trSMTFabrication.Disabled = true;
                this.tbxSMTFabricationDN.Enabled = false;
                this.tbxSMTFabricationDVS.Enabled = false;
            }
            else
            {
                this.tbxSMTFabricationDN.Text = entity.SMTFabricationDN;
                this.tbxSMTFabricationDVS.Text = entity.SMTFabricationDVS;
            }

            if (SYSModuleTypeEntity.HasComponentPart != 'Y')
            {
                this.trComponentPart.Disabled = true;
                this.tbxComponentPart.Enabled = false;
                this.tbxComponentPartDN.Enabled = false;
                this.tbxComponentPartDVS.Enabled = false;
            }
            else
            {
                this.tbxComponentPart.Text = entity.ComponentPart;
                this.tbxComponentPartDN.Text = entity.ComponentPartDN;
                this.tbxComponentPartDVS.Text = entity.ComponentPartDVS;
            }

            if (SYSModuleTypeEntity.HasGroupPart != 'Y')
            {
                this.trGroupPart.Disabled = true;
                this.tbxGroupPart.Enabled = false;
                this.tbxGroupPartDN.Enabled = false;
                this.tbxGroupPartDVS.Enabled = false;
            }
            else
            {
                this.tbxGroupPart.Text = entity.GroupPart;
                this.tbxGroupPartDN.Text = entity.GroupPartDN;
                this.tbxGroupPartDVS.Text = entity.GroupPartDVS;
            }

            if (SYSModuleTypeEntity.HasBondingFabrication != 'Y')
            {
                this.trBondingFabrication.Disabled = true;
                this.tbxBondingFabricationDN.Enabled = false;
                this.tbxBondingFabricationDVS.Enabled = false;
            }
            else
            {
                this.tbxBondingFabricationDN.Text = entity.BondingFabricationDN;
                this.tbxBondingFabricationDVS.Text = entity.BondingFabricationDVS;
            }
            this.tbxComments.Text = entity.Comments;
            this.tbxExplanation.Text = entity.Explanation;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
          
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
            entity.Explanation= this.tbxExplanation.Text.Trim().ToUpper();
            try
            {
                SMTFileInduceService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tip", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "updateSuccessMsg") + "');goBack();</script>");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SMTFileInduceService.Delete(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tip", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');goBack();</script>");
        }
    }
}

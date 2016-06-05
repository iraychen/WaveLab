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
    public partial class SMTModelFileInduceEdit : CommonPage
    {
        private int FileInducePK;
        private ISMTModelFileInduceService SMTModelFileInduceService;
        private ISYSModuleTypeService SYSModuleTypeService;
        private SMTModelFileInduceInfo entity;
        private SYSModuleTypeInfo SYSModuleTypeEntity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");
            SMTModelFileInduceService = (ISMTModelFileInduceService)cxt.GetObject("SV.SMTModelFileInduceService");

            FileInducePK =int.Parse( Request.QueryString["FileInducePK"]);
            entity = SMTModelFileInduceService.GetDetail(FileInducePK);
           
            if (!Page.IsPostBack)
            {
                this.ddlSYSModuleType.DataSource = SYSModuleTypeService.GetItems();
                this.ddlSYSModuleType.DataValueField = "ModuleTypeId";
                this.ddlSYSModuleType.DataTextField = "ModuleTypeDesc";
                this.ddlSYSModuleType.DataBind();
                this.ddlSYSModuleType.Items.Insert(0, new ListItem("", ""));
                LoadEntity();
                
            }
        }

        private void LoadEntity()
        {
            this.ddlSYSModuleType.SelectedValue = entity.ModuleTypeId;
            this.tbxBillSerialNumber.Text = entity.BillSerialNumber;
            this.tbxModuleDesc.Text = entity.ModuleDesc;
            this.tbxPCB.Text = entity.PCB;

            this.tbxSerialNumber.Text = entity.SerialNumber;
            this.tbxVersion.Text = entity.Version;

            this.tbxSpeBoard.Text = entity.SpeBoard;
            this.tbxSpeBoardDN.Text = entity.SpeBoardDN;
            this.tbxSpeBoardDVS.Text = entity.SpeBoardDVS;

            this.tbxSteelMesh.Text = entity.SteelMesh;
            this.tbxCoorPattern.Text = entity.CoorPattern;
            
            this.tbxComments.Text = entity.Comments;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
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
                SMTModelFileInduceService.Update(entity);
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
                SMTModelFileInduceService.Delete(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tip", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');goBack();</script>");
        }
    }
}

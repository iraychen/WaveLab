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
    public partial class SYSModuleTypeEdit : CommonPage
    {
       private string ModuleTypeId;
       private ISYSModuleTypeService SYSModuleTypeService;
       private SYSModuleTypeInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");

            ModuleTypeId = Request.QueryString["ModuleTypeId"];
            entity = SYSModuleTypeService.GetDetail(ModuleTypeId);
            if (!Page.IsPostBack)
            {
                LoadInfo();
                this.btnDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
            }
        }

        private void LoadInfo()
        {
            this.lblSYSModuleTypeInfo.Text = entity.ModuleTypeId;
            this.tbxModuleTypeDesc.Text = entity.ModuleTypeDesc;
            if (entity.HasGenBoard == 'Y')
            {
                this.cbxHasGenBoard.Checked = true;
            }
            else
            {
                this.cbxHasGenBoard.Checked = false;
            }
            if (entity.HasSpeBoard == 'Y')
            {
                this.cbxHasSpeBoard.Checked = true;
            }
            else
            {
                this.cbxHasSpeBoard.Checked = false;
            }
            if (entity.HasSMTFabrication == 'Y')
            {
                this.cbxHasSMTFabrication.Checked = true;
            }
            else
            {
                this.cbxHasSMTFabrication.Checked = false;
            }
            if (entity.HasComponentPart == 'Y')
            {
                this.cbxHasComponentPart.Checked = true;
            }
            else
            {
                this.cbxHasComponentPart.Checked = false;
            }
            if (entity.HasGroupPart == 'Y')
            {
                this.cbxHasGroupPart.Checked = true;
            }
            else
            {
                this.cbxHasGroupPart.Checked = false;
            }
            if (entity.HasBondingFabrication == 'Y')
            {
                this.cbxHasBondingFabrication.Checked = true;
            }
            else
            {
                this.cbxHasBondingFabrication.Checked = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.ModuleTypeDesc = this.tbxModuleTypeDesc.Text.Trim();
            if (this.cbxHasGenBoard.Checked == true)
            {
                entity.HasGenBoard = 'Y';
            }
            else
            {
                entity.HasGenBoard = 'N';
            }
            if (this.cbxHasSpeBoard.Checked == true)
            {
                entity.HasSpeBoard = 'Y';
            }
            else
            {
                entity.HasSpeBoard = 'N';
            }
            if (this.cbxHasSMTFabrication.Checked == true)
            {
                entity.HasSMTFabrication = 'Y';
            }
            else
            {
                entity.HasSMTFabrication = 'N';
            }
            if (this.cbxHasComponentPart.Checked == true)
            {
                entity.HasComponentPart = 'Y';
            }
            else
            {
                entity.HasComponentPart = 'N';
            }
            if (this.cbxHasGroupPart.Checked == true)
            {
                entity.HasGroupPart = 'Y';
            }
            else
            {
                entity.HasGroupPart = 'N';
            }
            if (this.cbxHasBondingFabrication.Checked == true)
            {
                entity.HasBondingFabrication = 'Y';
            }
            else
            {
                entity.HasBondingFabrication = 'N';
            }
            try
            {
                SYSModuleTypeService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "updateSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SYSModuleTypeService.Delete(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

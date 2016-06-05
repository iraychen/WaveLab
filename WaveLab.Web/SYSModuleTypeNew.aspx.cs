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
    public partial class moduleNew : CommonPage
    {
        private ISYSModuleTypeService SYSModuleTypeService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SYSModuleTypeService.CheckExists(this.tbxSYSModuleType.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg") + "');</script>");
                return;
            }

            SYSModuleTypeInfo entity = new SYSModuleTypeInfo();
            entity.ModuleTypeId = this.tbxSYSModuleType.Text.Trim();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.CreationDate = DateTime.Now;
            entity.CreatedBy = Page.User.Identity.Name;
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
                entity.HasSMTFabrication= 'Y';
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
                SYSModuleTypeService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

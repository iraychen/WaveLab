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
    public partial class SMTPCBSteelMeshNew : CommonPage
    {
        private ISMTPCBSteelMeshService SMTPCBSteelMeshService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SMTPCBSteelMeshService = (ISMTPCBSteelMeshService)cxt.GetObject("SV.SMTPCBSteelMeshService");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SMTPCBSteelMeshService.CheckExists(this.tbxPCB.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg") + "');</script>");
                return;
            }

            SMTPCBSteelMeshInfo entity = new SMTPCBSteelMeshInfo();
            entity.PCB= this.tbxPCB.Text.Trim();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.CreationDate = DateTime.Now;
            entity.CreatedBy = Page.User.Identity.Name;
            entity.SteelMesh = this.tbxSteelMesh.Text.Trim();
            if (this.tbxFactureDate.Text.Trim().Length > 0)
            {
                entity.FactureDate = DateTime.ParseExact(this.tbxFactureDate.Text.Trim(), "yyyy-MM-dd", null);
            }
           
            entity.SerialNo = this.tbxSerielNo.Text.Trim();
            entity.DocumentNo = this.tbxDocumentNo.Text.Trim();
            entity.Comments = this.tbxComments.Text.Trim();
            entity.Defect = this.tbxDefect.Text.Trim();
            try
            {
               SMTPCBSteelMeshService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

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
    public partial class SMTPCBSteelMeshEdit : CommonPage
    {
        private string pcb;
        private ISMTPCBSteelMeshService SMTPCBSteelMeshService;
        private SMTPCBSteelMeshInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SMTPCBSteelMeshService = (ISMTPCBSteelMeshService)cxt.GetObject("SV.SMTPCBSteelMeshService");

           pcb = Request.QueryString["pcb"];
           entity = SMTPCBSteelMeshService.GetDetail(pcb);
            if (!Page.IsPostBack)
            {
                LoadInfo();
                this.btnDelete.Attributes.Add("onclick", "return confirm('"+this.GetGlobalResourceObject("globalResource","confirmDeleteMsg")+"')");
            }
        }

        private void LoadInfo()
        {
            this.lblPCBInfo.Text = entity.PCB;
            this.tbxSteelMesh.Text = entity.SteelMesh;
            if (entity.FactureDate != null)
            {
                this.tbxFactureDate.Text = String.Format("{0:yyyy-MM-dd}", entity.FactureDate);
            }

            this.tbxSerielNo.Text = entity.SerialNo;
            this.tbxDocumentNo.Text = entity.DocumentNo;
            this.tbxComments.Text = entity.Comments;
            this.tbxDefect.Text = entity.Defect;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.SteelMesh = this.tbxSteelMesh.Text;
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
                SMTPCBSteelMeshService.Update(entity);
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
                SMTPCBSteelMeshService.Delete(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

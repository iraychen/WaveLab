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
    public partial class SMTBomCoorPatternEdit : CommonPage
    {
        private string module, bomdn, bomdvs;
        private ISMTBomCoorPatternService SMTBomCoorPatternService;
        private SMTBomCoorPatternInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SMTBomCoorPatternService = (ISMTBomCoorPatternService)cxt.GetObject("SV.SMTBomCoorPatternService");

            module = Request.QueryString["module"];
            bomdn = Request.QueryString["bomdn"];
            bomdvs = Request.QueryString["bomdvs"];
            entity = SMTBomCoorPatternService.GetDetail(module, bomdn, bomdvs);
            if (!Page.IsPostBack)
            {
                LoadInfo();
                this.btnDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
            }
        }

        private void LoadInfo()
        {
            this.lblModuleInfo.Text = entity.Module;
            this.lblBomDnInfo.Text = entity.BomDN;
            this.lblBomDvsInfo.Text = entity.BomDVS;
            this.tbxCoorPattern.Text = entity.CoorPattern;
            this.tbxComments.Text = entity.Comments;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.CoorPattern = this.tbxCoorPattern.Text.Trim();
            entity.Comments = this.tbxComments.Text.Trim();
            try
            {
                SMTBomCoorPatternService.Update(entity);
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
                SMTBomCoorPatternService.Delete(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

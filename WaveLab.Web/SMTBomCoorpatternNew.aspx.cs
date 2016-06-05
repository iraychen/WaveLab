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
    public partial class SMTBomCoorPatternNew : CommonPage
    {
        private ISMTBomCoorPatternService SMTBomCoorPatternService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SMTBomCoorPatternService = (ISMTBomCoorPatternService)cxt.GetObject("SV.SMTBomCoorPatternService");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SMTBomCoorPatternService.CheckExists(this.tbxModule.Text.Trim(), this.tbxBomDn.Text.Trim(), this.tbxBomDvs.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg") + "');</script>");
                return;
            }

            SMTBomCoorPatternInfo entity= new SMTBomCoorPatternInfo();
            entity.Module = this.tbxModule.Text.Trim();
            entity.BomDN = this.tbxBomDn.Text.Trim();
            entity.BomDVS = this.tbxBomDvs.Text.Trim();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.CreationDate = DateTime.Now;
            entity.CreatedBy = Page.User.Identity.Name;
            entity.CoorPattern = this.tbxCoorPattern.Text.Trim();
            entity.Comments = this.tbxComments.Text.Trim();
            try
            {
                SMTBomCoorPatternService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

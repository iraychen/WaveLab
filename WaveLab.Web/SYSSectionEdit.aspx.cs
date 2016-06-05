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
    public partial class SYSSectionEdit : CommonPage 
    {
        private string userId;
        private string SectionId;
        private ISYSSectionService sectionService ;
        private SYSSectionInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            sectionService = (ISYSSectionService)cxt.GetObject("SV.SYSSectionService");

            userId = Page.User.Identity.Name;
            SectionId = Request.QueryString["sectionid"];
            entity = sectionService.GetDetail(SectionId);
            if (!Page.IsPostBack)
            {
                LoadInfo();
                this.btnDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
            }
        }

        private void LoadInfo()
        {
            this.lblSectionIdInfo.Text = entity.SectionId;
            this.tbxSectionDesc.Text = entity.SectionDesc;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.SectionDesc = this.tbxSectionDesc.Text.Trim();
            try
            {
                sectionService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Tip", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "updateSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                sectionService.Delete(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Tip", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

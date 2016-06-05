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
using WaveLab.Model;
using WaveLab.IService;
using Spring.Context;
using Spring.Context.Support;
namespace WaveLab.Web
{
    public partial class SYSRoleNew : CommonPage 
    {
        private ISYSRoleService roleService ;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            roleService = (ISYSRoleService)cxt.GetObject("SV.SYSRoleService");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (roleService.CheckExists(this.tbxRoleDesc.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("roleExistsMsg") + "');</script>");
                return;
            }

            SYSRoleInfo entity = new SYSRoleInfo();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.CreationDate = DateTime.Now;
            entity.CreatedBy = Page.User.Identity.Name;
            entity.RoleDesc = this.tbxRoleDesc.Text.Trim();

            try
            {
                roleService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Tip", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

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
    public partial class InjurantTypeNew : CommonPage
    {

        private IInjurantTypeService service;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            service = (IInjurantTypeService)cxt.GetObject("SV.InjurantTypeService");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (service.CheckExists(this.tbxInjurantTypeDesc.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg") + "');</script>");
                return;
            }

            InjurantTypeInfo entity = new InjurantTypeInfo();
            entity.InjurantTypeDesc = this.tbxInjurantTypeDesc.Text.Trim();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.CreationDate = DateTime.Now;
            entity.CreatedBy = Page.User.Identity.Name;
            

            try
            {
                service.Save(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

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
    public partial class InjurantTypeEdit : CommonPage
    {
        private string injurantTypeId;
        private IInjurantTypeService service;
        private InjurantTypeInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            service = (IInjurantTypeService)cxt.GetObject("SV.InjurantTypeService");

            injurantTypeId = Request.QueryString["injuranttypeid"];
            entity = service.GetDetail(int.Parse(injurantTypeId));
            if (!Page.IsPostBack)
            {
                LoadInfo();
                this.btnDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
            }
        }
        private void LoadInfo()
        {
            this.tbxInjurantTypeDesc.Text = entity.InjurantTypeDesc;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (service.CheckExists(entity, this.tbxInjurantTypeDesc.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg") + "');</script>");
                return;
            }

            entity.InjurantTypeDesc = this.tbxInjurantTypeDesc.Text.Trim();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            try
            {
                service.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "updateSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                service.Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

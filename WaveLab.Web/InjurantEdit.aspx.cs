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
    public partial class InjurantEdit : CommonPage
    {
        private string injurantId;
        private IInjurantService service;
        private IInjurantTypeService typeService;
        private InjurantInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            service = (IInjurantService)cxt.GetObject("SV.InjurantService");
            typeService = (IInjurantTypeService)cxt.GetObject("SV.InjurantTypeService");

            injurantId = Request.QueryString["injurantid"];
            entity = service.GetDetail(int.Parse(injurantId));
            if (!Page.IsPostBack)
            {
                this.ddlInjurantType.DataSource = typeService.GetItems(new Hashtable(), "injurant_type_desc", "asc");
                this.ddlInjurantType.DataValueField = "InjurantTypeId";
                this.ddlInjurantType.DataTextField = "InjurantTypeDesc";
                this.ddlInjurantType.DataBind();
                this.ddlInjurantType.Items.Insert(0, new ListItem("", ""));

                LoadInfo();
                this.btnDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
            }
        }
        private void LoadInfo()
        {
            this.tbxInjurantDescEn.Text = entity.InjurantDescEn;
            this.tbxInjurantDescCn.Text = entity.InjurantDescCn;
            this.tbxMolecularFormula.Text = entity.MolecularFormula;
            this.tbxCasNo.Text = entity.CasNo;
            this.tbxMainPurpose.Text = entity.MainPurpose;
            this.ddlInjurantType.SelectedValue = entity.InjurantTypeItem.InjurantTypeId.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (service.CheckExists(entity, this.tbxInjurantDescCn.Text.Trim(), this.tbxInjurantDescEn.Text.Trim(), this.tbxCasNo.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg") + "');</script>");
                return;
            }

            entity.InjurantDescEn = this.tbxInjurantDescEn.Text.Trim();
            entity.InjurantDescCn = this.tbxInjurantDescCn.Text.Trim();
            entity.MolecularFormula = this.tbxMolecularFormula.Text.Trim();
            entity.CasNo = this.tbxCasNo.Text.Trim();

            InjurantTypeInfo injurantTypeItem = new InjurantTypeInfo();
            if (this.ddlInjurantType.SelectedValue.Trim().Length > 0)
            {
                injurantTypeItem = typeService.GetDetail(int.Parse(this.ddlInjurantType.SelectedValue.Trim()));
            }
            entity.InjurantTypeItem = injurantTypeItem;
            entity.MainPurpose = this.tbxMainPurpose.Text.Trim();
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

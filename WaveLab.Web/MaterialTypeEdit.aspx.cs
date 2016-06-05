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
    public partial class MaterialTypeEdit : CommonPage
    {
        private string materialTypeId;
        private IMaterialTypeService service;
        private MaterialTypeInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            service = (IMaterialTypeService)cxt.GetObject("SV.MaterialTypeService");

            materialTypeId = Request.QueryString["MaterialTypeid"];
            entity = service.GetDetail(int.Parse(materialTypeId));
            if (!Page.IsPostBack)
            {
                LoadInfo();
                this.btnDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
            }
        }
        private void LoadInfo()
        {

            this.tbxMaterialTypeDesc.Text = entity.MaterialTypeDesc;
            if (entity.CalByQuantity == 'Y')
            {
                this.rblCalByQuantity.SelectedValue = "Y";
            }
            else
            {
                this.rblCalByQuantity.SelectedValue = "N";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (service.CheckExists(entity, this.tbxMaterialTypeDesc.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg") + "');</script>");
                return;
            }

            entity.MaterialTypeDesc = this.tbxMaterialTypeDesc.Text.Trim();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            if (this.rblCalByQuantity.SelectedValue == "Y")
            {
                entity.CalByQuantity = 'Y';
            }
            else
            {
                entity.CalByQuantity = 'N';
            }
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

        protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>goBack();</script>");
        }
    }
}

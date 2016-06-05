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
    public partial class ProductEdit : CommonPage
    {
        
        private string productId;
        private IProductService service;
        private ProductInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            service = (IProductService)cxt.GetObject("SV.ProductService");
            productId = Request.QueryString["productid"];
            entity = service.GetDetail(int.Parse(productId));
            if (!Page.IsPostBack)
            {
                LoadInfo();
                this.btnDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
            }
        }
        private void LoadInfo()
        {

            this.tbxProductDesc.Text = entity.ProductDesc;
            //if (entity.Audited == 'Y')
            //{
            //    this.rblAudited.SelectedValue = "Y";
            //}
            //else
            //{
            //    this.rblAudited.SelectedValue = "N";
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (service.CheckExists(entity,this.tbxProductDesc.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg") + "');</script>");
                return;
            }

            entity.ProductDesc = this.tbxProductDesc.Text.Trim();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            //if (this.rblAudited.SelectedValue == "Y")
            //{
            //    entity.Audited = 'Y';
            //}
            //else
            //{
            //    entity.Audited = 'N';
            //}
            try
            {
                service.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "updateSuccessMsg") + "');goBack();</script>");
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
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');goBack();</script>");
        }
    }
}

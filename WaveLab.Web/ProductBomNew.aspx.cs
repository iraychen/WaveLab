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
    public partial class ProductBomNew : CommonPage
    {
        private IProductService productService;
        private IMaterialTypeService materialTypeService;
        private ISYSModuleTypeService SYSModuleTypeService;
        private IProductBomService productBomService;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            productService = (IProductService)cxt.GetObject("SV.ProductService");
            materialTypeService = (IMaterialTypeService)cxt.GetObject("SV.MaterialTypeService");
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");
            productBomService = (IProductBomService)cxt.GetObject("SV.ProductBomService");

            if (!Page.IsPostBack)
            {
                LoadCriteria();
            }
        }

        private void LoadCriteria()
        {
            this.ddlProduct.DataSource = productService.GetItems(new Hashtable(), "product_desc", "asc");
            this.ddlProduct.DataValueField = "ProductId";
            this.ddlProduct.DataTextField = "ProductDesc";
            this.ddlProduct.DataBind();

            this.ddlMaterialType.DataSource = materialTypeService.GetItems(new Hashtable(), "material_type_desc", "asc");
            this.ddlMaterialType.DataValueField = "MaterialTypeId";
            this.ddlMaterialType.DataTextField = "MaterialTypeDesc";
            this.ddlMaterialType.DataBind();
            this.ddlMaterialType.Items.Insert(0, new ListItem("", ""));

            this.ddlSYSModuleType.DataSource = SYSModuleTypeService.GetItems();
            this.ddlSYSModuleType.DataValueField = "ModuleTypeId";
            this.ddlSYSModuleType.DataTextField = "ModuleTypeDesc";
            this.ddlSYSModuleType.DataBind();
            this.ddlSYSModuleType.Items.Insert(0, new ListItem("", ""));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (productBomService.CheckExists(int.Parse(this.ddlProduct.SelectedValue),this.tbxMaterialCode.Text.Trim(),this.tbxMaterialDesc.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg") + "');</script>");
                return;
            }

            ProductInfo productItem = new ProductInfo
            {
                ProductId = Convert.ToInt32(this.ddlProduct.SelectedValue),
                ProductDesc = this.ddlProduct.SelectedItem.Text
            };
            MaterialTypeInfo materialTypeItem = new MaterialTypeInfo();
          
            SYSModuleTypeInfo ModuleTypeItem = new SYSModuleTypeInfo();

            if (this.ddlMaterialType.SelectedValue.Trim().Length > 0)
            {
                materialTypeItem.MaterialTypeId = Convert.ToInt32(this.ddlMaterialType.SelectedValue.Trim());
                materialTypeItem.MaterialTypeDesc = this.ddlMaterialType.SelectedItem.Text;
            }

            if (this.ddlSYSModuleType.SelectedValue.Trim().Length > 0)
            {
                ModuleTypeItem.ModuleTypeId =this.ddlSYSModuleType.SelectedValue.Trim();
                ModuleTypeItem.ModuleTypeDesc = this.ddlSYSModuleType.SelectedItem.Text;
            }

            ProductBomInfo entity = new ProductBomInfo();
            entity.ProductItem = productItem;
            entity.MaterialCode = this.tbxMaterialCode.Text.Trim();
            entity.MaterialTypeItem = materialTypeItem;
            entity.MaterialDesc = this.tbxMaterialDesc.Text.Trim();
            entity.SupplierName = this.tbxSupplierName.Text.Trim();
            entity.Amount = Convert.ToDouble(this.tbxAmount.Text.Trim());
            entity.ModuleTypeItem = ModuleTypeItem;
            entity.Comment = this.tbxComment.Text.Trim();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.CreationDate = DateTime.Now;
            entity.CreatedBy = Page.User.Identity.Name;


            try
            {
                productBomService.Save(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

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
    public partial class ProductBomEdit : CommonPage
    {
        private string productBomId;
        private IProductService productService;
        private IMaterialTypeService materialTypeService;
        private ISYSModuleTypeService SYSModuleTypeService;
        private IProductBomService productBomService;
        private ProductBomInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            productService = (IProductService)cxt.GetObject("SV.ProductService");
            materialTypeService = (IMaterialTypeService)cxt.GetObject("SV.MaterialTypeService");
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");
            productBomService = (IProductBomService)cxt.GetObject("SV.ProductBomService");


            productBomId = Request.QueryString["productbomtid"];
            entity = productBomService.GetDetail(int.Parse(productBomId));
            if (!Page.IsPostBack)
            {
                LoadCriteria();

                LoadInfo();
                this.btnDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
            }
        }

        private void LoadCriteria()
        {
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

        private void LoadInfo()
        {
            this.lblProductDesc.Text = entity.ProductItem.ProductDesc;
            this.lblMaterialCodeInfo.Text = entity.MaterialCode;
            this.ddlMaterialType.SelectedValue = entity.MaterialTypeItem.MaterialTypeId.ToString();
            this.lblMaterialDescInfo.Text = entity.MaterialDesc;
            this.tbxSupplierName.Text = entity.SupplierName;
            this.tbxAmount.Text = entity.Amount.ToString();
            this.ddlSYSModuleType.SelectedValue = entity.ModuleTypeItem.ModuleTypeId.Trim().ToString();
            this.tbxComment.Text = entity.Comment;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MaterialTypeInfo materialTypeItem = new MaterialTypeInfo();
            SYSModuleTypeInfo ModuleTypeItem = new SYSModuleTypeInfo();
            if (this.ddlMaterialType.SelectedValue.Trim().Length > 0)
            {
                materialTypeItem.MaterialTypeId = Convert.ToInt32(this.ddlMaterialType.SelectedValue.Trim());
                materialTypeItem.MaterialTypeDesc = this.ddlMaterialType.SelectedItem.Text;
            }
            if (this.ddlSYSModuleType.SelectedValue.Trim().Length > 0)
            {
                ModuleTypeItem.ModuleTypeId = this.ddlSYSModuleType.SelectedValue.Trim();
                ModuleTypeItem.ModuleTypeDesc = this.ddlSYSModuleType.SelectedItem.Text;
            }
            entity.MaterialTypeItem = materialTypeItem;
            entity.SupplierName = this.tbxSupplierName.Text.Trim();
            entity.Amount = Convert.ToDouble(this.tbxAmount.Text.Trim());
            entity.ModuleTypeItem = ModuleTypeItem;
            entity.Comment = this.tbxComment.Text.Trim();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            try
            {
                productBomService.Update(entity);
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
                productBomService.Delete(entity);
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

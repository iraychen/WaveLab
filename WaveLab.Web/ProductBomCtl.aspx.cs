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
using System.Collections.Generic;

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class ProductBomCtl : CommonPage
    {
        private Hashtable equalHashTable = new Hashtable();
        private Hashtable hashTable = new Hashtable();
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
                BindResult();
            }
        }

        private void LoadCriteria()
        {

            this.ddlProduct.DataSource = productService.GetItems(new Hashtable(),"product_desc", "asc");
            this.ddlProduct.DataValueField = "ProductId";
            this.ddlProduct.DataTextField = "ProductDesc";
            this.ddlProduct.DataBind();
            this.ddlProduct.Items.Insert(0, new ListItem("", ""));

            this.ddlMaterialType.DataSource = materialTypeService.GetItems(new Hashtable(),"material_type_desc", "asc");
            this.ddlMaterialType.DataValueField = "MaterialTypeId";
            this.ddlMaterialType.DataTextField = "MaterialTypeDesc";
            this.ddlMaterialType.DataBind();
            this.ddlMaterialType.Items.Insert(0, new ListItem("", ""));

            this.ddlSYSModuleType.DataSource = SYSModuleTypeService.GetItems();
            this.ddlSYSModuleType.DataValueField = "ModuleTypeId";
            this.ddlSYSModuleType.DataTextField = "ModuleTypeDesc";
            this.ddlSYSModuleType.DataBind();
            this.ddlSYSModuleType.Items.Insert(0, new ListItem("", ""));

            if (string.IsNullOrEmpty(Request.QueryString["product_id"]) == false)
            {
                this.ddlProduct.SelectedValue = Request.QueryString["product_id"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["material_type_id"]) == false)
            {
                this.ddlMaterialType.SelectedValue = Request.QueryString["material_type_id"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["material_code"]) == false)
            {
                this.tbxMaterialCode.Text = Request.QueryString["material_code"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["material_desc"]) == false)
            {
                this.tbxMaterialDesc.Text = Request.QueryString["material_desc"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["module_type_id"]) == false)
            {
                this.ddlSYSModuleType.SelectedValue = Request.QueryString["module_type_id"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["sb"]) == false)
            {
                ViewState["sortby"] = Request.QueryString["sb"].ToString();
            }
            else
            {
                ViewState["sortby"] = "b.product_desc,a.material_code,a.material_desc";
            }

            if (string.IsNullOrEmpty(Request.QueryString["ob"]) == false)
            {
                ViewState["orderby"] = Request.QueryString["ob"].ToString();
            }
            else
            {
                ViewState["orderby"] = "asc";
            }
        }

        private void GetSearchCriteria()
        {
            if (this.ddlProduct.SelectedValue.Trim().Length > 0)
            {
                equalHashTable.Add("product_id", this.ddlProduct.SelectedValue.Trim());
            }
            if (this.ddlMaterialType.SelectedValue.Trim().Length > 0)
            {
                equalHashTable.Add("material_type_id", this.ddlMaterialType.SelectedValue.Trim());
            }

            if (this.tbxMaterialCode.Text.Trim().Length > 0)
            {
                hashTable.Add("material_code", this.tbxMaterialCode.Text.Trim());
            }

            if (this.tbxMaterialDesc.Text.Trim().Length > 0)
            {
                hashTable.Add("material_desc", System.Web.HttpUtility.HtmlEncode(this.tbxMaterialDesc.Text.Trim()));
            }

            if (this.ddlSYSModuleType.SelectedValue.Trim().Length > 0)
            {
                equalHashTable.Add("module_type_id", this.ddlSYSModuleType.SelectedValue.Trim());
            }
        }

        private void BindResult()
        {
            GetSearchCriteria();
            IList<ProductBomInfo> items = productBomService.GetItems(equalHashTable, hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.GVList.Visible = false;
                this.PagerNavigator.Visible = false;

            }
            else
            {
                this.lblRecCount.Visible = false;
                this.GVList.Visible = true;
                this.PagerNavigator.Visible = true;
                this.PagerNavigator.RecordCount = items.Count;
                if (!Page.IsPostBack && string.IsNullOrEmpty(Request.QueryString["page"]) == false)
                {
                    this.PagerNavigator.CurrentPageIndex = int.Parse(Request.QueryString["page"]);
                }

                var pageItems =
                (
                  from item in items
                  select item
                ).Skip(this.PagerNavigator.PageSize * (this.PagerNavigator.CurrentPageIndex - 1)).Take(this.PagerNavigator.PageSize);

                this.GVList.DataSource = pageItems;
                this.GVList.DataBind();

            }

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("ProductBomCtl.aspx?1=1");
            foreach (DictionaryEntry item in equalHashTable)
            {
                builder.Append("&" + item.Key + "=" + item.Value.ToString());
            }
            foreach (DictionaryEntry item in hashTable)
            {
                builder.Append("&" + item.Key + "=" + item.Value.ToString());
            }
            builder.Append("&sb=" + ViewState["sortby"]);
            builder.Append("&ob=" + ViewState["orderby"]);
            builder.Append("&page=" + this.PagerNavigator.CurrentPageIndex);
            this.hfdCurLink.Value = System.Web.HttpUtility.UrlEncode(builder.ToString());
        }

        protected void GVList_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["sortby"].ToString() == e.SortExpression)
            {
                if (ViewState["orderby"].ToString() == "asc")
                {
                    ViewState["orderby"] = "desc";
                }
                else
                {
                    ViewState["orderby"] = "asc";
                }
            }
            else
            {
                ViewState["sortby"] = e.SortExpression;
            }
            this.BindResult();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.PagerNavigator.CurrentPageIndex = 1;
            this.BindResult();
        }

        protected void PagerNavigator_PageChanged(object sender, EventArgs e)
        {
            this.BindResult();
        }
    }
}

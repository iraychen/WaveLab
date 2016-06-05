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
using System.IO;
using Spring.Context;
using Spring.Context.Support;
using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class RptProductBom :  CommonPage 
    {
        private IProductService productService;
        private IMaterialTypeService materialTypeService;
        private IProductBomService productBomService;
        private IProductBomReportService productBomReportService;
        private Hashtable equalHashTable=new Hashtable();
        private Hashtable paraHashTable = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            productService = (IProductService)cxt.GetObject("SV.ProductService");
            materialTypeService = (IMaterialTypeService)cxt.GetObject("SV.MaterialTypeService");
            productBomService = (IProductBomService)cxt.GetObject("SV.ProductBomService");

            productBomReportService = (IProductBomReportService)cxt.GetObject("SV.ProductBomReportService");

            if (!Page.IsPostBack)
            {
                LoadCriteria();
            }
        }

        private void LoadCriteria()
        {
            //Hashtable hashTable = new Hashtable();
            //hashTable.Add("audited", "Y");
            this.ddlProduct.DataSource = productService.GetItems(new Hashtable(), "product_desc", "asc");
            this.ddlProduct.DataValueField = "ProductId";
            this.ddlProduct.DataTextField = "ProductDesc";
            this.ddlProduct.DataBind();
            this.ddlProduct.Items.Insert(0, new ListItem("", ""));

            this.ddlMaterialType.DataSource = materialTypeService.GetItems(new Hashtable(), "material_type_desc", "asc");
            this.ddlMaterialType.DataValueField = "MaterialTypeId";
            this.ddlMaterialType.DataTextField = "MaterialTypeDesc";
            this.ddlMaterialType.DataBind();
            this.ddlMaterialType.Items.Insert(0, new ListItem("", ""));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            //bool showProduct = true;

            builder.Append("RptProductBomList.aspx?1=1");

            if (this.ddlProduct.SelectedValue.Length > 0)
            {
                builder.Append("&productid="+this.ddlProduct.SelectedValue.Trim());

                //showProduct = false;
                //equalHashTable.Add("product_id", this.ddlProduct.SelectedValue.Trim());
                //paraHashTable.Add(this.lblProduct.Text, this.ddlProduct.SelectedItem.Text);
            }
            if (this.ddlMaterialType.SelectedValue.Length > 0)
            {
                builder.Append("&materialtypeid=" + this.ddlMaterialType.SelectedValue.Trim());

                //equalHashTable.Add("material_type_id", this.ddlMaterialType.SelectedValue.Trim());
                //paraHashTable.Add(this.lblMaterialType.Text, this.ddlMaterialType.SelectedItem.Text);
            }
            if (this.tbxMaterialCode.Text.Trim().Length > 0)
            {
                builder.Append("&materialcode=" + this.tbxMaterialCode.Text.Trim());

                //equalHashTable.Add("material_code", this.tbxMaterialCode.Text.Trim());
                //paraHashTable.Add(this.lblMaterialCode.Text, this.tbxMaterialCode.Text.Trim());
            }
            if (this.tbxMaterialDesc.Text.Trim().Length > 0)
            {
                builder.Append("&materialdesc=" + this.tbxMaterialDesc.Text.Trim());

                //equalHashTable.Add("material_desc", this.tbxMaterialDesc.Text.Trim());
                //paraHashTable.Add(this.lblMaterialDesc.Text, this.tbxMaterialDesc.Text.Trim());
            }

            Response.Redirect(builder.ToString());

            //string ExportType = "S";
            //switch (ExportType)
            //{
            //    case "S":
                   
            //        break;
            //    case "E":
                    //Report Paras
                    //string sortBy, orderBy;
                    //sortBy = "b.product_desc,a.material_code,a.material_desc";
                    //orderBy = "asc";
                    //System.Collections.Generic.IList<ProductBomInfo> items = productBomService.GetItems(equalHashTable, new Hashtable(), sortBy, orderBy);

                    ////Report Header
                    //ArrayList arrayList = new ArrayList();
                    //if (showProduct == true)
                    //{
                    //    arrayList.Add(this.GetLocalResourceObject("ProductHeader"));
                    //}
                    //arrayList.Add(this.GetLocalResourceObject("MaterialCodeHeader"));
                    //arrayList.Add(this.GetLocalResourceObject("MaterialTypeHeader"));
                    //arrayList.Add(this.GetLocalResourceObject("MaterialDescHeader"));
                    //arrayList.Add(this.GetLocalResourceObject("SupplierNameHeader"));
                    //arrayList.Add(this.GetLocalResourceObject("AmountHeader"));
                    //arrayList.Add(this.GetLocalResourceObject("SYSModuleTypeHeader"));
                    //arrayList.Add(this.GetLocalResourceObject("CommentHeader"));

                    ////Export
                    //MemoryStream ms = roductBomReportService.Export(this.lblTitle.Text.Trim(), paraHashTable, showProduct, arrayList, items);
                    //Response.ClearHeaders();
                    //Response.Clear();
                    //Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
                    //Response.ContentType = "application/octet-stream";
                    //Response.Flush();
                    //Response.BinaryWrite(ms.GetBuffer());
                    //Response.End();
            //        break;
            //    default :
            //        break;
            //}
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
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
    public partial class RptMCTOriginal : CommonPage
    {
        private IProductService productService;
        private IMaterialTypeService materialTypeService;
        private IMCTReportService mctReportService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            productService = (IProductService)cxt.GetObject("SV.ProductService");
            materialTypeService = (IMaterialTypeService)cxt.GetObject("SV.MaterialTypeService");
            mctReportService = (IMCTReportService)cxt.GetObject("SV.MCTReportService");

            if (!Page.IsPostBack)
            {
                LoadCriteria();
            }
        }

        private void LoadCriteria()
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add("audited", "Y");
            this.ddlProduct.DataSource = productService.GetItems(hashTable,"product_desc", "asc");
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
            Hashtable hashTable = new Hashtable();
            IList<DictionaryEntry> paras = new List<DictionaryEntry>();

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("RptMCTOriginalList.aspx?1=1");

            bool showProduct = true;

            if (this.ddlProduct.SelectedValue.Length > 0)
            {
                builder.Append("&productid=" + this.ddlProduct.SelectedValue.Trim());
                showProduct = false;
                hashTable.Add("product_id", this.ddlProduct.SelectedValue.Trim());
                paras.Add(new DictionaryEntry(this.lblProduct.Text, this.ddlProduct.SelectedItem.Text));
            }
            if (this.ddlMaterialType.SelectedValue.Length > 0)
            {
                builder.Append("&materialtypeid=" + this.ddlMaterialType.SelectedValue.Trim());

                hashTable.Add("material_type_id", this.ddlMaterialType.SelectedValue.Trim());
                paras.Add(new DictionaryEntry(this.lblMaterialType.Text, this.ddlMaterialType.SelectedItem.Text));
            }
            if (this.tbxMaterialCode.Text.Trim().Length > 0)
            {
                builder.Append("&materialcode=" + this.tbxMaterialCode.Text.Trim());

                hashTable.Add("material_code", this.tbxMaterialCode.Text.Trim());
                paras.Add(new DictionaryEntry(this.lblMaterialCode.Text, this.tbxMaterialCode.Text.Trim()));
            }
            if (this.tbxMaterialDesc.Text.Trim().Length > 0)
            {
                builder.Append("&materialdesc=" +  this.tbxMaterialDesc.Text.Trim());

                hashTable.Add("material_desc",  System.Web.HttpUtility.HtmlEncode(this.tbxMaterialDesc.Text.Trim()));
                paras.Add(new DictionaryEntry(this.lblMaterialDesc.Text, this.tbxMaterialDesc.Text.Trim()));
            }

            string ExportType = this.ddlExportType.SelectedValue.Trim();
            switch (ExportType)
            {
                case "S":
                      Response.Redirect(builder.ToString());
                    break;
                case "E":
                    string sortBy, orderBy;
                    sortBy = "m.product_desc,m.material_type_desc,m.material_code,m.material_desc,m.component_desc";
                    orderBy = "asc";
                    System.Collections.Generic.IList<RptMCTOriginalInfo> items = mctReportService.QueryMCTOriginal(hashTable, sortBy, orderBy);


                   //Report Header
                    ArrayList headerArray = new ArrayList();
                    if (showProduct == true)
                    {
                       headerArray.Add(this.GetLocalResourceObject("BoundFieldResource1.HeaderText"));
                    }
                   headerArray.Add(this.GetLocalResourceObject("BoundFieldResource2.HeaderText"));
                   headerArray.Add(this.GetLocalResourceObject("BoundFieldResource3.HeaderText"));
                   headerArray.Add(this.GetLocalResourceObject("BoundFieldResource4.HeaderText"));
                   headerArray.Add(this.GetLocalResourceObject("BoundFieldResource5.HeaderText"));
                   headerArray.Add(this.GetLocalResourceObject("BoundFieldResource6.HeaderText"));
                   headerArray.Add(this.GetLocalResourceObject("BoundFieldResource7.HeaderText"));
                   headerArray.Add(this.GetLocalResourceObject("BoundFieldResource8.HeaderText"));
                   headerArray.Add(this.GetLocalResourceObject("BoundFieldResource9.HeaderText"));
                   headerArray.Add(this.GetLocalResourceObject("BoundFieldResource10.HeaderText"));
                   headerArray.Add(this.GetLocalResourceObject("BoundFieldResource11.HeaderText"));

                    MemoryStream ms = mctReportService.ExportMCTOriginal(this.lblTitle.Text.Trim(), paras, showProduct,headerArray, items);
                    Response.ClearHeaders();
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
                    Response.ContentType = "application/octet-stream";
                    Response.Flush();
                    Response.BinaryWrite(ms.GetBuffer());
                    Response.End();
                    break;
                default :
                    break;
            } 
        }
    }
}

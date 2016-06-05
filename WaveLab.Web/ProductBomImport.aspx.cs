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
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;
using WaveLab.Service.Utility;

namespace WaveLab.Web
{
    public partial class ProductBomImport : CommonPage
    {
        private IProductBomImportService productBomImportService;
        private IProductService productService;
        private IMaterialTypeService materialTypeService;
        private ISYSModuleTypeService SYSModuleTypeService;
        private IProductBomService productBomService;
        private ISampleTemplateService sampleTemplateService;

        private int errorCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            productService = (IProductService)cxt.GetObject("SV.ProductService");
            materialTypeService = (IMaterialTypeService)cxt.GetObject("SV.MaterialTypeService");
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");
            productBomService = (IProductBomService)cxt.GetObject("SV.ProductBomService");
            sampleTemplateService = (ISampleTemplateService)cxt.GetObject("SV.SampleTemplateService");
            if (!Page.IsPostBack)
            {
                this.ddlProduct.DataSource = productService.GetItems(new Hashtable(), "product_desc", "asc");
                this.ddlProduct.DataTextField = "ProductDesc";
                this.ddlProduct.DataValueField = "ProductId";
                this.ddlProduct.DataBind();
            }
        }

        #region "Download SampleExcel"

        protected void lbtTemplateDownLoad_Click(object sender, EventArgs e)
        {
            string fileName = sampleTemplateService.GetSampleTemplate("PRODUCT_BOM").DocumentPath;
            string filePath = WaveLab.Service.Setting.sampleExcelPath + fileName;
            FileStream stream = new FileStream(filePath, FileMode.Open);
            int count = Convert.ToInt32(stream.Length);
            Byte[] bytes = new Byte[count];
            stream.Read(bytes, 0, count);
            stream.Close();
            Response.ClearHeaders();
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.ContentType = "application/octet-stream";
            Response.Flush();
            Response.BinaryWrite(bytes);
            Response.End();
        }

        #endregion

        #region "Upload Excel"
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string filePath = this.fileUploader.PostedFile.FileName;

            int index = filePath.LastIndexOf(".");
            string ext = filePath.Substring(index).ToUpper();

            if (string.Equals(ext, ".XLS") == true)
            {

                ViewState.Add("ProductId", this.ddlProduct.SelectedValue);
                ProductInfo productItem = new ProductInfo
                {
                    ProductId = Convert.ToInt32(this.ddlProduct.SelectedValue),
                    ProductDesc = this.ddlProduct.SelectedItem.Text
                };
                
                DataTable DT = productBomImportService.Import(productItem, this.fileUploader.FileContent, "Sheet1");
                if (DT.Rows.Count == 0)
                {
                    this.lblRecCount.Text = this.GetLocalResourceObject("norecords").ToString();
                    this.lblErrorCount.Visible = false;
                    this.GVList.Visible = false;
                    this.btnImport.Visible = false;
                }
                else
                {
                    this.lblErrorCount.Visible = true;
                    this.GVList.Visible = true;
                    this.GVList.DataSource = DT;
                    this.GVList.DataBind();

                    this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "total").ToString() + this.GVList.Rows.Count + " " + this.GetGlobalResourceObject("globalResource", "records").ToString();
                    this.lblErrorCount.Text = errorCount + this.GetLocalResourceObject("errorRecordsMsg").ToString(); ;

                    this.btnImport.Visible = true;
                    this.btnImport.Attributes.Add("onclick", "return confirm('" + this.GetLocalResourceObject("confirmImportMsg").ToString() + "')");
                }
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                HiddenField hfdIsPass = (HiddenField)e.Row.FindControl("hfdIsPass");

                string materialCode, materialDesc, supplierName, Amount;
                materialCode = WebUtitlity.InputText(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MaterialCode")),50).Trim();
                materialDesc = WebUtitlity.InputText(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MaterialDesc")),50).Trim();
                supplierName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SupplierName"));
                Amount = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Amount"));
               
                //Check Format
                if (
                    materialCode.Length == 0 || materialDesc.Length == 0 || supplierName.Length == 0 || Amount.Length==0 ||
                    materialCode.Length > 50 || materialDesc.Length > 50 || supplierName.Length> 50  || Regex.IsMatch(Amount,@"^\d+(\.\d+)?$") ==false 
                   )
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    hfdIsPass.Value = "N";
                    errorCount++;
                }
                else 
                {
                    //Check Type
                    string  materialTypeDesc, ModuleTypeDesc;
                    materialTypeDesc = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MaterialTypeDesc"));
                    ModuleTypeDesc = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ModuleTypeDesc"));
                    if (
                           (string.IsNullOrEmpty(materialTypeDesc) == false && materialTypeService.CheckExists(materialTypeDesc) == false) ||
                           (string.IsNullOrEmpty(ModuleTypeDesc) == false && SYSModuleTypeService.CheckExistsByDesc(ModuleTypeDesc) == false)
                        )
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;
                        errorCount++;
                        hfdIsPass.Value = "N";
                    }
                    else
                    {
                        hfdIsPass.Value = "Y";
                    }
                }
            }
        }

        #endregion

        #region "Import Data"
        protected void btnImport_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(ViewState["ProductId"]);

            int count = this.GVList.Rows.Count;
           
            List<ProductBomInfo> items = new List<ProductBomInfo>();
           
            for (int i = 0; i < count; i++)
            {
                HiddenField hfdIsPass = (HiddenField)this.GVList.Rows[i].FindControl("hfdIsPass");

                if (hfdIsPass.Value == "Y")
                {
                    ProductBomInfo item = new ProductBomInfo();

                    ProductInfo productItem = new ProductInfo
                    {
                        ProductId = productId
                    };
                    item.ProductItem = productItem;

                    item.MaterialCode = WebUtitlity.InputText(this.GVList.Rows[i].Cells[1].Text, 50).Trim();
                    item.MaterialTypeItem=new MaterialTypeInfo{
                        MaterialTypeDesc = WebUtitlity.InputText(this.GVList.Rows[i].Cells[2].Text, 50).Trim()
                    };
                    item.MaterialDesc = WebUtitlity.InputText(this.GVList.Rows[i].Cells[3].Text, 50).Trim();
                    item.SupplierName= WebUtitlity.InputText(this.GVList.Rows[i].Cells[4].Text, 50).Trim();
                    item.Amount = Convert.ToDouble(WebUtitlity.InputText(this.GVList.Rows[i].Cells[5].Text, 8).Trim());
                    item.ModuleTypeItem=new SYSModuleTypeInfo
                    {
                        ModuleTypeDesc = WebUtitlity.InputText(this.GVList.Rows[i].Cells[6].Text, 50).Trim()
                    };
                    item.Comment = WebUtitlity.InputText(this.GVList.Rows[i].Cells[7].Text, 100).Trim();
                   
                    item.LastUpdateDate = DateTime.Now;
                    item.LastUpdatedBy = Page.User.Identity.Name;
                    item.CreationDate = DateTime.Now;
                    item.CreatedBy = Page.User.Identity.Name;
                    items.Add(item);
                }
            }

          

            try
            {
                productBomService.Import(productId,items);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("importSuccessMsg").ToString() + "');</script>");
            this.btnImport.Visible = false;
        }
        #endregion
    }
}

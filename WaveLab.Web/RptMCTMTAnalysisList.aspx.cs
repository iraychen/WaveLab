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
    public partial class RptMCTMTAnalysisList : CommonPage
    {
        private string productId, materialTypeId;
        private IProductService productService;
        private IMaterialTypeService materialTypeService;
        private IMCTReportService mctReportService;
        private Hashtable hashTable = new Hashtable();
        string pastProductDesc = "", pastMaterialTypeDesc = "",  pastComponentDesc = "", pastHomoMaterialName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            productService = (IProductService)cxt.GetObject("SV.ProductService");
            materialTypeService = (IMaterialTypeService)cxt.GetObject("SV.MaterialTypeService");
            mctReportService = (IMCTReportService)cxt.GetObject("SV.MCTReportService");


            GetParas();
            if (!Page.IsPostBack)
            {
                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"] = "m.product_desc,m.material_type_desc,m.component_desc";
                }

                if (ViewState["orderby"] == null)
                {
                    ViewState["orderby"] = "asc";
                }
                BindResult();
            }
        }

        private void GetParas()
        {
            productId = Request.QueryString["productid"];
            materialTypeId = Request.QueryString["materialtypeid"];
           

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            int paraColumn = 1;
            builder.Append("<table  width=\"100%\" cellpadding=\"0\" border=\"0\" cellspacing =\"0\">");

            ArrayList paras = new ArrayList();
            if (string.IsNullOrEmpty(productId) == false)
            {
                hashTable.Add("product_id", productId);
                paras.Add(this.GetLocalResourceObject("BoundFieldResource1.HeaderText") + ": " + productService.GetDetail(int.Parse(productId)).ProductDesc);
            }
            if (string.IsNullOrEmpty(materialTypeId) == false)
            {
                hashTable.Add("material_type_id", materialTypeId);
                paras.Add(this.GetLocalResourceObject("BoundFieldResource2.HeaderText") + ": " + materialTypeService.GetDetail(int.Parse(materialTypeId)).MaterialTypeDesc);
            }

            for (int i = 0; i <= paras.Count - 1; i++)
            {
                if (paraColumn == 1)
                {
                    builder.Append("<tr><td>" + paras[i].ToString() + "</td>");
                    paraColumn = 2;
                }
                else
                {
                    builder.Append("<td>" + paras[i].ToString() + "</td></tr>");
                    paraColumn = 1;
                }

                if (i == paras.Count - 1)
                {
                    if (paraColumn == 2)
                    {
                        builder.Append("</tr>");
                    }
                }
            }
            builder.Append("</table>");
            this.divParas.InnerHtml = builder.ToString();
        }

        private void BindResult()
        {
            System.Collections.Generic.IList<RptMCTMTAnalysisInfo> items = mctReportService.QueryMCTMTAnalysis(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());

            if (items.Count == 0)
            {
                this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "noRecordsMsg").ToString();
                this.GVList.Visible = false;
            }
            else
            {
                this.GVList.DataSource = items;
                this.GVList.DataBind();
                this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "total").ToString() + " " + this.GVList.Rows.Count + " " + this.GetGlobalResourceObject("globalResource", "records").ToString();
                if (string.IsNullOrEmpty(productId) == false)
                {
                    this.GVList.Columns[0].Visible = false;
                }
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {

                if (string.Equals(Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "ProductDesc")), pastProductDesc) == true)
                {
                    e.Row.Cells[0].Text = "";
                }
                if (string.Equals(Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "ProductDesc")), pastProductDesc) == true &&
                    string.Equals(Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "MaterialTypeDesc")), pastMaterialTypeDesc) == true)
                {
                    e.Row.Cells[1].Text = "";
                }

                if (string.Equals(Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "ProductDesc")), pastProductDesc) == true &&
                   string.Equals(Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "MaterialTypeDesc")), pastMaterialTypeDesc) == true &&
                   string.Equals(Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "ComponentDesc")), pastComponentDesc) == true)
                {
                    e.Row.Cells[2].Text = "";
                }

                if (string.Equals(Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "ProductDesc")), pastProductDesc) == true &&
                    string.Equals(Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "MaterialTypeDesc")), pastMaterialTypeDesc) == true &&
                    string.Equals(Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "ComponentDesc")), pastComponentDesc) == true &&
                    string.Equals(Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "HomoMaterialName")), pastHomoMaterialName) == true)
                {
                    e.Row.Cells[3].Text = "";
                }
                pastProductDesc = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "ProductDesc"));
                pastMaterialTypeDesc = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "MaterialTypeDesc"));
                pastComponentDesc = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "ComponentDesc"));
                pastHomoMaterialName = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "HomoMaterialName"));
            }
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

    }
}

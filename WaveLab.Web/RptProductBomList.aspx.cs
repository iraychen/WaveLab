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
    public partial class RptProductBomList : CommonPage
    {
        private string productId,materialTypeId,materialCode, materialDesc;
        private IProductService productService;
        private IMaterialTypeService materialTypeService;
        private IProductBomService productBomService;
        private Hashtable equalHashTable = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            productService = (IProductService)cxt.GetObject("SV.ProductService");
            materialTypeService = (IMaterialTypeService)cxt.GetObject("SV.MaterialTypeService");
            productBomService = (IProductBomService)cxt.GetObject("SV.ProductBomService");

            GetParas();
            if (!Page.IsPostBack)
            {
                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"] = "b.product_desc,a.material_code,a.material_desc";
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
            materialCode = Request.QueryString["materialcode"];
            materialDesc = System.Web.HttpUtility.HtmlEncode(Request.QueryString["materialdesc"]);

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            int paraColumn = 1;
            builder.Append("<table  width=\"100%\" cellpadding=\"0\" border=\"0\" cellspacing =\"0\">");

            ArrayList paraArrayList = new ArrayList();
            if (string.IsNullOrEmpty(productId) == false)
            {
                equalHashTable.Add("product_id", productId);
                paraArrayList.Add(this.GetLocalResourceObject("TemplateFieldResource1.HeaderText") + ": " + productService.GetDetail(int.Parse(productId)).ProductDesc);
            }
            if (string.IsNullOrEmpty(materialCode) == false)
            {
                equalHashTable.Add("material_code", materialCode);
                paraArrayList.Add(this.GetLocalResourceObject("BoundFieldResource1.HeaderText") + ": " + materialCode);
            }
            if (string.IsNullOrEmpty(materialTypeId) == false)
            {
                equalHashTable.Add("material_type_id", materialTypeId);
                paraArrayList.Add(this.GetLocalResourceObject("TemplateFieldResource2.HeaderText") + ": " + materialTypeService.GetDetail(int.Parse(materialTypeId)).MaterialTypeDesc);
            }
            if (string.IsNullOrEmpty(materialDesc) == false)
            {
                equalHashTable.Add("material_desc", materialDesc);
                paraArrayList.Add(this.GetLocalResourceObject("BoundFieldResource2.HeaderText") + ": " + materialDesc);
            }
           
            for (int i = 0; i <= paraArrayList.Count - 1; i++)
            {
                if (paraColumn == 1)
                {
                    builder.Append("<tr><td>" + paraArrayList[i].ToString() + "</td>");
                    paraColumn = 2;
                }
                else
                {
                    builder.Append("<td>" + paraArrayList[i].ToString() + "</td></tr>");
                    paraColumn = 1;
                }

                if (i == paraArrayList.Count - 1)
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
            System.Collections.Generic.IList<ProductBomInfo> items = productBomService.GetItems(equalHashTable, new Hashtable(), ViewState["sortby"].ToString(), ViewState["orderby"].ToString());

            if (items.Count ==0)
            {
                this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "noRecordsMsg").ToString();
                this.GVList.Visible = false;
            }
            else
            {
                this.GVList.DataSource = items;
                this.GVList.DataBind();
                this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "total").ToString() +" " + this.GVList.Rows.Count + " " + this.GetGlobalResourceObject("globalResource", "records").ToString();
                if (string.IsNullOrEmpty(productId)==false)
                {
                    this.GVList.Columns[0].Visible = false;
                }
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

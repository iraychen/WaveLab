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
using Spring.Context;
using Spring.Context.Support;
using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class RptMCTCountDtl : CommonPage
    {
        private string materialCode, materialDesc, supplierName;
        private IMCTReportService mctReportService;
        private string  pastComponentDesc, pastHomoMaterialName;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
          
            mctReportService = (IMCTReportService)cxt.GetObject("SV.MCTReportService");


            materialCode = Request.QueryString["materialcode"];
            materialDesc = Request.QueryString["materialdesc"];
            supplierName = Request.QueryString["suppliername"];

            if (!Page.IsPostBack)
            {
                this.lblMaterialCodeVal.Text = materialCode;
                this.lblMaterialDescVal.Text = materialDesc;
                this.lblSupplierNameVal.Text = supplierName;
           
                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"] = "a.component_desc,a.homo_material_name";
                }

                if (ViewState["orderby"] == null)
                {
                    ViewState["orderby"] = "asc";
                }

                BindResult();
            }
        }

        private void BindResult()
        {
            IList<MCTDtlInfo> items=mctReportService.GetMaterialSubstances(materialCode,materialDesc,supplierName,ViewState["sortby"].ToString(),ViewState["orderby"].ToString());
            
            this.GVList.DataSource = items ;
            this.GVList.DataBind();
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                if (string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "ComponentDesc").ToString(), pastComponentDesc) == true)
                {
                    e.Row.Cells[0].Text = "";
                }

                if ( string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "ComponentDesc").ToString(), pastComponentDesc) == true &&
                    string.Equals(DataBinder.GetPropertyValue(e.Row.DataItem, "HomoMaterialName").ToString(), pastHomoMaterialName) == true)
                {
                    e.Row.Cells[1].Text = "";
                }
                pastComponentDesc = DataBinder.GetPropertyValue(e.Row.DataItem, "ComponentDesc").ToString();
                pastHomoMaterialName = DataBinder.GetPropertyValue(e.Row.DataItem, "HomoMaterialName").ToString();
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

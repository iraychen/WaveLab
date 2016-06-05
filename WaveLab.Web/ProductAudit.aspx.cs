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
    public partial class ProductAudit : CommonPage
    {
        private int productId;
        private ProductInfo entity;
        private IProductService service;
        private IProductAuditService productAuditService;
        private bool showMCT=false;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            service = (IProductService)cxt.GetObject("SV.ProductService");
            productAuditService = (IProductAuditService)cxt.GetObject("SV.ProductAuditService");

            if (string.IsNullOrEmpty(Request.QueryString["productid"]) == false)
            {
                productId = int.Parse(Request.QueryString["productid"]);
                entity = service.GetDetail(productId);
            }

            if (!Page.IsPostBack)
            {
                this.lblProductDesc.Text = entity.ProductDesc;
                if (entity.Audited == 'Y')
                {
                    this.rblAudited.SelectedValue = "Y";
                }
                else
                {
                    this.rblAudited.SelectedValue = "N";
                }
                ViewState["sortby"] = "k.material_code,k.material_desc,k.supplier_name,k.supplied ";
                ViewState["orderby"] = "asc";
               
                BindResult();
            }
        }

        private void BindResult()
        {
            string status = this.rblFilter.SelectedValue.Trim();

            IList<ProductAuditInfo> items = service.GetSuppliedMCTItems(productId,status, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                //this.rblFilter.Visible = false;
                this.GVList.Visible = false;
                this.lblAudited.Visible = false;
                this.rblAudited.Visible = false;
                this.btnSave.Visible = false;
                this.btnReset.Visible = false;
                this.btnExportExcel.Enabled = false;
                this.lblRecCount.Text = this.GetLocalResourceObject("lblRecCountResource1.Text").ToString();
            }
            else
            {
                //this.rblFilter.Visible = true;
                this.GVList.Visible = true;
                this.lblAudited.Visible = true;
                this.rblAudited.Visible = true;
                this.btnSave.Visible = true;
                this.btnReset.Visible = true; ;
                this.btnExportExcel.Enabled = true;
                //this.PagerNavigator.Visible = true;
                //this.PagerNavigator.RecordCount = items.Count;

                this.GVList.DataSource = items;
                this.GVList.DataBind();

                if (showMCT == true )
                {
                    this.GVList.Columns[4].Visible = true;
                }

                this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "total").ToString() + this.GVList.Rows.Count + " " + this.GetGlobalResourceObject("globalResource", "records").ToString();

            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbtMCTView = (LinkButton)e.Row.FindControl("lbtMCTView");
                char supplied;
                supplied = Convert.ToChar(DataBinder.Eval(e.Row.DataItem, "Supplied"));
                if (supplied == 'Y')
                {
                    if (showMCT == false)
                    {
                        showMCT = true;
                    }
                    lbtMCTView.Attributes.Add("onclick", "return makeWindow('MCT','" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MctId")) + "')");
                }
                else
                {
                    lbtMCTView.Visible = false;
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

        protected void rblFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindResult();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            if (this.rblAudited.SelectedValue.Trim() == "Y")
            {
                entity.Audited = 'Y';
            }
            else
            {
                entity.Audited = 'N';
            }
            try
            {
                service.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');goBack();</script>");
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            IList<ProductAuditInfo> items = service.GetSuppliedMCTItems(productId, this.rblFilter.SelectedValue.Trim(), ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            IList<DictionaryEntry> paras = new List<DictionaryEntry>();
            paras.Add(new DictionaryEntry(this.lblProduct.Text, this.lblProductDesc.Text));
           // paras.Add(new DictionaryEntry(this.rblFilter.SelectedValue.Trim(), this.rblFilter.SelectedItem.Text));
            //Report Header
            ArrayList headerArray = new ArrayList();
            headerArray.Add(this.GetLocalResourceObject("BoundFieldResource1.HeaderText"));
            headerArray.Add(this.GetLocalResourceObject("BoundFieldResource2.HeaderText"));
            headerArray.Add(this.GetLocalResourceObject("BoundFieldResource3.HeaderText"));
            headerArray.Add(this.GetLocalResourceObject("BoundFieldResource4.HeaderText"));

            MemoryStream ms = productAuditService.ExportProductAudit(this.GetLocalResourceObject("ExcelExportTitle").ToString(), paras, headerArray, items);
            Response.ClearHeaders();
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
            Response.ContentType = "application/octet-stream";
            Response.Flush();
            Response.BinaryWrite(ms.GetBuffer());   
        }
    }
}

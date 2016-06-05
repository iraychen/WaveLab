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
    public partial class SMTDocumentCtl : CommonPage
    {
       private Hashtable hashTable = new Hashtable();
       private ISMTDocumentService documentService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            documentService = (ISMTDocumentService)cxt.GetObject("SV.SMTDocumentService");

            if (!Page.IsPostBack)
            {

                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"] = "documentno";
                }

                if (ViewState["orderby"] == null)
                {
                    ViewState["orderby"] = "asc";
                }
                BindResult();
            }
        }

        private void GetSearchCriteria()
        {
            if (this.tbxDocumentNo.Text.Trim().Length > 0)
            {
                hashTable.Add("documentno", this.tbxDocumentNo.Text.Trim());
            }
            if (this.tbxVersion.Text.Trim().Length > 0)
            {
                hashTable.Add("version", this.tbxVersion.Text.Trim());
            }
        }

        private void BindResult()
        {
            GetSearchCriteria();
            IList<SMTDocumentInfo> items = documentService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
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
               
                var pageItems =
              (
                from item in items
                select item
              ).Skip(this.PagerNavigator.PageSize * (this.PagerNavigator.CurrentPageIndex - 1)).Take(this.PagerNavigator.PageSize);

                this.GVList.DataSource = pageItems;
                this.GVList.DataBind();
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                Label lblVersion = (Label)e.Row.FindControl("lblVersion");

               lblVersion.Text =Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Version"));
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

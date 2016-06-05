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
    public partial class MCTCtl : CommonPage
    {
        private Hashtable hashTable = new Hashtable();
        private IMCTService mctService;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            mctService = (IMCTService)cxt.GetObject("SV.MCTService");

            if (!Page.IsPostBack)
            {
                LoadCriteria();

                BindResult();
            }
        }

        private void LoadCriteria()
        {
            if (string.IsNullOrEmpty(Request.QueryString["suplier_name"]) == false)
            {
                this.tbxSupplierName.Text = Request.QueryString["suplier_name"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["creation_date"]) == false)
            {
                this.tbxCreationDate.Text = Request.QueryString["creation_date"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["part_no"]) == false)
            {
                this.tbxPartNo.Text = Request.QueryString["part_no"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["model"]) == false)
            {
                this.tbxModel.Text = Request.QueryString["model"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["sb"]) == false)
            {
                ViewState["sortby"] = Request.QueryString["sb"].ToString();
            }
            else
            {
                ViewState["sortby"] = "a.creation_date";
            }

            if (string.IsNullOrEmpty(Request.QueryString["ob"]) == false)
            {
                ViewState["orderby"] = Request.QueryString["ob"].ToString();
            }
            else
            {
                ViewState["orderby"] = "desc";
            }
        }

        private void GetSearchCriteria()
        {
            if (this.tbxSupplierName.Text.Trim().Length > 0)
            {
                hashTable.Add("supplier_name", this.tbxSupplierName.Text.Trim());
            }
            if (this.tbxCreationDate.Text.Trim().Length > 0)
            {
                hashTable.Add("creation_date", this.tbxCreationDate.Text.Trim());
            }
            if (this.tbxPartNo.Text.Trim().Length > 0)
            {
                hashTable.Add("part_no", this.tbxPartNo.Text.Trim());
            }
            if (this.tbxModel.Text.Trim().Length > 0)
            {
                hashTable.Add("model", System.Web.HttpUtility.HtmlEncode(this.tbxModel.Text.Trim()));
            }
        }

        private void BindResult()
        {
            GetSearchCriteria();

            IList<MCTQueryInfo> items = mctService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
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

                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                builder.Append("MCTCtl.aspx?1=1");
                foreach (DictionaryEntry item in hashTable)
                {
                    builder.Append("&" + item.Key + "=" + item.Value);
                }
                builder.Append("&sb=" + ViewState["sortby"]);
                builder.Append("&ob=" + ViewState["orderby"]);
                builder.Append("&page=" + this.PagerNavigator.CurrentPageIndex);
                this.hfdCurLink.Value = System.Web.HttpUtility.UrlEncode(builder.ToString());
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

        protected void GVList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int MCTId=int.Parse(this.GVList.DataKeys[e.RowIndex].Values["MCTId"].ToString());
            MCTInfo entity = mctService.GetDetail(MCTId);
            try
            {
                mctService.Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');</script>");
            this.BindResult();
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbtView = (LinkButton)e.Row.Cells[4].FindControl("lbtView");
                LinkButton lbtReplace = (LinkButton)e.Row.Cells[5].FindControl("lbtReplace");
                LinkButton lbtDel= (LinkButton)e.Row.Cells[6].Controls[0];
                lbtView.Attributes.Add("onclick", "return makeWindow('VIEW','" + DataBinder.GetPropertyValue(e.Row.DataItem,"MCTId").ToString() + "')");
                lbtReplace.Attributes.Add("onclick", "return redirect('RP','" + HttpUtility.UrlEncode(DataBinder.GetPropertyValue(e.Row.DataItem, "SupplierName").ToString()) + "','"+
                    DataBinder.GetPropertyValue(e.Row.DataItem, "PartNo").ToString() + "','" + HttpUtility.UrlEncode(DataBinder.GetPropertyValue(e.Row.DataItem, "Model").ToString()) + "')");
                lbtDel.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
            }
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

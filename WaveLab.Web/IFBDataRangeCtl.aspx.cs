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
    public partial class IFBDataRangeCtl : CommonPage
    {
        private IIFBDataRangeService IFBDataRangeService;
        private Hashtable hashTable = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            IFBDataRangeService = (IIFBDataRangeService)cxt.GetObject("SV.IFBDataRangeService");
          
            if (!Page.IsPostBack)
            {
                LoadCriteria();

                BindResult();
            }
        }

        private void LoadCriteria()
        {
            if (string.IsNullOrEmpty(Request.QueryString["DATA"]) == false)
            {
                this.tbxData.Text = Request.QueryString["DATA"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["DESCRIPTION"]) == false)
            {
                this.tbxDescription.Text = Request.QueryString["DESCRIPTION"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["sb"]) == false)
            {
                ViewState["sortby"] = Request.QueryString["sb"].ToString();
            }
            else
            {
                ViewState["sortby"] = "A.DATA";
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

        private void GetParas()
        {           
            if (this.tbxData.Text.Trim().Length > 0)
            {
                hashTable.Add("DATA", this.tbxData.Text.Trim());
            }
            if (this.tbxDescription.Text.Trim().Length > 0)
            {
                hashTable.Add("DESC", this.tbxDescription.Text.Trim());
            }
        }

        private void BindResult()
        {
            GetParas();
            int recCount;
            if (ViewState["recCount"] == null)
            {
                recCount = IFBDataRangeService.Query(hashTable);
                ViewState["recCount"] = recCount;
            }
            else
            {
                recCount = (int)ViewState["recCount"];
            }
            if (recCount == 0)
            {
                this.lblRecCount.Visible = true;
                this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "noRecordsMsg").ToString();
                this.GVList.Visible = false;
                this.PagerNavigator.Visible = false;
            }
            else
            {
                this.lblRecCount.Visible = false;
                this.GVList.Visible = true;
                this.PagerNavigator.Visible = true;

                this.PagerNavigator.RecordCount = recCount;

                if (!Page.IsPostBack && string.IsNullOrEmpty(Request.QueryString["page"]) == false)
                {
                    this.PagerNavigator.CurrentPageIndex = int.Parse(Request.QueryString["page"]);
                }
                IList<IFBDataRangeInfo> items = IFBDataRangeService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString(), this.PagerNavigator.CurrentPageIndex, this.PagerNavigator.PageSize);
                this.GVList.DataSource = items;
                this.GVList.DataBind();
            }

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("IFBDataRangeCtl.aspx?1=1");
            foreach (DictionaryEntry item in hashTable)
            {
                builder.Append("&" + item.Key + "=" + item.Value);
            }
            builder.Append("&sb=" + ViewState["sortby"]);
            builder.Append("&ob=" + ViewState["orderby"]);

            builder.Append("&page=" + this.PagerNavigator.CurrentPageIndex);
            this.hfdCurLink.Value = System.Web.HttpUtility.UrlEncode(builder.ToString());
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                ImageButton ImgBtnEdit = (ImageButton)e.Row.FindControl("ImgBtnEdit");
                ImgBtnEdit.Attributes.Add("onclick", "return makeWindow('EDIT','" +
                    Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Data")) + "','" +
                    HttpUtility.UrlEncode(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Description"))) + "','" +
                    Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Unit")) + "')");

                ImageButton ImgBtnDelete = (ImageButton)e.Row.FindControl("ImgBtnDelete");
                ImgBtnDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
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
            ViewState["recCount"] = null;

            this.PagerNavigator.CurrentPageIndex = 1;
            this.BindResult();
        }

        protected void PagerNavigator_PageChanged(object sender, EventArgs e)
        {
            this.BindResult();
        }

        protected void GVList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Data = this.GVList.DataKeys[e.RowIndex].Values["Data"].ToString();
            try
            {
                IFBDataRangeService.Delete(Data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');</script>");

            ViewState["recCount"] = null;
            this.BindResult();
        }
    }
}

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
    public partial class SPCTxMaskFlatItems : CommonPage
    {
        private ISPCTxMaskFlatItemService SPCTxMaskFlatItemService;
        private ISPCTxMaskFlatService SPCTxMaskFlatService;
        private ISYSSecurityMasterService SYSSecurityMasterService;
      
        private Hashtable hashTable = new Hashtable();
        private bool allowManage;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCTxMaskFlatItemService = (ISPCTxMaskFlatItemService)cxt.GetObject("SV.SPCTxMaskFlatItemService");
            SPCTxMaskFlatService = (ISPCTxMaskFlatService)cxt.GetObject("SV.SPCTxMaskFlatService");
            SYSSecurityMasterService = (ISYSSecurityMasterService)cxt.GetObject("SV.SYSSecurityMasterService");

            allowManage = SYSSecurityMasterService.CheckPerm(Page.User.Identity.Name, "ManageSPC");
            if (!Page.IsPostBack)
            {
                LoadCriteria();
                BindResult();
                this.GVList.Columns[4].Visible = allowManage;
            }
        }

        private void LoadCriteria()
        {
            if (string.IsNullOrEmpty(Request.QueryString["type"]) == false)
            {
                this.tbxType.Text = Request.QueryString["type"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["items"]) == false)
            {
                this.rblItems.SelectedValue = Request.QueryString["items"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["sb"]) == false)
            {
                ViewState["sortby"] = Request.QueryString["sb"].ToString();
            }
            else
            {
                ViewState["sortby"] = "type";
            }

            if (string.IsNullOrEmpty(Request.QueryString["ob"]) == false)
            {
                ViewState["orderby"] = Request.QueryString["ob"].ToString();
            }
            else
            {
                ViewState["orderby"] = "asc";
            }
        }

        private void GetParas()
        {
            if (this.tbxType.Text.Trim().Length > 0)
            {
                hashTable.Add("type", this.tbxType.Text.Trim());
            }
            hashTable.Add("items", this.rblItems.SelectedValue);
        }

        private void BindResult()
        {
            GetParas();
            IList<SPCTxMaskFlatItemInfo> items = new List<SPCTxMaskFlatItemInfo>();
            if (this.rblItems.SelectedValue == "00")
            {
                items = SPCTxMaskFlatService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
                this.GVList.Columns[4].Visible = false;
            }
            else
            {
                items=SPCTxMaskFlatItemService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
                this.GVList.Columns[4].Visible = true;
            }

            if (items.Count == 0)
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

            }

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("SPCTxMaskFlatItems.aspx?1=1");
            foreach (DictionaryEntry item in hashTable)
            {
                builder.Append("&" + item.Key + "=" + item.Value);
            }
            builder.Append("&sb=" + ViewState["sortby"]);
            builder.Append("&ob=" + ViewState["orderby"]);
            this.hfdCurLink.Value = System.Web.HttpUtility.UrlEncode(builder.ToString());
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton btnSelect = (LinkButton)e.Row.FindControl("btnSelect");
                btnSelect.Attributes.Add("onclick", "return makeWindow('GROUP','" +
                    Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")) + "','" +
                    Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Mode")) + "','" +
                    Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CH")) + "')");

                if (this.rblItems.SelectedValue == "01")
                {
                    LinkButton lbtEdit = (LinkButton)e.Row.FindControl("lbtEdit");
                    lbtEdit.Attributes.Add("onclick", "return makeWindow('Edit','" +
                        Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "TxMaskFlatItemPK")) + "')");

                    HiddenField TxMaskFlatItemPK = (HiddenField)e.Row.FindControl("TxMaskFlatItemPK");
                    TxMaskFlatItemPK.Value = Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "TxMaskFlatItemPK"));

                    LinkButton lbtDelete = (LinkButton)e.Row.FindControl("lbtDelete");
                    lbtDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ViewState["sortby"] == null)
            {
                ViewState["sortby"] = "d.model";
            }
            if (ViewState["orderby"] == null)
            {
                ViewState["orderby"] = "asc";
            }
            this.PagerNavigator.CurrentPageIndex = 1;
            this.BindResult();
        }

        protected void PagerNavigator_PageChanged(object sender, EventArgs e)
        {
            this.BindResult();
        }

        protected void GVList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HiddenField TxMaskFlatItemPK = (HiddenField)this.GVList.Rows[e.RowIndex].FindControl("TxMaskFlatItemPK");

            SPCTxMaskFlatItemInfo item = SPCTxMaskFlatItemService.Get(int.Parse(TxMaskFlatItemPK.Value));
            try
            {
                SPCTxMaskFlatItemService.Delete(item);
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

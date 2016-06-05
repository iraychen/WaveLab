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
    public partial class SPCStationLineLossItemIndex :  CommonPage
    {
        private ISPCStationLineLossItemService SPCStationLineLossItemService;
        private Hashtable hashTable = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCStationLineLossItemService = (ISPCStationLineLossItemService)cxt.GetObject("SV.SPCStationLineLossItemService");

            if (!Page.IsPostBack)
            {
                LoadCriteria();

                BindResult();
            }
        }

        private void LoadCriteria()
        {
            if (string.IsNullOrEmpty(Request.QueryString["Station_No"]) == false)
            {
                this.tbxStationNo.Text = Request.QueryString["Station_No"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["sb"]) == false)
            {
                ViewState["sortby"] = Request.QueryString["sb"].ToString();
            }
            else
            {
                ViewState["sortby"] = "Station_No";
            }

            if (string.IsNullOrEmpty(Request.QueryString["ob"]) == false)
            {
                ViewState["orderby"] = Request.QueryString["ob"].ToString();
            }
            else
            {
                ViewState["orderby"] = "Asc";
            }
        }

        private void GetParas()
        {
            if (this.tbxStationNo.Text.Trim().Length > 0)
            {
                hashTable.Add("Station_No", this.tbxStationNo.Text.Trim());
            }
            if (this.tbxCHNo.Text.Trim().Length > 0)
            {
                hashTable.Add("CH_No", this.tbxCHNo.Text.Trim());
            }
            if (this.tbxFrequencyBand.Text.Trim().Length > 0)
            {
                hashTable.Add("Frequency_Band", this.tbxFrequencyBand.Text.Trim());
            }
            if (this.tbxItem.Text.Trim().Length > 0)
            {
                hashTable.Add("Item", this.tbxItem.Text.Trim());
            }  
        }

        private void BindResult()
        {
            GetParas();
            IList<SPCStationLineLossItemInfo> items = SPCStationLineLossItemService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());           
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
            builder.Append("SPCStationLineLossItemIndex.aspx?1=1");
            foreach (DictionaryEntry item in hashTable)
            {
                builder.Append("&" + item.Key + "=" + item.Value);
            }
            builder.Append("&sb=" + ViewState["sortby"]);
            builder.Append("&ob=" + ViewState["orderby"]);           
            this.hfdCurLink.Value = System.Web.HttpUtility.UrlEncode(builder.ToString());
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


        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbtLineLossInput = (LinkButton)e.Row.FindControl("lbtLineLossInput");
                lbtLineLossInput.Attributes.Add("onclick", "return makeWindow('LineLossInput','" +
                    Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "LineLossItemPK")) + "')");

                LinkButton lbtLineLossSPC = (LinkButton)e.Row.FindControl("lbtLineLossSPC");
           
                lbtLineLossSPC.Attributes.Add("onclick", "return makeWindow('LineLossSPC','" +
                   Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "LineLossItemPK")) + "')");

                LinkButton lbtEdit = (LinkButton)e.Row.FindControl("lbtEdit");
                lbtEdit.Attributes.Add("onclick", "return makeWindow('Edit','" +
                    Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "LineLossItemPK")) + "')");

                LinkButton lbtDelete = (LinkButton)e.Row.FindControl("lbtDelete");
                lbtDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
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
            int LineLossItemPK = int.Parse(this.GVList.DataKeys[e.RowIndex].Values["LineLossItemPK"].ToString());
            SPCStationLineLossItemInfo entity = SPCStationLineLossItemService.Get(LineLossItemPK);
            try
            {
                SPCStationLineLossItemService.Delete(entity);
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

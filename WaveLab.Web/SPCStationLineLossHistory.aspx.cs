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
    public partial class SPCStationLineLossHistory : CommonPage
    {
        private ISPCStationLineLossService SPCStationLineLossService;

        private Hashtable hashTable = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCStationLineLossService = (ISPCStationLineLossService)cxt.GetObject("SV.SPCStationLineLossService");

            if (!Page.IsPostBack)
            {

                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"] = "a.Date_To";
                }

                if (ViewState["orderby"] == null)
                {
                    ViewState["orderby"] = "Desc";
                }
                BindResult();
            }
        }

        private void GetParas()
        {
            if (this.tbxStationNo.Text.Trim().Length > 0) { hashTable.Add("Station_No", this.tbxStationNo.Text.Trim()); }
            if (this.tbxCHNo.Text.Trim().Length > 0) { hashTable.Add("CH_No", this.tbxCHNo.Text.Trim()); }
            if (this.tbxFrequencyBand.Text.Trim().Length > 0) { hashTable.Add("Frequency_Band", this.tbxFrequencyBand.Text.Trim()); }
            if (this.tbxItem.Text.Trim().Length > 0) { hashTable.Add("Item", this.tbxItem.Text.Trim()); }
            if (this.tbxDateFrom.Text.Trim().Length > 0) { hashTable.Add("Date_From", this.tbxDateFrom.Text.Trim()); }
            if (this.tbxDateTo.Text.Trim().Length > 0) { hashTable.Add("Date_To", this.tbxDateTo.Text.Trim()); }
        }

        private void BindResult()
        {
            GetParas();
            int recCount;
            if (ViewState["recCount"] == null)
            {
                recCount = SPCStationLineLossService.QueryHistory(hashTable);
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
                IList<SPCStationLineLossInfo> items = SPCStationLineLossService.QueryHistory(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString(), this.PagerNavigator.CurrentPageIndex, this.PagerNavigator.PageSize);
                this.GVList.DataSource = items;
                this.GVList.DataBind();
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbtView = (LinkButton)e.Row.FindControl("lbtView");
                lbtView.Attributes.Add("onclick", "return makeWindow('VIEW','" +
                    Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LineLossPK")) + "')");
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ViewState["recCount"] = null;

            this.PagerNavigator.CurrentPageIndex = 1;
            this.BindResult();

        }

        protected void PagerNavigator_PageChanged(object sender, EventArgs e)
        {
            this.BindResult();
        }

    }
}

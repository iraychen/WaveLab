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
    public partial class SPCFixtureReturnLossHistory : CommonPage
    {
        private ISPCFixtureReturnLossService SPCFixtureReturnLossService;
        private ISPCFixtureInsertionLossService SPCFixtureInsertionLossService;
        private Hashtable hashTable = new Hashtable();
        private string type;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCFixtureReturnLossService = (ISPCFixtureReturnLossService)cxt.GetObject("SV.SPCFixtureReturnLossService");
            SPCFixtureInsertionLossService = (ISPCFixtureInsertionLossService)cxt.GetObject("SV.SPCFixtureInsertionLossService");
          
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
            type = this.rblType.SelectedValue;
            if (this.tbxFixture.Text.Trim().Length > 0) { hashTable.Add("Fixture", this.tbxFixture.Text.Trim()); }
            if (this.tbxCH.Text.Trim().Length > 0) { hashTable.Add("CH", this.tbxCH.Text.Trim()); }
            if (this.tbxFrequencyBand.Text.Trim().Length > 0) { hashTable.Add("Frequency_Band", this.tbxFrequencyBand.Text.Trim()); }
            if (this.tbxDateFrom.Text.Trim().Length > 0) { hashTable.Add("Date_From", this.tbxDateFrom.Text.Trim()); }
            if (this.tbxDateTo.Text.Trim().Length > 0) { hashTable.Add("Date_To", this.tbxDateTo.Text.Trim()); }
        }

        private void BindResult()
        {
            GetParas();
            int recCount=0;
            if (ViewState["recCount"] == null)
            {
                if (type == "01")
                {
                    recCount = SPCFixtureReturnLossService.QueryHistory(hashTable);
                }
                else if(type=="02")
                {
                    recCount = SPCFixtureInsertionLossService.QueryHistory(hashTable);
                }
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
                if (type == "01")
                {
                    IList<SPCFixtureReturnLossInfo> items = SPCFixtureReturnLossService.QueryHistory(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString(), this.PagerNavigator.CurrentPageIndex, this.PagerNavigator.PageSize);
                    this.GVList.DataSource = items;
                    this.GVList.DataBind();
                }
                else if (type == "02")
                {
                    IList<SPCFixtureInsertionLossInfo> items = SPCFixtureInsertionLossService.QueryHistory(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString(), this.PagerNavigator.CurrentPageIndex, this.PagerNavigator.PageSize);
                    this.GVList.DataSource = items;
                    this.GVList.DataBind();
                } 
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbtView = (LinkButton)e.Row.FindControl("lbtView");
                if (type == "01")
                {
                    lbtView.Attributes.Add("onclick", "return makeWindow('ReturnLossView','" +
                    Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ReturnLossPK")) + "')");
                }
                else if (type == "02")
                {
                    lbtView.Attributes.Add("onclick", "return makeWindow('InsertionLossView','" +
                   Convert.ToString(DataBinder.Eval(e.Row.DataItem, "InsertionLossPK")) + "')");
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

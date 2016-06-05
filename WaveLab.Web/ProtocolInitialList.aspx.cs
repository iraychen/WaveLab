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
    public partial class ProtocolInitialList : CommonPage
    {
        private IProtocolInitService ProtocolInitService;
        private Hashtable hashTable = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            ProtocolInitService = (IProtocolInitService)cxt.GetObject("SV.ProtocolInitService");
            if (!Page.IsPostBack)
            {
                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"] = "a.end_time";
                }

                if (ViewState["orderby"] == null)
                {
                    ViewState["orderby"] = "desc";
                }
                BindResult();
            }
        }

        private void GetParas()
        {
            if (this.tbxModel.Text.Trim().Length > 0)
            {
                hashTable.Add("model", this.tbxModel.Text.Trim());
            }
          
            if (this.tbxSerialNo.Text.Trim().Length > 0)
            {
                hashTable.Add("serial_no", this.tbxSerialNo.Text.Trim());
            }
            if (this.tbxDateFrom.Text.Trim().Length > 0)
            {
                hashTable.Add("date_from", this.tbxDateFrom.Text.Trim());
            }
            if (this.tbxDateTo.Text.Trim().Length > 0)
            {
                hashTable.Add("date_to", this.tbxDateTo.Text.Trim());
            }
        }

        private void BindResult()
        {
            GetParas();
            int recCount;
            if (ViewState["recCount"] == null)
            {
                recCount = ProtocolInitService.Query(hashTable);
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
                IList<ProtocolInitInfo> items = ProtocolInitService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString(), this.PagerNavigator.CurrentPageIndex, this.PagerNavigator.PageSize);
                this.GVList.DataSource = items;
                this.GVList.DataBind();
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbtSerialNo = (LinkButton)e.Row.FindControl("lbtSerialNo");
                lbtSerialNo.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SerialNo"));
                lbtSerialNo.Attributes.Add("onclick", "return makeWindow('VIEW','" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ProtocolInitId")) + "')");

                Label lblFinalFlag = (Label)e.Row.FindControl("lblFinalFlag");
                if (Convert.ToChar(DataBinder.Eval(e.Row.DataItem, "FinalFlag")) == 'P')
                {
                    lblFinalFlag.Text = "<font color='green'>PASS</font>";
                }
                else if (Convert.ToChar(DataBinder.Eval(e.Row.DataItem, "FinalFlag")) == 'F')
                {
                    lblFinalFlag.Text = "<font color='red'>FAIL</font>";
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

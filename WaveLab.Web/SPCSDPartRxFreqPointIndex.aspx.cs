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
    public partial class SPCSDPartRxFreqPointIndex : CommonPage
    {
        private ISPCSDPartRxFreqPointService SPCSDPartRxFreqPointService;
        private Hashtable hashTable = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCSDPartRxFreqPointService = (ISPCSDPartRxFreqPointService)cxt.GetObject("SV.SPCSDPartRxFreqPointService");

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
            if (string.IsNullOrEmpty(Request.QueryString["Divde"]) == false)
            {
                this.chxDivide.Checked = Request.QueryString["Divde"]=="Y"?true:false;             
            }
            if (string.IsNullOrEmpty(Request.QueryString["CH"]) == false)
            {
                this.tbxCH.Text = Request.QueryString["CH"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["Serial_No"]) == false)
            {
                this.tbxSerialNo.Text = Request.QueryString["Serial_No"].ToString();
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

            hashTable.Add("Divide", this.chxDivide.Checked == true ? "Y" : "N");
            this.GVList.Columns[1].Visible = this.chxDivide.Checked;

            if (this.tbxCH.Text.Trim().Length > 0)
            {
                hashTable.Add("CH", this.tbxCH.Text.Trim());
            }

            if (this.tbxSerialNo.Text.Trim().Length > 0)
            {
                hashTable.Add("Serial_No", this.tbxSerialNo.Text.Trim());
            }
        }

        private void BindResult()
        {
          
            GetParas();
            int recCount=0;
            if (ViewState["recCount"] == null)
            {
                recCount = SPCSDPartRxFreqPointService.GetSDParts(hashTable);
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
                IList<SPCSDPartRxFreqPointInfo> items = SPCSDPartRxFreqPointService.GetSDParts(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString(), this.PagerNavigator.CurrentPageIndex, this.PagerNavigator.PageSize);
                this.GVList.DataSource = items;
                this.GVList.DataBind();

             
              
            }

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("SPCSDPartRxFreqPointIndex.aspx?1=1");
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
                LinkButton lbtEdit = (LinkButton)e.Row.FindControl("lbtEdit");
                lbtEdit.Attributes.Add("onclick", "return makeWindow('Edit','" +
                    Convert.ToString(DataBinder.GetPropertyValue(e.Row.DataItem, "SDPartPK")) + "')");

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
            int SDPartPK = int.Parse(this.GVList.DataKeys[e.RowIndex].Values["SDPartPK"].ToString());
            SPCSDPartRxFreqPointInfo entity = SPCSDPartRxFreqPointService.Get(SDPartPK);
            try
            {
                SPCSDPartRxFreqPointService.Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');</script>");

            ViewState["recCount"] = null;
            this.BindResult();
        }

        protected void PagerNavigator_PageChanged(object sender, EventArgs e)
        {
            this.BindResult();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["recCount"] = null;

            this.PagerNavigator.CurrentPageIndex = 1;
            this.BindResult();
        }
    }
}

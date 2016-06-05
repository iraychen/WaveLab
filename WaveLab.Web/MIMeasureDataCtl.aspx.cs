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
    public partial class MIMeasureDataCtl : CommonPage
    {
        private IMIMeasureDataService MIMeasureDataService;
        private Hashtable hashTable = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            MIMeasureDataService = (IMIMeasureDataService)cxt.GetObject("SV.MIMeasureDataService");

            if (!Page.IsPostBack)
            {
                LoadCriteria();

                BindResult();
            }
        }

        private void LoadCriteria()
        {
            if (string.IsNullOrEmpty(Request.QueryString["order_no"]) == false)
            {
                this.tbxOrderNo.Text = Request.QueryString["order_no"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["model"]) == false)
            {
                this.tbxModel.Text = Request.QueryString["model"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["code"]) == false)
            {
                this.tbxCode.Text = Request.QueryString["code"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["serial_no"]) == false)
            {
                this.tbxSerialNo.Text = Request.QueryString["serial_no"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["date_from"]) == false)
            {
                this.tbxDateFrom.Text = Request.QueryString["date_from"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["date_to"]) == false)
            {
                this.tbxDateTo.Text = Request.QueryString["date_to"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["sb"]) == false)
            {
                ViewState["sortby"] = Request.QueryString["sb"].ToString();
            }
            else
            {
                ViewState["sortby"] = "a.last_update_date";
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
            if (this.tbxOrderNo.Text.Trim().Length > 0)
            {
                hashTable.Add("order_no", this.tbxOrderNo.Text.Trim());
            }
            if (this.tbxModel.Text.Trim().Length > 0)
            {
                hashTable.Add("model", this.tbxModel.Text.Trim());
            }
            if (this.tbxCode.Text.Trim().Length > 0)
            {
                hashTable.Add("code", this.tbxCode.Text.Trim());
            }
            if (this.tbxSerialNo.Text.Trim().Length > 0)
            {
                hashTable.Add("serial_no", this.tbxSerialNo.Text.Trim());
            }
        }

        private void BindResult()
        {
            GetParas();
            int recCount;
            if (ViewState["recCount"] == null)
            {
                recCount = MIMeasureDataService.Query(hashTable);
                ViewState["recCount"] = recCount;
            }
            else
            {
                recCount = (int)ViewState["recCount"];
            }
            if(recCount==0)
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
                IList<MIMeasureDataInfo> items = MIMeasureDataService.Query(hashTable, ViewState["sortby"].ToString(),ViewState["orderby"].ToString(), this.PagerNavigator.CurrentPageIndex, this.PagerNavigator.PageSize);
                this.GVList.DataSource = items;
                this.GVList.DataBind();
            }

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("MIMeasureDataCtl.aspx?1=1");
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
                    Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MIMeasureDataId")) + "','"+
                    Convert.ToString(DataBinder.Eval(e.Row.DataItem, "OrderNo"))+"','"+
                    Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Code"))+"','"+
                    Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Model")) + "')");

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
            ViewState["recCount"]=null;

            this.PagerNavigator.CurrentPageIndex = 1;
            this.BindResult();
        }

        protected void PagerNavigator_PageChanged(object sender, EventArgs e)
        {
            this.BindResult();
        }

        protected void GVList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int MIMeasureDataId = int.Parse(this.GVList.DataKeys[e.RowIndex].Values["MIMeasureDataId"].ToString());
            MIMeasureDataInfo entity = MIMeasureDataService.GetDetail(MIMeasureDataId);
            try
            {
                MIMeasureDataService.Delete(entity);
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

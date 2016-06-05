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
    public partial class SMTBomCoorPatternCtl :  CommonPage
    {
        private ISMTBomCoorPatternService SMTBomCoorPatternService;
        private Hashtable hashTable = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SMTBomCoorPatternService = (ISMTBomCoorPatternService)cxt.GetObject("SV.SMTBomCoorPatternService");


            if (!Page.IsPostBack)
            {
                LoadCriteria();
             
                BindResult();
            }
        }

        private void LoadCriteria()
        {
            if (string.IsNullOrEmpty(Request.QueryString["module"]) == false)
            {
                this.tbxModule.Text = Request.QueryString["module"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["bomdn"]) == false)
            {
                this.tbxBomDn.Text = Request.QueryString["bomdn"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["bomdvs"]) == false)
            {
                this.tbxBomDVS.Text = Request.QueryString["bomdvs"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["coorpattern"]) == false)
            {
                this.tbxCoorPattern.Text = Request.QueryString["coorpattern"].ToString();
            }
            if (string.IsNullOrEmpty(Request.QueryString["sb"]) == false)
            {
                ViewState["sortby"] = Request.QueryString["sb"].ToString();
            }
            else
            {
                ViewState["sortby"] = "module";
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

        private void GetSearchCriteria()
        {
            if (this.tbxModule.Text.Trim().Length > 0)
            {
                hashTable.Add("module", this.tbxModule.Text.Trim());
            }
            if (this.tbxBomDn.Text.Trim().Length > 0)
            {
                hashTable.Add("bomdn", this.tbxBomDn.Text.Trim());
            }
            if (this.tbxBomDVS.Text.Trim().Length > 0)
            {
                hashTable.Add("bomdvs", this.tbxBomDVS.Text.Trim());
            }
            if (this.tbxCoorPattern.Text.Trim().Length > 0)
            {
                hashTable.Add("coorpattern", this.tbxCoorPattern.Text.Trim());
            }
        }

        private void BindResult()
        {
            GetSearchCriteria();
            IList<SMTBomCoorPatternInfo> items = SMTBomCoorPatternService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
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
            builder.Append("SMTBomCoorPatternCtl.aspx?1=1");
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
                LinkButton lbtEdit = (LinkButton)e.Row.FindControl("lbtEdit");
                lbtEdit.Attributes.Add("onclick", "return makeWindow('EDIT','" + System.Web.HttpUtility.UrlEncode(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "module"))) +
                    "','" + System.Web.HttpUtility.UrlEncode(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "bomdn"))) +
                   "','" + System.Web.HttpUtility.UrlEncode(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "bomdvs"))) + "')");
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

        protected void lbtImport_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMTBomCoorPatternImport.aspx");
        }
    }
}

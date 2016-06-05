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

using WaveLab.Model;
using WaveLab.IService;

using Spring.Context;
using Spring.Context.Support;

namespace WaveLab.Web
{
    public partial class SYSModuleTypectl : CommonPage
    {
        private Hashtable hashTable = new Hashtable();
        private ISYSModuleTypeService SYSModuleTypeService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");

            if (!Page.IsPostBack)
            {
                LoadCriteria();
                BindResult();
            }
        }

        private void LoadCriteria()
        {
            if (string.IsNullOrEmpty(Request.QueryString["module_type_id"]) == false)
            {
                this.tbxSYSModuleType.Text = Request.QueryString["module_type_id"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["module_type_desc"]) == false)
            {
                this.tbxModuleTypeDesc.Text = Request.QueryString["module_type_desc"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["sb"]) == false)
            {
                ViewState["sortby"] = Request.QueryString["sb"].ToString();
            }
            else
            {
                ViewState["sortby"] = "module_type_id";
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
            if (this.tbxSYSModuleType.Text.Trim().Length > 0)
            {
                hashTable.Add("module_type_id", this.tbxSYSModuleType.Text.Trim());
            }

            if (this.tbxModuleTypeDesc.Text.Trim().Length > 0)
            {
                hashTable.Add("module_type_desc", this.tbxModuleTypeDesc.Text.Trim());
            }
        }

        private void BindResult()
        {
            GetSearchCriteria();
            IList<SYSModuleTypeInfo> items = SYSModuleTypeService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());

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

                var pageItems =
                (
                  from item in items
                  select item
                ).Skip(this.PagerNavigator.PageSize * (this.PagerNavigator.CurrentPageIndex - 1)).Take(this.PagerNavigator.PageSize);

                this.GVList.DataSource = pageItems;
                this.GVList.DataBind();

                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                builder.Append("SYSModuleTypeCtl.aspx?1=1");
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

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbtEdit = (LinkButton)e.Row.FindControl("lbtEdit");
                lbtEdit.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ModuleTypeId"));
                lbtEdit.Attributes.Add("onclick", "return makeWindow('EDIT','" + System.Web.HttpUtility.UrlEncode(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ModuleTypeId"))) + "')");
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
    }
}

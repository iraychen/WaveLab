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
using WaveLab.Model;
using WaveLab.IService;
using System.Collections.Generic;
using Spring.Context;
using Spring.Context.Support;
namespace WaveLab.Web
{
    public partial class SYSRoleCtl : CommonPage
    {
        private ISYSRoleService roleService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            roleService = (ISYSRoleService)cxt.GetObject("SV.SYSRoleService");
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["sb"]) == false)
                {
                    ViewState["sortby"] = Request.QueryString["sb"].ToString();
                }
                else
                {
                    ViewState["sortby"] = "role_desc";
                }

                if (string.IsNullOrEmpty(Request.QueryString["ob"]) == false)
                {
                    ViewState["orderby"] = Request.QueryString["ob"].ToString();
                }
                else
                {
                    ViewState["orderby"] = "asc";
                }
                BindResult();
            }
        }

        private void BindResult()
        {
            IList<SYSRoleInfo> items = roleService.Query(ViewState["sortby"].ToString(), ViewState["orderby"].ToString());

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
            builder.Append("SYSRoleCtl.aspx?1=1");
            builder.Append("&sb=" + ViewState["sortby"]);
            builder.Append("&ob=" + ViewState["orderby"]);
            builder.Append("&page=" + this.PagerNavigator.CurrentPageIndex);
            this.hfdCurLink.Value = System.Web.HttpUtility.UrlEncode(builder.ToString());
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbtRole = (LinkButton)e.Row.FindControl("lbtRole");
                LinkButton lbtAC = (LinkButton)e.Row.FindControl("lbtAC");
                LinkButton lbtActionAC = (LinkButton)e.Row.FindControl("lbtActionAC");
                lbtRole.Attributes.Add("onclick", "return makeWindow('EDIT','" + DataBinder.Eval(e.Row.DataItem, "RoleId") + "')");
                lbtAC.Attributes.Add("onclick", "return makeWindow('AC','" + DataBinder.Eval(e.Row.DataItem, "RoleId") + "')");
                lbtActionAC.Attributes.Add("onclick", "return makeWindow('ACTION','" + DataBinder.Eval(e.Row.DataItem, "RoleId") + "')");
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

        protected void PagerNavigator_PageChanged(object sender, EventArgs e)
        {
            this.BindResult();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {          
            this.PagerNavigator.CurrentPageIndex = 1;
            this.BindResult();
        }
    }
}

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
    public partial class SYSsecurityMasterCtl : CommonPage
    {
        private Hashtable hashTable = new Hashtable();
        private ISYSSecurityMasterService SecurityMasterService;
        private IItemService itemService;
        private ISYSSectionService sectionService;
        private ISYSRoleService roleService ;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SecurityMasterService = (ISYSSecurityMasterService)cxt.GetObject("SV.SYSSecurityMasterService");
            itemService = (IItemService)cxt.GetObject("SV.ItemService");
            sectionService = (ISYSSectionService)cxt.GetObject("SV.SYSSectionService");
            roleService = (ISYSRoleService)cxt.GetObject("SV.SYSRoleService");

            if (!Page.IsPostBack)
            {
                LoadCriteria();
                BindResult();
            }
        }

        private void LoadCriteria()
        {

            this.ddlAdmin.DataSource = itemService.GetItems();
            this.ddlAdmin.DataValueField = "itemValue";
            this.ddlAdmin.DataTextField = "itemText";
            this.ddlAdmin.DataBind();
            this.ddlAdmin.Items.Insert(0, new ListItem("", ""));

            this.ddlActive.DataSource = itemService.GetItems();
            this.ddlActive.DataValueField = "itemValue";
            this.ddlActive.DataTextField = "itemText";
            this.ddlActive.DataBind();
            this.ddlActive.Items.Insert(0, new ListItem("", ""));

            this.ddlSection.DataSource = sectionService.GetItems();
            this.ddlSection.DataValueField = "SectionId";
            this.ddlSection.DataTextField = "SectionDesc";
            this.ddlSection.DataBind();
            this.ddlSection.Items.Insert(0, new ListItem("", ""));

            if(string.IsNullOrEmpty(Request.QueryString["user_id"])==false)
            {
                this.tbxUserId.Text = Request.QueryString["user_id"].ToString();
            }

            if(string.IsNullOrEmpty(Request.QueryString["user_name"])==false)
            {
                this.tbxUserName.Text=Request.QueryString["user_name"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["admin"]) == false)
            {
                this.ddlAdmin.SelectedValue = Request.QueryString["admin"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["active"]) == false)
            {
                this.ddlActive.SelectedValue = Request.QueryString["active"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["section_id"]) == false)
            {
                this.ddlSection.SelectedValue = Request.QueryString["section_id"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["sb"]) == false)
            {
                ViewState["sortby"] = Request.QueryString["sb"].ToString();
            }
            else
            {
                ViewState["sortby"] = "user_id";
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
            if (this.tbxUserId.Text.Trim().Length > 0)
            {
                hashTable.Add("user_id", this.tbxUserId.Text.Trim());
            }
            if (this.tbxUserName.Text.Trim().Length > 0)
            {
                hashTable.Add("user_name", this.tbxUserName.Text.Trim());
            }
            if (this.ddlAdmin.SelectedValue.Trim().Length > 0)
            {
                hashTable.Add("admin", this.ddlAdmin.SelectedValue.Trim());
            }
            if (this.ddlActive.SelectedValue.Trim().Length > 0)
            {
                hashTable.Add("active", this.ddlActive.SelectedValue.Trim());
            }
            if (this.ddlSection.SelectedValue.Trim().Length > 0)
            {
                hashTable.Add("section_id", this.ddlSection.SelectedValue.Trim());
            }
        }

        private void BindResult()
        {
             GetSearchCriteria();

             IList<SYSSecurityMasterInfo> items = SecurityMasterService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
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
            builder.Append("SYSSecurityMasterCtl.aspx?1=1");
            foreach (DictionaryEntry item in hashTable)
            {
                builder.Append("&" + item.Key + "=" + item.Value);
            }
            builder.Append("&sb=" + ViewState["sortby"]);
            builder.Append("&ob=" + ViewState["orderby"]);
            builder.Append("&page=" + this.PagerNavigator.CurrentPageIndex);
            this.hfdCurLink.Value = System.Web.HttpUtility.UrlEncode(builder.ToString());
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

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                LinkButton lbtEdit = (LinkButton)e.Row.FindControl("lbtEdit");
                LinkButton lbtRA = (LinkButton)e.Row.FindControl("lbtRA");
                lbtEdit.Attributes.Add("onclick", "return makeWindow('EDIT','" + System.Web.HttpUtility.UrlEncode(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserId"))) +"')");
                lbtRA.Attributes.Add("onclick", "return makeWindow('RA','" + System.Web.HttpUtility.UrlEncode(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserId"))) + "')");
                if (DataBinder.Eval(e.Row.DataItem, "sectionItem") != null)
                {
                    e.Row.Cells[4].Text = ((SYSSectionInfo)DataBinder.Eval(e.Row.DataItem, "sectionItem")).SectionDesc;
                }
            }
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

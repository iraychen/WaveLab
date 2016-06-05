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
    public partial class SMTFileInduceCtl : CommonPage
    {
        private Hashtable hashTable = new Hashtable();
       private ISMTFileInduceService SMTFileInduceService;
       private ISYSModuleTypeService SYSModuleTypeService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");
            SMTFileInduceService = (ISMTFileInduceService)cxt.GetObject("SV.SMTFileInduceService");
          
            if (!Page.IsPostBack)
            {
                LoadCriteria();
                BindResult();
            }
        }

        private void LoadCriteria()
        {
           
            this.ddlSYSModuleType.DataSource = SYSModuleTypeService.GetItems();
            this.ddlSYSModuleType.DataValueField = "ModuleTypeId";
            this.ddlSYSModuleType.DataTextField = "ModuleTypeDesc";
            this.ddlSYSModuleType.DataBind();
            this.ddlSYSModuleType.Items.Insert(0, new ListItem("", ""));

            if (string.IsNullOrEmpty(Request.QueryString["module_type_id"]) == false)
            {
                this.ddlSYSModuleType.SelectedValue = Request.QueryString["module_type_id"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["material_code"]) == false)
            {
                this.tbxMaterialCode.Text = Request.QueryString["material_code"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["material_desc"]) == false)
            {
                this.tbxMaterialDesc.Text = Request.QueryString["material_desc"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["pcb"]) == false)
            {
                this.tbxPCB.Text= Request.QueryString["pcb"].ToString();
            }

            if (string.IsNullOrEmpty(Request.QueryString["sb"]) == false)
            {
                ViewState["sortby"] = Request.QueryString["sb"].ToString();
            }
            else
            {
                ViewState["sortby"] = "module_type_desc";
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
            if (this.ddlSYSModuleType.SelectedValue.Trim().Length > 0)
            {
                hashTable.Add("module_type_id", this.ddlSYSModuleType.SelectedValue.Trim());
            }
            if (this.tbxMaterialCode.Text.Trim().Length > 0)
            {
                hashTable.Add("material_code", this.tbxMaterialCode.Text.Trim());
            }

            if (this.tbxMaterialDesc.Text.Trim().Length > 0)
            {
                hashTable.Add("material_desc", this.tbxMaterialDesc.Text.Trim());
            }

            if (this.tbxPCB.Text.Trim().Length > 0)
            {
                hashTable.Add("pcb", this.tbxPCB.Text.Trim());
            }
        }

        private void BindResult()
        {
            GetSearchCriteria();
            IList<SMTFileInduceInfo> items = SMTFileInduceService.Query(hashTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
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
                this.PagerNavigator.RecordCount = items.Count ;
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
                this.GVList.HeaderRow.TableSection = TableRowSection.TableHeader;  

            }

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("SMTFileInduceCtl.aspx?1=1");
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
                lbtEdit.Attributes.Add("onclick", "return redirect('EDIT','" + System.Web.HttpUtility.UrlEncode(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MaterialCode"))) +
                   "','" + System.Web.HttpUtility.UrlEncode(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MaterialDesc"))) +
                   "','" + System.Web.HttpUtility.UrlEncode(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PCB"))) + "')");
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

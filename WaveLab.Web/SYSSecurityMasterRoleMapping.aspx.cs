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
    public partial class SYSSecurityMasterRoleMapping : CommonPage
    {
        private string userId;
        private IList<SYSRoleInfo> masterRoleItems;
        private ISYSSecurityMasterService SecurityMasterService;
        private ISYSRoleService roleService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SecurityMasterService = (ISYSSecurityMasterService)cxt.GetObject("SV.SYSSecurityMasterService");
            roleService = (ISYSRoleService)cxt.GetObject("SV.SYSRoleService");

            userId = Request.QueryString["userid"];
            
            if (!Page.IsPostBack)
            {
                this.lblUserIdVal.Text = userId;
                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"] = "role_desc";
                }

                if (ViewState["orderby"] == null)
                {
                    ViewState["orderby"] = "asc";
                }
                BindResult();
            }
        }

        private void BindResult()
        {
            masterRoleItems = SecurityMasterService.GetRoles(userId);
            IList<SYSRoleInfo> items = roleService.Query(ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.GVList.Visible = false;
            }
            else
            {
                this.lblRecCount.Visible = false;
                this.GVList.Visible = true;


                this.GVList.DataSource = items;
                this.GVList.DataBind();
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                CheckBox cbxRole = (CheckBox)e.Row.FindControl("check");
                int count = (from roleItem in masterRoleItems
                           where roleItem.RoleId == Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "RoleId"))
                           select roleItem).Count<SYSRoleInfo>();
                if (count> 0)
                {
                    cbxRole.Checked = true;
                }
                else
                {
                    cbxRole.Checked = false;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            IList<SYSRoleInfo> roleItems = new List<SYSRoleInfo>();
            for (int i = 0; i < this.GVList.Rows.Count; i++)
            {
                CheckBox cbx = (CheckBox)this.GVList.Rows[i].FindControl("check");
                if (cbx.Checked == true)
                {
                   SYSRoleInfo item=new SYSRoleInfo()
                   {
                       RoleId=Convert.ToInt32(this.GVList.DataKeys[i].Values["RoleId"]),
                       LastUpdateDate =DateTime.Now,
                       LastUpdatedBy =Page.User.Identity.Name,
                       CreationDate =DateTime.Now,
                       CreatedBy =Page.User.Identity.Name
                   };
                   roleItems.Add(item);
                }
            }
            try
            {
                SecurityMasterService.SaveRoleMapping(userId, roleItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');refresh();</script>");
        }
    }
}

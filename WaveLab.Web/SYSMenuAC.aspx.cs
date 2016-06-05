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

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;
using System.Collections.Generic;

namespace WaveLab.Web
{
    public partial class SYSMenuAC : CommonPage 
    {
        private int menuId;
        private IList<SYSRoleInfo> menuRoleItems;
        private ISYSMenuService menuService;
        private ISYSRoleService roleService;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            roleService = (ISYSRoleService)cxt.GetObject("SV.SYSRoleService");
            menuService = (ISYSMenuService)cxt.GetObject("SV.SYSMenuService");

            menuId = int.Parse(Request.QueryString["menuid"]);

            if (!Page.IsPostBack)
            {
                this.lblMenuInfo.Text = menuService.GetMenuPath(menuId);
                SYSMenuInfo entity = menuService.GetDetail(menuId);
                if (entity.MenuItem == 'Y')
                {
                    this.lblMenu.Text = this.GetLocalResourceObject("lblMenuItemResource1.Text").ToString();
                }
                else
                {
                    this.lblMenu.Text = this.GetLocalResourceObject("lblSubMenuResource1.Text").ToString();
                }
                if (ViewState["sortby"] == null)
                {
                    ViewState["sortby"]="role_desc";
                }

                if (ViewState["orderby"] == null)
                {
                    ViewState["orderby"]="asc";
                }
                BindResult();
            }
        }

        private void BindResult()
        {
            menuRoleItems = menuService.GetRoles(menuId);
            IList<SYSRoleInfo> items = roleService.Query( ViewState["sortby"].ToString(), ViewState["orderby"].ToString());
            if (items.Count == 0)
            {
                this.lblRoleCount.Visible = true;
                this.GVList.Visible = false;
            }
            else
            {
                this.lblRoleCount.Visible = false;
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
                int count = (from roleItem in menuRoleItems
                             where roleItem.RoleId == Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "RoleId"))
                             select roleItem).Count<SYSRoleInfo>();
                if (count>0)
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
            if(ViewState["sortby"].ToString()==e.SortExpression)
            {
                if (ViewState["orderby"].ToString() == "asc")
                {
                    ViewState["orderby"] = "desc";
                }
                else{
                    ViewState["orderby"] = "asc";
                }
            }
            else{
                ViewState["sortby"]=e.SortExpression;
            }
            this.BindResult();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            IList<SYSRoleInfo> roleItems = new List<SYSRoleInfo>();
            IList<SYSRoleInfo> unRoleItems = new List<SYSRoleInfo>();
            for (int i = 0; i < this.GVList.Rows.Count; i++)
            {
                CheckBox cbx =(CheckBox) this.GVList.Rows[i].FindControl("check");
                SYSRoleInfo roleItem = new SYSRoleInfo();
                roleItem.RoleId =int.Parse(this.GVList.DataKeys[i].Values["RoleId"].ToString());
                if (cbx.Checked == true)
                {
                    roleItem.LastUpdateDate =DateTime.Now;
                    roleItem.LastUpdatedBy =Page.User.Identity.Name;
                    roleItem.CreationDate =DateTime.Now ;
                    roleItem.CreatedBy =Page.User.Identity.Name;
                    roleItems.Add(roleItem);
                }
                else
                {
                    unRoleItems.Add(roleItem);
                }
            }


            IList<DictionaryEntry> mappings = new List<DictionaryEntry>();
            IList<DictionaryEntry> unMappings = new List<DictionaryEntry>();

            List<int> parents = new List<int>();
            List<int> childs = new List<int>();

            menuService.GetParents(parents, menuId);
            menuService.GetChilds(childs, menuId);

            foreach (SYSRoleInfo roleItem in roleItems)
            {
                IList<SYSMenuInfo> roleMenuItems = roleService.GetMenus(roleItem.RoleId);

                foreach (int dbMenuId in parents)
                {
                    int count = (from mapping in roleMenuItems
                                 where mapping.MenuId == dbMenuId
                                 select mapping).Count<SYSMenuInfo>();
                    if (count == 0)
                    {
                        DictionaryEntry entry = new DictionaryEntry(dbMenuId, roleItem);
                        mappings.Add(entry);
                    }
                }
            }

            foreach (int dbUnMenuId in childs)
            {
                foreach (SYSRoleInfo unRoleItem in unRoleItems)
                {
                    DictionaryEntry unEntry = new DictionaryEntry(dbUnMenuId, unRoleItem);
                    unMappings.Add(unEntry);
                }
            }
            try
            {
                menuService.SaveRoles(mappings, unMappings);
            }
            catch (Exception ex)
            {
                throw ex;
            }
  
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');refresh();</script>");
        }
    }
}

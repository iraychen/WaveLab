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
    public partial class SYSMenuEdit : CommonPage 
    {
        private int menuId ;
        private SYSMenuInfo entity;
        private ISYSMenuService menuService;
        private ISYSRoleService roleService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            menuService = (ISYSMenuService)cxt.GetObject("SV.SYSMenuService");

            menuId = int.Parse(Request.QueryString["menuid"]);
            entity = menuService.GetDetail(menuId);

            if (!Page.IsPostBack)
            {
                this.ddlParent.DataSource = menuService.GetSubMenu();
                this.ddlParent.DataTextField = "MenuDesc";
                this.ddlParent.DataValueField = "MenuId";
                this.ddlParent.DataBind();
                ListItem firstItem = new ListItem(this.GetGlobalResourceObject("globalResource", "topItem").ToString(), "0");
                this.ddlParent.Items.Insert(0, firstItem);

                LoadInfo();
                this.btnDelete.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");

            }
        }
        private void LoadInfo()
        {
            this.tbxMenuDesc.Text = entity.MenuDesc;
            this.ddlParent.SelectedValue =Convert.ToString( entity.ParentId);
            ViewState.Add("oldParentId",entity.ParentId);
            this.ddlEnabled.SelectedValue = Convert.ToString(entity.Enabled);
            this.tbxImageUrl.Text = entity.ImageUrl;
            if (entity.MenuItem == 'Y')
            {
                this.rbtMenuItem.Checked = true;
                this.tbxUrl.Text = entity.Url;
            }
            else
            {
                this.rbtSubMenu.Checked = true;
                this.tbxUrl.Text = "";
                this.urlRow.Style.Add("display", "none");
                this.imageUrlRow.Style.Add("display", "none");
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (menuService.CheckExists(this.tbxMenuDesc.Text.Trim(), menuId, int.Parse(this.ddlParent.SelectedValue.Trim())) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("menuExistsMessage") + "');</script>");
                return;
            }
            if (this.rbtMenuItem.Checked == true && menuService.CheckUrlExists(this.tbxUrl.Text.Trim(), menuId) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("urlExistsMessage") + "');</script>");
                return;
            }

            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name ;
            entity.MenuDesc =this.tbxMenuDesc.Text.Trim();
            entity.ParentId = int.Parse(this.ddlParent.SelectedValue);
            entity.Enabled = char.Parse(this.ddlEnabled.SelectedValue);
            if (rbtMenuItem.Checked == true)
            {
                entity.MenuItem = 'Y';
                entity.Url = this.tbxUrl.Text.Trim();
                entity.ImageUrl = this.tbxImageUrl.Text.Trim();
            }
            else
            {
                entity.MenuItem = 'N';
                entity.Url = null;
                entity.ImageUrl = null;
            }

            bool transform=false;
            IList<DictionaryEntry> mappings = new List<DictionaryEntry>();

            if (entity.ParentId != int.Parse(ViewState["oldParentId"].ToString()))
            {
                transform = true;

                IList<SYSRoleInfo> roleItems = menuService.GetRoles(menuId);

                List<int> newPath = new List<int>();
                menuService.GetParents(newPath, entity.ParentId);

                foreach (SYSRoleInfo roleItem in roleItems)
                {
                    IList<SYSMenuInfo> menuItems = roleService.GetMenus(roleItem.RoleId);

                    IEnumerator<int> ienum = newPath.GetEnumerator();

                    while (ienum.MoveNext())
                    {
                        int count=(from menuItem in menuItems
                                   where menuItem.MenuId== (int)ienum.Current
                                   select menuItem).Count<SYSMenuInfo>();
                        if (count==0)
                        {
                            SYSRoleInfo item = new SYSRoleInfo();
                            item.RoleId = roleItem.RoleId;
                            item.LastUpdateDate = entity.LastUpdateDate;
                            item.LastUpdatedBy = entity.LastUpdatedBy;
                            item.CreationDate = entity.LastUpdateDate;
                            item.CreatedBy = entity.LastUpdatedBy;
                            DictionaryEntry entry= new DictionaryEntry(ienum.Current, item);
                            mappings.Add(entry);
                        }
                    }
                }
            }

            try
            {
                menuService.Update(entity, transform, mappings);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "updateSuccessMsg") + "');closeWindow('SYSmenuCtl.aspx');</script>");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
               menuService.Delete(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');closeWindow('SYSmenuCtl.aspx');</script>");
        }
    }
}

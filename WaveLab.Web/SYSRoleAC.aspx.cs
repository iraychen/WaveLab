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
    public partial class SYSRoleAC : CommonPage 
    {
        private int roleId;
        private List<int> checkedNodes=new List<int>();

        private IList<SYSMenuInfo> allMenuItems;
        private IList<SYSMenuInfo> roleMenuItems;

        private ISYSMenuService menuService;
        private ISYSRoleService roleService;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            menuService = (ISYSMenuService)cxt.GetObject("SV.SYSMenuService");
          
            roleService = (ISYSRoleService)cxt.GetObject("SV.SYSRoleService");
            roleId = int.Parse(Request.QueryString["roleid"]);
           
            if (!Page.IsPostBack)
            {
                SYSRoleInfo entity = roleService.GetDetail(roleId);
                this.lblRoldeInfoDesc.Text = entity.RoleDesc;

                this.btnCopy.Attributes.Add("onclick", "return redirect('COPY','" + roleId + "')");

                roleMenuItems = roleService.GetMenus(roleId);
                allMenuItems = menuService.GetItems();
                
                LoaAllMenus(this.treeViewAllMenus.Nodes, 0);
                LoadSelectedMenus(this.treeViewSelectedMenus.Nodes, 0);
            }
        }

        private void LoaAllMenus( TreeNodeCollection nodes,int parentId)
        {
            var items = from item in allMenuItems
                        where item.ParentId == parentId
                        orderby item.Sequence
                        select item;
            IEnumerator iEnum = items.GetEnumerator();
            while (iEnum.MoveNext())
            {
                SYSMenuInfo item = (SYSMenuInfo)iEnum.Current;
                TreeNode node = new TreeNode();
                node.Value = item.MenuId.ToString();
                node.Text = item.MenuDesc;
                node.SelectAction = TreeNodeSelectAction.None;
                if (item.MenuItem == 'N')
                {
                    this.LoaAllMenus(node.ChildNodes, item.MenuId);
                }
                nodes.Add(node);
            }

        }

        private void LoadSelectedMenus(TreeNodeCollection nodes, int parentId)
        {
            var items = from item in roleMenuItems
                        where item.ParentId == parentId
                        orderby item.Sequence
                        select item;
            IEnumerator iEnum = items.GetEnumerator();
            while (iEnum.MoveNext())
            {
                SYSMenuInfo item = (SYSMenuInfo)iEnum.Current;
                TreeNode node = new TreeNode();
                node.Value = item.MenuId.ToString();
                node.Text = item.MenuDesc;
                node.SelectAction = TreeNodeSelectAction.None;
                if (item.MenuItem == 'N')
                {
                    this.LoadSelectedMenus(node.ChildNodes, item.MenuId);
                }
                nodes.Add(node);
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            roleMenuItems = roleService.GetMenus(roleId);// PostBack Data

            GetCheckedNodes(this.treeViewAllMenus.Nodes);
            foreach (int item in checkedNodes)
            {
                int count = (from menuItem in roleMenuItems
                             where menuItem.MenuId == item
                             select menuItem).Count<SYSMenuInfo>();
                if (count>0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" +
                    this.GetLocalResourceObject("menuItemMessage") + menuService.GetMenuPath(item) + this.GetLocalResourceObject("existsMessage") + "');</script>");
                    return;
                }
            }

            List<int> allMenus = new List<int>();
            foreach (int item in checkedNodes)
            {
                menuService.GetParents(allMenus, item);
            }

            IList<SYSMenuInfo> menuItems = new List<SYSMenuInfo>();
            List<int> selectedMenus = allMenus.Distinct<int>().ToList<int>();
            foreach (int menuId in selectedMenus)
            {
                int count = (from menuItem in roleMenuItems
                             where menuItem.MenuId == menuId
                             select menuItem).Count<SYSMenuInfo>();
                if (count == 0)
                {
                    SYSMenuInfo menuItem = new SYSMenuInfo();
                    menuItem.MenuId = menuId;
                    menuItem.LastUpdateDate = DateTime.Now;
                    menuItem.LastUpdatedBy = Page.User.Identity.Name;
                    menuItem.CreationDate = DateTime.Now;
                    menuItem.CreatedBy = Page.User.Identity.Name;
                    menuItems.Add(menuItem);
                }
            }
            try
            {
                roleService.SaveMenus(roleId, menuItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("addSuccessMessage") + "');refresh();</script>");
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GetCheckedNodes(this.treeViewSelectedMenus.Nodes);

            List<int> childs = new List<int>();
            foreach (int  menuId in checkedNodes)
            {
                menuService.GetChilds(childs, menuId);
            }

            IList<SYSMenuInfo> menuItems = new List<SYSMenuInfo>();
            foreach (int menuId in childs)
            {
                SYSMenuInfo menuItem = new SYSMenuInfo();
                menuItem.MenuId = menuId;
                menuItem.LastUpdateDate = DateTime.Now;
                menuItem.LastUpdatedBy = Page.User.Identity.Name;
                menuItem.CreationDate = DateTime.Now;
                menuItem.CreatedBy = Page.User.Identity.Name;
                menuItems.Add(menuItem);
            }
            try
            {
                roleService.DeleteMenus(roleId, menuItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("subSuccessMessage") + "');refresh();</script>");
        }

        private void GetCheckedNodes(TreeNodeCollection nodes)
        {
            foreach(TreeNode node in nodes)
            {
                if (node.Checked == true)
                {
                    checkedNodes.Add(int.Parse(node.Value));
                }
                if (node.ChildNodes.Count > 0)
                {
                    GetCheckedNodes(node.ChildNodes);
                }
            }
        }
    }
}

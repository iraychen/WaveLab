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
using System.Web.SessionState;

using WaveLab.Model;
using WaveLab.IService;
using Spring.Context;
using Spring.Context.Support;
namespace WaveLab.Web
{
    public partial class SYSRoleActionAC : CommonPage
    {
        private int roleId;

        private IList<SYSMenuInfo> roleMenuItems;
        private IList<SYSActionInfo> roleActionItems;

        private ISYSRoleService roleService;
        private ISYSActionService actionService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            roleService = (ISYSRoleService)cxt.GetObject("SV.SYSRoleService");
            actionService = (ISYSActionService)cxt.GetObject("SV.SYSActionService");

            roleId = int.Parse(Request.QueryString["roleid"]);

            if (!Page.IsPostBack)
            {
                SYSRoleInfo entity = roleService.GetDetail(roleId);
                this.lblRoldeDesc.Text = entity.RoleDesc;

                this.btnCopy.Attributes.Add("onclick", "return redirect('COPY','" + roleId + "')");

                roleMenuItems = roleService.GetMenus(roleId);
                LoadMenus(this.tvACMenu.Nodes, 0);

                this.actionTable.Visible = false;
                this.btnSave.Visible = false;
                this.btnReset.Visible = false;
            }
        }

        private void LoadMenus(TreeNodeCollection nodes, int parentId)
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
                if (item.MenuItem == 'N')
                {
                    node.SelectAction = TreeNodeSelectAction.None;
                    this.LoadMenus(node.ChildNodes, item.MenuId);
                }
                else
                {
                    node.SelectAction = TreeNodeSelectAction.Select;
                }
                nodes.Add(node);
            }

        }

        protected void tvACMenu_SelectedNodeChanged(object sender, EventArgs e)
        {
            this.actionTable.Visible = true;
            this.BindResult();
        }

        private void BindResult()
        {
            roleActionItems = roleService.GetActions(roleId);

            if (ViewState["sortby"] == null)
            {
                ViewState["sortby"] = "action";
            }

            if (ViewState["orderby"] == null)
            {
                ViewState["orderby"] = "asc";
            }

            Hashtable hastTable = new Hashtable();
            if (this.tvACMenu.SelectedNode.Value != null)
            {
                hastTable.Add("module_id", this.tvACMenu.SelectedNode.Value);
            }
            IList<SYSActionInfo> items = actionService.Query(hastTable, ViewState["sortby"].ToString(), ViewState["orderby"].ToString());

            if (items.Count == 0)
            {
                this.lblRecCount.Visible = true;
                this.btnSave.Visible = false;
                this.btnReset.Visible = false;
                this.GVList.Visible = false;
            }
            else
            {
                this.lblRecCount.Visible = false;
                this.GVList.Visible = true;
                this.btnSave.Visible = true;
                this.btnReset.Visible = true;

                this.GVList.DataSource = items;
                this.GVList.DataBind();
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                CheckBox cbxRole = (CheckBox)e.Row.FindControl("check");
                int count = (from actionItem in roleActionItems
                             where actionItem.ActionId == Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ActionId"))
                             select actionItem).Count<SYSActionInfo>();
                if (count > 0)
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
            IList<SYSActionInfo> actionItems = new List<SYSActionInfo>();
            for (int i = 0; i < this.GVList.Rows.Count; i++)
            {
                CheckBox cbx = (CheckBox)this.GVList.Rows[i].FindControl("check");
                if (cbx.Checked == true)
                {
                    SYSActionInfo item = new SYSActionInfo()
                    {
                        ActionId = Convert.ToInt32(this.GVList.DataKeys[i].Values["ActionId"]),
                        LastUpdateDate = DateTime.Now,
                        LastUpdatedBy = Page.User.Identity.Name,
                        CreationDate = DateTime.Now,
                        CreatedBy = Page.User.Identity.Name
                    };
                    actionItems.Add(item);
                }
            }
            try
            {
                roleService.SaveActions(roleId, actionItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            this.BindResult();
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');</script>");
                    
        }
    }
}

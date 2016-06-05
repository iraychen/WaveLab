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

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class SYSActionCtl : CommonPage
    {
        private string valuePath;
        private IList<SYSMenuInfo> menuItems;
        private ISYSMenuService menuService;
        private ISYSActionService actionService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            menuService = (ISYSMenuService)cxt.GetObject("SV.SYSMenuService");
            actionService = (ISYSActionService)cxt.GetObject("SV.SYSActionService");
           
            if (!Page.IsPostBack)
            {
                menuItems = menuService.Query();
                loadMenu(this.tvMenu.Nodes, 0);

                if (string.IsNullOrEmpty(Request.QueryString["tvvalue"]) == false)
                {
                    this.GetValuePath(this.tvMenu.Nodes, Request.QueryString["tvvalue"]);
                    string[] expandNodeValue = valuePath.Split('/');
                    this.ExpandTree(this.tvMenu.Nodes, expandNodeValue);
                    this.tbxAction.Text = "";
                    this.tbxActionName.Text = "";
                    this.btnSave.Enabled = true;
                    this.BindResult();
                }

            }
        }

        private void loadMenu(TreeNodeCollection nodes, int parent)
        {
            List<SYSMenuInfo> list = (from item in menuItems
                                   where item.ParentId == parent
                                   orderby item.Sequence
                                   select item).ToList<SYSMenuInfo>();
            if (list.Count > 0)
            {
                IEnumerator ienum = list.GetEnumerator();
                while (ienum.MoveNext())
                {
                    SYSMenuInfo entity = (SYSMenuInfo)ienum.Current;
                    TreeNode node = new TreeNode();

                    node.Text = entity.MenuDesc;
                    node.Value = Convert.ToString(entity.MenuId);
                    if (entity.MenuItem == 'N')
                    {
                        node.SelectAction = TreeNodeSelectAction.None;
                        this.loadMenu(node.ChildNodes, entity.MenuId);
                    }
                    else
                    {
                        node.SelectAction = TreeNodeSelectAction.Select;
                    }
                    nodes.Add(node);
                }
            }

        }

        private void GetValuePath(TreeNodeCollection nodes, string selectedValue)
        {
            foreach (TreeNode node in nodes)
            {
                if (int.Parse(node.Value) == int.Parse(selectedValue))                {
                    valuePath = node.ValuePath;
                    node.Selected = true;
                    return;
                }
                if (node.ChildNodes.Count > 0)
                {
                    this.GetValuePath(node.ChildNodes, selectedValue);
                }
            }
        }

        private void ExpandTree(TreeNodeCollection nodes, string[] expandNodeValue)
        {
            foreach (TreeNode node in nodes)
            {
                if (expandNodeValue.Contains(node.Value))
                {
                    node.Expanded = true;
                }
                if (node.ChildNodes.Count > 0)
                {
                    this.ExpandTree(node.ChildNodes, expandNodeValue);
                }
            }
        }

        protected void tvMenu_SelectedNodeChanged(object sender, EventArgs e)
        {
            this.tbxAction.Text = "";
            this.tbxActionName.Text = "";
            this.btnSave.Enabled = true;
            this.btnUpdate.Enabled = false;
            this.BindResult();
        }

        private void BindResult()
        {
            if (ViewState["sortby"]==null)
            {
                ViewState["sortby"] = "action";
            }

            if (ViewState["orderby"]==null)
            {
                ViewState["orderby"] = "asc";
            }

            Hashtable hastTable = new Hashtable();
            if (this.tvMenu.SelectedNode.Value != null)
            {
                hastTable.Add("module_id", this.tvMenu.SelectedNode.Value);
            }
            IList<SYSActionInfo> items = actionService.Query(hastTable,ViewState["sortby"].ToString(), ViewState["orderby"].ToString());

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
                LinkButton lbtAC = (LinkButton)e.Row.FindControl("lbtAC");
                lbtAC.Attributes.Add("onclick", "return makeWindow('AC','" + DataBinder.Eval(e.Row.DataItem, "ActionId") + "','" + this.tvMenu.SelectedNode.Value + "')");

                LinkButton lbtDel = (LinkButton)e.Row.FindControl("lbtDelete");
                lbtDel.Attributes.Add("onclick", "return confirm('" + this.GetGlobalResourceObject("globalResource", "confirmDeleteMsg") + "')");
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
            if (actionService.CheckExists(this.tbxAction.Text.Trim(), null) == true)
            {
                ScriptManager.RegisterStartupScript(this.updatePanel, this.updatePanel.GetType(), "exists", "alert('" + this.GetLocalResourceObject("ExistsMessage") + "');",true);
            }
            else 
            {
                SYSActionInfo entity = new SYSActionInfo();
                entity.Action = this.tbxAction.Text.Trim();
                entity.ActionName = this.tbxActionName.Text.Trim();
                entity.ModuleItem = new SYSMenuInfo()
                {
                    MenuId = int.Parse(this.tvMenu.SelectedNode.Value)
                };
                entity.LastUpdateDate = DateTime.Now;
                entity.LastUpdatedBy = Page.User.Identity.Name;
                entity.CreationDate = DateTime.Now;
                entity.CreatedBy = Page.User.Identity.Name;
                try
                {
                    actionService.Save(entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                this.tbxAction.Text = "";
                this.tbxActionName.Text = "";
                ScriptManager.RegisterStartupScript(this.updatePanel, this.updatePanel.GetType(), "success", "alert('" + this.GetLocalResourceObject("SaveSuccessMsg") + "');",true);
            }
            this.BindResult();
        }

        protected void GVList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int actionId=int.Parse(this.GVList.SelectedValue.ToString());
            SYSActionInfo entity = actionService.GetDetail(actionId);
            this.tbxAction.Text = entity.Action;
            this.tbxActionName.Text = entity.ActionName;

            this.btnSave.Enabled = false;
            this.btnUpdate.Enabled = true;

           
            for(int i=0;i<this.GVList.Rows.Count;i++)
            {
                if (i == this.GVList.SelectedRow.RowIndex)
                {
                    this.GVList.SelectedRow.BackColor = System.Drawing.Color.DarkOrange;
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        this.GVList.Rows[i].BackColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        this.GVList.Rows[i].BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int actionId=int.Parse(this.GVList.SelectedValue.ToString());
            if (actionService.CheckExists(this.tbxAction.Text.Trim(), actionId) == true)
            {
                ScriptManager.RegisterStartupScript(this.updatePanel, this.updatePanel.GetType(), "exists", "alert('" + this.GetLocalResourceObject("ExistsMessage") + "');",true);
            }
            else
            {
                SYSActionInfo entity = new SYSActionInfo();
                entity.Action = this.tbxAction.Text.Trim();
                entity.ActionName = this.tbxActionName.Text.Trim();
                entity.ModuleItem = new SYSMenuInfo()
                {
                    MenuId = int.Parse(this.tvMenu.SelectedNode.Value)
                };
                entity.LastUpdateDate = DateTime.Now;
                entity.LastUpdatedBy = Page.User.Identity.Name;
                entity.ActionId = actionId;
                try
                {
                    actionService.Update(entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                this.tbxAction.Text = "";
                this.tbxActionName.Text = "";
                this.btnUpdate.Enabled = false;
                this.btnSave.Enabled = true;
                ScriptManager.RegisterStartupScript(this.updatePanel, this.updatePanel.GetType(), "success", "alert('" + this.GetLocalResourceObject("UpdateSuccessMsg") + "');", true);
            }
            this.BindResult();
        }

        protected void GVList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int actionId = int.Parse(this.GVList.DataKeys[e.RowIndex].Values["ActionId"].ToString());
            SYSActionInfo entity = actionService.GetDetail(actionId);
            try
            {
                actionService.Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            ScriptManager.RegisterStartupScript(this.updatePanel, this.updatePanel.GetType(), "success", "alert('" + this.GetGlobalResourceObject("globalResource", "deleteSuccessMsg") + "');", true);
            this.BindResult();
        }
    }
}

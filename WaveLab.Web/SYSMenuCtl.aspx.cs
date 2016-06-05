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
    public partial class SYSMenuCtl : CommonPage
    {
        private List<int> expNodes=new List<int>();
        private IList<SYSMenuInfo> menuItems;
        private ISYSMenuService menuService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();         
            menuService = (ISYSMenuService)cxt.GetObject("SV.SYSMenuService");

            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["clear"]))
                {
                    Session.Remove("expNodes");
                }
            }
            if (Session["expNodes"] != null)
            {
                expNodes = (List<int>)Session["expNodes"];
            }
            menuItems = menuService.Query();
            loadMenu(this.tvMenu.Nodes, 0);
        }
        
        private void loadMenu(TreeNodeCollection nodes,  int parent)
        {

            List<SYSMenuInfo> list=(from item in menuItems
                                where item.ParentId == parent
                                orderby item.Sequence
                                select item).ToList<SYSMenuInfo>();
            if(list.Count>0)
            {
                IEnumerator ienum=list.GetEnumerator();
                while(ienum.MoveNext())
                {
                    SYSMenuInfo entity=(SYSMenuInfo)ienum.Current;
                    TreeNode node=new TreeNode();
                   
                    node.Text = "<table width=100% cellspacing =1 onmouseover=\"this.style.backgroundColor='#FFFF66'\"" +
                        " onmouseout=\"this.style.backgroundColor='#eeeeff'\">" +
                        "<tr style='text-decoration:underline'>" +
                        "     <td><a href=\"javasript:void(0)\" onclick=\"javascript:return makeWindow('EDIT','" + entity.MenuId + "')\">" + entity.MenuDesc + "</a></td>" +
                        "     <td style=width:90px><a href=\"javasript:void(0)\" onclick=\"javascript:return makeWindow('AC','" + entity.MenuId + "')\">" + this.GetGlobalResourceObject("globalResource", "EditText") + "</a></td>" +
                        "     <td style=width:80px><a href=\"javasript:void(0)\" onclick=\"javascript:return makeWindow('OR','" + entity.ParentId + "')\">" + this.GetGlobalResourceObject("globalResource", "orderKey") + "</a></td>" +
                        "</tr></table>";
                    node.Value =Convert.ToString(entity.MenuId);
                    node.SelectAction = TreeNodeSelectAction.None;
                    bool isExp = false;
                    for (int i = 0; i < expNodes.Count; i++)
                    {
                        if (expNodes[i] == entity.MenuId)
                        {
                            isExp = true;
                            break;
                        }
                    }
                    if (isExp == true)
                    {
                        node.Expand();
                    }
                    else
                    {
                        node.Collapse();
                    }
                    if(entity.MenuItem=='N')
                    {
                        this.loadMenu(node.ChildNodes, entity.MenuId);
                    }
                    nodes.Add(node);
                }
            }

        }

        protected void tvMenu_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            expNodes.Add(int.Parse(e.Node.Value));
           
            Session["expNodes"]= expNodes;
        }

        protected void tvMenu_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
        {
            for (int i = 0; i < expNodes.Count; i++)
            {
                if (expNodes[i] == int.Parse(e.Node.Value))
                {
                    expNodes.RemoveAt(i);
                }
            }
            Session["expNodes"]= expNodes;
        }

     

    }
}

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

using WaveLab.IService;
using WaveLab.Model;
using System.Collections.Generic;

namespace WaveLab.Web
{
    public partial class SYSMenuOrder : CommonPage 
    {
        private int parentId;
        private ISYSMenuService menuService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            menuService = (ISYSMenuService)cxt.GetObject("SV.SYSMenuService");

            parentId =int.Parse( Request.QueryString["parentid"]);

            if (!Page.IsPostBack)
            {
                this.lblMenuPath.Text = menuService.GetMenuNavigatePath(parentId);
                IList<SYSMenuInfo> items = menuService.GetMenuByParentId(parentId);
                this.lbxItems.DataSource =items;
                this.lbxItems.DataValueField ="menuid";
                this.lbxItems.DataTextField="menudesc";
                this.lbxItems.DataBind();
            }
        }

        protected void ibtUp_Click(object sender, ImageClickEventArgs e)
        {
           int index=this.lbxItems.SelectedIndex;
           if(index >0)
           {
               ListItem item =new ListItem();
               item.Text=this.lbxItems.Items[index-1].Text;
               item.Value=this.lbxItems.Items[index-1].Value;

               this.lbxItems.Items[index-1].Text=this.lbxItems.Items[index].Text;
               this.lbxItems.Items[index-1].Value=this.lbxItems.Items[index].Value;

               this.lbxItems.Items[index].Text=item.Text ;
               this.lbxItems.Items[index].Value=item.Value;

               this.lbxItems.SelectedIndex=index-1;
           }
      
        }

        protected void ibtDown_Click(object sender, ImageClickEventArgs e)
        {
            int index = this.lbxItems.SelectedIndex;
            if (index < this.lbxItems.Items.Count)
            {
                ListItem item = new ListItem();
                item.Text = this.lbxItems.Items[index + 1].Text;
                item.Value = this.lbxItems.Items[index + 1].Value;

                this.lbxItems.Items[index + 1].Text = this.lbxItems.Items[index].Text;
                this.lbxItems.Items[index + 1].Value = this.lbxItems.Items[index].Value;

                this.lbxItems.Items[index].Text = item.Text;
                this.lbxItems.Items[index].Value = item.Value;

                this.lbxItems.SelectedIndex = index + 1;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Hashtable hashTable = new Hashtable();
            for (int i = 1; i <=this.lbxItems.Items.Count; i++)
            {
                SYSMenuInfo item = new SYSMenuInfo();
                item.MenuId = int.Parse(this.lbxItems.Items[i - 1].Value);
                item.MenuDesc = this.lbxItems.Items[i - 1].Text;
                item.LastUpdateDate = DateTime.Now;
                item.LastUpdatedBy = Page.User.Identity.Name;
                hashTable.Add(item, i);

            }
            try
            {
                menuService.UpdateSequence(hashTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('menuCtl.aspx');</script>");
        }
    }
}

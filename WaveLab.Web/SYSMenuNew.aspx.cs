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
    public partial class SYSMenuNew : CommonPage 
    {
        private ISYSMenuService menuService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            menuService = (ISYSMenuService)cxt.GetObject("SV.SYSMenuService");

            if (!Page.IsPostBack)
            {
                this.ddlParent.DataSource = menuService.GetSubMenu();
                this.ddlParent.DataTextField = "MenuDesc";
                this.ddlParent.DataValueField ="MenuId";
                this.ddlParent.DataBind();
                
                ListItem firstItem = new ListItem(this.GetGlobalResourceObject("globalResource","topItem").ToString(), "0");
                this.ddlParent.Items.Insert(0, firstItem);
              
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (menuService.CheckExists(this.tbxMenuDesc.Text.Trim(), null,int.Parse(this.ddlParent.SelectedValue.Trim())) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("menuExistsMessage") + "');</script>");
                return;
            }
            if (this.rbtMenuItem.Checked == true && menuService.CheckUrlExists(this.tbxUrl.Text.Trim(), null) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("urlExistsMessage") + "');</script>");
                return;
            }
            SYSMenuInfo entity = new SYSMenuInfo();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.CreationDate = DateTime.Now;
            entity.CreatedBy = Page.User.Identity.Name;
            entity.MenuDesc = this.tbxMenuDesc.Text.Trim();
            entity.ParentId = int.Parse(this.ddlParent.SelectedValue);
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
            entity.Enabled = char.Parse(this.ddlEnabled.SelectedValue);
            
            try
            {
                menuService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('SYSmenuCtl.aspx');</script>");
        }
    }
}

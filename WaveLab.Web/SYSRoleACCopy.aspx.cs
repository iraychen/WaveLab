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
using WaveLab.Model;
using WaveLab.IService;
using Spring.Context;
using Spring.Context.Support;
namespace WaveLab.Web
{
    public partial class SYSRoleACCopy : CommonPage
    {
        private int roleId;
        
        private ISYSRoleService roleService;

        protected void Page_Load(object sender, EventArgs e)
        {
            roleId = int.Parse(Request.QueryString["roleid"]);
            IApplicationContext cxt = ContextRegistry.GetContext();
           
            roleService = (ISYSRoleService)cxt.GetObject("SV.SYSRoleService");
            if (!Page.IsPostBack)
            {
                SYSRoleInfo entity = roleService.GetDetail(roleId);
                this.lblRoldeInfoDesc.Text = entity.RoleDesc;

                IList<SYSRoleInfo> items=roleService.GetItems();

                this.ddlOtherRole.DataSource =(from item in items
                                               where item.RoleId!=roleId
                                               select item).ToList<SYSRoleInfo>();

                this.ddlOtherRole.DataTextField = "RoleDesc";
                this.ddlOtherRole.DataValueField = "RoleId";
                this.ddlOtherRole.DataBind();
                this.ddlOtherRole.Items.Insert(0, new ListItem("", ""));
            }
        }

        protected void btnEnsure_Click(object sender, EventArgs e)
        {
            try
            {
                roleService.SaveMenusRoleCopy(int.Parse(this.ddlOtherRole.SelectedValue), roleId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("successMsg") + "');goBack();</script>");
        }
    }
}

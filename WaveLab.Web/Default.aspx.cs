using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class _default : System.Web.UI.Page
    {
        //private IList<int> arItems;
       // private IList<MenuInfo> menuItems;
        private ISYSSecurityMasterService SecurityMasterService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SecurityMasterService = (ISYSSecurityMasterService)cxt.GetObject("SV.SYSSecurityMasterService");

            if (!Page.IsPostBack)
            {
                this.lbtLogout.Attributes.Add("onclick", "return confirm('" + this.GetLocalResourceObject("logoutTip") + "?')");
                SYSSecurityMasterInfo currentUser = SecurityMasterService.GetDetail(Page.User.Identity.Name);
                this.lbtUser.Text = currentUser.UserName;
            }
        }

        protected void lbtLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("logout.aspx");
        }
    }
}

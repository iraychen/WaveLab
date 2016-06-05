using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Security.Cryptography;
using System.Xml.Linq;

using Spring.Context;
using Spring.Context.Support;

using WaveLab.IService;
using WaveLab.Service.Utility;
using System.Text;

namespace WaveLab.Web
{
    public partial class login :  System.Web.UI.Page 
    {
        private ISYSSecurityMasterService SecurityMasterService;
            
       protected void Page_Load(object sender, EventArgs e)
       {
           IApplicationContext cxt = ContextRegistry.GetContext();
           SecurityMasterService = (ISYSSecurityMasterService)cxt.GetObject("SV.SYSSecurityMasterService");

           if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
           {
               Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script type='text/javascript'>top.location.replace('login.aspx');</script>");
           }
       }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
            string userId ;
            userId = this.tbxUserName.Text.Trim().ToString();

            if (SecurityMasterService.CheckExists(userId) == false)
            {
                showError(this.GetLocalResourceObject("notExistsTip").ToString());
                return;
            }

            string passWord =this.tbxPassWord.Text.Trim().ToString();

            if (SecurityMasterService.CheckPWD(userId, Encrytor.Encryt(passWord)) == false)
            {
                showError(this.GetLocalResourceObject("passWordErrorTip").ToString());
                return;
            }
            if (SecurityMasterService.CheckActive(userId) == false)
            {
                showError(this.GetLocalResourceObject("notActiveTip").ToString());
                return;
            }

            IList<int> arItems = SecurityMasterService.GetACMenu(userId.ToUpper());
            if(arItems.Count==0)
            {
                showError(this.GetLocalResourceObject("noARMsg").ToString());
                return;
            }

            FormsAuthentication.RedirectFromLoginPage(userId.ToUpper(), false);
        }

        private void showError(string message)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Tip", "<script type='text/javascript'>alert('"+message+"');</script>");
        }
    }
}

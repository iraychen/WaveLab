using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WaveLab.Web
{
    public class CommonPage : System.Web.UI.Page
    {
        //private ISecurityMasterService arSecurityMasterService;
        //private IMenuService arMenuService;

        //protected void Page_PreInit(object sender, EventArgs e)
        //{
            //if (Session["PageTheme"] != null)
            //{
            //    this.Theme = Session["pagetheme"].ToString();
            //}
            //else
            //{
            //    this.Theme = "default";
            //}
           
            //this.StyleSheetTheme = Request.Cookies["pagetheme"].Value;
        //}
        //protected void Page_Init(object sender, EventArgs e)
        //{
            //string appPath, rawUrl, requestUrl;
            //appPath = Request.ApplicationPath.ToLower();
            //rawUrl = Request.RawUrl.ToLower();
            //if (appPath != "/")
            //{
            //    requestUrl = rawUrl.Replace(appPath, "");
            //}
            //else
            //{
            //    requestUrl = rawUrl;
            //}
            //if (requestUrl.StartsWith("/") == true)
            //{
            //    requestUrl = requestUrl.Substring(1);
            //}

            //int index = requestUrl.LastIndexOf("?");
            //if (index > -1)
            //{
            //    requestUrl = requestUrl.Substring(0, index);
            //}

            //if (arMenuService.CheckUrlExists(requestUrl, null) == true && arSecurityMasterService.CheckAccessRight(Page.User.Identity.Name, requestUrl) == false)
            //{
            //    Response.Write("<center><font color=\"red\">" + this.GetGlobalResourceObject("globalResource", "noAccessRightMsg") + "</font></center>");
            //    Response.End();
            //}
        //}
    }
}

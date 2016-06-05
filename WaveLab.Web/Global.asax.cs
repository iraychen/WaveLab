using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using System.Globalization;
using System.Threading;
using System.Text;

namespace WaveLab.Web
{
    public class Global : System.Web.HttpApplication
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger("WebLogger");
        
        protected void Application_Start(object sender, EventArgs e)
        {
           
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //string lang = string.Empty;
            //HttpCookie cookie = Request.Cookies["culturename"];
            //if (cookie != null && cookie.Value != null)
            //    lang = cookie.Value;
            //CultureInfo culture = new CultureInfo(lang);
            //Thread.CurrentThread.CurrentUICulture = culture;
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (this.Server.GetLastError() == null)
            {
                return;
            }

            Exception ex = this.Server.GetLastError().GetBaseException();
            StringBuilder sb = new StringBuilder();

            sb.Append(ex.Message);
            sb.Append("\r\nSOURCE: " + ex.Source);
		    sb.Append("\r\n引发当前异常的原因: " + ex.TargetSite);
            sb.Append("\r\n堆栈跟踪: " + ex.StackTrace);
            logger.Error(sb.ToString());
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
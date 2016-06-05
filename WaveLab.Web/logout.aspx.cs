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

namespace WaveLab.Web
{
    public partial class logout : CommonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             FormsAuthentication.SignOut();
  
             Response.Write("<script type='text/javascript'>top.location.replace('login.aspx');</script>");
        }
    }
}

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

namespace WaveLab.Web
{
    public partial class SYSSecurityMasterView : CommonPage 
    {
        private string userId,userName, passWord;
        private ISYSSecurityMasterService SecurityMasterService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SecurityMasterService = (ISYSSecurityMasterService)cxt.GetObject("SV.SYSSecurityMasterService");

            userId = Request.QueryString["userid"];
            userName = Request.QueryString["username"];
            passWord = Request.QueryString["pwd"];
            if (!Page.IsPostBack)
            {
                string type = Request.QueryString["type"];
                switch (type)
                { 
                    case "N":
                        this.lblTitle.Text = this.GetLocalResourceObject("newAccount").ToString();
                        break;
                    case "E":
                        this.lblTitle.Text = this.GetLocalResourceObject("resetPwd").ToString();
                        break;
                    default:
                        break;
                }
                this.lblUserId.Text= userId;
                this.lblPassWord.Text = passWord;
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            
            Response.ClearHeaders();
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");
            Response.ContentType = "application/octet-stream";
            Response.Flush();
            Response.BinaryWrite(SecurityMasterService.ExportToPdf(userId, userName, passWord)); 
            Response.End();
           
        }
    }
}

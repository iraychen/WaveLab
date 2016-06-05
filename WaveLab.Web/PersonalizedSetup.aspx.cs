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
using WaveLab.Service.Utility;

namespace WaveLab.Web
{
    public partial class PersonalizedSetup : System.Web.UI.Page
    {
        private ISYSSecurityMasterService SecurityMasterService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SecurityMasterService = (ISYSSecurityMasterService)cxt.GetObject("SV.SYSSecurityMasterService");
            if (!Page.IsPostBack)
            {

                this.strengthNewPwd.PrefixText = this.GetLocalResourceObject("PrefixText").ToString();
                this.strengthNewPwd.TextStrengthDescriptions = this.GetLocalResourceObject("TextStrengthDescriptions").ToString();

                this.strengthConfirmPwd.PrefixText = this.GetLocalResourceObject("PrefixText").ToString();
                this.strengthConfirmPwd.TextStrengthDescriptions = this.GetLocalResourceObject("TextStrengthDescriptions").ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string oldPassWord = this.tbxPwd.Text.Trim();
            string newPassWord = this.tbxNewPwd.Text.Trim();

            if (SecurityMasterService.CheckPWD(Page.User.Identity.Name, Encrytor.Encryt(oldPassWord)) == false)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "wrong password", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("wrongPwdMsg") + "');</script>");
                return;
            }
            SYSSecurityMasterInfo entity = SecurityMasterService.GetDetail(Page.User.Identity.Name);
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.PassWord = Encrytor.Encryt(newPassWord);

            try
            {
                SecurityMasterService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Tip", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("successMsg") + "');self.close();</script>");
        }
    }
}

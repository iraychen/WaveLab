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

namespace WaveLab.Web
{
    public partial class SPCPullingForceTargetNew : CommonPage
    {
        private ISPCPullingForceTargetService SPCPullingForceTargetService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCPullingForceTargetService = (ISPCPullingForceTargetService)cxt.GetObject("SV.SPCPullingForceTargetService");

            if (!Page.IsPostBack)
            {
                this.tbxEffectiveDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SPCPullingForceTargetService.CheckExists(this.tbxMachineNo.Text.Trim().ToUpper(), this.tbxEffectiveDate.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("ExistsMsg") + "');</script>");
                return;
            }

            SPCPullingForceTargetInfo entity = new SPCPullingForceTargetInfo();

            entity.MachineNo = this.tbxMachineNo.Text.Trim().ToUpper();
            entity.EffectiveDate = DateTime.ParseExact(this.tbxEffectiveDate.Text.Trim().ToUpper(), "yyyy-MM-dd", null);

            entity.UCL_X = Convert.ToDouble(this.tbxUCL_X.Text.Trim());
            entity.LCL_X = Convert.ToDouble(this.tbxLCL_X.Text.Trim());
            entity.CL_X = Convert.ToDouble(this.tbxCL_X.Text.Trim());

            entity.UCL_R = Convert.ToDouble(this.tbxUCL_R.Text.Trim());
            entity.LCL_R = Convert.ToDouble(this.tbxLCL_R.Text.Trim());
            entity.CL_R = Convert.ToDouble(this.tbxCL_R.Text.Trim());

            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name.ToUpper();
         
            try
            {
                SPCPullingForceTargetService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow();</script>");
        }
    }
}

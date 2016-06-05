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
    public partial class SPCPullingForceTargetEdit : CommonPage
    {
        private ISPCPullingForceTargetService SPCPullingForceTargetService;
        private SPCPullingForceTargetInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCPullingForceTargetService = (ISPCPullingForceTargetService)cxt.GetObject("SV.SPCPullingForceTargetService");

            int PullingForceTargetPK = int.Parse(Request.QueryString["key"]);
            entity = SPCPullingForceTargetService.GetDetail(PullingForceTargetPK);

            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            this.ltlMachineNo.Text = entity.MachineNo;
            this.ltlEffectiveDate.Text = String.Format("{0:yyyy-MM-dd}",entity.EffectiveDate);

            this.tbxUCL_X.Text = string.Format("{0:f2}", entity.UCL_X);
            this.tbxLCL_X.Text = string.Format("{0:f2}", entity.LCL_X);
            this.tbxCL_X.Text = string.Format("{0:f2}", entity.CL_X);

            this.tbxUCL_R.Text = string.Format("{0:f2}", entity.UCL_R);
            this.tbxLCL_R.Text = string.Format("{0:f2}", entity.LCL_R);
            this.tbxCL_R.Text = string.Format("{0:f2}", entity.CL_R);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            entity.UCL_X = Convert.ToDouble(this.tbxUCL_X.Text.Trim());
            entity.LCL_X = Convert.ToDouble(this.tbxLCL_X.Text.Trim());
            entity.CL_X = Convert.ToDouble(this.tbxCL_X.Text.Trim());

            entity.UCL_R = Convert.ToDouble(this.tbxUCL_R.Text.Trim());
            entity.LCL_R = Convert.ToDouble(this.tbxLCL_R.Text.Trim());
            entity.CL_R = Convert.ToDouble(this.tbxCL_R.Text.Trim());

            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;

            try
            {
                SPCPullingForceTargetService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tip", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "updateSuccessMsg") + "');closeWindow();</script>");
        }

    }
}

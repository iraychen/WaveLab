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
    public partial class SPCPullingForceNew : CommonPage
    {
       private ISPCPullingForceService SPCPullingForceService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCPullingForceService = (ISPCPullingForceService)cxt.GetObject("SV.SPCPullingForceService");
         
            if (!Page.IsPostBack)
            {
                this.tbxWorkingDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SPCPullingForceService.CheckExists(this.tbxMachineNo.Text.Trim().ToUpper(), this.tbxWorkingDate.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("ExistsMsg") + "');</script>");
                return;
            }

            SPCPullingForceInfo entity = new SPCPullingForceInfo();

            entity.MachineNo = this.tbxMachineNo.Text.Trim().ToUpper();
            entity.WorkingDate = DateTime.ParseExact(this.tbxWorkingDate.Text.Trim().ToUpper(), "yyyy-MM-dd", null);

            entity.MWMType = this.tbxMWMType.Text.Trim();
            if (this.tbxMachinePressure.Text.Trim().Length > 0)
            {
                entity.MachinePressure = int.Parse(this.tbxMachinePressure.Text.Trim());
            }
            if (this.tbxPowerFirstPoint.Text.Trim().Length > 0)
            {
                entity.PowerFirstPoint = int.Parse(this.tbxPowerFirstPoint.Text.Trim());
            }
            if (this.tbxPowerSecondPoint.Text.Trim().Length > 0)
            {
                entity.PowerSecondPoint = int.Parse(this.tbxPowerSecondPoint.Text.Trim());
            }
            entity.Operator = this.tbxOperator.Text.Trim();
            entity.X1 = Convert.ToDouble(this.tbxX1.Text.Trim());
            entity.X2 = Convert.ToDouble(this.tbxX2.Text.Trim());
            entity.X3 = Convert.ToDouble(this.tbxX3.Text.Trim());
            entity.X4 = Convert.ToDouble(this.tbxX4.Text.Trim());
            entity.X5 = Convert.ToDouble(this.tbxX5.Text.Trim());
            entity.X6 = Convert.ToDouble(this.tbxX6.Text.Trim());
            entity.X7 = Convert.ToDouble(this.tbxX7.Text.Trim());
            entity.X8 = Convert.ToDouble(this.tbxX8.Text.Trim());
            entity.X9 = Convert.ToDouble(this.tbxX9.Text.Trim());
            entity.X10 = Convert.ToDouble(this.tbxX10.Text.Trim());
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name.ToUpper();

            try
            {
                SPCPullingForceService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

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
    public partial class SPCPullingForceEdit : CommonPage
    {
       private ISPCPullingForceService SPCPullingForceService;
        private SPCPullingForceInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {

            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCPullingForceService = (ISPCPullingForceService)cxt.GetObject("SV.SPCPullingForceService");
         

            int PullingForcePK = int.Parse(Request.QueryString["key"]);
            entity = SPCPullingForceService.GetDetail(PullingForcePK);

            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            this.ltlMachineNo.Text = entity.MachineNo;
            this.ltlWorkingDate.Text = String.Format("{0:yyyy-MM-dd}", entity.WorkingDate);

            this.tbxMWMType.Text = entity.MWMType;
            this.tbxMachinePressure.Text=string.Format("{0:d}", entity.MachinePressure);
            this.tbxPowerFirstPoint.Text = string.Format("{0:d}", entity.PowerFirstPoint);
            this.tbxPowerSecondPoint.Text = string.Format("{0:d}", entity.PowerSecondPoint);
            this.tbxOperator.Text = entity.Operator;

            this.tbxX1.Text = string.Format("{0:f2}", entity.X1);
            this.tbxX2.Text = string.Format("{0:f2}", entity.X2);
            this.tbxX3.Text = string.Format("{0:f2}", entity.X3);
            this.tbxX4.Text = string.Format("{0:f2}", entity.X4);
            this.tbxX5.Text = string.Format("{0:f2}", entity.X5);
            this.tbxX6.Text = string.Format("{0:f2}", entity.X6);
            this.tbxX7.Text = string.Format("{0:f2}", entity.X7);
            this.tbxX8.Text = string.Format("{0:f2}", entity.X8);
            this.tbxX9.Text = string.Format("{0:f2}", entity.X9);
            this.tbxX10.Text = string.Format("{0:f2}", entity.X10);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
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
                SPCPullingForceService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tip", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "updateSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }

    }
}

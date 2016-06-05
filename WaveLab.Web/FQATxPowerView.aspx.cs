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
using System.Collections.Generic;
using System.Web.UI.DataVisualization.Charting;
using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class FQATxPowerView : CommonPage
    {
        private IFQATxPowerService FQATxPowerService;
        private FQATxPowerInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            FQATxPowerService = (IFQATxPowerService)cxt.GetObject("SV.FQATxPowerService");


            if (!Page.IsPostBack)
            {
                int FQATxPowerId = int.Parse(Request.QueryString["FQATxPowerId"]);
                entity = FQATxPowerService.GetDetail(FQATxPowerId);
                LoadDtl();
            }
        }

        private void LoadDtl()
        {
          
            this.ltlModel.Text = entity.Model;
     
            this.ltlSerialNo.Text = entity.SerialNo;

            this.ltlStationNo.Text = entity.StationNo;
       
            if (entity.EndTime != null)
            {
                this.ltlEndTime.Text = entity.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            this.ltlRunningTime.Text = entity.RunningTime;

            this.ltlReason.Text = entity.Reason;
            this.ltlAppVersion.Text = entity.AppVersion;
            if (entity.FinalFlag == 'P')
            {
                this.ltlFinalFlag.Text = "<font color='green'>PASS</font>";
            }
            else if (entity.FinalFlag == 'F')
            {
                this.ltlFinalFlag.Text = "<font color='red'>FAIL</font>";
            }
            this.ltlOperator.Text = entity.Operator;


            this.LVResult.DataSource = entity.FQATxPowerTableItems;
            this.LVResult.DataBind();
        }
    }
}

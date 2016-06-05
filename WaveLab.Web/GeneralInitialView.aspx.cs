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
using Spring.Context;
using Spring.Context.Support;
using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class GeneralInitialView : CommonPage
    {
        private IGeneralInitService generalInitService;
        private GeneralInitInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            generalInitService = (IGeneralInitService)cxt.GetObject("SV.GeneralInitService");

            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["GeneralInitId"]) == false)
                {
                    int generalInitId = int.Parse(Request.QueryString["GeneralInitId"]);
                    entity = generalInitService.GetDetail(generalInitId);
                    LoadDtl();
                }
            }
        }

        private void LoadDtl()
        {
            //this.ltlOrderNo.Text = entity.OrderNo;
            this.ltlModel.Text= entity.Model;
            //this.ltlCode.Text = entity.Code;
            this.ltlSerialNo.Text = entity.SerialNo;
            this.ltlStationNo.Text = entity.StationNo;
            if(entity.EndTime!=null)
            {
                this.ltlEndTime.Text = entity.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            this.ltlTypeLow.Text = entity.TypeLow;
            this.ltlFreqRangeLow.Text = entity.FreqRangeLow;
            this.ltlAlarmLow.Text = entity.AlarmLow;

            this.ltlTypeHigh.Text = entity.TypeHigh;
            this.ltlFreqRangeHigh.Text = entity.FreqRangeHigh;
            this.ltlAlarmHigh.Text = entity.AlarmHigh;

            this.ltlPowerRange.Text = entity.PowerRange;
            this.ltlModeMaxPower.Text = entity.ModeMaxPower;
            this.ltlRSSIOffSet.Text = entity.RSSIOffSet;
            this.ltlPowerOffSet.Text = entity.PowerOffSet;
            this.ltlAging.Text = entity.Aging;
            this.ltlFilterSwitch.Text = entity.FilterSwitch;
            this.ltlNoiseFigure.Text = entity.NoiseFigure;
            this.ltlMaxSupportedBandWidth.Text = entity.MaxSupportedBandWidth;
            this.ltlControledVoltageExt.Text = entity.ControledVoltageExt;
            this.ltlTxTempOffSet.Text = entity.TxTempOffSet;
            this.ltlCleiNo.Text = entity.CleiNo;
            this.ltlHardVersion.Text = entity.HardVersion;
            this.ltlModelNo.Text = entity.ModelNo;

            this.ltlMCUVersion.Text = entity.MCUVersion;
            this.ltlRunningTime.Text = entity.RunningTime;
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
            this.ltlReason.Text = entity.Reason;
        }
    }
}

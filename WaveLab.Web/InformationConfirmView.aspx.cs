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
    public partial class InformationConfirmView : CommonPage
    {
        private IInformationConfirmService confirmService;
        private InformationConfirmInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {

            IApplicationContext cxt = ContextRegistry.GetContext();
            confirmService = (IInformationConfirmService)cxt.GetObject("SV.InformationConfirmService");
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["ConfirmId"]) == false)
                {
                    int conformId = int.Parse(Request.QueryString["ConfirmId"]);
                    entity = confirmService.GetDetail(conformId);
                    LoadDtl();
                }
            }
        }

        private void LoadDtl()
        {
            this.ltlModel.Text = entity.Model;
            this.ltlSerialNo.Text = entity.SerialNo;
            this.ltlStationNo.Text = entity.StationNo;
            this.ltlRunningTime.Text = entity.RunningTime;
            if (entity.EndTime != null)
            {
                this.ltlEndTime.Text = entity.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            this.ltlTypeLow.Text = entity.TypeLow;
            this.ltlTypeHigh.Text = entity.TypeHigh;
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
            this.ltlPowerRange.Text = entity.PowerRange;
            this.ltlFreqRange.Text = entity.FreqRange;
            this.ltlModeMaxPower.Text = entity.ModeMaxPower;
            this.ltlRSSIOffSet.Text = entity.RSSIOffSet;
            this.ltlRSSICHOffSet.Text = entity.RSSICHOffSet;
            this.ltlPowerOffSet.Text = entity.PowerOffSet;
            this.ltlAging.Text = entity.Aging;
            this.ltlFilterSwitch.Text = entity.FilterSwitch;
            this.ltlMCUVersion.Text = entity.MCUVersion;
            this.ltlPartNum.Text = entity.PartNum;
            this.ltlIDNum.Text = entity.IDNum;
            this.ltlTxPll.Text = entity.TxPll;
            this.ltlRxPll.Text = entity.RxPll;
            this.ltlPaI.Text = entity.PaI;
            this.ltlTxPow.Text = entity.TxPow;
            this.ltlNegative5V.Text = entity.Negative5V;
            this.ltlTxIF.Text = entity.TxIf;
            this.ltlControledVoltage.Text = entity.ControledVoltage;
            this.ltlControledVoltageExt.Text = entity.ControledVoltageExt;
            this.ltlTxTempOffSet.Text = entity.TxTempOffSet;
            this.ltlTxPowRange.Text = entity.TxPowRange;
            this.ltlAtpcRange.Text = entity.AtpcRange;
            this.ltlRSSIAlarm.Text = entity.RSSIAlarm;

            this.ltlRemodlo.Text=entity.Remodlo;
            this.ltlTemperature.Text=entity.Temperature;
            this.ltlModelNo.Text=entity.ModelNo;
            this.ltlCleiNo.Text=entity.CleiNo;
            this.ltlIQCIVolt.Text=entity.IQCIVolt;
            this.ltlIQCQVolt.Text=entity.IQCQVolt;
            this.ltlMaufactDate.Text=entity.MaufactDate;
            this.ltlTheHighestMode.Text=entity.TheHighestMode;
            this.ltlTheHighestCapacity.Text=entity.TheHighestCapacity;
            this.ltlOrderingNo.Text=entity.OrderingNo;
            this.ltlAssociatedEclipseVersion.Text=entity.AssociatedEclipseVersion;
            this.ltlMaxSuppurtedBandWidth.Text=entity.MaxSuppurtedBandWidth;
            this.ltlBootLoadVersion.Text=entity.BootLoadVersion;
            this.ltlNoiseFigure.Text=entity.NoiseFigure;
            this.ltlHardWareVersion.Text = entity.HardWareVersion;
            this.ltlReason.Text = entity.Reason;
        }
    }
}

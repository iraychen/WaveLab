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
    public partial class ProtocolInitialView : CommonPage
    {
        private IProtocolInitService ProtocolInitService;
        private ProtocolInitInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            ProtocolInitService = (IProtocolInitService)cxt.GetObject("SV.ProtocolInitService");

            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["ProtocolInitId"]) == false)
                {
                    int protocolInitId = int.Parse(Request.QueryString["ProtocolInitId"]);
                    entity = ProtocolInitService.GetDetail(protocolInitId);
                    LoadDtl();
                }
            }
        }

        private void LoadDtl()
        {
            this.ltlModel.Text = entity.Model;
            this.ltlSerialNo.Text = entity.SerialNo;
            this.ltlRunningTime.Text = entity.RunningTime;
            if (entity.EndTime != null)
            {
                this.ltlEndTime.Text = entity.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            this.ltlTypeLow.Text = entity.TypeLow;
            this.ltlTypeHigh.Text= entity.TypeHigh;
            this.ltlAppVersion.Text=entity.AppVersion ;
            if (entity.FinalFlag == 'P')
            {
                this.ltlFinalFlag.Text = "<font color='green'>PASS</font>";
            }
            else if (entity.FinalFlag == 'F')
            {
                this.ltlFinalFlag.Text = "<font color='red'>FAIL</font>";
            }
            this.ltlOperator.Text=entity.Operator ;
            this.ltlPowerRange.Text=entity.PowerRange;
            this.ltlFreqRangeLow.Text=entity.FreqRangeLow;
            this.ltlFreqRangeHigh.Text = entity.FreqRangeHigh;
            this.ltlModeMaxPower.Text=entity.ModeMaxPower;
            this.ltlRSSIOffSet.Text= entity.RSSIOffSet;
            this.ltlPowerOffSet.Text=entity.PowerOffSet;
            this.ltlAging.Text=entity.Aging;
            this.ltlFilterSwitch.Text=entity.FilterSwitch;
            this.ltlMCUVersion.Text=entity.MCUVersion;
            this.ltlPartNum.Text=entity.PartNum;
            this.ltlIDNum.Text=entity.IDNum ;
            this.ltlTxPllLow.Text=entity.TxPllLow;
            this.ltlRxPllLow.Text=entity.RxPllLow;
            this.ltlPaILow.Text=entity.PaILow;
            this.ltlTxPowLow.Text=entity.TxPowLow;
            this.ltlNegative5VLow.Text=entity.Negative5VLow;
            this.ltlTxIFLow.Text=entity.TxIFLow;
            this.ltlTxPllHigh.Text=entity.TxPllHigh;
            this.ltlRxPllHigh.Text=entity.RxPllHigh;
            this.ltlPaIHigh.Text=entity.PaIHigh ;
            this.ltlTxPowHigh.Text=entity.TxPowHigh ;
            this.ltlNegative5VHigh.Text= entity.Negative5VHigh;
            this.ltlTxIFHigh.Text=entity.TxIFHigh;
            //this.ltlAtpcRange.Text=entity.AtpcRange;
            this.ltlRSSIAlarm.Text=entity.RSSIAlarm;
            this.ltlFactoryInfo.Text = entity.FactoryInfo;
            this.ltlReason.Text = entity.Reason;
        }
    }
}

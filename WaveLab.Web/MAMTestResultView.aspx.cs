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
    public partial class MAMTestResultView : CommonPage
    {
       private IMAMTestResultService MAMTestResultService;
        private MAMTestResultInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            MAMTestResultService = (IMAMTestResultService)cxt.GetObject("SV.MAMTestResultService");

            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["MAMTestResultId"]) == false)
                {
                    int MAMTestResultId = int.Parse(Request.QueryString["MAMTestResultId"]);
                    entity = MAMTestResultService.GetDetail(MAMTestResultId);
                    LoadDtl();
                }
            }
        }

        private void LoadDtl()
        {
            this.ltlType.Text=entity.Type ;
            this.ltlMBSerialNo.Text =entity.MBSerialNo;
            this.ltlPllSerialNo.Text =entity.PLLSerialNo;
            if (entity.EndTime != null){this.ltlEndTime.Text = entity.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");}
           
            this.ltlIFFrequency.Text =entity.IFFrequency;
            this.ltlREVMainBoard.Text=entity.REVMainBoard;
            this.ltlREVPllBoard.Text=entity.REVPLLBoard;
            this.ltlStationNo.Text=entity.StationNo;

            if (entity.TxLoPower.Trim().Length > 0) { this.ltlTxLoPower.Text = String.Format("{0:f3}", Convert.ToDouble(entity.TxLoPower)); }

            this.ltlRxLoPower.Text=entity.RxLoPower;
            this.ltlRxIF10.Text =entity.RxIF10;
            this.ltlRxIFNegative67.Text =entity.RxIFNegative67;
            if (entity.AbsPrxIFOffset.Trim().Length > 0) { this.ltlAbsPrxIFOffSet.Text = String.Format("{0:f1}", Convert.ToDouble(entity.AbsPrxIFOffset)); }
            this.ltlTxIF.Text=entity.TxIF ;
            this.ltlTxIFRange.Text=entity.TXIFRange;
            if (entity.LoOffset.Trim().Length > 0) { this.ltlLoOffset.Text = String.Format("{0:f3}", Convert.ToDouble(entity.LoOffset)); }
            this.ltlRSSIHighLow.Text=entity.RSSIHighLow ;
            this.ltlCtrlVoltage.Text=entity.CtrlVoltage;
            this.ltlHeater.Text=entity.Heater ;
            this.ltlAging.Text=entity.Aging;

            if (entity.FlatTxIF.Trim().Length > 0) { this.ltlFlatTxIF.Text = String.Format("{0:f1}", Convert.ToDouble(entity.FlatTxIF)); }
            if (entity.FlatTxLo.Trim().Length > 0) { this.ltlFlatTxLo.Text = String.Format("{0:f1}", Convert.ToDouble(entity.FlatTxLo)); }
            if (entity.FlatRxIF.Trim().Length > 0) { this.ltlFlatRxIF.Text = String.Format("{0:f1}", Convert.ToDouble(entity.FlatRxIF)); }
  
            this.ltlTxPll.Text=entity.TxPLL;
            this.ltlPAI.Text=entity.PAI;
            this.ltlRxPll.Text=entity.RxPLL;
            this.ltlTxPow.Text=entity.TxPow;
            this.ltlNegative5V.Text=entity.Negative5V;
            this.ltlTxIFResult.Text=entity.TxIFResult;
            this.ltlFirmWareVersion.Text=entity.FirmWareVersion;
            this.ltlBwLowHigh.Text=entity.BwLowHigh;

            this.ltlFSKFreq.Text = entity.FSKFreq;
            this.ltlLoLeakage.Text = entity.LoLeakage;
            this.ltlTemperature.Text = entity.Temperature;
            this.ltlRemodlo.Text = entity.Remodlo;

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

            this.GVDtl.DataSource = entity.DetailItems;
            this.GVDtl.DataBind();

            // Chart Result

            this.chartResult.DataSource = entity.DetailItems;
            this.chartResult.Series["Series1"].YValueMembers = "TxIFSweep";
            this.chartResult.Series["Series2"].YValueMembers = "TxLoSweep";
            this.chartResult.Series["Series3"].YValueMembers = "RxIFSweep";
        }

        protected void chartResult_CustomizeLegend(object sender, CustomizeLegendEventArgs e)
        {
            if (e.LegendName == "Legends1")
            {
                foreach (LegendItem item in e.LegendItems)
                {
                    if (item.SeriesName == "Series1" || item.SeriesName == "Series3" || item.SeriesName == "Series5")
                    {
                        item.ImageStyle = LegendImageStyle.Line;
                    }
                }
            }
        }
    }
}

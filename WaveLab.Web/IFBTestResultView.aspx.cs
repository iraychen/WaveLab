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
    public partial class IFBTestResultView : CommonPage
    {

       private IIFBTestResultService IFBTestResultService;
        private IFBTestResultInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            IFBTestResultService = (IIFBTestResultService)cxt.GetObject("SV.IFBTestResultService");

            if (!Page.IsPostBack)
            {
                int IFBTestResultId = int.Parse(Request.QueryString["IFBTestResultId"]);
                entity = IFBTestResultService.GetDetail(IFBTestResultId);
                LoadDtl();
            }
        }

        private void LoadDtl()
        {
            this.ltlType.Text = entity.Type;
            this.ltlSerialNo.Text = entity.SerialNo;
            if (entity.EndTime != null){this.ltlEndTime.Text = entity.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");}

            this.ltlIFFrequency.Text = entity.IFFrequency;
            this.ltlREV.Text = entity.REV;
            this.ltlTxIF.Text = entity.TxIF;
            this.ltlLoIF.Text = entity.LoIF;
            this.ltlRxIF5.Text = entity.RxIF5;
            this.ltlRxIFNegative65.Text = entity.RxIFNegative65;
            this.ltlAbsRxIFAmpl.Text = entity.AbsRxIFAmpl;

            if (entity.RSSIVolt5.Trim().Length > 0) { this.ltlRSSIVolt5.Text = String.Format("{0:f5}",Convert.ToDouble(entity.RSSIVolt5)); };

            if (entity.RSSIVoltNegative65.Trim().Length > 0) { this.ltlRSSIVoltNegative65.Text = String.Format("{0:f5}", Convert.ToDouble(entity.RSSIVoltNegative65)); };

            this.ltlTxIFRange.Text = entity.TxIFRanne;
            this.ltlLoFrequencyOffset.Text = entity.LoFrequencyOffset;
            this.ltlTxPll.Text = entity.TxPLL;
            this.ltlPAI.Text = entity.PAI;
            this.ltlRxPll.Text = entity.RxPLL;
            this.ltlTxPow.Text = entity.TxPow;
            this.ltlNegative5V.Text = entity.Negative5V;
            this.ltlTxIFResult.Text = entity.TxIFResult;

            this.ltlOperator.Text = entity.Operator;
            this.ltlAppVersion.Text = entity.AppVersion;
            if (entity.FinalFlag == 'P')
            {
                this.ltlFinalFlag.Text = "<font color='green'>PASS</font>";
            }
            else if (entity.FinalFlag == 'F')
            {
                this.ltlFinalFlag.Text = "<font color='red'>FAIL</font>";
            }
           
        }
    }
}

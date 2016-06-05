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
    public partial class MWMTestResultView : CommonPage
    {
       private IMWMTestResultService MWMTestResultService;
        private MWMTestResultInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            MWMTestResultService = (IMWMTestResultService)cxt.GetObject("SV.MWMTestResultService");

            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["MWMTestResultId"]) == false)
                {
                    int MWMTestResultId = int.Parse(Request.QueryString["MWMTestResultId"]);
                    entity = MWMTestResultService.GetDetail(MWMTestResultId);
                    LoadDtl();
                }
            }
        }

        private void LoadDtl()
        {
            this.ltlType.Text=entity.Type ;
            this.ltlSerialNo.Text =entity.SerialNo;
            this.ltlStationNo.Text = entity.StationNo;
            if (entity.EndTime != null){this.ltlEndTime.Text = entity.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");}

            if (entity.TxP1dB.Trim().Length > 0) { this.ltlTxP1dB.Text = String.Format("{0:f7}", Convert.ToDouble(entity.TxP1dB)); }
            if (entity.TxGainFlatness.Trim().Length > 0) { this.ltlTxGainFlatness.Text = String.Format("{0:f2}", Convert.ToDouble(entity.TxGainFlatness)); }
            if (entity.TxLoRejectMin.Trim().Length > 0) { this.ltlTxLoRejectMin.Text = String.Format("{0:f2}", Convert.ToDouble(entity.TxLoRejectMin)); }
            if (entity.TxLoRejectMax.Trim().Length > 0) { this.ltlTxLoRejectMax.Text = String.Format("{0:f2}", Convert.ToDouble(entity.TxLoRejectMax)); }
            if (entity.TxAttnDiff.Trim().Length > 0) { this.ltlTxAttnDiff.Text = String.Format("{0:f2}", Convert.ToDouble(entity.TxAttnDiff)); }
            if (entity.RxGainFlatness.Trim().Length > 0) { this.ltlRxGainFlatness.Text = String.Format("{0:f2}", Convert.ToDouble(entity.RxGainFlatness)); }
            if (entity.CurrentOn5V1.Trim().Length > 0) { this.ltlCurrentOn5V1.Text = String.Format("{0:f2}", Convert.ToDouble(entity.CurrentOn5V1)); }
            if (entity.CurrentOn5V2.Trim().Length > 0) { this.ltlCurrentOn5V2.Text = String.Format("{0:f2}", Convert.ToDouble(entity.CurrentOn5V2)); }
            if (entity.CurrentOn5V3.Trim().Length > 0) { this.ltlCurrentOn5V3.Text = String.Format("{0:f2}", Convert.ToDouble(entity.CurrentOn5V3)); }
            if (entity.CurrentOnHPA.Trim().Length > 0) { this.ltlCurrentOnHPA.Text = String.Format("{0:f2}", Convert.ToDouble(entity.CurrentOnHPA)); }
            if (entity.PwrDVoltage.Trim().Length > 0) { this.ltlPwrDVoltage.Text = String.Format("{0:f2}", Convert.ToDouble(entity.PwrDVoltage)); }
            if (entity.PwrRVoltage.Trim().Length > 0) { this.ltlPwrRVoltage.Text = String.Format("{0:f2}", Convert.ToDouble(entity.PwrRVoltage)); }
            if (entity.RefDVoltage.Trim().Length > 0) { this.ltlRefDVoltage.Text = String.Format("{0:f2}", Convert.ToDouble(entity.RefDVoltage)); }
            if (entity.AbsVerfVpwrDOffset.Trim().Length > 0) { this.ltlAbsVerfVpwrDOffset.Text = String.Format("{0:f2}", Convert.ToDouble(entity.AbsVerfVpwrDOffset)); }

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

            this.chartResult.ChartAreas["ChartArea1"].AxisX.Minimum = entity.DetailItems.Min(item => item.TxIndex);
            this.chartResult.ChartAreas["ChartArea1"].AxisX.Maximum = entity.DetailItems.Max(item => item.TxIndex);

            this.chartResult.Series["Series1"].XValueMember = "TxIndex";
            this.chartResult.Series["Series1"].YValueMembers = "TxGain";

            this.chartResult.Series["Series2"].XValueMember = "TxIndex";
            this.chartResult.Series["Series2"].YValueMembers = "RxIFGain";
        }

 
    }
}

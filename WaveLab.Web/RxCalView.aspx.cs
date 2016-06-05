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
    public partial class RxCalView : CommonPage
    {
        private IRxCalService rxCalService;
        private RxCalInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            rxCalService = (IRxCalService)cxt.GetObject("SV.RxCalService");


            if (!Page.IsPostBack)
            {
                int rxCalId = int.Parse(Request.QueryString["RxCalId"]);
                entity = rxCalService.GetDetail(rxCalId);
                LoadDtl();
            }
        }

        private void LoadDtl()
        {
            this.ltlModel.Text = entity.Model;
            this.ltlSerialNo.Text = entity.SerialNo;

            this.ltlStationNo.Text = entity.StationNo;
            this.ltlChNo.Text = entity.CHNo;
            this.ltlWGNo.Text = entity.WGNo;
            if (entity.EndTime != null)
            {
                this.ltlEndTime.Text = entity.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
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

            this.GVResult.DataSource = entity.RxCalRSSIDetItems;
            this.GVResult.DataBind();

            // Chart Rx Calibrate Result

            if (entity.RxCalRSSIDetItems.Count == 0)
            {
                this.chartRxCalResult.Visible = false;
            }
            else
            {
                this.chartRxCalResult.DataSource = entity.RxCalRSSIDetItems;
                this.chartRxCalResult.Series["Series1"].EmptyPointStyle.BorderWidth = 0;
                this.chartRxCalResult.Series["Series1"].EmptyPointStyle.MarkerStyle = MarkerStyle.None;
                this.chartRxCalResult.Series["Series1"].XValueMember = "Data";
                this.chartRxCalResult.Series["Series1"].YValueMembers = "RSSI";
            }
        }

        protected void chartRxCalResult_CustomizeLegend(object sender, CustomizeLegendEventArgs e)
        {
            if (e.LegendName == "Legends1")
            {
                foreach (LegendItem item in e.LegendItems)
                {
                    if (item.SeriesName == "Series1")
                    {
                        item.ImageStyle = LegendImageStyle.Line;
                        item.MarkerStyle = MarkerStyle.Diamond;
                        item.MarkerSize = 7;
                    }
                }
            }
        }
    }
}

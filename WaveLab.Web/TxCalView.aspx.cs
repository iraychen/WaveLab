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
    public partial class TxCalView : CommonPage
    {
        private ITxCalService txCalService;
        private TxCalInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            txCalService = (ITxCalService)cxt.GetObject("SV.TxCalService");

            if (!Page.IsPostBack)
            {
                int txCalId = int.Parse(Request.QueryString["TxCalid"]);
                entity = txCalService.GetDetail(txCalId);
                LoadDtl();
            }
        }

        private void LoadDtl()
        {
            this.ltlModel.Text = entity.Model;

            this.ltlSerialNo.Text = entity.SerialNo;

            this.ltlTuningPot.Text = entity.TuningPot;
            this.ltlStationNo.Text = entity.StationNo;
            this.ltlChNo.Text = entity.CHNo;
            this.ltlWGNo.Text = entity.WGNo;

            if (entity.EndTime != null)
            {
                this.ltlEndTime.Text = entity.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            this.ltlRunningTime.Text = entity.RunningTime;


            this.ltlAppVersion.Text = entity.AppVersion;
            this.ltlReason.Text = entity.Reason;
            if (entity.FinalFlag == 'P')
            {
                this.ltlFinalFlag.Text = "<font color='green'>PASS</font>";
            }
            else if (entity.FinalFlag == 'F')
            {
                this.ltlFinalFlag.Text = "<font color='red'>FAIL</font>";
            }
            this.ltlOperator.Text = entity.Operator;


            this.LVResult.DataSource = entity.TxCalTableItems;
            this.LVResult.DataBind();

            // Chart Tx Calibrate Power Result
            var txCalPowerResult = from item in entity.TxCalTableItems
                                   where  item.TPSTDbm != null
                                   orderby item.TPSTDbm ascending
                                   select item;
            if (txCalPowerResult.Count() == 0)
            {
                this.chartTxCalPowerResult.Visible = false;
            }
            else
            {
                chartTxCalPowerResult.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                this.chartTxCalPowerResult.DataSource = txCalPowerResult;
             
                this.chartTxCalPowerResult.Series["Series1"].XValueMember = "TPSTDbm";
                this.chartTxCalPowerResult.Series["Series1"].YValueMembers = "TPSTTxPowSetData";
            }
            // Chart Tx Calibrate CH Result
          
            var txCalCHResult = from item in entity.TxCalTableItems
                                where item.ChannelNo != null && (item.ChannelImageFlag=='Y' || item.ChannelImageFlag=='y')
                                orderby item.ChannelNo ascending
                                select item;
         
            if (txCalCHResult.Count() == 0)
            {
                this.chartTxCalCHResult.Visible = false;
            }
            else
            {
                System.Nullable<int> minChannelNo = null, maxChannelNo = null, minChannelOutData = null, maxChannelOutData = null;

                bool atFirstRow = true;

                foreach (TxCalTableInfo item in txCalCHResult)
                {
                    if (atFirstRow == true)
                    {
                        if (item.ChannelNo != null)
                        {
                            minChannelNo = item.ChannelNo.Value;
                            maxChannelNo = item.ChannelNo.Value;
                        }
                        atFirstRow = false;
                    }
                    if (item.ChannelNo < minChannelNo && item.ChannelNo!=null)
                    {
                        minChannelNo = item.ChannelNo.Value;
                    }

                    if (item.ChannelNo > maxChannelNo && item.ChannelNo != null)
                    {
                        maxChannelNo = item.ChannelNo.Value;
                    }
                }

                var dbm15Row = from item in txCalPowerResult
                            where item.TPSTDbm == 15
                            select item;

                IEnumerator iEnum = dbm15Row.GetEnumerator();
                while (iEnum.MoveNext())
                {
                    TxCalTableInfo dbm15Item = (TxCalTableInfo)iEnum.Current;
                    minChannelOutData = dbm15Item.TPSTTxPowSetData-5;
                    maxChannelOutData = dbm15Item.TPSTTxPowSetData + 5;
                }
                
                this.chartTxCalCHResult.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                this.chartTxCalCHResult.ChartAreas["ChartArea1"].AxisX.Minimum = minChannelNo.Value;
                this.chartTxCalCHResult.ChartAreas["ChartArea1"].AxisX.Maximum = maxChannelNo.Value;

                this.chartTxCalCHResult.ChartAreas["ChartArea1"].AxisY.Minimum = minChannelOutData.Value;
                this.chartTxCalCHResult.ChartAreas["ChartArea1"].AxisY.Maximum = maxChannelOutData.Value;

                this.chartTxCalCHResult.DataSource = txCalCHResult;

                this.chartTxCalCHResult.Series["Series1"].XValueMember = "ChannelNo";
                this.chartTxCalCHResult.Series["Series1"].YValueMembers = "ChannelOutData";
            }
        }
    }
}

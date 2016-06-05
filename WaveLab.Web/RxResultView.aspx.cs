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
    public partial class RxResultView :  CommonPage
    {
        private IRxResultService rxResultService;
        private RxResultInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            rxResultService = (IRxResultService)cxt.GetObject("SV.RxResultService");


            if (!Page.IsPostBack)
            {
                int rxResultId = int.Parse(Request.QueryString["RxResultId"]);
                entity = rxResultService.GetDetail(rxResultId);
                LoadDtl();
            }
        }

        private void LoadDtl()
        {
            this.ltlModel.Text = entity.Model;
            this.ltlSerialNo.Text = entity.SerialNo;

            this.ltlStationNo.Text = entity.StationNo;
            this.ltlChannel.Text = entity.Channel;
            this.ltlChNo.Text = entity.CHNo;
            this.ltlWGNo.Text = entity.WGNo;

            if (entity.EndTime != null)
            {
                this.ltlEndTime.Text = entity.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            this.ltlRunningTime.Text = entity.RunningTime;

            this.ltlRXAGC.Text = entity.RXAGC;
            this.ltlRssiOffSet.Text = entity.RSSIOffSet;
            this.ltlNF.Text = entity.NF;
            this.ltlBWLowHigh.Text = entity.BWLowHIgh;
            this.ltlFreq140M.Text = entity.Freq140M;

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

            this.GVResult.DataSource = entity.RxResultPowerLevelItems;
            this.GVResult.DataBind();

            string customer = String.Empty;
            if (String.IsNullOrEmpty(entity.Model) == false)
            {
                customer = entity.Model.Substring(0, 1);
            }
            if (customer == "X")
            {
                this.GVResult.Columns[2].Visible = false;
                this.GVResult.Columns[3].Visible = false;
                this.GVResult.Columns[8].Visible = false;
                this.GVResult.Columns[9].Visible = false;
                this.GVResult.Columns[10].Visible = false;
            }
            else if (customer == "A")
            {
                this.GVResult.Columns[2].Visible = false;
                this.GVResult.Columns[3].Visible = false;

                this.GVResult.Columns[4].Visible = false;
                this.GVResult.Columns[5].Visible = false;
                this.GVResult.Columns[6].Visible = false;
                this.GVResult.Columns[7].Visible = false;

            }
            else
            {
                this.GVResult.Columns[4].Visible = false;
                this.GVResult.Columns[5].Visible = false;
                this.GVResult.Columns[6].Visible = false;
                this.GVResult.Columns[7].Visible = false;
                this.GVResult.Columns[8].Visible = false;
                this.GVResult.Columns[9].Visible = false;
                this.GVResult.Columns[10].Visible = false;

            }
        }
    }
}

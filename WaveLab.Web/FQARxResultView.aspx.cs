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
    public partial class FQARxResultView : CommonPage
    {
        private IFQARxResultService FQARxResultService;
        private FQARxResultInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            FQARxResultService = (IFQARxResultService)cxt.GetObject("SV.FQARxResultService");
            if (!Page.IsPostBack)
            {
                int FQARxResultId = int.Parse(Request.QueryString["FQARxResultId"]);
                entity = FQARxResultService.GetDetail(FQARxResultId);
                LoadDtl();
            }
        }

        private void LoadDtl()
        {
            
            this.ltlModel.Text = entity.Model;
          
            this.ltlSerialNo.Text = entity.SerialNo;

            this.ltlStationNo.Text = entity.StationNo;
            this.ltlCH.Text = entity.CH;
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

            this.GVResult.DataSource = entity.FQARxResultPowerLevelItems;
            this.GVResult.DataBind();
        }
    }
}

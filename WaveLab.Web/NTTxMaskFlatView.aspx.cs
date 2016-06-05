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
    public partial class NTTxMaskFlatView : CommonPage
    {
        private INTTxMaskFlatService NTTxMaskFlatService;
        private NTTxMaskFlatInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            NTTxMaskFlatService = (INTTxMaskFlatService)cxt.GetObject("SV.NTTxMaskFlatService");

            int NTTxMaskFlatId = int.Parse(Request.QueryString["NTTxMaskFlatId"]);
            entity = NTTxMaskFlatService.GetDetail(NTTxMaskFlatId);
            if (!Page.IsPostBack)
            {
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
            this.ltlRunningTime.Text = entity.RunningTime;
            if (entity.EndTime != null)
            {
                this.ltlEndTime.Text = entity.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }

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


            this.GVNTTxMaskFlat.DataSource = entity.NTTxMaskFlatDetailItems;
            this.GVNTTxMaskFlat.DataBind();
        }

    }
}

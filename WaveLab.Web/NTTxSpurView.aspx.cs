﻿using System;
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
    public partial class NTTxSpurView : CommonPage
    {
        private INTTxSpurService NTTxSpurService;
        private NTTxSpurInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
             IApplicationContext cxt = ContextRegistry.GetContext();
            NTTxSpurService = (INTTxSpurService)cxt.GetObject("SV.NTTxSpurService");

            int NTTxSpurId = int.Parse(Request.QueryString["NTTxSpurId"]);
            entity = NTTxSpurService.GetDetail(NTTxSpurId);
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
            this.GVNTTxSpur.DataSource = entity.NTTxSpurDetailItems;
            this.GVNTTxSpur.DataBind();
        }
    }
}

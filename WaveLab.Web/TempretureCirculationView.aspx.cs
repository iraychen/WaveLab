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
    public partial class TempretureCirculationView :  CommonPage
    {
        private ITemCirculationService temCirculationService;
        private TemCirculationInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            temCirculationService = (ITemCirculationService)cxt.GetObject("SV.TemCirculationService");

            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["TemcirculationId"]) == false)
                {
                    int temCirculationId = int.Parse(Request.QueryString["TemcirculationId"]);
                    entity = temCirculationService.GetDetail(temCirculationId);
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
            this.ltlFecCorByteCnt.Text= entity.FecCorByteCnt;
            this.ltlFecUncorBlockCnt.Text=entity.FecUncorBlockCnt ;
            this.ltlMSRDI.Text=entity.MSRDI;
            this.ltlRLOS.Text=entity.RLOS ;
            this.ltlTUAIS.Text=entity.TUAIS ;
            this.ltlRadioRslLow.Text= entity.RadioRslLow ;
            this.ltlRadioRslHigh.Text=entity.RadioRslHigh  ;
            this.ltlRadioTslLow .Text=entity.RadioTslLow  ;
            this.ltlRadioTslHigh.Text=entity.RadioTslHigh  ;
            this.ltlRadioMute.Text=entity.RADIOMUTE ;
            this.ltlPowerAlm.Text=entity.POWERALM ;
            this.ltlHardBad.Text=entity.HARDBAD  ;
            this.ltlTempAlarm.Text=entity.TEMPALARM  ;
            this.ltlIFInpwrAbn.Text=entity.IFINPWRABN  ;
            this.ltlBdStatus.Text=entity.BDSTATUS ;
            this.ltlHpRdi.Text =entity.HPRDI  ;
            this.ltlRloc.Text =entity.RLOC  ;
            this.ltlRoof.Text=entity.ROOF  ;
            this.ltlRlof.Text=entity.RLOF  ;
            this.ltlMwFecUncor.Text=entity.MWFECUNCOR ; 
            this.ltlMwLof.Text=entity.MWLOF ;

            this.ltlCurTxPower.Text=entity.CurTXPower  ;
            this.ltlMaxCurTxPower.Text=entity.MaxCurTXPower  ;
            this.ltlMinTxPower.Text=entity.MinTXPower  ;
            this.ltlMaxTxPower.Text=entity.MaxTXPower ; 
            this.ltlMinTxPower.Text=entity.MinTXPower ;
            this.ltlQPSKSetPower.Text=entity.QPSKSetPower  ;
            this.ltlQPSKPower.Text=entity.QPSKPower  ;
            this.ltlCurRxPower.Text=entity.CurRXPower  ;
            this.ltlMaxCurRxPower.Text=entity.MaxCurRXPower  ;
            this.ltlMinRxPower.Text=entity.MinRXPower  ;
            this.ltlMaxRxPower.Text=entity.MaxRXPower  ;
            this.ltlMinRxPower.Text=entity.MinRXPower ;

            this.ltlES.Text = entity.ES;
            this.ltlSES.Text = entity.SES;
            this.ltlAIS.Text = entity.AIS;

            this.ltlMode.Text=entity.Mode ;
            this.ltlBusinese.Text=entity.Businese ;
            this.ltlIDUType.Text=entity.IDUType ;
        }
    }
}

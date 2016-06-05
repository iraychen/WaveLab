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
using Spring.Context;
using Spring.Context.Support;
using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class MIMeasureDataNew : CommonPage
    {
        private IMIMeasureDataService MIMeasureDataService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            MIMeasureDataService = (IMIMeasureDataService)cxt.GetObject("SV.MIMeasureDataService");

            if (!Page.IsPostBack)
            {
                this.ltlOrderNo.Text = Request.QueryString["key1"].ToString();
                this.ltlCode.Text = Request.QueryString["key2"].ToString();
                this.ltlModel.Text = Request.QueryString["key3"].ToString();
                this.ltlSerialNo.Text = Request.QueryString["key4"].ToString();
            }
        }

        protected void btnPrevStep_Click(object sender, EventArgs e)
        {
            string url = "SerialNoList.aspx?backlink=" +System.Web.HttpUtility.UrlEncode( Request.QueryString["backlink"]);
            Response.Redirect(url);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (MIMeasureDataService.CheckExists(this.ltlSerialNo.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg") + "');</script>");
                return;
            }

            MIMeasureDataInfo entity = new MIMeasureDataInfo();
            entity.SerialNo = this.ltlSerialNo.Text;
            entity.RSSIR1Mode = this.tbxRSSIMode1.Text;
            entity.RSSIR1N20Power = this.tbxNegative120.Text;
            entity.RSSIR1N30Power = this.tbxNegative130.Text;
            entity.RSSIR1N40Power = this.tbxNegative140.Text;
            entity.RSSIR1N50Power = this.tbxNegative150.Text;
            entity.RSSIR1N60Power = this.tbxNegative160.Text;
            entity.RSSIR1N70Power = this.tbxNegative170.Text;
            entity.RSSIR1N80Power = this.tbxNegative180.Text;
            entity.RSSIR1N90Power = this.tbxNegative190.Text;
            entity.RSSIR2Mode = this.tbxRSSIMode2.Text;
            entity.RSSIR2N20Power = this.tbxNegative220.Text;
            entity.RSSIR2N30Power= this.tbxNegative230.Text;
            entity.RSSIR2N40Power = this.tbxNegative240.Text;
            entity.RSSIR2N50Power = this.tbxNegative250.Text;
            entity.RSSIR2N60Power = this.tbxNegative260.Text;
            entity.RSSIR2N70Power = this.tbxNegative270.Text;
            entity.RSSIR2N80Power = this.tbxNegative280.Text;
            entity.RSSIR2N90Power = this.tbxNegative290.Text;
            switch(this.rblRSSIFinalFlag.SelectedValue )
            {
                case "P":
                    entity.RSSIFinalFlag = 'P';
                    break;
                case "F":
                    entity.RSSIFinalFlag = 'F';
                    break;
                default:
                    entity.RSSIFinalFlag = null;
                    break;
            }
            entity.RSSIOperator = this.tbxRSSIOperator.Text.Trim();
            if (this.tbxRSSITestTime.Text.Trim().Length > 0)
            {
                entity.RSSITestTime = DateTime.ParseExact(this.tbxRSSITestTime.Text.Trim(), "yyyy-MM-dd", null);
            }


            entity.SNRMode = this.ddlSNRMode.SelectedValue;
            entity.SNRLocalLeft = this.tbxSNRLocalLeft.Text ;
            entity.SNRIFPoint = this.tbxSNRIFPoint.Text;
            entity.SNRLocalRight = this.tbxSNRLocalRight.Text ;
            switch (this.rblSNRFinalFlag.SelectedValue)
            {
                case "P":
                    entity.SNRFinalFlag = 'P';
                    break;
                case "F":
                    entity.SNRFinalFlag = 'F';
                    break;
                default:
                    entity.SNRFinalFlag = null;
                    break;
            }
            entity.SNROperator = this.tbxSNROperator.Text.Trim();
            if (this.tbxSNRTestTime.Text.Trim().Length > 0)
            {
                entity.SNRTestTime = DateTime.ParseExact(this.tbxSNRTestTime.Text.Trim(), "yyyy-MM-dd", null);
            }

            entity.MicroVibrationMode = this.tbxMicroVibrationMode.Text;
            entity.MicroVibrationErrorCount = this.tbxMicroVibrationErrorCount.Text;
            switch (this.rblMicroVibrationFinalFlag.SelectedValue)
            {
                case "P":
                    entity.MicroVibrationFinalFlag = 'P';
                    break;
                case "F":
                    entity.MicroVibrationFinalFlag = 'F';
                    break;
                default:
                    entity.MicroVibrationFinalFlag = null;
                    break;
            }
            entity.MicroVibrationOperator = this.tbxMicroVibrationOperator.Text.Trim();
            if (this.tbxMicroVibrationTestTime.Text.Trim().Length > 0)
            {
                entity.MicroVibrationTestTime = DateTime.ParseExact(this.tbxMicroVibrationTestTime.Text.Trim(), "yyyy-MM-dd", null);
            }

            entity.AGCMMode = this.tbxAGCMMode.Text;
            entity.AGCMR1Channel = this.tbxAGCMR1Channel.Text;
            entity.AGCMR1UpperLimit = this.tbxAGCMR1UpperLimit.Text;
            entity.AGCMR1UpperAttenuation = this.tbxAGCMR1UpperAttenuation.Text;
            entity.AGCMR1LowerLimit = this.tbxAGCMR1LowerLimit.Text;
            entity.AGCMR1LowerAttenuation = this.tbxAGCMR1LowerAttenuation.Text;
            entity.AGCMR2Channel = this.tbxAGCMR2Channel.Text;
            entity.AGCMR2UpperLimit = this.tbxAGCMR2UpperLimit.Text;
            entity.AGCMR2UpperAttenuation = this.tbxAGCMR2UpperAttenuation.Text;
            entity.AGCMR2LowerLimit = this.tbxAGCMR2LowerLimit.Text;
            entity.AGCMR2LowerAttenuation = this.tbxAGCMR2LowerAttenuation.Text;
            switch (this.rblAGCMFinalFlag.SelectedValue)
            {
                case "P":
                    entity.AGCMFinalFlag = 'P';
                    break;
                case "F":
                    entity.AGCMFinalFlag = 'F';
                    break;
                default:
                    entity.AGCMFinalFlag = null;
                    break;
            }
            entity.AGCMOperator = this.tbxAGCMOperator.Text.Trim();
            if (this.tbxAGCMTestTime.Text.Trim().Length > 0)
            {
                entity.AGCMTestTime = DateTime.ParseExact(this.tbxAGCMTestTime.Text.Trim(), "yyyy-MM-dd", null);
            }

            entity.AGCIPRMode=this.ddlAGCIPRMode.SelectedValue;
            entity.AGCIPRR1Channel = this.tbxAGCIPRR1Channel.Text;
            entity.AGCIPRR1UpperLimit = this.tbxAGCIPRR1UpperLimit.Text;
            entity.AGCIPRR1LowerLimit = this.tbxAGCIPRR1LowerLimit.Text;
            entity.AGCIPRR2Channel = this.tbxAGCIPRR2Channel.Text;
            entity.AGCIPRR2UpperLimit = this.tbxAGCIPRR2UpperLimit.Text;
            entity.AGCIPRR2LowerLimit = this.tbxAGCIPRR2LowerLimit.Text;
            entity.AGCIPRR3Channel = this.tbxAGCIPRR3Channel.Text;
            entity.AGCIPRR3UpperLimit = this.tbxAGCIPR3UpperLimit.Text;
            entity.AGCIPRR3LowerLimit = this.tbxAGCIPR3LowerLimit.Text;
            switch (this.rblAGCIPRFinalFlag.SelectedValue)
            {
                case "P":
                    entity.AGCIPRFinalFlag = 'P';
                    break;
                case "F":
                    entity.AGCIPRFinalFlag = 'F';
                    break;
                default:
                    entity.AGCIPRFinalFlag = null;
                    break;
            }
            entity.AGCIPROperator = this.tbxAGCIPROperator.Text.Trim();
            if (this.tbxAGCIPRTestTime.Text.Trim().Length > 0)
            {
                entity.AGCIPRTestTime = DateTime.ParseExact(this.tbxAGCIPRTestTime.Text.Trim(), "yyyy-MM-dd", null);
            }

            entity.AGCXCRR1Mode = this.tbxAGCXCRR1Mode.Text;
            entity.AGCXCRR1Channel = this.tbxAGCXCRR1Channel.Text;
            entity.AGCXCRR1UpperLimit = this.tbxAGCXCRR1UpperLimit.Text;
            entity.AGCXCRR1LowerLimit = this.tbxAGCXCRR1LowerLimit.Text;
            entity.AGCXCRR2Mode = this.tbxAGCXCRR2Mode.Text;
            entity.AGCXCRR2Channel = this.tbxAGCXCRR2Channel.Text;
            entity.AGCXCRR2UpperLimit = this.tbxAGCXCRR2UpperLimit.Text;
            entity.AGCXCRR2LowerLimit = this.tbxAGCXCR2LowerLimit.Text;
            switch (this.rblAGCXCRFinalFlag.SelectedValue)
            {
                case "P":
                    entity.AGCXCRFinalFlag = 'P';
                    break;
                case "F":
                    entity.AGCXCRFinalFlag = 'F';
                    break;
                default:
                    entity.AGCXCRFinalFlag = null;
                    break;
            }
            entity.AGCXCROperator = this.tbxAGCXCROperator.Text.Trim();
            if (this.tbxAGCXCRTestTime.Text.Trim().Length > 0)
            {
                entity.AGCXCRTestTime = DateTime.ParseExact(this.tbxAGCXCRTestTime.Text.Trim(), "yyyy-MM-dd", null);
            }

            entity.Airtight = this.tbxAirtight.Text;
            switch (this.rblAirtightFinalFlag.SelectedValue)
            {
                case "P":
                    entity.AirtightFinalFlag = 'P';
                    break;
                case "F":
                    entity.AirtightFinalFlag = 'F';
                    break;
                default:
                    entity.AirtightFinalFlag = null;
                    break;
            }
            entity.AirtightOperator = this.tbxAirtightOperator.Text.Trim();
            if (this.tbxAirtightTestTime.Text.Trim().Length > 0)
            {
                entity.AirtightTestTime = DateTime.ParseExact(this.tbxAirtightTestTime.Text.Trim(), "yyyy-MM-dd", null);
            }

            entity.TemG3XMCMode = this.tbxTemG3XMCMode.Text;
            entity.TemG3XMCErrorNo = this.tbxTemG3XMCErrorNo.Text;
            entity.TemG3XMCErrorSeconds = this.tbxTemG3XMCErrorSeconds.Text;
            entity.TemG3XMCAIS = this.tbxTemG3XMCAIS.Text;
            switch (this.rblTemG3XMCFinalFlag.SelectedValue)
            {
                case "P":
                    entity.TemG3XMCFinalFlag = 'P';
                    break;
                case "F":
                    entity.TemG3XMCFinalFlag = 'F';
                    break;
                default:
                    entity.TemG3XMCFinalFlag = null;
                    break;
            }
            entity.TemG3XMCOperator = this.tbxTemG3XMCOperator.Text.Trim();
            if (this.tbxTemG3XMCTestTime.Text.Trim().Length > 0)
            {
                entity.TemG3XMCTestTime = DateTime.ParseExact(this.tbxTemG3XMCTestTime.Text.Trim(), "yyyy-MM-dd", null);
            }

            entity.TemPTNMode = this.ddlTemPTNMode.SelectedValue;
            entity.TemPTNLossRate = this.tbxTemPTNLossRate.Text;
            entity.TemPTNErrorSeconds = this.tbxTemPTNErrorSeconds.Text;
            switch (this.rblTemPTNFinalFlag.SelectedValue)
            {
                case "P":
                    entity.TemPTNFinalFlag = 'P';
                    break;
                case "F":
                    entity.TemPTNFinalFlag = 'F';
                    break;
                default:
                    entity.TemPTNFinalFlag = null;
                    break;
            }
            entity.TemPTNOperator = this.tbxTemPTNOperator.Text.Trim();
            if (this.tbxTemPTNTestTime.Text.Trim().Length > 0)
            {
                entity.TemPTNTestTime = DateTime.ParseExact(this.tbxTemPTNTestTime.Text.Trim(), "yyyy-MM-dd", null);
            }

            entity.TemOML6101LossRate = this.tbxTemOML6101LossRate.Text;
            switch (this.rblTemOML6101FinalFlag.SelectedValue)
            {
                case "P":
                    entity.TemOML6101FinalFlag = 'P';
                    break;
                case "F":
                    entity.TemOML6101FinalFlag = 'F';
                    break;
                default:
                    entity.TemOML6101FinalFlag = null;
                    break;
            }
            entity.TemOML6101Operator = this.tbxTemOML6101Operator.Text.Trim();
            if (this.tbxTemOML6101TestTime.Text.Trim().Length > 0)
            {
                entity.TemOML6101TestTime = DateTime.ParseExact(this.tbxTemOML6101TestTime.Text.Trim(), "yyyy-MM-dd", null);
            }

            entity.TemOML6205TotalError = this.tbxTemOML6205TotalError.Text;
            switch (this.rblTemOML6205FinalFlag.SelectedValue)
            {
                case "P":
                    entity.TemOML6205FinalFlag = 'P';
                    break;
                case "F":
                    entity.TemOML6205FinalFlag = 'F';
                    break;
                default:
                    entity.TemOML6205FinalFlag = null;
                    break;
            }
            entity.TemOML6205Operator = this.tbxTemOML6205Operator.Text.Trim();
            if (this.tbxTemOML6205TestTime.Text.Trim().Length > 0)
            {
                entity.TemOML6205TestTime = DateTime.ParseExact(this.tbxTemOML6205TestTime.Text.Trim(), "yyyy-MM-dd", null);
            }

            entity.TemOML6202TotalError = this.tbxTemOML6202TotalError.Text;
            switch (this.rblTemOML6202FinalFlag.SelectedValue)
            {
                case "P":
                    entity.TemOML6202FinalFlag = 'P';
                    break;
                case "F":
                    entity.TemOML6202FinalFlag = 'F';
                    break;
                default:
                    entity.TemOML6202FinalFlag = null;
                    break;
            }
            entity.TemOML6202Operator = this.tbxTemOML6202Operator.Text.Trim();
            if (this.tbxTemOML6202TestTime.Text.Trim().Length > 0)
            {
                entity.TemOML6202TestTime = DateTime.ParseExact(this.tbxTemOML6202TestTime.Text.Trim(), "yyyy-MM-dd", null);
            }

            entity.FTCMode = this.tbxFTCMode.Text;
            entity.FTCErrorCount = this.tbxFTCErrorNo.Text;
            entity.FTCErrorSeconds = this.tbxFTCErrorSeconds.Text;
            entity.FTCAIS = this.tbxlblFTCAIS.Text;
            switch (this.rblFTCFinalFlag.SelectedValue)
            {
                case "P":
                    entity.FTCFinalFlag = 'P';
                    break;
                case "F":
                    entity.FTCFinalFlag = 'F';
                    break;
                default:
                    entity.FTCFinalFlag = null;
                    break;
            }
            entity.FTCOperator = this.tbxFTCOperator.Text.Trim();
            if (this.tbxFTCTestTime.Text.Trim().Length > 0)
            {
                entity.FTCTestTime = DateTime.ParseExact(this.tbxFTCTestTime.Text.Trim(), "yyyy-MM-dd", null);
            }

            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;

            try
            {
               MIMeasureDataService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

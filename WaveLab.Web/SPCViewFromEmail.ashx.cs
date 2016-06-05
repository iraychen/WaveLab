using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;


using WaveLab.Model;
using WaveLab.IService;


namespace WaveLab.Web
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SPCViewFromEmail : IHttpHandler
    {
        ISYSSecurityMasterService SecurityMasterService;

        public void ProcessRequest(HttpContext context)
        {
            string userId = context.Request.Params["userId"];
            if (string.IsNullOrEmpty(userId) == false && SecurityMasterService.CheckExists(userId) == true)
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(userId, false);
                string projectCode=context.Request.Params["ProjectCode"];
                string errorPK = context.Request.Params["errorPK"];
                switch (projectCode)
                {
                    case "01":
                        context.Response.Redirect("SPCTxPowerView.aspx?key=" + errorPK);
                        break;
                    case "02":
                        context.Response.Redirect("SPCRxPowerView.aspx?key=" + errorPK);
                        break;
                    case "03":
                        context.Response.Redirect("SPCTxMaskFlatView.aspx?key=" + errorPK);
                        break;
                    case "04":
                        context.Response.Redirect("SPCPullingForceWeeklyView.aspx?key=" + errorPK);
                        break;
                    case "05":
                        context.Response.Redirect("SPCPullingForceMonthlyView.aspx?key=" + errorPK);
                        break;
                    case "06":
                        context.Response.Redirect("SPCStationLineLossView.aspx?LineLossPK=" + errorPK);
                        break;
                    case "07":
                        context.Response.Redirect("SPCFixtureReturnLossView.aspx?ReturnLossPK=" + errorPK);
                        break;
                    case "08":
                        context.Response.Redirect("SPCSDPartTxPowerView.aspx?XMRPK=" + errorPK);
                        break;
                    case "09":
                        context.Response.Redirect("SPCSDPartRxPowerView.aspx?XMRPK=" + errorPK);
                        break;
                    case "10":
                        context.Response.Redirect("SPCSDPartRxFreqPointView.aspx?XMRPK=" + errorPK);
                        break;
                    case "11":
                        context.Response.Redirect("SPCSDPartTxLoPOwerView.aspx?XMRPK=" + errorPK);
                        break;
                    case "12":
                        context.Response.Redirect("SPCSDPartRxAGCView.aspx?XMRPK=" + errorPK);
                        break;
                    case "13":
                        context.Response.Redirect("SPCSDPartTxGainView.aspx?XMRPK=" + errorPK);
                        break;
                    case "14":
                        context.Response.Redirect("SPCSDPartRxIFGainView.aspx?XMRPK=" + errorPK);
                        break;
                  
                    default:
                        break;
                }
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("no access right,pls contact to the system administor!");
            }
          
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}

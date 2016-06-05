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
using System.IO;
using Spring.Context;
using Spring.Context.Support;
using WaveLab.Model;
using WaveLab.IService;
using WaveLab.Service;
using WaveLab.Service.Utility;

using SapRfcVbProvider;


namespace WaveLab.Web
{
    public partial class rptConsignProcessExport : CommonPage
    {
        private ISYSFunctionControlService functionControlService ;
        private ISMTCPTemplateService SMTCPTemplateService;
        private ISMTFileInduceService SMTFileInduceService;
        private ISMTConsignProcessSAPService consignProcessSAPService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            functionControlService = (ISYSFunctionControlService)cxt.GetObject("SV.SYSFunctionControlService");
            SMTCPTemplateService = (ISMTCPTemplateService)cxt.GetObject("SV.SMTCPTemplateService");
            consignProcessSAPService = (ISMTConsignProcessSAPService)cxt.GetObject("SV.SMTConsignProcessSAPService");
            SMTFileInduceService = (ISMTFileInduceService)cxt.GetObject("SV.SMTFileInduceService");

            if (!Page.IsPostBack)
            {
                if (functionControlService.GetDetail("CPRPT").Enable != 'Y')
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Lock", WebUtitlity.LockScreen(this.GetLocalResourceObject("rptProhibitMsg").ToString()).ToString());
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //check Template
            SMTCPTemplateInfo template = SMTCPTemplateService.GetExportTemplate();
            if (template == null)
            {
                this.ShowMessage(this.GetLocalResourceObject("templateNotExistsMsg").ToString());
                return;
            }

            bool ODUCPExists = false;
            string aufnr = "",  materialCode = "", materialDesc = "", pcb = "",bdmng = "",vco="";

            //Sap Solution
            string Im_Aufnr=String.Empty;
            if (!string.IsNullOrEmpty(this.tbxAufnr.Text.Trim()))
            {
                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                for (int i = 0; i < 12 - this.tbxAufnr.Text.Trim().Length; i++)
                {
                    builder.Append("0");
                }
                builder.Append(this.tbxAufnr.Text.Trim());
                Im_Aufnr = builder.ToString();
            }

            SapVbProvider sapVbProvider = new SapVbProvider("", ConfigurationManager.AppSettings["SapApplicationServer"],
                                                 ConfigurationManager.AppSettings["SapClient"],
                                                 ConfigurationManager.AppSettings["SapSystemNumber"]);

            bool isLoin = sapVbProvider.ConnectToSAP(ConfigurationManager.AppSettings["SapUser"],
                                     ConfigurationManager.AppSettings["SapPassword"],
                                     ConfigurationManager.AppSettings["SapLanguage"]);

            sapVbProvider.SetFuncName("ZWAVE_PROORDER_INFO");

            sapVbProvider.SetParamName("im_aufnr", Im_Aufnr);

            sapVbProvider.ExecFun();


            if (isLoin == false)
            {
                this.ShowMessage(this.GetLocalResourceObject("ConnectionError").ToString());
                return;
            }
            else
            {
                string result = sapVbProvider.GetOutPutParam("RESULT");
                switch (result)
                {
                    case "0":
                        string plnbez, maktx;

                        string fieldsTopMat = "AUFNR,PLNBEZ,MAKTX";
                        DataTable DTTopMat = sapVbProvider.GetOutPutStructure(fieldsTopMat, "EXP_ZPPS06W", true);
                        aufnr = DTTopMat.Rows[0]["AUFNR"].ToString();
                        plnbez = DTTopMat.Rows[0]["PLNBEZ"].ToString();
                        maktx = DTTopMat.Rows[0]["MAKTX"].ToString();

                        string fieldsProd = "Matnr,MAKTXCOMP,BDMNG,RSPOS";
                        DataTable DTMara = sapVbProvider.GetOutPutTable(fieldsProd, "TAB_COMP", true);
                        for (int i = 0; i < DTMara.Rows.Count; i++)
                        {
                            if (SMTFileInduceService.CheckExists(plnbez, maktx,DTMara.Rows[i]["MAKTXCOMP"].ToString()) == true)
                            {
                                ODUCPExists = true;
                                materialCode = plnbez;
                                materialDesc = maktx;
                                pcb = DTMara.Rows[i]["MAKTXCOMP"].ToString();
                                bdmng = Math.Truncate(decimal.Parse(DTMara.Rows[i]["BDMNG"].ToString())).ToString();
                                break;
                            }
                        }

                        var query = from item in DTMara.AsEnumerable()
                                    where item["MAKTXCOMP"].ToString().Contains("VCO")==true
                                    select item;
                       
                        if (query.AsQueryable().Count()>0)
                        {
                            var VCORow = query.OrderByDescending(x => x["RSPOS"]).First();
                            vco = VCORow["Matnr"].ToString();
                        }
                        //foreach(var row in selectVCORows.)
                        //{
                         //   vco = row["Matnr"].ToString();
                        //}
                       // for (int i = 0; i < DTMara.Rows.Count; i++)
                       //{
                       //    if ( DTMara.Rows[i]["MAKTXCOMP"].ToString().Contains("VCO")==true)
                       //     {
                       //         vco = DTMara.Rows[i]["Matnr"].ToString();
                                //vco = DTMara.Rows[i]["MAKTXCOMP"].ToString(); 
                       //         break;
                       //     }
                       // }
                        break;
                    case "1":
                        this.ShowMessage(this.GetLocalResourceObject("auFnrNotExists").ToString());
                        break;
                    default:
                        break;
                }
                sapVbProvider.DisConnectSAP();
            }
            //Export Excel
            if (ODUCPExists == false)
            {
                this.ShowMessage(this.GetLocalResourceObject("CpNotExists").ToString());
            }
            else
            {
                SMTFileInduceInfo item = SMTFileInduceService.GetDetail(materialCode, materialDesc, pcb);
                MemoryStream ms = consignProcessSAPService.ExportForAufnr(template.DocumentPath, aufnr, bdmng,vco, item);
                Response.ClearHeaders();
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.BinaryWrite(ms.GetBuffer());
                Response.End();
            }
        }

        private void ShowMessage(string message)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script type='text/javascript'>alert('" + message + "');</script>");
        }
    }
}

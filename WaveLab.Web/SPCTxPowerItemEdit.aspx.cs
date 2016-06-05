using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Text;

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class SPCTxPowerItemEdit : CommonPage
    {
        private int TxPowerItemPK;
        private SPCTxPowerItemInfo item;
        private ISPCTxPowerItemService SPCTxPowerItemService;
        private ISYSSecurityMasterService SYSSecurityMasterService;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();          
            SPCTxPowerItemService = (ISPCTxPowerItemService)cxt.GetObject("SV.SPCTxPowerItemService");
            SYSSecurityMasterService = (ISYSSecurityMasterService)cxt.GetObject("SV.SYSSecurityMasterService");

            TxPowerItemPK = int.Parse(Request.QueryString["TxPowerItemPK"]);
            item = SPCTxPowerItemService.Get(TxPowerItemPK);

            if (!Page.IsPostBack)
            {
                if (SYSSecurityMasterService.CheckPerm(Page.User.Identity.Name, "ManageSPC") == false)
                {
                    this.btnViewLog.Visible = false;
                }

                this.ltlType.Text = item.Type;
                this.ltlMode.Text = item.Mode;
                this.ltlCH.Text = item.CH;
                this.ltlPW.Text = item.PW;
                this.tbxSamplingLower.Text = String.Format("{0:f2}", item.SamplingLower);
                this.tbxSamplingUpper.Text = String.Format("{0:f2}", item.SamplingUpper);
                this.tbxLSL.Text = String.Format("{0:f2}", item.LSL);
                this.tbxUSL.Text = String.Format("{0:f2}", item.USL);
                if (item.LCL_X != null)
                {
                    this.tbxLCL_X.Text = String.Format("{0:f2}", item.LCL_X);
                }
                if (item.UCL_X != null)
                {
                    this.tbxUCL_X.Text = String.Format("{0:f2}", item.UCL_X);
                }
                if (item.LCL_R != null)
                {
                    this.tbxLCL_R.Text = String.Format("{0:f2}", item.LCL_R);
                }
                if (item.UCL_R != null)
                {
                    this.tbxUCL_R.Text = String.Format("{0:f2}", item.UCL_R);
                }
                if (item.Enable == 'Y')
                {
                    this.chxEnable.Checked = true;
                }
                else
                {
                    this.chxEnable.Checked = false;
                }
            }
        }
     
        protected void btnSave_Click(object sender, EventArgs e)
        {
            item.SamplingLower = Convert.ToDouble(this.tbxSamplingLower.Text.Trim());
            item.SamplingUpper = Convert.ToDouble(this.tbxSamplingUpper.Text.Trim());
            item.LSL = Convert.ToDouble(this.tbxLSL.Text.Trim());
            item.USL = Convert.ToDouble(this.tbxUSL.Text.Trim());

            if (this.tbxLCL_X.Text.Trim().Length == 0)
            {
                item.LCL_X = null;
            }
            else
            {
                item.LCL_X = Convert.ToDouble(this.tbxLCL_X.Text.Trim());
            }
            if (this.tbxUCL_X.Text.Trim().Length == 0)
            {
                item.UCL_X = null;
            }
            else
            {
                item.UCL_X = Convert.ToDouble(this.tbxUCL_X.Text.Trim());
            }
            if (this.tbxLCL_R.Text.Trim().Length == 0)
            {
                item.LCL_R = null;
            }
            else
            {
                item.LCL_R = Convert.ToDouble(this.tbxLCL_R.Text.Trim());
            }
            if (this.tbxUCL_R.Text.Trim().Length == 0)
            {
                item.UCL_R = null;
            }
            else
            {
                item.UCL_R = Convert.ToDouble(this.tbxUCL_R.Text.Trim());
            }
            if (this.chxEnable.Checked == true)
            {
                item.Enable = 'Y';
            }
            else
            {
                item.Enable = 'N';
            }
            item.LastUpdateDate = DateTime.Now;
            item.LastUpdatedBy = Page.User.Identity.Name;

            try
            {
                SPCTxPowerItemService.Update(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }

        protected void btnViewLog_Click(object sender, EventArgs e)
        {
            Response.Redirect("SPCTxPowerItemLog.aspx?TxPowerItemPK=" + TxPowerItemPK);
        }
    }
}

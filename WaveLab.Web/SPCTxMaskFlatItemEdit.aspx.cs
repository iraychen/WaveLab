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
    public partial class SPCTxMaskFlatItemEdit : CommonPage
    {
        private int TxMaskFlatItemPK;
        private SPCTxMaskFlatItemInfo item;
        private ISPCTxMaskFlatItemService SPCTxMaskFlatItemService;
        private ISYSSecurityMasterService SYSSecurityMasterService;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();          
            SPCTxMaskFlatItemService = (ISPCTxMaskFlatItemService)cxt.GetObject("SV.SPCTxMaskFlatItemService");
            SYSSecurityMasterService = (ISYSSecurityMasterService)cxt.GetObject("SV.SYSSecurityMasterService");

            TxMaskFlatItemPK = int.Parse(Request.QueryString["TxMaskFlatItemPK"]);
            item = SPCTxMaskFlatItemService.Get(TxMaskFlatItemPK);

            if (!Page.IsPostBack)
            {
                if (SYSSecurityMasterService.CheckPerm(Page.User.Identity.Name, "ManageSPC") == false)
                {
                    this.btnViewLog.Visible = false;

                }
                this.ltlType.Text = item.Type;
                this.ltlMode.Text = item.Mode;
                this.ltlCH.Text = item.CH;

                this.tbxSamplingLower.Text = String.Format("{0:f2}", item.SamplingLower);
                this.tbxSamplingUpper.Text = String.Format("{0:f2}", item.SamplingUpper);
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
                SPCTxMaskFlatItemService.Update(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }

        protected void btnViewLog_Click(object sender, EventArgs e)
        {
            Response.Redirect("SPCTxMaskFlatItemLog.aspx?TxMaskFlatItemPK=" + TxMaskFlatItemPK);
        }
    }
}

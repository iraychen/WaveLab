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
    public partial class SPCSDPartMWMEdit : CommonPage
    {
        private ISPCSDPartMWMService SPCSDPartMWMService;
        private int SDPartPK;
        private SPCSDPartMWMInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCSDPartMWMService = (ISPCSDPartMWMService)cxt.GetObject("SV.SPCSDPartMWMService");

            SDPartPK = int.Parse(Request.QueryString["SDPartPK"]);
            entity = SPCSDPartMWMService.Get(SDPartPK);

            if (!Page.IsPostBack)
            {
               
                LoadData();
            }
        }

        private void LoadData()
        {
            this.ltlStationNo.Text = entity.StationNo;
            this.ltlTxIndex.Text = entity.TxIndex;
            this.ltlSerialNo.Text = entity.SerialNo;
            this.tbxLSL_TxGain.Text = string.Format("{0:f2}", entity.LSL_TxGain);
            this.tbxUSL_TxGain.Text = string.Format("{0:f2}", entity.USL_TxGain);
            this.tbxLSL_RxIFGain.Text = string.Format("{0:f2}", entity.LSL_RxIFGain);
            this.tbxUSL_RxIFGain.Text = string.Format("{0:f2}", entity.USL_RxIFGain);
            this.chxEnable.Checked = entity.Enable == 'Y' ? true : false;
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (this.tbxLSL_TxGain.Text.Trim().Length == 0)
            {
                entity.LSL_TxGain = null;
            }
            else
            {
                entity.LSL_TxGain = Convert.ToDouble(this.tbxLSL_TxGain.Text.Trim());
            }
            if (this.tbxUSL_TxGain.Text.Trim().Length == 0)
            {
                entity.USL_TxGain = null;
            }
            else
            {
                entity.USL_TxGain = Convert.ToDouble(this.tbxUSL_TxGain.Text.Trim());
            }
            if (this.tbxLSL_RxIFGain.Text.Trim().Length == 0)
            {
                entity.LSL_RxIFGain = null;
            }
            else
            {
                entity.LSL_RxIFGain = Convert.ToDouble(this.tbxLSL_RxIFGain.Text.Trim());
            }
            if (this.tbxUSL_RxIFGain.Text.Trim().Length == 0)
            {
                entity.USL_RxIFGain = null;
            }
            else
            {
                entity.USL_RxIFGain = Convert.ToDouble(this.tbxUSL_RxIFGain.Text.Trim());
            }
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name.ToUpper();
            entity.Enable = this.chxEnable.Checked==true ? 'Y' :'N';
            try
            {
                SPCSDPartMWMService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

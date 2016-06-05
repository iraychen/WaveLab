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
    public partial class SPCSDPartRxPowerEdit : CommonPage
    {
        private ISPCSDPartRxPowerService SPCSDPartRxPowerService;
        private int SDPartPK;
        private SPCSDPartRxPowerInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCSDPartRxPowerService = (ISPCSDPartRxPowerService)cxt.GetObject("SV.SPCSDPartRxPowerService");

            SDPartPK = int.Parse(Request.QueryString["SDPartPK"]);
            entity = SPCSDPartRxPowerService.Get(SDPartPK);

            if (!Page.IsPostBack)
            {
               
                LoadData();
            }
        }

        private void LoadData()
        {
            this.ltlStationNo.Text = entity.StationNo;
            this.CHNoRow.Visible=entity.Divide == 'Y'?true:false;
            this.ltlCHNo.Text = entity.CHNo;
            this.ltlMode.Text = entity.Mode;
            this.ltlCH.Text = entity.CH;
            this.ltlPW.Text = entity.PW;
            this.ltlSerialNo.Text = entity.SerialNo;
            this.tbxLSL.Text = string.Format("{0:f2}", entity.LSL);
            this.tbxUSL.Text = string.Format("{0:f2}", entity.USL);

            this.chxEnable.Checked = entity.Enable == 'Y' ? true : false;
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (this.tbxLSL.Text.Trim().Length == 0)
            {
                entity.LSL = null;
            }
            else
            {
                entity.LSL = Convert.ToDouble(this.tbxLSL.Text.Trim());
            }
            if (this.tbxUSL.Text.Trim().Length == 0)
            {
                entity.USL = null;
            }
            else
            {
                entity.USL = Convert.ToDouble(this.tbxUSL.Text.Trim());
            }
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name.ToUpper();
            entity.Enable = this.chxEnable.Checked==true ? 'Y' :'N';
            try
            {
                SPCSDPartRxPowerService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

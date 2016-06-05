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
    public partial class SPCSDPartMAMEdit : CommonPage
    {
        private ISPCSDPartMAMService SPCSDPartMAMService;
        private int SDPartPK;
        private SPCSDPartMAMInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCSDPartMAMService = (ISPCSDPartMAMService)cxt.GetObject("SV.SPCSDPartMAMService");

            SDPartPK = int.Parse(Request.QueryString["SDPartPK"]);
            entity = SPCSDPartMAMService.Get(SDPartPK);

            if (!Page.IsPostBack)
            {
               
                LoadData();
            }
        }

        private void LoadData()
        {
            this.ltlStationNo.Text = entity.StationNo;
          
            this.ltlSerialNo.Text = entity.SerialNo;
            this.tbxLSL_TxLoPower.Text = string.Format("{0:f2}", entity.LSL_TxLoPower);
            this.tbxUSL_TxLoPower.Text = string.Format("{0:f2}", entity.USL_TxLoPower);
            this.tbxLSL_RxAGC.Text = string.Format("{0:f2}", entity.LSL_RxAGC);
            this.tbxUSL_RxAGC.Text = string.Format("{0:f2}", entity.USL_RxAGC);
            this.chxEnable.Checked = entity.Enable == 'Y' ? true : false;
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (this.tbxLSL_TxLoPower.Text.Trim().Length == 0)
            {
                entity.LSL_TxLoPower = null;
            }
            else
            {
                entity.LSL_TxLoPower = Convert.ToDouble(this.tbxLSL_TxLoPower.Text.Trim());
            }
            if (this.tbxUSL_TxLoPower.Text.Trim().Length == 0)
            {
                entity.USL_TxLoPower = null;
            }
            else
            {
                entity.USL_TxLoPower = Convert.ToDouble(this.tbxUSL_TxLoPower.Text.Trim());
            }
            if (this.tbxLSL_RxAGC.Text.Trim().Length == 0)
            {
                entity.LSL_RxAGC = null;
            }
            else
            {
                entity.LSL_RxAGC = Convert.ToDouble(this.tbxLSL_RxAGC.Text.Trim());
            }
            if (this.tbxUSL_RxAGC.Text.Trim().Length == 0)
            {
                entity.USL_RxAGC = null;
            }
            else
            {
                entity.USL_RxAGC = Convert.ToDouble(this.tbxUSL_RxAGC.Text.Trim());
            }
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name.ToUpper();
            entity.Enable = this.chxEnable.Checked==true ? 'Y' :'N';
            try
            {
                SPCSDPartMAMService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

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
    public partial class SPCStationLineLossItemCreate :CommonPage
    {
        private ISPCStationLineLossItemService SPCStationLineLossItemService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCStationLineLossItemService = (ISPCStationLineLossItemService)cxt.GetObject("SV.SPCStationLineLossItemService");

            if (!Page.IsPostBack)
            {
               
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SPCStationLineLossItemService.CheckExists(this.tbxStationNo.Text.Trim().ToUpper(),this.tbxCHNo.Text.Trim(),
                this.tbxFrequencyBand.Text.Trim().ToUpper(),this.tbxItem.Text.Trim().ToUpper()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("ExistsMsg") + "');</script>");
                return;
            }

            SPCStationLineLossItemInfo entity = new SPCStationLineLossItemInfo();
            entity.StationNo = this.tbxStationNo.Text.Trim().ToUpper();
            entity.CHNo = this.tbxCHNo.Text.Trim();
            entity.FrequencyBand = this.tbxFrequencyBand.Text.Trim().ToUpper();
            entity.Item = this.tbxItem.Text.Trim().ToUpper();
            entity.MachineInfo = this.tbxMachineInfo.Text.Trim();
            entity.ModifiedLog = this.tbxModifiedLog.Text.Trim();
           
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name.ToUpper();

            try
            {
                SPCStationLineLossItemService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

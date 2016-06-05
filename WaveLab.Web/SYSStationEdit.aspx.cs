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
    public partial class SYSStationEdit : CommonPage
    {
        private ISYSStationService SYSStationService;
        private string stationNo;
        private SYSStationInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSStationService = (ISYSStationService)cxt.GetObject("SV.SYSStationService");

            stationNo = Request.QueryString["StationNo"];
            entity = SYSStationService.Get(stationNo);

            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            this.ltlStationNo.Text = entity.StationNo;
            this.tbxPosition.Text = entity.Position;
          
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            entity.Position = this.tbxPosition.Text.Trim();
           
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name.ToUpper();

            try
            {
                SYSStationService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

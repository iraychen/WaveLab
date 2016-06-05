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
    public partial class SPCFixtureItemCreate : CommonPage
    {
        private ISPCFixtureItemService SPCFixtureItemService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCFixtureItemService = (ISPCFixtureItemService)cxt.GetObject("SV.SPCFixtureItemService");
  
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SPCFixtureItemService.CheckExists(this.tbxFixture.Text.Trim().ToUpper(), this.tbxFrequencyBand.Text.Trim().ToUpper(), this.tbxCH.Text.Trim().ToUpper()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("ExistsMsg") + "');</script>");
                return;
            }

            SPCFixtureItemInfo entity = new SPCFixtureItemInfo();
            entity.Fixture= this.tbxFixture.Text.Trim().ToUpper();
            entity.CH = this.tbxCH.Text.Trim().ToUpper();
            entity.FrequencyBand = this.tbxFrequencyBand.Text.Trim();
 
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name.ToUpper();

            try
            {
                SPCFixtureItemService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

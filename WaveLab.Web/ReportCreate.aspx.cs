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
    public partial class ReportCreate : CommonPage
    {
        private IReportGroupService ReportGroupService;
        private IReportService ReportService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            ReportGroupService = (IReportGroupService)cxt.GetObject("SV.ReportGroupService");
            ReportService = (IReportService)cxt.GetObject("SV.ReportService");

            if (!Page.IsPostBack)
            {
                this.ddlReportGroup.DataSource = ReportGroupService.GetItems();
                this.ddlReportGroup.DataValueField = "GroupCode";
                this.ddlReportGroup.DataTextField = "Descript";
                this.ddlReportGroup.DataBind();
                ListItem firstItem = new ListItem("", "");
                this.ddlReportGroup.Items.Insert(0, firstItem);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ReportService.CheckExists(this.ddlReportGroup.SelectedValue.Trim(), this.tbxTitle.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("ExistsMsg") + "');</script>");
                return;
            }

          
            try
            {
                ReportInfo entity = new ReportInfo();
                entity.GroupCode = this.ddlReportGroup.SelectedValue;
                entity.Title = this.tbxTitle.Text.Trim();
                entity.Url = this.tbxUrl.Text.Trim();

                entity.LastUpdateDate = DateTime.Now;
                entity.LastUpdatedBy = Page.User.Identity.Name.ToUpper();

                ReportService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}

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

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;


namespace WaveLab.Web
{
    public partial class ReportEdit : CommonPage
    {
        private int reportPK;
        private ReportInfo entity;
        private IReportGroupService ReportGroupService;
        private IReportService ReportService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            ReportGroupService = (IReportGroupService)cxt.GetObject("SV.ReportGroupService");
            ReportService = (IReportService)cxt.GetObject("SV.ReportService");

            reportPK = int.Parse(Request.QueryString["ReportPK"]);
            entity = ReportService.GetDetail(reportPK);

            if (!Page.IsPostBack)
            {
                this.ddlReportGroup.DataSource = ReportGroupService.GetItems();
                this.ddlReportGroup.DataValueField = "GroupCode";
                this.ddlReportGroup.DataTextField = "Descript";
                this.ddlReportGroup.DataBind();
                ListItem firstItem = new ListItem("", "");
                this.ddlReportGroup.Items.Insert(0, firstItem);

                LoadInfo();
               
            }
        }
        private void LoadInfo()
        {
            this.ddlReportGroup.SelectedValue = entity.GroupCode;
            this.tbxTitle.Text = entity.Title;
            this.tbxUrl.Text=entity.Url;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                entity.GroupCode = this.ddlReportGroup.SelectedValue;
                entity.Title = this.tbxTitle.Text.Trim();
                entity.Url = this.tbxUrl.Text.Trim();

                entity.LastUpdateDate = DateTime.Now;
                entity.LastUpdatedBy = Page.User.Identity.Name;
                ReportService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }

    }
}

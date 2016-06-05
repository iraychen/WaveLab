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
    public partial class SPCProjectEdit : CommonPage
    {
        private ISPCProjectService SPCProjectService;
        private string ProjectCode;
        private SPCProjectInfo entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCProjectService = (ISPCProjectService)cxt.GetObject("SV.SPCProjectService");

            ProjectCode = Request.QueryString["ProjectCode"];
            entity = SPCProjectService.Get(ProjectCode);

            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            this.ltlProjectCode.Text = entity.ProjectCode;
            this.ltlProjectDesc.Text = entity.ProjectDesc;
            this.tbxMinTimes.Text = entity.MinTimes.ToString();
            this.tbxMaxTimes.Text = entity.MaxTimes.ToString();
            this.tbxGroupingNo.Text = entity.GroupingNo.ToString();
            this.tbxReceiver.Text = entity.Receiver;
            this.tbxCC.Text = entity.CC;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            entity.MinTimes = Convert.ToInt32(this.tbxMinTimes.Text.Trim());
            entity.MaxTimes = Convert.ToInt32(this.tbxMaxTimes.Text.Trim());
            entity.Receiver = this.tbxReceiver.Text.Trim();
            entity.CC = this.tbxCC.Text.Trim();
            if (this.tbxGroupingNo.Text.Trim().Length == 0)
            {
                entity.GroupingNo = null;
            }
            else
            {
                entity.GroupingNo = Convert.ToInt32(this.tbxGroupingNo.Text.Trim());
            }
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name.ToUpper();

            try
            {
                SPCProjectService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tip", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "updateSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }
    }
}
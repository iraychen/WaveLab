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
    public partial class SYSSecurityMasterEdit : CommonPage 
    {
        private string userId;
        private SYSSecurityMasterInfo entity;
        private ISYSSecurityMasterService SecurityMasterService;
        private IItemService itemService;
        private ISYSSectionService sectionService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SecurityMasterService = (ISYSSecurityMasterService)cxt.GetObject("SV.SYSSecurityMasterService");
            itemService = (IItemService)cxt.GetObject("SV.ItemService");
            sectionService = (ISYSSectionService)cxt.GetObject("SV.SYSSectionService");

            userId = Request.QueryString["userid"];
            entity=SecurityMasterService.GetDetail(userId);
            if (!Page.IsPostBack)
            {
                this.GetOptions();
                this.LoadInfo();
                this.btnResetPwd.Attributes.Add("onclick", "return confirm('"+this.GetLocalResourceObject("resetPwdMsg").ToString()+"')");
            }
        }

        private void GetOptions()
        {
           
            this.ddlAdmin.DataSource = itemService.GetItems();
            this.ddlAdmin.DataValueField = "itemValue";
            this.ddlAdmin.DataTextField = "itemText";
            this.ddlAdmin.DataBind();
            this.ddlAdmin.Items.Insert(0, new ListItem("", ""));

            this.ddlActive.DataSource = itemService.GetItems();
            this.ddlActive.DataValueField = "itemValue";
            this.ddlActive.DataTextField = "itemText";
            this.ddlActive.DataBind();
            this.ddlActive.Items.Insert(0, new ListItem("", ""));

            this.ddlSection.DataSource = sectionService.GetItems();
            this.ddlSection.DataValueField = "sectionId";
            this.ddlSection.DataTextField = "sectionDesc";
            this.ddlSection.DataBind();
            this.ddlSection.Items.Insert(0, new ListItem("", ""));
        }

        private void LoadInfo()
        {
            this.lblUserId.Text = entity.UserId;
            this.tbxUserName.Text = entity.UserName;
            ViewState.Add("username", entity.UserName);
            this.ddlAdmin.SelectedValue = entity.Admin;
            this.ddlActive.SelectedValue = entity.Active;
            if(entity.SectionItem!=null)
            {
                this.ddlSection.SelectedValue = entity.SectionItem.SectionId;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.UserName = this.tbxUserName.Text.Trim();
            entity.Admin = this.ddlAdmin.SelectedValue;
            entity.Active = this.ddlActive.SelectedValue;

            SYSSectionInfo sectionItem = new SYSSectionInfo()
            {
                SectionId = this.ddlSection.SelectedValue
            };
            entity.SectionItem = sectionItem;

            try
            {
               SecurityMasterService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Tip", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "updateSuccessMsg") + "');closeWindow('" + System.Web.HttpUtility.UrlDecode(Request.QueryString["backlink"]) + "');</script>");
        }

        protected void btnResetPwd_Click(object sender, EventArgs e)
        {
            string srcPwd = WaveLab.Service.Utility.Encrytor.GenPassWord();
            entity.PassWord = WaveLab.Service.Utility.Encrytor.Encryt(srcPwd);
            entity.LastUpdateDate=DateTime.Now;
            entity.LastUpdatedBy =Page.User.Identity.Name;
            try
            {
                SecurityMasterService.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Response.Redirect("SYSSecuritymasterView.aspx?type=E&userid=" + entity.UserId + "&username=" + ViewState["username"].ToString() + "&pwd=" + srcPwd);
        }
    }
}

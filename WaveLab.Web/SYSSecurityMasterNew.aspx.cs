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
using System.Text;
using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;

namespace WaveLab.Web
{
    public partial class SYSSecurityMasterNew : CommonPage 
    {
        private ISYSSecurityMasterService SecurityMasterService;
        private IItemService itemService;
        private ISYSSectionService sectionService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SecurityMasterService = (ISYSSecurityMasterService)cxt.GetObject("SV.SYSSecurityMasterService");
            itemService = (IItemService)cxt.GetObject("SV.ItemService");
            sectionService = (ISYSSectionService)cxt.GetObject("SV.SYSSectionService");

            if (!Page.IsPostBack)
            {
                this.GetOptions();
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
            this.ddlSection.DataValueField = "SectionId";
            this.ddlSection.DataTextField = "SectionDesc";
            this.ddlSection.DataBind();
            this.ddlSection.Items.Insert(0, new ListItem("", ""));

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SecurityMasterService.CheckExists(this.tbxUserId.Text.Trim()) == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("existsMsg") + "');</script>");
                return;
            }

            SYSSecurityMasterInfo entity = new SYSSecurityMasterInfo();
            entity.UserId = this.tbxUserId.Text.Trim().ToUpper();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.CreationDate = DateTime.Now;
            entity.CreatedBy = Page.User.Identity.Name;

            string srcPwd=WaveLab.Service.Utility.Encrytor.GenPassWord();

            entity.PassWord = WaveLab.Service.Utility.Encrytor.Encryt(srcPwd);
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
               SecurityMasterService.Save(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string url="SYSSecuritymasterView.aspx?type=N&userid=" + entity.UserId + "&username=" + entity.UserName + "&pwd=" + srcPwd;
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>redirect('"+url+"');</script>");
        }
    }
}

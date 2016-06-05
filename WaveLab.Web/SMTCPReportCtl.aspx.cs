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

using WaveLab.IService;
using WaveLab.Model;

namespace WaveLab.Web
{
    public partial class SMTCPReportCtl : CommonPage
    {
        private const string functionId = "CPRPT";
        private ISYSFunctionControlService SYSFunctionControlService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSFunctionControlService = (ISYSFunctionControlService)cxt.GetObject("SV.SYSFunctionControlService");

            if (!Page.IsPostBack)
            {
                if (SYSFunctionControlService.CheckExists(functionId) == false)
                {
                    this.rbtProhibit.Checked = true;
                }
                else
                {
                    SYSFunctionControlInfo entity = SYSFunctionControlService.GetDetail(functionId);
                    if (entity.Enable == 'Y')
                    {
                        this.rbtEnable.Checked = true;
                    }
                    else
                    {
                        this.rbtProhibit.Checked = true;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool existsFlag = SYSFunctionControlService.CheckExists(functionId);

            SYSFunctionControlInfo entity = new SYSFunctionControlInfo();
            entity.FunctionId = functionId;
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            if (this.rbtEnable.Checked == true)
            {
                entity.Enable = 'Y';
            }

            if (this.rbtProhibit.Checked == true)
            {
                entity.Enable = 'N';
            }

            try
            {
                if (existsFlag == false)
                {
                    entity.CreationDate = DateTime.Now;
                    entity.CreatedBy = Page.User.Identity.Name;

                    SYSFunctionControlService.Save(entity);
                }
                else
                {
                    SYSFunctionControlService.Update(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "exists", "<script type='text/javascript'>alert('" + this.GetGlobalResourceObject("globalResource", "saveSuccessMsg") + "');refresh();</script>");
        }
    }
}

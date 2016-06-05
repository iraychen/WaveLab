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
    public partial class SMTCPTemplateNew : CommonPage
    {
        private ISMTCPTemplateService SMTCPTemplateService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SMTCPTemplateService = (ISMTCPTemplateService)cxt.GetObject("SV.SMTCPTemplateService");
     
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string filePath = this.fileUploader.PostedFile.FileName;

            int index = filePath.LastIndexOf(".");
            string ext = filePath.Substring(index).ToUpper();

            if (string.Equals(ext, ".XLS") == true)
            {
                string documentPath = DateTime.Now.ToString("yyyyMMddHHmmssff") + ext;
              
                SMTCPTemplateInfo entity = new SMTCPTemplateInfo();
                entity.EffectiveDate = DateTime.ParseExact(this.tbxEffectiveDate.Text.Trim(), "yyyy-MM-dd", null);
                entity.LastUpdateDate = DateTime.Now;
                entity.LastUpdatedBy = Page.User.Identity.Name;
                entity.CreationDate = DateTime.Now;
                entity.CreatedBy = Page.User.Identity.Name;
                entity.DocumentPath = documentPath;
                try
                {
                    SMTCPTemplateService.Save(entity);
                    this.fileUploader.SaveAs(WaveLab.Service.Setting.sampleExcelPath + documentPath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("uploadSuccessMsg").ToString() + "');goBack();</script>");
            }
            
        }
    }
}

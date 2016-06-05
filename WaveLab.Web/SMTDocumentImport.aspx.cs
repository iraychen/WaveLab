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
using System.IO;

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;
using WaveLab.Service.Utility;

namespace WaveLab.Web
{
    
    public partial class SMTDocumentImport : CommonPage
    {
        private int errorCount;
        private ISMTDocumentService SMTdocumentService;
        private ISMTDocumentImportService SMTDocumentImportService;
        private ISampleTemplateService sampleTemplateService;

        private IEnumerable<String> mutipleItems;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SMTdocumentService = (ISMTDocumentService)cxt.GetObject("SV.SMTDocumentService");
            SMTDocumentImportService = (ISMTDocumentImportService)cxt.GetObject("SV.SMTDocumentImportService");
            sampleTemplateService = (ISampleTemplateService)cxt.GetObject("SV.SampleTemplateService");
        
        }

        #region "DownLoad"
        protected void lbtDocument_Click(object sender, EventArgs e)
        {
            string fileName = sampleTemplateService.GetSampleTemplate("SMT_DOCUMENT_VERSION").DocumentPath;
            string filePath = WaveLab.Service.Setting.sampleExcelPath +fileName  ;
            FileStream stream = new FileStream(filePath, FileMode.Open);
            int count = Convert.ToInt32(stream.Length);
            Byte[] bytes = new Byte[count];
            stream.Read(bytes, 0, count);
            stream.Close();
            Response.ClearHeaders();
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.ContentType = "application/octet-stream";
            Response.Flush();
            Response.BinaryWrite(bytes);
            Response.End();
        }
        #endregion

        #region "Upload"
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string filePath = this.fileUploader.PostedFile.FileName;

            int index = filePath.LastIndexOf(".");
            string ext = filePath.Substring(index).ToUpper();

            if (string.Equals(ext, ".XLS") == true)
            {

                DataTable DT;
                try
                {
                    DT = SMTDocumentImportService.Import(this.fileUploader.FileContent, "Sheet1");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                if (DT.Columns.Count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "templateWrong", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("templateWrongMsg").ToString() + "');</script>");
                    return;
                }

                if (DT.Rows.Count == 0)
                {
                    this.lblRecCount.Text = this.GetLocalResourceObject("noRecordsMsg").ToString();
                    this.lblErrorCount.Visible = false;
                    this.GVList.Visible = false;
                    this.btnImport.Visible = false;
                }
                else
                {
                    
                    this.GVList.Visible = true;
                    this.lblErrorCount.Visible = true;

                    var groupItems = from item in DT.AsEnumerable()
                                   group item by item["DocumentNo"] into temp
                                      select new 
                                      {
                                          DocumentNo = temp.Key,
                                          No_Of_Count=temp.Count()
                                      };
                    mutipleItems = from item in groupItems
                                       where item.No_Of_Count > 1
                                       select item.DocumentNo.ToString();

                    this.GVList.DataSource = DT;
                    this.GVList.DataBind();


                    this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource","total").ToString() + DT.Rows.Count + " " + this.GetGlobalResourceObject("globalResource","records").ToString();
                 
                    this.lblErrorCount.Text = errorCount + this.GetLocalResourceObject("errorRecordsMsg").ToString(); ;

                    if (errorCount == 0)
                    {
                        this.btnImport.Visible = true;
                        this.btnImport.Attributes.Add("onclick", "return confirm('" + this.GetLocalResourceObject("confirmImportMsg").ToString() + "')");
                       
                    }
                   
                }
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                string documentNo, version;
                documentNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DocumentNo"));
                version = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Version"));

               

                Label lblDocumentNo = (Label)e.Row.FindControl("lblDocumentNo");
                lblDocumentNo.Text = documentNo;

                if (documentNo.Length == 0 || documentNo.Length > 50 || version.Length == 0 || version.Length > 2 || mutipleItems.Contains(documentNo))
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    errorCount++;
                }
            }
        }
        #endregion

        #region "Import"
        protected void btnImport_Click(object sender, EventArgs e)
        {
            
            IList<SMTDocumentInfo> items = new List<SMTDocumentInfo>();
            int count = this.GVList.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                SMTDocumentInfo item = new SMTDocumentInfo();
                Label lblDocumentNo = (Label)this.GVList.Rows[i].FindControl("lblDocumentNo");
                item.DocumentNo = WebUtitlity.InputText(lblDocumentNo.Text, 50).Trim();

                item.Version = WebUtitlity.InputText(this.GVList.Rows[i].Cells[1].Text, 2).Trim();

                item.LastUpdateDate = DateTime.Now;
                item.LastUpdatedBy = Page.User.Identity.Name;
                item.CreationDate = DateTime.Now;
                item.CreatedBy = Page.User.Identity.Name;
                items.Add(item);
            }
         
            try
            {
                SMTdocumentService.Import(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("importSuccessMsg").ToString() + "');self.location.href='SMTFileInduceUpdateDVS.aspx';</script>");
        }
        #endregion
      
    }
}

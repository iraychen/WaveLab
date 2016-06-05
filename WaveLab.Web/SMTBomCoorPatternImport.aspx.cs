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
using System.Text;
using System.IO;

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;
using WaveLab.Service.Utility;

namespace WaveLab.Web
{
    public partial class SMTBomCoorPatternImport : CommonPage
    {
        private int existsCount, errorCount;
        private ISMTBomCoorPatternImportService SMTBomCoorPatternImportService;
        private ISMTBomCoorPatternService SMTBomCoorPatternService;
        private ISampleTemplateService sampleTemplateService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SMTBomCoorPatternImportService = (ISMTBomCoorPatternImportService)cxt.GetObject("SV.SMTBomCoorPatternImportService");
            SMTBomCoorPatternService = (ISMTBomCoorPatternService)cxt.GetObject("SV.SMTBomCoorPatternService");
            sampleTemplateService = (ISampleTemplateService)cxt.GetObject("SV.SampleTemplateService");
        
        
        }

        #region "Download SampleExcel"

        protected void lbtSample_Click(object sender, EventArgs e)
        {
            string fileName = sampleTemplateService.GetSampleTemplate("SMT_BOM_COORPATTERN").DocumentPath;
            string filePath = WaveLab.Service.Setting.sampleExcelPath + fileName;
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

        #region "Upload Excel"
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
                    DT = SMTBomCoorPatternImportService.Import(this.fileUploader.FileContent, "Sheet1");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                if (DT.Columns.Count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("templateWrongMsg").ToString() + "');</script>");
                    return;
                }

                if (DT.Rows.Count == 0)
                {
                    this.lblRecCount.Text = this.GetLocalResourceObject("norecords").ToString();
                    this.lblExistsCount.Visible = false;
                    this.lblErrorCount.Visible = false;
                    this.GVList.Visible = false;
                    this.btnImport.Visible = false;
                }
                else
                {
                    this.lblExistsCount.Visible = true;
                    this.lblErrorCount.Visible = true;
                    this.GVList.Visible = true;
                    this.GVList.DataSource = DT;
                    this.GVList.DataBind();

                    this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "total").ToString() + DT.Rows.Count + " " + this.GetGlobalResourceObject("globalResource", "records").ToString();
                    this.lblExistsCount.Text = existsCount + this.GetLocalResourceObject("existsRecordMsg").ToString();
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
                CheckBox cbx = (CheckBox)e.Row.FindControl("check");
                HiddenField hfdExists = (HiddenField)e.Row.FindControl("hfdExists");
                string module, bomDN, bomDVS;
                module =WebUtitlity.InputText(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Module")),50).Trim();
                bomDN = WebUtitlity.InputText(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BomDN")),50).Trim();
                bomDVS = WebUtitlity.InputText(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BomDVS")), 50).Trim();

                if (module.Length == 0 || module.Length > 50 || bomDN.Length == 0 || bomDN.Length > 50 || bomDVS.Length == 0 || bomDVS.Length > 50)
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    cbx.Checked = false;
                    e.Row.Enabled = false;
                    errorCount++;
                }
                else
                {
                    if (SMTBomCoorPatternService.CheckExists(module, bomDN, bomDVS) == true)
                    {
                        e.Row.BackColor = System.Drawing.Color.DarkOrange;
                        cbx.Checked = false;
                        hfdExists.Value = "Y";
                        existsCount++;
                    }
                    else
                    {
                        hfdExists.Value = "N";
                    }
                }
            }
        }

        #endregion

        #region "Import Data"
        protected void btnImport_Click(object sender, EventArgs e)
        {
            int count = this.GVList.Rows.Count;
            IList<SMTBomCoorPatternInfo> newItems = new List<SMTBomCoorPatternInfo>();
            IList<SMTBomCoorPatternInfo> editItems = new List<SMTBomCoorPatternInfo>();
            for (int i = 0; i < count; i++)
            {
                CheckBox chx = (CheckBox)this.GVList.Rows[i].FindControl("check");
                if (chx.Checked == true)
                {
                    HiddenField hfdExists = (HiddenField)this.GVList.Rows[i].FindControl("hfdExists");

                    SMTBomCoorPatternInfo item = new SMTBomCoorPatternInfo();
                    item.Module = WebUtitlity.InputText(this.GVList.Rows[i].Cells[1].Text, 50).Trim();
                    item.BomDN = WebUtitlity.InputText(this.GVList.Rows[i].Cells[2].Text, 50).Trim();
                    item.BomDVS= WebUtitlity.InputText(this.GVList.Rows[i].Cells[3].Text, 50).Trim();
                    item.CoorPattern= WebUtitlity.InputText(this.GVList.Rows[i].Cells[4].Text, 100).Trim();
                    item.LastUpdateDate = DateTime.Now;
                    item.LastUpdatedBy = Page.User.Identity.Name;
                    item.Comments = WebUtitlity.InputText(this.GVList.Rows[i].Cells[5].Text, 100).Trim();
                    if (hfdExists.Value == "N")
                    {
                        item.CreationDate = DateTime.Now;
                        item.CreatedBy = Page.User.Identity.Name;
                        newItems.Add(item);
                    }
                    else
                    {
                        editItems.Add(item);
                    }
                }
            }
            try
            {
                SMTBomCoorPatternService.Import(newItems, editItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("importSuccessMsg").ToString() + "');</script>");
            this.btnImport.Visible = false;
        }
        #endregion

    }
}

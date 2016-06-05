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
using System.Text.RegularExpressions;

using Spring.Context;
using Spring.Context.Support;

using WaveLab.Model;
using WaveLab.IService;
using WaveLab.Service.Utility;

namespace WaveLab.Web
{
    public partial class SPCParametersImport : CommonPage
    {
        private int errorCount;
        private ISPCParameterService SPCParameterService;
        private ISampleTemplateService sampleTemplateService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SPCParameterService = (ISPCParameterService)cxt.GetObject("SV.SPCParameterService");
        }

        #region "DownLoad"
        protected void lbtDocument_Click(object sender, EventArgs e)
        {
            string fileName = sampleTemplateService.GetSampleTemplate("SPC_PARAMETER").DocumentPath;
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
                    DT = SPCParameterService.Upload(this.fileUploader.FileContent, "Sheet1");
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

                    this.GVList.DataSource = DT;
                    this.GVList.DataBind();


                    this.lblRecCount.Text = this.GetGlobalResourceObject("globalResource", "total").ToString() + DT.Rows.Count + " " + this.GetGlobalResourceObject("globalResource", "records").ToString();

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
                string N,A2,D2,D3,D4,A3,C4,B3,B4;
                N = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "N"));
                A2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "A2"));
                D2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "D2"));
                D3 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "D3"));
                D4 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "D4"));
                A3 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "A3"));
                C4 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "C4"));
                B3 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "B3"));
                B4 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "B4"));


                if (Regex.IsMatch(N, @"^\d+$") == false ||
                    (A2.Length >0 && Regex.IsMatch(A2, @"^\d+(\.\d+)?$") == false) ||
                    (D2.Length >0 && Regex.IsMatch(D2, @"^\d+(\.\d+)?$") == false )||
                    (D3.Length >0 && Regex.IsMatch(D3, @"^\d+(\.\d+)?$") == false) ||
                    (D4.Length >0 && Regex.IsMatch(D4, @"^\d+(\.\d+)?$") == false) ||
                    (A3.Length >0 && Regex.IsMatch(A3, @"^\d+(\.\d+)?$") == false) ||
                    (C4.Length >0 && Regex.IsMatch(C4, @"^\d+(\.\d+)?$") == false) ||
                    (B3.Length >0 && Regex.IsMatch(B3, @"^\d+(\.\d+)?$") == false) ||
                    (B4.Length > 0 && Regex.IsMatch(B4, @"^\d+(\.\d+)?$") == false))
                {
                    e.Row.BackColor = System.Drawing.Color.Orange;
                    errorCount++;
                }
            }
        }
        #endregion

        #region "Import"
        protected void btnImport_Click(object sender, EventArgs e)
        {
            IList<SPCParameterInfo> items = new List<SPCParameterInfo>();
            int count = this.GVList.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                SPCParameterInfo item = new SPCParameterInfo();
               
                item.N = Convert.ToInt32(WebUtitlity.InputText(this.GVList.Rows[i].Cells[0].Text, 50).Trim());
                if (WebUtitlity.InputText(this.GVList.Rows[i].Cells[1].Text, 50).Trim().Length == 0)
                {
                    item.A2 =null;
                }
                else
                {
                    item.A2 = Convert.ToDouble(WebUtitlity.InputText(this.GVList.Rows[i].Cells[1].Text, 50).Trim());
                }
                if (WebUtitlity.InputText(this.GVList.Rows[i].Cells[2].Text, 50).Trim().Length == 0)
                {
                    item.D2 = null;
                }
                else
                {
                    item.D2 = Convert.ToDouble(WebUtitlity.InputText(this.GVList.Rows[i].Cells[2].Text, 50).Trim());
                }
                if (WebUtitlity.InputText(this.GVList.Rows[i].Cells[3].Text, 50).Trim().Length == 0)
                {
                    item.D3 = null;
                }
                else
                {
                    item.D3 = Convert.ToDouble(WebUtitlity.InputText(this.GVList.Rows[i].Cells[3].Text, 50).Trim());             
                }
                if (WebUtitlity.InputText(this.GVList.Rows[i].Cells[4].Text, 50).Trim().Length == 0)
                {
                    item.D4 = null;
                }
                else
                {
                    item.D4 = Convert.ToDouble(WebUtitlity.InputText(this.GVList.Rows[i].Cells[4].Text, 50).Trim());
                }
                if (WebUtitlity.InputText(this.GVList.Rows[i].Cells[5].Text, 50).Trim().Length == 0)
                {
                    item.A3= null;
                }
                else
                {
                    item.A3 = Convert.ToDouble(WebUtitlity.InputText(this.GVList.Rows[i].Cells[5].Text, 50).Trim());
                }
                if (WebUtitlity.InputText(this.GVList.Rows[i].Cells[6].Text, 50).Trim().Length == 0)
                {
                    item.C4= null;
                }
                else
                {
                    item.C4 = Convert.ToDouble(WebUtitlity.InputText(this.GVList.Rows[i].Cells[6].Text, 50).Trim());
                }
                if (WebUtitlity.InputText(this.GVList.Rows[i].Cells[7].Text, 50).Trim().Length == 0)
                {
                    item.B3 = null;
                }
                else
                {
                    item.B3 = Convert.ToDouble(WebUtitlity.InputText(this.GVList.Rows[i].Cells[7].Text, 50).Trim());
                }
                if (WebUtitlity.InputText(this.GVList.Rows[i].Cells[8].Text, 50).Trim().Length == 0)
                {
                    item.B4 = null;
                }
                else
                {
                    item.B4 = Convert.ToDouble(WebUtitlity.InputText(this.GVList.Rows[i].Cells[8].Text, 50).Trim());
                }
               
                item.LastUpdateDate = DateTime.Now;
                item.LastUpdatedBy = Page.User.Identity.Name;
               
                items.Add(item);
            }

            try
            {
                SPCParameterService.Import(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("importSuccessMsg").ToString() + "');self.location.href='SPCParametersCtl.aspx';</script>");
        }
        #endregion
    }
}

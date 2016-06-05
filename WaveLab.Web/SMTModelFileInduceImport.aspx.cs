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
    public partial class SMTModelFileInduceImport : CommonPage
    {
        private int existsCount, errorCount;
        private ISYSModuleTypeService SYSModuleTypeService;
     
        private ISMTModelFileInduceService SMTModelFileInduceService;
        private ISampleTemplateService sampleTemplateService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            SYSModuleTypeService = (ISYSModuleTypeService)cxt.GetObject("SV.SYSModuleTypeService");
            SMTModelFileInduceService = (ISMTModelFileInduceService)cxt.GetObject("SV.SMTModelFileInduceService");
            sampleTemplateService = (ISampleTemplateService)cxt.GetObject("SV.SampleTemplateService");

            if (!Page.IsPostBack)
            {
                this.ddlSYSModuleType.DataSource = SYSModuleTypeService.GetItems();
                this.ddlSYSModuleType.DataTextField = "ModuleTypeDesc";
                this.ddlSYSModuleType.DataValueField = "ModuleTypeId";
                this.ddlSYSModuleType.DataBind();
            }
        }

        #region "Download SampleExcel"

        protected void lbtSample_Click(object sender, EventArgs e)
        {
            string fileName = sampleTemplateService.GetSampleTemplate("SMT_MODEL_FILE_INDUCE").DocumentPath;
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

                SYSModuleTypeInfo SYSModuleTypeInfo =new SYSModuleTypeInfo();
                SYSModuleTypeInfo.ModuleTypeId=this.ddlSYSModuleType.SelectedValue;

                DataTable DT;
                try
                {
                   DT = SMTModelFileInduceService.Upload(SYSModuleTypeInfo, this.fileUploader.FileContent, "Sheet1");
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
                CheckBox cbx= (CheckBox)e.Row.FindControl("check");
                HiddenField hfdExists = (HiddenField)e.Row.FindControl("hfdExists");
                string BillSerialNumber, ModuleDesc, PCB;
                BillSerialNumber = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BillSerialNumber"));
                ModuleDesc = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ModuleDesc"));
                PCB=Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PCB"));

                if (BillSerialNumber.Length == 0 || BillSerialNumber.Length >50 ||  ModuleDesc.Length == 0 ||  ModuleDesc .Length > 50 || PCB.Length == 0 || PCB.Length > 50)
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    cbx.Checked = false;
                    e.Row.Enabled = false;
                    errorCount++;
                }
                else
                {

                    SMTModelFileInduceInfo entity = new SMTModelFileInduceInfo();
                    entity.BillSerialNumber = BillSerialNumber;
                    entity.ModuleDesc = ModuleDesc;
                    entity.PCB = PCB;

                    if (SMTModelFileInduceService.CheckExists(entity)==true)
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

        #region "Import "
        protected void btnImport_Click(object sender, EventArgs e)
        {
            int count=this.GVList.Rows.Count ;
            IList<SMTModelFileInduceInfo> newItems = new List<SMTModelFileInduceInfo>();
            IList<SMTModelFileInduceInfo> editItems = new List<SMTModelFileInduceInfo>();
            for (int i=0; i < count; i++)
            {
                CheckBox chx =(CheckBox) this.GVList.Rows[i].FindControl("check");
                if(chx.Checked == true)
                {
                    HiddenField hfdExists = (HiddenField)this.GVList.Rows[i].FindControl("hfdExists");

                    SMTModelFileInduceInfo item = new SMTModelFileInduceInfo();
                    item.ModuleTypeId = this.GVList.DataKeys[i].Values["ModuleTypeId"].ToString();
                    item.BillSerialNumber = WebUtitlity.InputText(this.GVList.Rows[i].Cells[1].Text, 13).Trim();
                    item.ModuleDesc = WebUtitlity.InputText(this.GVList.Rows[i].Cells[2].Text, 40).Trim();
                    item.PCB = WebUtitlity.InputText(this.GVList.Rows[i].Cells[3].Text, 40).Trim();
                    item.SerialNumber = WebUtitlity.InputText(this.GVList.Rows[i].Cells[4].Text, 50).Trim();
                    item.Version = WebUtitlity.InputText(this.GVList.Rows[i].Cells[5].Text, 50).Trim();
                    item.SpeBoard = WebUtitlity.InputText(this.GVList.Rows[i].Cells[6].Text, 50).Trim();
                    item.SpeBoardDN = WebUtitlity.InputText(this.GVList.Rows[i].Cells[7].Text, 50).Trim();
                    item.SpeBoardDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[8].Text, 50).Trim();
                    item.FabricationDN = WebUtitlity.InputText(this.GVList.Rows[i].Cells[9].Text, 50).Trim();
                    item.FabricationDVS = WebUtitlity.InputText(this.GVList.Rows[i].Cells[10].Text, 50).Trim();
                    item.SteelMesh = WebUtitlity.InputText(this.GVList.Rows[i].Cells[11].Text, 50).Trim();
                    item.CoorPattern = WebUtitlity.InputText(this.GVList.Rows[i].Cells[12].Text, 50).Trim();
                    item.Comments = WebUtitlity.InputText(this.GVList.Rows[i].Cells[13].Text, 100).Trim();
                    item.LastUpdateDate = DateTime.Now;
                    item.LastUpdatedBy = Page.User.Identity.Name;
                    if (hfdExists.Value == "N")
                    {
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
                SMTModelFileInduceService.Import(newItems, editItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "<script type='text/javascript'>alert('"+this.GetLocalResourceObject("importSuccessMsg").ToString()+"');</script>");
            this.btnImport.Visible = false;
        }
        #endregion


    }
}

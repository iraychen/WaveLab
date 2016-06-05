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
using System.Text.RegularExpressions;

using Spring.Context;
using Spring.Context.Support;
using WaveLab.Model;
using WaveLab.IService;
using WaveLab.Service.Utility;


namespace WaveLab.Web
{
    public partial class MCTImport : CommonPage
    {
        private IInjurantService injurantService;
        private IMCTImportService mctImportService;
        private IMCTService mctService;
        private ISampleTemplateService sampleTemplateService;

        private int errorCount;
        bool atFirst = true;
        string pastPartNo, pastModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            mctService = (IMCTService)cxt.GetObject("SV.MCTService");
            mctImportService = (IMCTImportService)cxt.GetObject("SV.MCTService");
            sampleTemplateService = (ISampleTemplateService)cxt.GetObject("SV.MCTService");
        }

        #region "Download SampleExcel"

        protected void lbtTemplateDownLoad_Click(object sender, EventArgs e)
        {
            string fileName = sampleTemplateService.GetSampleTemplate("MCT").DocumentPath;
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
                bool pass = true;

                MCTImportInfo mctImport = mctImportService.Import(this.fileUploader.FileContent, "Sheet1");
                if (mctImport.BasicInfo == null || mctImport.ProductSubstanceInfo == null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("templateWrongMsg").ToString() + "');</script>");
                    return;
                }

                this.tblMaterialComposition.Visible = true;
                this.lblSupplierNameVal.Text = Convert.ToString(mctImport.BasicInfo["SupplierName"]);
                this.lblCompletedDateVal.Text =Convert.ToString( mctImport.BasicInfo["CompletedDate"]);
                this.lblDeparmentVal.Text = Convert.ToString(mctImport.BasicInfo["Department"]);
                this.lblCompleteByVal.Text = Convert.ToString(mctImport.BasicInfo["CompletedBy"]);
                this.lblEmailVal.Text = Convert.ToString(mctImport.BasicInfo["Email"]);
                this.lblTelVal.Text = Convert.ToString(mctImport.BasicInfo["Tel"]);
                this.lblFaxVal.Text = Convert.ToString(mctImport.BasicInfo["Fax"]);

                //Check Basic Information Format
                if (this.lblSupplierNameVal.Text.Trim().Length == 0)
                {
                    this.lblSupplierNameKey.BackColor = System.Drawing.Color.Gray;
                    this.lblSupplierNameVal.BackColor = System.Drawing.Color.Gray;
                    errorCount++;
                }
                if ( WebUtitlity.IsDateFormat(this.lblCompletedDateVal.Text.Trim()) == false)
                {
                    this.lblCompletedDateKey.BackColor = System.Drawing.Color.Gray;
                    this.lblCompletedDateVal.BackColor = System.Drawing.Color.Gray;
                    errorCount++;
                }

                if (mctImport.ProductSubstanceInfo.Rows.Count == 0)
                {
                    this.lblRecCount.Text = this.GetLocalResourceObject("norecords").ToString();
                    this.GVList.Visible = false;
                    pass = false;
                }
                else
                {
                    this.GVList.Visible = true;
                    this.GVList.DataSource = mctImport.ProductSubstanceInfo;
                    this.GVList.DataBind();
                }
                //Summary Error Count
                if (errorCount > 0)
                {
                    pass = false;
                }
                if (pass == false)
                {
                    this.btnImport.Visible = false;
                }
                else
                {
                    this.btnImport.Visible = true;
                    this.btnImport.Attributes.Add("onclick", "return confirm('" + this.GetLocalResourceObject("confirmImportMsg").ToString() + "')");
                }
               
            }
        }

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                HiddenField hfdIsPass = (HiddenField)e.Row.FindControl("hfdIsPass");

                string substanceName,substanceMass, casNo, supplierName, partNo, model,contentRate;
                supplierName = this.lblSupplierNameVal.Text.Trim();
                substanceName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SubstanceName"));
                substanceMass = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SubstanceMass"));
                casNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CasNo"));

                //Loop For Get Data
                partNo = WebUtitlity.InputText(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PartNo")), 50).Trim();
                model = WebUtitlity.InputText(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Model")), 50).Trim();
                contentRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ContentRate")).Trim();

                if (partNo.Length == 0 && string.IsNullOrEmpty(pastPartNo) == false)
                {
                    partNo = pastPartNo;
                }

                if (model.Length == 0 && string.IsNullOrEmpty(pastModel) == false)
                {
                    model = pastModel;
                }


                if (
                        atFirst == true || 
                        (
                        atFirst == false && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PartNo")).Length>0 &&
                        string.Equals(pastPartNo, Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PartNo")).Trim()) == false
                        )
                   )
                {
                    pastPartNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PartNo")).Trim();
                    
                }

                if (
                       atFirst == true ||
                       (
                       atFirst == false && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Model")).Length > 0 &&
                       string.Equals(pastModel, Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Model")).Trim()) == false
                       )
                  )
                {
                    pastModel = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Model")).Trim();

                }

               if (atFirst == true)
               {
                   atFirst = false;
               }
                
                //Check Format
               if (partNo.Length == 0 || model.Length == 0 || Regex.IsMatch(substanceMass, @"^\d+(\.\d+)?$") == false ||
                  Regex.IsMatch(contentRate, @"^\d+(\.\d+)?$") == false || (Regex.IsMatch(contentRate, @"^\d+(\.\d+)?$") == true && Convert.ToDouble(contentRate) > 100))
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    hfdIsPass.Value = "N";
                    errorCount++;
                }
                else
                {
                    //Check Injurant
                    if (injurantService.CheckInjuct(substanceName, casNo) == true)
                    {
                        e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
                        e.Row.Cells[6].BackColor = System.Drawing.Color.Red;
                       // hfdIsPass.Value = "N";
                        //errorCount++;
                    }
                   
                    //Check Exists

                    if (mctService.CheckExists(supplierName, partNo, model) == true)
                    {
                        
                        e.Row.Cells[1].BackColor = System.Drawing.Color.DarkOrange;
                        e.Row.Cells[2].BackColor = System.Drawing.Color.DarkOrange;
                        hfdIsPass.Value = "N";
                        errorCount++;

                    }
                    else
                    {
                        hfdIsPass.Value = "Y";
                    }
                   
                }

            }
        }

        #endregion

        #region "Import Data"
        protected void btnImport_Click(object sender, EventArgs e)
        {

            MCTInfo entity = new MCTInfo();
            entity.SupplierName = this.lblSupplierNameVal.Text.Trim();
            if (this.lblCompletedDateVal.Text.Trim().Length >0)
            {
                entity.CompletedDate = DateTime.ParseExact(this.lblCompletedDateVal.Text.Trim(),"yyyy-MM-dd",null);
            }
            
            entity.Department = this.lblDeparmentVal.Text.Trim();
            entity.CompletedBy = this.lblCompleteByVal.Text.Trim();
            entity.Email = this.lblEmailVal.Text.Trim();
            entity.Tel = this.lblTelVal.Text.Trim();
            entity.Fax = this.lblFaxVal.Text.Trim();
            entity.LastUpdateDate = DateTime.Now;
            entity.LastUpdatedBy = Page.User.Identity.Name;
            entity.CreationDate = DateTime.Now;
            entity.CreatedBy = Page.User.Identity.Name;

            //Import Data
            string materialDesc = null, model = null, partNo = null, componentDesc = null, homoMaterialName = null;
            string preMaterialDesc = null, preModel = null, prePartNo = null, preComponentDesc = null, preHomoMaterialName = null;

            int count = this.GVList.Rows.Count;
            IList<MCTDtlInfo> mctDtlItem = new List<MCTDtlInfo>();

            for (int i = 0; i < count; i++)
            {
                HiddenField hfdIsPass = (HiddenField)this.GVList.Rows[i].FindControl("hfdIsPass");
                if (hfdIsPass.Value == "Y" )
                {
                    MCTDtlInfo item = new MCTDtlInfo();

                    //Material Desc
                    Label lblMaterialDesc=(Label)(this.GVList.Rows[i].Cells[0].FindControl("lblMaterialDesc"));
                    materialDesc = WebUtitlity.InputText(lblMaterialDesc.Text, 50).Trim();
                    if (materialDesc.Trim().Length == 0 && string.IsNullOrEmpty(preMaterialDesc) == false)
                    {
                        item.MaterialDesc = preMaterialDesc;
                    }
                    else
                    {
                        item.MaterialDesc = materialDesc;
                    }
                    if (atFirst == true || (atFirst == false && materialDesc.Trim().Length > 0 && string.Equals(preMaterialDesc, materialDesc) == false))
                    {
                        preMaterialDesc = materialDesc;
                    }

                    //Model
                    model = WebUtitlity.InputText(this.GVList.Rows[i].Cells[1].Text, 50).Trim();
                    if (model.Trim().Length == 0 && string.IsNullOrEmpty(preModel) == false)
                    {
                        item.Model = preModel;
                    }
                    else
                    {
                        item.Model = model;
                    }
                    if (atFirst == true || (atFirst == false && model.Trim().Length > 0 && string.Equals(preModel, model) == false))
                    {
                        preModel = model;
                    }
                    //PartNo
                    partNo = WebUtitlity.InputText(this.GVList.Rows[i].Cells[2].Text, 50).Trim();
                    if (partNo.Trim().Length == 0 && string.IsNullOrEmpty(prePartNo) == false)
                    {
                        item.PartNo = prePartNo;
                    }
                    else
                    {
                        item.PartNo = partNo;
                    }
                    if (atFirst == true || (atFirst == false && partNo.Trim().Length > 0 && string.Equals(prePartNo, partNo) == false))
                    {
                        prePartNo = partNo;
                    }

                    //ComponentDesc 
                    componentDesc = WebUtitlity.InputText(this.GVList.Rows[i].Cells[3].Text, 50).Trim();
                    if (componentDesc.Trim().Length == 0 && string.IsNullOrEmpty(preComponentDesc) == false)
                    {
                        item.ComponentDesc = preComponentDesc;
                    }
                    else
                    {
                        item.ComponentDesc = componentDesc;
                    }
                    if (atFirst == true || (atFirst == false && componentDesc.Trim().Length > 0 && string.Equals(preComponentDesc, componentDesc) == false))
                    {
                        preComponentDesc = componentDesc;
                    }
                    //HomoMaterialName
                    homoMaterialName = WebUtitlity.InputText(this.GVList.Rows[i].Cells[4].Text, 50).Trim();
                    if (homoMaterialName.Trim().Length == 0 && string.IsNullOrEmpty(preHomoMaterialName) == false)
                    {
                        item.HomoMaterialName = preHomoMaterialName;
                    }
                    else
                    {
                        item.HomoMaterialName = homoMaterialName;
                    }
                    if (atFirst == true || (atFirst == false && homoMaterialName.Trim().Length > 0 && string.Equals(preHomoMaterialName, homoMaterialName) == false))
                    {
                        preHomoMaterialName = homoMaterialName;
                    }

                    if (atFirst == true)
                    {
                        atFirst = false;
                    }

                    item.SubstanceName = WebUtitlity.InputText(this.GVList.Rows[i].Cells[5].Text, 50).Trim();
                    item.CASNo = WebUtitlity.InputText(this.GVList.Rows[i].Cells[6].Text, 50).Trim();
                    item.SubstanceMass = double.Parse(WebUtitlity.InputText(this.GVList.Rows[i].Cells[7].Text, 50).Trim());
                    item.ContentRate = double.Parse(WebUtitlity.InputText(this.GVList.Rows[i].Cells[8].Text, 50).Trim());
                    //item.Comment = WebUtitlity.InputText(this.GVList.Rows[i].Cells[9].Text, 100).Trim();
                
                    item.LastUpdateDate = DateTime.Now;
                    item.LastUpdatedBy = Page.User.Identity.Name;
                    item.CreationDate = DateTime.Now;
                    item.CreatedBy = Page.User.Identity.Name;
                    mctDtlItem.Add(item);
                }
            }

            entity.MCTDtlItem = mctDtlItem;

            try
            {
                mctService.Save(entity) ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "<script type='text/javascript'>alert('" + this.GetLocalResourceObject("importSuccessMsg").ToString() + "');</script>");
            this.btnImport.Visible = false;
        }
        #endregion
    }
}

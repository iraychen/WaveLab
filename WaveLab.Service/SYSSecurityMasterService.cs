using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WaveLab.Service
{
    public class SYSSecurityMasterService:ISYSSecurityMasterService
   {

       public ISYSSecurityMaster dal;

       #region For Login
       public bool CheckExists(string userId)
       {
           return dal.CheckExists(userId);
       }
       public  bool CheckPWD(string userId, string passWord)
       {
           return dal.CheckPWD(userId, passWord);
       }
       public  bool CheckActive(string userId)
       {
           return dal.CheckActive(userId);
       }
       public bool IsAdmin(string userId)
       {
           return dal.IsAdmin(userId);
       }

       public IList<int> GetACMenu(string userId)
       {
           return dal.GetACMenu(userId);
       }
       #endregion

       #region Basic Operation
       public IList<SYSSecurityMasterInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
       {
           return dal.Query(hashTable, sortBy, orderBy);
       }

       public  void Save(SYSSecurityMasterInfo entity)
       {
           dal.Save(entity);
       }

       public SYSSecurityMasterInfo GetDetail(string userId)
       {
           return dal.GetDetail(userId);
       }

       public void Update(SYSSecurityMasterInfo entity)
       {
           dal.Update(entity);
       }

       public IList<SYSRoleInfo> GetRoles(string userId)
       {
           return dal.GetRoles(userId);
       }

       public void SaveRoleMapping(string userId, IList<SYSRoleInfo> roleItems)
       {
           dal.SaveRoleMapping(userId, roleItems);
       }

       public bool CheckPerm(string UserId, string op)
       {
           return dal.CheckPerm(UserId, op);
       }
       #endregion

       #region Export PDF
       public Byte[] ExportToPdf(string userId, string userName, string passWord)
       {
           string filePath = Setting.TempFilePath + Common.GetTempFileName(".pdf");
           FileStream stream = new FileStream(filePath, FileMode.Create);
           Document document = new Document(PageSize.A5, -10, -10, 0, 0);

           PdfWriter writer = PdfWriter.GetInstance(document, stream);

           //Header
           Phrase headerPhrase = new Phrase();
           PdfPTable headerTable = new PdfPTable(2);
           headerTable.SetWidths(new float[] { 0.6F, 0.4F });

           Helper.PDFHelper.PDFAddCell(headerTable, Convert.ToString((char)13), 2, 0, "L", Helper.PDFHelper.SimSunFont12);

           Image headerImage = Image.GetInstance(Setting.ImagesPath + "logo_bg_white.jpg");
           headerImage.BorderWidth = 0;
           headerImage.ScaleAbsolute(100, 50);
           PdfPCell headerImageCell = new PdfPCell();
           headerImageCell.BorderWidth = 0;
           headerImageCell.AddElement(headerImage);
           headerTable.AddCell(headerImageCell);

           Helper.PDFHelper.PDFAddCell(headerTable, Convert.ToString((char)13), 1, 0, "L", Helper.PDFHelper.SimSunFont14);

           PdfPCell headerLineCell = new PdfPCell();
           headerLineCell.BorderWidthTop = 1;
           headerLineCell.BorderWidthRight = 0;
           headerLineCell.BorderWidthBottom = 0;
           headerLineCell.BorderWidthLeft = 0;
           headerLineCell.Colspan = 2;
           headerTable.AddCell(headerLineCell);

           headerPhrase.Add(headerTable);

           iTextSharp.text.HeaderFooter header = new HeaderFooter(headerPhrase, true);
           header.Border = 0;
           document.Header = header;


           document.Open();
           try
           {
               //Content
               PdfPTable pdfInnerTable = new PdfPTable(2);
               Helper.PDFHelper.PDFAddCell(pdfInnerTable, Convert.ToString((char)13), 2, 0, "L", Helper.PDFHelper.SimSunFont14);
               pdfInnerTable.SetWidths(new float[] { 0.2F, 0.8F });
               Helper.PDFHelper.PDFAddCell(pdfInnerTable, userName, 1, 0, "C", Helper.PDFHelper.SimSunFontUnderLine14);
               Helper.PDFHelper.PDFAddCell(pdfInnerTable, " 先生/女士:", 1, 0, "L", Helper.PDFHelper.SimSunFont14);

               document.Add(pdfInnerTable);

               PdfPTable pdfTable = new PdfPTable(4);
               pdfTable.SetWidths(new float[] { 0.2F, 0.3F, 0.3F, 0.2F });
               pdfTable.DefaultCell.BorderWidth = 0;

               Helper.PDFHelper.PDFAddCell(pdfTable, Convert.ToString((char)13), 4, 0, "L", Helper.PDFHelper.SimSunFont14);
               Helper.PDFHelper.PDFAddCell(pdfTable, Convert.ToString((char)13), 4, 0, "L", Helper.PDFHelper.SimSunFont14);

               Helper.PDFHelper.PDFAddCell(pdfTable, "    你好，欢迎使用产线数据库管理系统，你可凭借以", 4, 0, "L", Helper.PDFHelper.SimSunFont14);
               Helper.PDFHelper.PDFAddCell(pdfTable, Convert.ToString((char)13), 4, 0, "L", Helper.PDFHelper.SimSunFont14);
               Helper.PDFHelper.PDFAddCell(pdfTable, "下的用户名与密码，登录到该系统中.请妥善保管，并注", 4, 0, "L", Helper.PDFHelper.SimSunFont14);
               Helper.PDFHelper.PDFAddCell(pdfTable, Convert.ToString((char)13), 4, 0, "L", Helper.PDFHelper.SimSunFont14);
               Helper.PDFHelper.PDFAddCell(pdfTable, "意保密,切记不可将账号转给他人使用。如有问题，请联", 4, 0, "L", Helper.PDFHelper.SimSunFont14);
               Helper.PDFHelper.PDFAddCell(pdfTable, Convert.ToString((char)13), 4, 0, "L", Helper.PDFHelper.SimSunFont14);
               Helper.PDFHelper.PDFAddCell(pdfTable, "系系统管理员,谢谢！", 4, 0, "L", Helper.PDFHelper.SimSunFont14);

               Helper.PDFHelper.PDFAddCell(pdfTable, Convert.ToString((char)13), 4, 0, "L", Helper.PDFHelper.SimSunFont14);
               Helper.PDFHelper.PDFAddCell(pdfTable, Convert.ToString((char)13), 4, 0, "L", Helper.PDFHelper.SimSunFont14);
               Helper.PDFHelper.PDFAddCell(pdfTable, "网  址: ", 1, 0, "R", Helper.PDFHelper.SimSunFont14);
               Helper.PDFHelper.PDFAddCell(pdfTable, ConfigurationManager.AppSettings["WebUrl"]+"/Login.aspx", 3, 0, "L", Helper.PDFHelper.SimSunFontItalic13);

               Helper.PDFHelper.PDFAddCell(pdfTable, Convert.ToString((char)13), 4, 0, "L", Helper.PDFHelper.SimSunFont14);


               Helper.PDFHelper.PDFAddCell(pdfTable, "用户名: ", 1, 0, "R", Helper.PDFHelper.SimSunFont14);
               Helper.PDFHelper.PDFAddCell(pdfTable, userId.ToLower(), 3, 0, "L", Helper.PDFHelper.SimSunFontItalic13);

               Helper.PDFHelper.PDFAddCell(pdfTable, Convert.ToString((char)13), 4, 0, "L", Helper.PDFHelper.SimSunFont14);

               Helper.PDFHelper.PDFAddCell(pdfTable, "密  码: ", 1, 0, "R", Helper.PDFHelper.SimSunFont14);
               Helper.PDFHelper.PDFAddCell(pdfTable, passWord, 3, 0, "L", Helper.PDFHelper.SimSunFontItalic13);

               Helper.PDFHelper.PDFAddCell(pdfTable, Convert.ToString((char)13), 4, 0, "L", Helper.PDFHelper.SimSunFont14);

               for (int i = 0; i <= 6; i++)
               {
                   Helper.PDFHelper.PDFAddCell(pdfTable, Convert.ToString((char)13), 4, 0, "L", Helper.PDFHelper.SimSunFont14);
               }
               document.Add(pdfTable);


               //Footer
             
               PdfPTable footerTable = new PdfPTable(2);
               footerTable.SetWidths(new float[] { 0.5F, 0.5F });
               PdfPCell footerLineCell = new PdfPCell();
               footerLineCell.BorderWidthTop = 1;
               footerLineCell.BorderWidthRight = 0;
               footerLineCell.BorderWidthBottom = 0;
               footerLineCell.BorderWidthLeft = 0;
               footerLineCell.Colspan = 2;
               footerTable.AddCell(footerLineCell);

               Helper.PDFHelper.PDFAddCell(footerTable,"波达通讯设备（广州）有限公司", 1, 0, "L", Helper.PDFHelper.SimSunFont12);
               Helper.PDFHelper.PDFAddCell(footerTable, "生效日期：" + DateTime.Now.ToString("yyyy-MM-dd"), 1, 0, "R", Helper.PDFHelper.SimSunFont12);

               document.Add(footerTable);

           }
           catch
           {

           }
           finally
           {
               document.Close();
               stream.Close();
           }
           FileStream outstream = new FileStream(filePath, FileMode.Open);
           int count = Convert.ToInt32(outstream.Length);
           Byte[] bytes = new Byte[count];
           outstream.Read(bytes, 0, count);
           outstream.Close();
           if (File.Exists(filePath) == true)
           {
               System.IO.File.Delete(filePath);
           }
           return bytes;

       }
       #endregion
   }
}

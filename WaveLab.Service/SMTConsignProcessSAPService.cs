using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.HSSF.UserModel.Contrib;
using NPOI.SS.Util;
using NPOI.SS.UserModel;

namespace WaveLab.Service
{
    public class SMTConsignProcessSAPService : ISMTConsignProcessSAPService
    {
       public ISMTPCBSteelMesh pcbSteelMesh;
       public ISMTBomCoorPattern bomCoorPattern;
       public ISYSSerialNoGenerator serialNoGenerator;

       public  MemoryStream ExportForAufnr(string templateFileName,string aufnr,string bdmng,string vco,SMTFileInduceInfo item)
       {
           //string sheetName = aufnr;

           FileStream stream = new FileStream(Setting.sampleExcelPath + templateFileName, FileMode.Open, FileAccess.Read);
           HSSFWorkbook workbook = new HSSFWorkbook(stream);
           Sheet sheet = workbook.GetSheetAt(0);

           //Serial No
           if (sheet.GetRow(2).GetCell(6) == null)
           {
               sheet.GetRow(2).CreateCell(6);
           }
           string serianNoValue = serialNoGenerator.GenerateSerialNo("CPR");
           if (string.IsNullOrEmpty(serianNoValue)==false)
           {
               sheet.GetRow(2).GetCell(6).CellStyle = Helper.ExcelHelper.GetDateCellStyle(workbook, 12);
               sheet.GetRow(2).GetCell(6).SetCellValue(serianNoValue);
               sheet.AddMergedRegion(new CellRangeAddress(2, 2, 6, 7));
           }
         

           if (sheet.GetRow(3).GetCell(6) == null)
           {
               sheet.GetRow(3).CreateCell(6);
           }
           sheet.GetRow(3).GetCell(6).CellStyle = Helper.ExcelHelper.GetDateCellStyle(workbook, 12);
           sheet.GetRow(3).GetCell(6).SetCellValue(DateTime.Now);
           sheet.AddMergedRegion(new CellRangeAddress(3, 3, 6, 7));

           sheet.GetRow(5).GetCell(1).CellStyle = Helper.ExcelHelper.GetNumberCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 12, 1, 1, 1, 1,"0");
           sheet.GetRow(5).GetCell(1).SetCellType(CellType.NUMERIC);
           sheet.GetRow(5).GetCell(1).SetCellValue(int.Parse(aufnr));

           sheet.GetRow(5).GetCell(2).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 12, 1, 1, 1, 1);
           sheet.GetRow(5).GetCell(2).SetCellValue(item.MaterialCode);

           sheet.GetRow(5).GetCell(3).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 12, 1, 1, 1, 1);
           sheet.GetRow(5).GetCell(3).SetCellValue(item.ModuleTypeItem.ModuleTypeDesc);

           sheet.GetRow(5).GetCell(4).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 12, 1, 1, 1, 1);
           sheet.GetRow(5).GetCell(4).SetCellValue(item.MaterialDesc);

           sheet.GetRow(5).GetCell(6).CellStyle = Helper.ExcelHelper.GetNumberCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 12, 1, 1, 1, 1, "0");
           sheet.GetRow(5).GetCell(6).SetCellType(CellType.NUMERIC);
           sheet.GetRow(5).GetCell(6).SetCellValue(int.Parse(bdmng));

           sheet.GetRow(8).GetCell(2).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 0);
           sheet.GetRow(8).GetCell(2).SetCellValue(item.PCB);

          
           sheet.GetRow(8).GetCell(5).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 0);
           sheet.GetRow(8).GetCell(5).SetCellValue(vco);

           sheet.AddMergedRegion(new CellRangeAddress(8, 8, 2, 3));
           if (Convert.ToString(item.GenBoardDN).Trim().Length > 0 || Convert.ToString(item.GenBoardDVS).Trim().Length > 0)
           {
               sheet.GetRow(20).GetCell(2).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 1);
               sheet.GetRow(20).GetCell(2).SetCellValue(item.GenBoardDN + "/" + item.GenBoardDVS);
           }
           if (Convert.ToString(item.SpeBoardDN).Trim().Length > 0 || Convert.ToString(item.SpeBoardDVS).Trim().Length > 0)
           {
               sheet.GetRow(20).GetCell(4).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 1, 1, 1);
               sheet.GetRow(20).GetCell(4).SetCellValue(item.SpeBoardDN + "/" + item.SpeBoardDVS);
           }
           if (Convert.ToString(item.SMTFabricationDN).Trim().Length > 0 || Convert.ToString(item.SMTFabricationDVS).Trim().Length > 0)
           {
               sheet.GetRow(21).GetCell(2).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 1);
               sheet.GetRow(21).GetCell(2).SetCellValue(item.SMTFabricationDN + "/" + item.SMTFabricationDVS);

           }

           if(bomCoorPattern.CheckExists(item.GenBoard, item.GenBoardDN, item.GenBoardDVS)==true)
           {
               SMTBomCoorPatternInfo bomCoorPatternEntity = bomCoorPattern.GetDetail(item.GenBoard, item.GenBoardDN, item.GenBoardDVS);
               if (string.IsNullOrEmpty(bomCoorPatternEntity.CoorPattern) == false)
               {
                   sheet.GetRow(22).GetCell(3).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 0);
                   sheet.GetRow(22).GetCell(3).SetCellValue(bomCoorPatternEntity.CoorPattern);
               }
           }
           
           if (string.IsNullOrEmpty(item.Comments) == false)
           {
               sheet.GetRow(23).GetCell(1).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 0);
               sheet.GetRow(23).GetCell(1).SetCellValue(item.Comments);
           }

           if(pcbSteelMesh.CheckExists(item.PCB)==true)
           {
               SMTPCBSteelMeshInfo pcbSteelMeshEntity=pcbSteelMesh.GetDetail(item.PCB);
               if (string.IsNullOrEmpty(pcbSteelMeshEntity.SteelMesh) == false)
               {
                   sheet.GetRow(24).GetCell(3).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 0);
                   sheet.GetRow(24).GetCell(3).SetCellValue(pcbSteelMeshEntity.SteelMesh);
               }
           }

           MemoryStream ms = new MemoryStream();
           workbook.Write(ms);
           workbook = null;
           return ms;

       }

        //public  MemoryStream Export(string templateFileName,List<ConsignProcessInfo> items)
        //{
        //     string sheetName = "Sheet";

        //     FileStream stream = new FileStream(Setting.sampleExcelPath + templateFileName, FileMode.Open, FileAccess.Read);
        //     HSSFWorkbook workbook = new HSSFWorkbook(stream);

        //     int i;
        //     for (i = 1; i <= items.Count - 1; i++)
        //     {
        //         workbook.CloneSheet(0);
        //     }

        //    for(i=0;i<=items.Count -1;i++)
        //    {
        //        workbook.SetSheetName(i, sheetName+(i + 1).ToString());
        //    }
        //    for (int count = 0;count <= items.Count - 1; count++)
        //    {
        //        ConsignProcessInfo item = items[count];
        //        Sheet activeSheet = workbook.GetSheetAt(count);


        //        if (activeSheet.GetRow(3).GetCell(6) == null)
        //        {
        //            activeSheet.GetRow(3).CreateCell(6);
        //        }
        //        activeSheet.GetRow(3).GetCell(6).CellStyle = Helper.ExcelHelper.GetDateCellStyle(workbook, 12);
        //        activeSheet.GetRow(3).GetCell(6).SetCellValue(DateTime.Now);
        //        activeSheet.AddMergedRegion(new CellRangeAddress(3, 3, 6, 7));

        //        activeSheet.GetRow(5).GetCell(2).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook,Helper.ExcelHelper.NormalColor, 'C', 12, 1, 1, 1, 1);
        //        activeSheet.GetRow(5).GetCell(2).SetCellValue(item.MaterialCode);

        //        activeSheet.GetRow(5).GetCell(3).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 12, 1, 1, 1, 1);
        //        activeSheet.GetRow(5).GetCell(3).SetCellValue(item.ModuleTypeItem.ModuleTypeDesc);

        //        activeSheet.GetRow(5).GetCell(4).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 12, 1, 1, 1, 1);
        //        activeSheet.GetRow(5).GetCell(4).SetCellValue(item.MaterialDesc);

        //        activeSheet.GetRow(8).GetCell(2).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 0);
        //        activeSheet.GetRow(8).GetCell(2).SetCellValue(item.PCB);
        //        activeSheet.AddMergedRegion(new CellRangeAddress(8, 8, 2, 3));
        //        if (Convert.ToString(item.GenBoardDN).Trim().Length > 0 || Convert.ToString(item.GenBoardDVS).Trim().Length > 0)
        //        {
        //            activeSheet.GetRow(20).GetCell(2).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 1);
        //            activeSheet.GetRow(20).GetCell(2).SetCellValue(item.GenBoardDN + "/" + item.GenBoardDVS);
        //        }
        //        if (item.ModuleTypeItem.HasSpeBoard == 'Y')
        //        {
        //            if (Convert.ToString(item.SpeBoardDN).Trim().Length > 0 || Convert.ToString(item.SpeBoardDVS).Trim().Length > 0)
        //            {
        //                activeSheet.GetRow(20).GetCell(4).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 1, 1, 1);
        //                activeSheet.GetRow(20).GetCell(4).SetCellValue(item.SpeBoardDN + "/" + item.SpeBoardDVS);
        //            }
        //        }
        //        if (Convert.ToString(item.FabricationDN).Trim().Length > 0 || Convert.ToString(item.FabricationDVS).Trim().Length > 0)
        //        {
        //            activeSheet.GetRow(21).GetCell(2).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 1);
        //            activeSheet.GetRow(21).GetCell(2).SetCellValue(item.FabricationDN + "/" + item.FabricationDVS);

        //        }

        //        BomCoorPatternInfo bomCoorPatternInfo = bomCoorPatternDal.GetDetail(item.GenBoard, item.GenBoardDN, item.GenBoardDVS);
        //        if (bomCoorPatternInfo != null)
        //        {
        //            if (string.IsNullOrEmpty(bomCoorPatternInfo.CoorPattern) == false)
        //            {
        //                activeSheet.GetRow(22).GetCell(3).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 0);
        //                activeSheet.GetRow(22).GetCell(3).SetCellValue(bomCoorPatternInfo.CoorPattern);
        //            }
        //            if (string.IsNullOrEmpty(item.Comments) == false)
        //            {
        //                activeSheet.GetRow(23).GetCell(1).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 0);
        //                activeSheet.GetRow(23).GetCell(1).SetCellValue(item.Comments);
        //            }
        //        }

        //        string steelMesh = pcbSteelMesh.GetDetail(item.PCB).SteelMesh;
        //        if (string.IsNullOrEmpty(steelMesh) == false)
        //        {
        //            activeSheet.GetRow(24).GetCell(3).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 0);
        //            activeSheet.GetRow(24).GetCell(3).SetCellValue(steelMesh);
        //        }
        //    }
        //     MemoryStream ms = new MemoryStream();  
        //     workbook.Write(ms);
        //     workbook = null;       
        //     return ms;    

        //}

    }
}

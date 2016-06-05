using System;
using System.Collections;
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
    public class SMTModelFileInduceService : ISMTModelFileInduceService
    {
        public ISMTModelFileInduce dal;

        public int Query(Hashtable hashTable)
        {
            return dal.Query(hashTable);
        }

        public IList<SMTModelFileInduceInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.Query(hashTable, sortBy, orderBy, page, pageSize);
        }

        public bool CheckExists(SMTModelFileInduceInfo entity)
        {
            return dal.CheckExists(entity);
        }

        public void Save(SMTModelFileInduceInfo entity)
        {
            dal.Save(entity);
        }

        public SMTModelFileInduceInfo GetDetail(int FileInducePK)
        {
            return dal.GetDetail(FileInducePK);
        }

        public void Update(SMTModelFileInduceInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SMTModelFileInduceInfo entity)
        {
            dal.Delete(entity);
        }

        public DataTable Upload(SYSModuleTypeInfo moduleTypeItem, Stream excelFileStream, string SheetName)
        {
            DataTable DT = new DataTable();
            HSSFWorkbook workbook = new HSSFWorkbook(excelFileStream);
            HSSFSheet sheet = (HSSFSheet)workbook.GetSheet(SheetName);

            int templateColumnCount = 13;
            //Check Template 
            bool temp = false;
            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                if (string.Equals(workbook.GetSheetAt(i).SheetName.ToUpper(), SheetName.ToUpper()) == true)
                {
                    temp = true;
                    break;
                }
            }
            if (temp == true)
            {
                if (sheet.GetRow(0) == null)
                {
                    temp = false;
                }
                else
                {
                    if (sheet.GetRow(0).LastCellNum != templateColumnCount)
                    {
                        temp = false;
                    }
                }
            }

            //Read Template
            if (temp == true)
            {
                DT.Columns.Add("ModuleTypeId", System.Type.GetType("System.String"));
                DT.Columns.Add("BillSerialNumber", System.Type.GetType("System.String"));
                DT.Columns.Add("ModuleDesc", System.Type.GetType("System.String"));
                DT.Columns.Add("PCB", System.Type.GetType("System.String"));
                DT.Columns.Add("SerialNumber", System.Type.GetType("System.String"));
                DT.Columns.Add("Version", System.Type.GetType("System.String"));
                DT.Columns.Add("SpeBoard", System.Type.GetType("System.String"));
                DT.Columns.Add("SpeBoardDN", System.Type.GetType("System.String"));
                DT.Columns.Add("SpeBoardDVS", System.Type.GetType("System.String"));
                DT.Columns.Add("FabricationDN", System.Type.GetType("System.String"));
                DT.Columns.Add("FabricationDVS", System.Type.GetType("System.String"));
                DT.Columns.Add("SteelMesh", System.Type.GetType("System.String"));
                DT.Columns.Add("CoorPattern", System.Type.GetType("System.String"));
                DT.Columns.Add("Comments", System.Type.GetType("System.String"));
  
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    HSSFRow row = (HSSFRow)sheet.GetRow(i);
                    if (row == null)
                    {
                        break;
                    }

                    //New DataRow
                    DataRow dataRow = DT.NewRow();
                    dataRow["ModuleTypeId"] = moduleTypeItem.ModuleTypeId;

                    for (int j = row.FirstCellNum; j <= row.LastCellNum; j++)
                    {
                        if (row.GetCell(j) == null)
                        {
                            break;
                        }

                        //Get Cell Value
                        string cellValue = null;
                        switch (row.GetCell(j).CellType)
                        {
                            case CellType.STRING:
                                cellValue = row.GetCell(j).StringCellValue;
                                break;
                            case CellType.NUMERIC:
                                cellValue = row.GetCell(j).NumericCellValue.ToString();
                                break;
                            default:
                                break;
                        }

                        //Set Cell Value
                        switch (j)
                        {
                            case 0:
                                dataRow["BillSerialNumber"] = cellValue;
                                break;
                            case 1:
                                dataRow["ModuleDesc"] = cellValue;
                                break;
                            case 2:
                                dataRow["PCB"] = cellValue;
                                break;
                            case 3:
                                dataRow["SerialNumber"] = cellValue;
                                break;
                            case 4:
                                dataRow["Version"] = cellValue;
                                break;
                            case 5:
                                dataRow["SpeBoard"] = cellValue;
                                break;
                            case 6:
                                dataRow["SpeBoardDN"] = cellValue;
                                break;
                            case 7:
                                dataRow["SpeBoardDVS"] = cellValue;
                                break;
                            case 8:
                                dataRow["FabricationDN"] = cellValue;
                                break;
                            case 9:
                                dataRow["FabricationDVS"] = cellValue;
                                break;
                            case 10:
                                dataRow["SteelMesh"] = cellValue;
                                break;
                            case 11:
                                dataRow["CoorPattern"] = cellValue;
                                break;
                            case 12:
                                dataRow["Comments"] = cellValue;
                                break;
                            default:
                                break;
                        }
                    }
                    DT.Rows.Add(dataRow);
                }
                DT.AcceptChanges();
            }
            excelFileStream.Close();
            sheet = null;
            workbook = null;
            return DT;
        }

  
        public void Import(IList<SMTModelFileInduceInfo> newItems, IList<SMTModelFileInduceInfo> editItems)
        {
            foreach (SMTModelFileInduceInfo newItem in newItems)
            {
                dal.Save(newItem);
            }
            foreach (SMTModelFileInduceInfo editItem in editItems)
            {
                dal.Update(editItem);
            }
        }

        public IList<SMTModelFileInduceInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

        public MemoryStream Export(string templateFileName, SMTModelFileInduceInfo entity)
        {
            string sheetName = "Sheet1";

            FileStream stream = new FileStream(Setting.sampleExcelPath + templateFileName, FileMode.Open, FileAccess.Read);
            HSSFWorkbook workbook = new HSSFWorkbook(stream);

           // int i;
            //for (i = 1; i <= items.Count - 1; i++)
            //{
            //    workbook.CloneSheet(0);
            //}

            //for (i = 0; i <= items.Count - 1; i++)
            //{
            //    workbook.SetSheetName(i, sheetName + (i + 1).ToString());
            //}
            //for (int count = 0; count <= items.Count - 1; count++)
            //{
                //ConsignProcessInfo item = items[count];
                Sheet sheet = workbook.GetSheetAt(0);


                if (sheet.GetRow(3).GetCell(6) == null)
                {
                    sheet.GetRow(3).CreateCell(6);
                }
                sheet.GetRow(3).GetCell(6).CellStyle = Helper.ExcelHelper.GetDateCellStyle(workbook, 12);
                sheet.GetRow(3).GetCell(6).SetCellValue(DateTime.Now);
                sheet.AddMergedRegion(new CellRangeAddress(3, 3, 6, 7));

                sheet.GetRow(5).GetCell(1).CellStyle = Helper.ExcelHelper.GetNumberCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 12, 1, 1, 1, 1, "0");
               // sheet.GetRow(5).GetCell(1).SetCellType(CellType.NUMERIC);
                sheet.GetRow(5).GetCell(1).SetCellValue(entity.BillSerialNumber);
                //sheet.GetRow(5).GetCell(2).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 12, 1, 1, 1, 1);
                //sheet.GetRow(5).GetCell(2).SetCellValue(entity..MaterialCode);

                sheet.GetRow(5).GetCell(3).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 12, 1, 1, 1, 1);
                sheet.GetRow(5).GetCell(3).SetCellValue(entity.ModuleTypeItem.ModuleTypeDesc);

                sheet.GetRow(5).GetCell(4).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 12, 1, 1, 1, 1);
                sheet.GetRow(5).GetCell(4).SetCellValue(entity.ModuleDesc);

                sheet.GetRow(8).GetCell(2).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 0);
                sheet.GetRow(8).GetCell(2).SetCellValue(entity.PCB);
                sheet.AddMergedRegion(new CellRangeAddress(8, 8, 2, 3));
                if (Convert.ToString(entity.SerialNumber).Trim().Length > 0 || Convert.ToString(entity.Version).Trim().Length > 0)
                {
                    sheet.GetRow(20).GetCell(2).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 1);
                    sheet.GetRow(20).GetCell(2).SetCellValue(entity.SerialNumber + "/" + entity.Version);
                }
                if (Convert.ToString(entity.SpeBoardDN).Trim().Length > 0 || Convert.ToString(entity.SpeBoardDVS).Trim().Length > 0)
                {
                    sheet.GetRow(20).GetCell(4).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 1, 1, 1);
                    sheet.GetRow(20).GetCell(4).SetCellValue(entity.SpeBoardDN + "/" + entity.SpeBoardDVS);
                }
                if (Convert.ToString(entity.FabricationDN).Trim().Length > 0 || Convert.ToString(entity.FabricationDVS).Trim().Length > 0)
                {
                    sheet.GetRow(21).GetCell(2).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 1);
                    sheet.GetRow(21).GetCell(2).SetCellValue(entity.FabricationDN + "/" + entity.FabricationDVS);

                }

                if (string.IsNullOrEmpty(entity.CoorPattern) == false)
                {
                    sheet.GetRow(22).GetCell(3).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 0);
                    sheet.GetRow(22).GetCell(3).SetCellValue(entity.CoorPattern);
                }
                if (string.IsNullOrEmpty(entity.Comments) == false)
                {
                    sheet.GetRow(23).GetCell(1).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 0);
                    sheet.GetRow(23).GetCell(1).SetCellValue(entity.Comments);
                }

                if (string.IsNullOrEmpty(entity.SteelMesh) == false)
                {
                    sheet.GetRow(24).GetCell(3).CellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 12, 1, 0, 1, 0);
                    sheet.GetRow(24).GetCell(3).SetCellValue(entity.SteelMesh);
                }
            //}
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            workbook = null;
            return ms;

        }

    }
}

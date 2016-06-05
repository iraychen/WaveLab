using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using WaveLab.Model;
using WaveLab.IService;

using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.HSSF.UserModel.Contrib;
using NPOI.SS.Util;
using NPOI.SS.UserModel;

namespace WaveLab.Service
{
    public class MCTImportService : IMCTImportService
    {
        public MCTImportInfo Import(Stream excelFileStream, string SheetName)
        {
            //Check Template
            HSSFWorkbook workbook = new HSSFWorkbook(excelFileStream);
            
            bool temp = false;
            int cellCount, topRows, bottomRows;
            cellCount = 10;
            topRows = 10;
            bottomRows = 9;

            HSSFSheet sheet = (HSSFSheet)workbook.GetSheet(SheetName);
            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                if (string.Equals(workbook.GetSheetAt(i).SheetName.ToUpper(), SheetName.ToUpper()) == true)
                {
                    temp = true;
                    break;
                }
            }

            if (temp == false)
            {
                if (workbook.GetSheetAt(0) != null)
                {
                    sheet = (HSSFSheet)workbook.GetSheetAt(0);
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
                    if (sheet.GetRow(0).LastCellNum != cellCount)
                    {
                        temp = false;
                    }
                }
            }


            //Define Return Data
            MCTImportInfo data = new MCTImportInfo();
            if (temp == true)
            {
                //Basic Infomation
                System.Collections.Hashtable basicInfo = new System.Collections.Hashtable();
                basicInfo.Add("SupplierName", GetValue(sheet.GetRow(4).GetCell(0).StringCellValue));
                basicInfo.Add("CompletedDate", GetValue(sheet.GetRow(5).GetCell(0).StringCellValue));
                basicInfo.Add("Department", GetValue(sheet.GetRow(5).GetCell(5).StringCellValue));
                basicInfo.Add("CompletedBy", GetValue(sheet.GetRow(6).GetCell(0).StringCellValue));
                basicInfo.Add("Email", GetValue(sheet.GetRow(6).GetCell(5).StringCellValue));
                basicInfo.Add("Tel", GetValue(sheet.GetRow(7).GetCell(0).StringCellValue));
                basicInfo.Add("Fax", GetValue(sheet.GetRow(7).GetCell(5).StringCellValue));
                data.BasicInfo = basicInfo;

                //Product Substance
                DataTable DT = new DataTable();
                DT.Columns.Add("MaterialDesc", System.Type.GetType("System.String"));
                DT.Columns.Add("Model", System.Type.GetType("System.String"));
                DT.Columns.Add("PartNo", System.Type.GetType("System.String"));
                DT.Columns.Add("ComponentDesc", System.Type.GetType("System.String"));
                DT.Columns.Add("HomoMaterialName", System.Type.GetType("System.String"));
                DT.Columns.Add("SubstanceName", System.Type.GetType("System.String"));
                DT.Columns.Add("CasNo", System.Type.GetType("System.String"));
                DT.Columns.Add("SubstanceMass", System.Type.GetType("System.String"));
                DT.Columns.Add("ContentRate", System.Type.GetType("System.String"));
                //DT.Columns.Add("Comment", System.Type.GetType("System.String"));

                for (int i = (sheet.FirstRowNum + topRows); i <= sheet.LastRowNum - bottomRows; i++)
                {
                    HSSFRow row = (HSSFRow)sheet.GetRow(i);
                    if (row == null || (
                        row.Cells[0].CellStyle.BorderLeft== CellBorderType.NONE  &&
                        row.Cells[0].CellStyle.BorderTop == CellBorderType.NONE &&
                        row.Cells[0].CellStyle.BorderRight == CellBorderType.NONE &&
                        row.Cells[0].CellStyle.BorderBottom == CellBorderType.NONE
                        ))
                    {
                        break;
                    }

                    DataRow dataRow = DT.NewRow();
                    for (int j = row.FirstCellNum; j <= row.LastCellNum; j++)
                    {
                        string cellValue = string.Empty;
                        if (row.GetCell(j) == null || row.GetCell(j).CellType == CellType.ERROR)
                        {
                            break;
                        }
                        switch (row.GetCell(j).CellType)
                        {
                            case CellType.STRING:
                                cellValue = row.GetCell(j).StringCellValue;
                                break;
                            case CellType.NUMERIC:
                                if (j == row.LastCellNum - 2)
                                {
                                    cellValue = string.Format("{0:f3}", row.GetCell(j).NumericCellValue);
                                }
                                else
                                {
                                    if (j == row.LastCellNum - 3)
                                    {
                                        cellValue = string.Format("{0:f5}", row.GetCell(j).NumericCellValue);
                                    }
                                    else
                                    {
                                        cellValue = row.GetCell(j).NumericCellValue.ToString();
                                    }  
                                }
                                break;
                            default:
                                break;
                        }
                        switch (j)
                        {
                            case 0:
                                dataRow["MaterialDesc"] = cellValue;
                                break;
                            case 1:
                                dataRow["Model"] = cellValue;
                                break;
                            case 2:
                                dataRow["PartNo"] = cellValue;
                                break;
                            case 3:
                                dataRow["ComponentDesc"] = cellValue;
                                break;
                            case 4:
                                dataRow["HomoMaterialName"] = cellValue;
                                break;
                            case 5:
                                dataRow["SubstanceName"] = cellValue;
                                break;
                            case 6:
                                dataRow["CasNo"] = cellValue;
                                break;
                            case 7:
                                dataRow["SubstanceMass"] = cellValue;
                                break;
                            case 8:
                                dataRow["ContentRate"] = cellValue;
                                break;
                            case 9:
                                //dataRow["Comment"] = row.GetCell(j).StringCellValue;
                                break;
                            default:
                                break;
                        }
                    }
                    DT.Rows.Add(dataRow);
                }
                DT.AcceptChanges();
                data.ProductSubstanceInfo = DT;
            }
            

            excelFileStream.Close();
            sheet = null;
            workbook = null;

            return data;
        }


        private string GetValue(string Orignal)
        {
            if (string.IsNullOrEmpty(Orignal) || Orignal.Length == 0)
            {
                return "";
            }
            string[] array = Orignal.Split('：');
            if (array.Length != 2)
            {
                return "";
            }
            else
            {
                return array[1].ToString();
            }
        }
    }
}

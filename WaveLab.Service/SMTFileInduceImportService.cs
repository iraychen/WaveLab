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
    public class SMTFileInduceImportService:ISMTFileInduceImportService
    {
        public DataTable Import(SYSModuleTypeInfo moduleTypeItem, Stream excelFileStream, string SheetName)
        {
            DataTable DT = new DataTable();
            HSSFWorkbook workbook = new HSSFWorkbook(excelFileStream);
            HSSFSheet sheet = (HSSFSheet)workbook.GetSheet(SheetName);

            int templateColumnCount = 21;
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
                DT.Columns.Add("MaterialCode", System.Type.GetType("System.String"));
                DT.Columns.Add("MaterialDesc", System.Type.GetType("System.String"));
                DT.Columns.Add("PCB", System.Type.GetType("System.String"));
                DT.Columns.Add("GenBoard", System.Type.GetType("System.String"));
                DT.Columns.Add("GenBoardDN", System.Type.GetType("System.String"));
                DT.Columns.Add("GenBoardDVS", System.Type.GetType("System.String"));
                DT.Columns.Add("SpeBoard", System.Type.GetType("System.String"));
                DT.Columns.Add("SpeBoardDN", System.Type.GetType("System.String"));
                DT.Columns.Add("SpeBoardDVS", System.Type.GetType("System.String"));
                DT.Columns.Add("SMTFabricationDN", System.Type.GetType("System.String"));
                DT.Columns.Add("SMTFabricationDVS", System.Type.GetType("System.String"));
                DT.Columns.Add("ComponentPart", System.Type.GetType("System.String"));
                DT.Columns.Add("ComponentPartDN", System.Type.GetType("System.String"));
                DT.Columns.Add("ComponentPartDVS", System.Type.GetType("System.String"));
                DT.Columns.Add("GroupPart", System.Type.GetType("System.String"));
                DT.Columns.Add("GroupPartDN", System.Type.GetType("System.String"));
                DT.Columns.Add("GroupPartDVS", System.Type.GetType("System.String"));
                DT.Columns.Add("BondingFabricationDN", System.Type.GetType("System.String"));
                DT.Columns.Add("BondingFabricationDVS", System.Type.GetType("System.String"));
                DT.Columns.Add("Comments", System.Type.GetType("System.String"));
                DT.Columns.Add("Explanation", System.Type.GetType("System.String"));

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
                                dataRow["MaterialCode"] = cellValue;
                                break;
                            case 1:
                                dataRow["MaterialDesc"] = cellValue;
                                break;
                            case 2:
                                dataRow["PCB"] = cellValue;
                                break;
                            case 3:
                                dataRow["GenBoard"] = cellValue;
                                break;
                            case 4:
                                dataRow["GenBoardDN"] = cellValue;
                                break;
                            case 5:
                                dataRow["GenBoardDVS"] = cellValue;
                                break;
                            case 6:
                                dataRow["SpeBoard"] = cellValue;
                                break;
                            case 7:
                                dataRow["SpeBoardDN"] = cellValue;
                                break;
                            case 8:
                                dataRow["SpeBoardDVS"] = cellValue;
                                break;
                            case 9:
                                dataRow["SMTFabricationDN"] = cellValue;
                                break;
                            case 10:
                                dataRow["SMTFabricationDVS"] = cellValue;
                                break;
                            case 11:
                                dataRow["ComponentPart"] = cellValue;
                                break;
                            case 12:
                                dataRow["ComponentPartDN"] = cellValue;
                                break;
                            case 13:
                                dataRow["ComponentPartDVS"] = cellValue;
                                break;
                            case 14:
                                dataRow["GroupPart"] = cellValue;
                                break;
                            case 15:
                                dataRow["GroupPartDN"] = cellValue;
                                break;
                            case 16:
                                dataRow["GroupPartDVS"] = cellValue;
                                break;
                            case 17:
                                dataRow["BondingFabricationDN"] = cellValue;
                                break;
                            case 18:
                                dataRow["BondingFabricationDVS"] = cellValue;
                                break;
                            case 19:
                                dataRow["Comments"] = cellValue;
                                break;
                            case 20:
                                dataRow["Explanation"] = cellValue;
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
    }
}

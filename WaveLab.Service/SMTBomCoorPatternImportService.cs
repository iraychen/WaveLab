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
    public class SMTBomCoorPatternImportService : ISMTBomCoorPatternImportService
    {
        public DataTable Import( Stream excelFileStream, string SheetName)
        {
            DataTable DT = new DataTable();
            HSSFWorkbook workbook = new HSSFWorkbook(excelFileStream);
            HSSFSheet sheet = (HSSFSheet)workbook.GetSheet(SheetName);

            int templateColumnCount =5;
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
                DT.Columns.Add("Module", System.Type.GetType("System.String"));
                DT.Columns.Add("BomDN", System.Type.GetType("System.String"));
                DT.Columns.Add("BomDVS", System.Type.GetType("System.String"));
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
                            default:
                                break;
                        }

                        //Set Cell Value
                        switch (j)
                        {
                            case 0:
                                dataRow["Module"] = cellValue;
                                break;
                            case 1:
                                dataRow["BomDN"] = cellValue;
                                break;
                            case 2:
                                dataRow["BomDVS"] = cellValue;
                                break;
                            case 3:
                                dataRow["CoorPattern"] = cellValue;
                                break;
                            case 4:
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
    }
}

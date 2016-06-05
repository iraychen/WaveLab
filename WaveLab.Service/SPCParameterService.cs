using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;


using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.POIFS;
using NPOI.Util;
using NPOI.SS.UserModel;

namespace WaveLab.Service
{
    public class SPCParameterService: ISPCParameterService
    {
        public ISPCParameter dal;

        public IList<SPCParameterInfo> Query()
        {
            return dal.Query();
        }

        public DataTable Upload(Stream excelFileStream, string SheetName)
        {
            DataTable DT = new DataTable();
            HSSFWorkbook workbook = new HSSFWorkbook(excelFileStream);
            HSSFSheet sheet = (HSSFSheet)workbook.GetSheet(SheetName);

            int templateColumnCount = 9;
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

                DT.Columns.Add("N", System.Type.GetType("System.String"));
                DT.Columns.Add("A2", System.Type.GetType("System.String"));
                DT.Columns.Add("D2", System.Type.GetType("System.String"));
                DT.Columns.Add("D3", System.Type.GetType("System.String"));
                DT.Columns.Add("D4", System.Type.GetType("System.String"));
                DT.Columns.Add("A3", System.Type.GetType("System.String"));
                DT.Columns.Add("C4", System.Type.GetType("System.String"));
                DT.Columns.Add("B3", System.Type.GetType("System.String"));
                DT.Columns.Add("B4", System.Type.GetType("System.String"));

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    DataRow dataRow = DT.NewRow();
                    HSSFRow row = (HSSFRow)sheet.GetRow(i);
                    if (row == null)
                    {
                        break;
                    }
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

                        switch (j)
                        {
                            case 0:
                                dataRow["N"] = cellValue;
                                break;
                            case 1:
                                dataRow["A2"] = cellValue;
                                break;
                            case 2:
                                dataRow["D2"] = cellValue;
                                break;
                            case 3:
                                dataRow["D3"] = cellValue;
                                break;
                            case 4:
                                dataRow["D4"] = cellValue;
                                break;
                            case 5:
                                dataRow["A3"] = cellValue;
                                break;
                            case 6:
                                dataRow["C4"] = cellValue;
                                break;
                            case 7:
                                dataRow["B3"] = cellValue;
                                break;
                            case 8:
                                dataRow["B4"] = cellValue;
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

        public void Import(IList<SPCParameterInfo> items)
        {
            dal.Import(items);
        }

        public SPCParameterInfo GetDetail(int n)
        {
            return dal.GetDetail(n);
        }
    }
}

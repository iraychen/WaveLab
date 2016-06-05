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
    public class ProductBomImportService : IProductBomImportService
    {
        public  DataTable Import(ProductInfo productItem,Stream excelFileStream, string SheetName)
        {
           
            DataTable DT = new DataTable();
            DT.Columns.Add("ProductId", System.Type.GetType("System.Int32"));
            DT.Columns.Add("ProductDesc", System.Type.GetType("System.String"));
            DT.Columns.Add("MaterialCode", System.Type.GetType("System.String"));
            DT.Columns.Add("MaterialTypeDesc", System.Type.GetType("System.String"));
            DT.Columns.Add("MaterialDesc", System.Type.GetType("System.String"));
            DT.Columns.Add("SupplierName", System.Type.GetType("System.String"));
            DT.Columns.Add("Amount", System.Type.GetType("System.String"));
            DT.Columns.Add("ModuleTypeDesc", System.Type.GetType("System.String"));
            DT.Columns.Add("Comment", System.Type.GetType("System.String"));
          
            bool temp = false;
            int cellCount = 7;
            HSSFWorkbook workbook = new HSSFWorkbook(excelFileStream);
            HSSFSheet sheet = (HSSFSheet)workbook.GetSheet(SheetName);
            for (int i = 0; i < workbook.NumberOfSheets ; i++)
            {
                if (string.Equals(workbook.GetSheetAt(i).SheetName.ToUpper(), SheetName.ToUpper()) == true)
                {
                    temp = true;
                    break;
                }
            }

            if (temp == true)
            {
                if (sheet.GetRow(0).LastCellNum != cellCount)
                {
                    temp = false;
                }
            }

            if (temp == true)
            {
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    HSSFRow row = (HSSFRow)sheet.GetRow(i);
                    if (row == null)
                    {
                        break;
                    }

                    DataRow dataRow = DT.NewRow();

                    dataRow["ProductId"] = productItem.ProductId;
                    dataRow["ProductDesc"] = productItem.ProductDesc;

                    

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
                                cellValue = row.GetCell(j).NumericCellValue.ToString();
                                break;
                            default:
                                break;
                        }
                        switch (j)
                        {
                            case 0:
                                dataRow["MaterialCode"] = cellValue;
                                break;
                            case 1:
                                dataRow["MaterialTypeDesc"] = cellValue;
                                break;
                            case 2:
                                dataRow["MaterialDesc"] = cellValue;
                                break;
                            case 3:
                                dataRow["SupplierName"] = cellValue;
                                break;
                            case 4:
                                dataRow["Amount"] = cellValue;
                                break;
                            case 5:
                                dataRow["ModuleTypeDesc"] = cellValue;
                                break;
                            case 6:
                                dataRow["Comment"] = cellValue;
                                break;
                            default:
                                break;
                        }
                    }
                    DT.Rows.Add(dataRow);
                }
            }
            excelFileStream.Close();
            sheet = null;
            workbook = null;
            DT.AcceptChanges();
            return DT;
        }

    }
}

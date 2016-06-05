using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
    public class ProductBomReportService:IProductBomReportService
    {
        public MemoryStream Export(string title, Hashtable paras, bool showProduct, ArrayList arrayList, IList<WaveLab.Model.ProductBomInfo> items)
        {
            //Define WorkBook
            HSSFWorkbook workbook = new HSSFWorkbook();
            Sheet sheet = workbook.CreateSheet("Sheet1");
            sheet.Autobreaks = true;
            int i, j;
            int rowNum = 0;

            sheet.FitToPage = true;

            //Define Cell Style
            CellStyle titleCellStyle, normalCellStyle, headerStringCellStyle, headerNumberCellStyle, rowStringCellStyle, rowNumberCellStyle, alterRowStringCellStyle, alterRowNumberCellStyle;
            titleCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 14, 0, 0, 0, 0);
            normalCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 10, 0, 0, 0, 0);
            headerStringCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.HeaderColor, 'L', 10, 1, 1, 1, 1);
            headerNumberCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.HeaderColor, 'R', 10, 1, 1, 1, 1);
            rowStringCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.RowColor, 'L', 10, 1, 1, 1, 1);
            rowNumberCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.RowColor, 'R', 10, 1, 1, 1, 1);
            alterRowStringCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.AlternatingRowColor, 'L', 10, 1, 1, 1, 1);
            alterRowNumberCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.AlternatingRowColor, 'R', 10, 1, 1, 1, 1);

            int columnCount= arrayList.Count;;
          
            //Title Row
            Row titleRow = sheet.CreateRow(rowNum);
            Cell titleCell = titleRow.CreateCell(0);
            titleRow.Height = 20 * 20;
            titleCell.CellStyle = titleCellStyle;
            titleCell.SetCellType(CellType.STRING);
            titleCell.SetCellValue(title);
            sheet.AddMergedRegion(new CellRangeAddress(rowNum, rowNum, 0, columnCount - 1));

            //First Blank Row
            rowNum++;

            Row blankRow = sheet.CreateRow(rowNum);
            Cell blankCell = blankRow.CreateCell(0);
            blankCell.CellStyle = normalCellStyle;
            sheet.AddMergedRegion(new CellRangeAddress(rowNum, rowNum, 0, columnCount - 1));

            rowNum++;

            //Paras Rows
            int paraColumn = 1;
            foreach (DictionaryEntry entry in paras)
            {
                if (paraColumn == 1)
                {
                    Row paraRow = sheet.CreateRow(rowNum);
                    Cell paraCell = paraRow.CreateCell(0);
                    paraCell.CellStyle = normalCellStyle;
                    paraCell.SetCellType(CellType.STRING);
                    paraCell.SetCellValue(entry.Key + ": " + entry.Value);
                    sheet.AddMergedRegion(new CellRangeAddress(rowNum, rowNum, 0, 1));

                    paraColumn = 2;
                }
                else
                {
                    Cell paraCell = sheet.GetRow(rowNum).CreateCell(2);
                    paraCell.CellStyle = normalCellStyle;
                    paraCell.SetCellType(CellType.STRING);
                    paraCell.SetCellValue(entry.Key + ": " + entry.Value);
                    sheet.AddMergedRegion(new CellRangeAddress(rowNum, rowNum, 2, columnCount-1));

                    paraColumn = 1;
                    rowNum++;
                }
            }

            if (paraColumn == 2)
            {
                Cell paraCell = sheet.GetRow(rowNum).CreateCell(2);
                paraCell.SetCellType(CellType.BLANK);
                sheet.AddMergedRegion(new CellRangeAddress(rowNum, rowNum, 2, columnCount - 1));

                paraColumn = 1;
                rowNum++;
            }

            //Total Row
            Row totalRow = sheet.CreateRow(rowNum);
            Cell totalCell = totalRow.CreateCell(0);
            totalCell.CellStyle = normalCellStyle;
            if (items.Count == 0)
            {
                totalCell.SetCellValue(System.Web.HttpContext.GetGlobalResourceObject("globalResource", "noRecordsMsg").ToString());
                sheet.AddMergedRegion(new CellRangeAddress(rowNum, rowNum, 0, columnCount - 1));
            }
            else
            {
                totalCell.SetCellValue(System.Web.HttpContext.GetGlobalResourceObject("globalResource", "total").ToString() + items.Count +" "+
                System.Web.HttpContext.GetGlobalResourceObject("globalResource", "records").ToString());
                sheet.AddMergedRegion(new CellRangeAddress(rowNum, rowNum, 0, columnCount - 1));

                rowNum++;

                //Header Row
                Row headerRow = sheet.CreateRow(rowNum);
                for (i = 0; i < columnCount; i++)
                {
                    Cell headerCell = headerRow.CreateCell(i);
                    if (i != columnCount - 3)
                    {
                        headerCell.CellStyle = headerStringCellStyle;
                    }
                    else
                    {
                        headerCell.CellStyle = headerNumberCellStyle;
                    }

                    headerCell.SetCellType(CellType.STRING);
                    headerCell.SetCellValue(arrayList[i].ToString());
                }
                rowNum++;

                //Items
                for (i = 0; i < items.Count; i++)
                {
                    Row row = sheet.CreateRow(rowNum);
                    for (j = 0; j < columnCount; j++)
                    {
                        Cell cell = row.CreateCell(j);
                        // Cell Style 
                        if (j != columnCount - 3)
                        {
                            cell.SetCellType(CellType.STRING);
                            if (i % 2 == 0)
                            {
                                cell.CellStyle = rowStringCellStyle;
                            }
                            else
                            {
                                cell.CellStyle = alterRowStringCellStyle;
                            }
                        }
                        else
                        {
                            cell.SetCellType(CellType.NUMERIC);
                            if (i % 2 == 0)
                            {
                                cell.CellStyle = rowNumberCellStyle;
                            }
                            else
                            {
                                cell.CellStyle = alterRowNumberCellStyle;
                            }
                        }

                        // Column 
                        switch (j)
                        {
                            case 0:
                                if (showProduct == false)
                                {
                                    cell.SetCellValue(items[i].MaterialCode);
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].ProductItem.ProductDesc);
                                }
                                break;
                            case 1:
                                if (showProduct == false)
                                {
                                    cell.SetCellValue(items[i].MaterialTypeItem.MaterialTypeDesc);
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].MaterialCode);
                                }
                                break;
                            case 2:
                                if (showProduct == false)
                                {
                                    cell.SetCellValue(items[i].MaterialDesc);
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].MaterialTypeItem.MaterialTypeDesc);
                                }
                                break;
                            case 3:
                                if (showProduct == false)
                                {
                                    cell.SetCellValue(items[i].SupplierName);
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].MaterialDesc);
                                }
                                break;
                            case 4:
                                if (showProduct == false)
                                {
                                    //cell.CellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("0.00000");
                                    cell.SetCellValue(Convert.ToDouble(items[i].Amount));
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].SupplierName);
                                }
                                break;
                            case 5:
                                if (showProduct == false)
                                {
                                    cell.SetCellValue(items[i].ModuleTypeItem.ModuleTypeDesc);
                                }
                                else
                                {
                                    //cell.CellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("0.00000");
                                    cell.SetCellValue(Convert.ToDouble(items[i].Amount));
                                }
                                break;
                            case 6:
                                if (showProduct == false)
                                {
                                    cell.SetCellValue(items[i].Comment);
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].ModuleTypeItem.ModuleTypeDesc);
                                }
                                break;
                            case 7:
                                if (showProduct == false)
                                {
                                    cell.SetCellValue("");
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].Comment);
                                }
                                break;
                            default:
                                break;
                        }


                    }
                    rowNum++;
                }

            }
           
           

            // Auto Size
            for (i = 0; i < columnCount; i++)
            {
                sheet.AutoSizeColumn(i);
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            workbook = null;
            return ms;
        }
    }
}

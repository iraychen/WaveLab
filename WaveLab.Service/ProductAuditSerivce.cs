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
    public class ProductAuditSerivce: IProductAuditService
    {

        public MemoryStream ExportProductAudit(string title, IList<DictionaryEntry> paras, ArrayList headerArray, IList<WaveLab.Model.ProductAuditInfo> items)
        {
            //Define WorkBook
            HSSFWorkbook workbook = new HSSFWorkbook();
            Sheet sheet = workbook.CreateSheet("Sheet1");
            sheet.Autobreaks = true;
            int i, j;
            int rowNum = 0;
            int columnCount = headerArray.Count;

            //Define Cell Style
            CellStyle titleCellStyle, normalCellStyle, headerStringCellStyle, rowStringCellStyle, alterRowStringCellStyle;

            titleCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 14, 0, 0, 0, 0);
            normalCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 10, 0, 0, 0, 0);
            headerStringCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.HeaderColor, 'L', 10, 1, 1, 1, 1);

            rowStringCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.RowColor, 'L', 10, 1, 1, 1, 1);
            alterRowStringCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.AlternatingRowColor, 'L', 10, 1, 1, 1, 1);

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
            for (i = 0; i < paras.Count; i++)
            {
                if (paraColumn == 1)
                {
                    Row paraRow = sheet.CreateRow(rowNum);
                    Cell paraCell = paraRow.CreateCell(0);
                    paraCell.CellStyle = normalCellStyle;
                    paraCell.SetCellType(CellType.STRING);
                    paraCell.SetCellValue(paras[i].Key + ": " + paras[i].Value);
                    sheet.AddMergedRegion(new CellRangeAddress(rowNum, rowNum, 0, 1));

                    paraColumn = 2;
                }
                else
                {
                    Cell paraCell = sheet.GetRow(rowNum).CreateCell(2);
                    paraCell.CellStyle = normalCellStyle;
                    paraCell.SetCellType(CellType.STRING);
                    paraCell.SetCellValue(paras[i].Key + ": " + paras[i].Value);
                    sheet.AddMergedRegion(new CellRangeAddress(rowNum, rowNum, 2, columnCount - 1));

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
                totalCell.SetCellValue(System.Web.HttpContext.GetGlobalResourceObject("globalResource", "total").ToString() + items.Count + " " +
                    System.Web.HttpContext.GetGlobalResourceObject("globalResource", "records").ToString());
                sheet.AddMergedRegion(new CellRangeAddress(rowNum, rowNum, 0, columnCount - 1));
                rowNum++;

                //Header Row
                Row headerRow = sheet.CreateRow(rowNum);
                for (i = 0; i < columnCount; i++)
                {
                    Cell headerCell = headerRow.CreateCell(i);
                    headerCell.CellStyle = headerStringCellStyle;
                    headerCell.SetCellType(CellType.STRING);
                    headerCell.SetCellValue(headerArray[i].ToString());
                }
                rowNum++;

                //Item Rows

                for (i = 0; i < items.Count; i++)
                {
                    Row row = sheet.CreateRow(rowNum);
                    for (j = 0; j < columnCount; j++)
                    {
                        Cell cell = row.CreateCell(j);
                        // Cell Style 
                        cell.SetCellType(CellType.STRING);
                        if (i % 2 == 0)
                        {
                            cell.CellStyle = rowStringCellStyle;
                        }
                        else
                        {
                            cell.CellStyle = alterRowStringCellStyle;
                        }

                        //Column 
                        switch (j)
                        {
                            case 0:
                                cell.SetCellValue(items[i].MaterialCode.Trim());
                                break;
                            case 1:
                                cell.SetCellValue(System.Web.HttpUtility.HtmlDecode(items[i].MaterialDesc));
                                break;
                            case 2:
                                cell.SetCellValue(items[i].SupplierName);
                                break;
                            case 3:
                                cell.SetCellValue(Convert.ToString(items[i].Supplied));
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

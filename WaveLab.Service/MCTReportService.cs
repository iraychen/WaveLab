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
    public class MCTReportService : IMCTReportService
    {
        public WaveLab.IDAL.IMCTReport dal;

        public IList<RptMCTMTAnalysisInfo> QueryMCTMTAnalysis(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.QueryMCTMTAnalysis(hashTable, sortBy, orderBy);
        }

        public IList<RptMCTOriginalInfo> QueryMCTOriginal(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.QueryMCTOriginal(hashTable, sortBy, orderBy);
        }

        public IList<RptMCTCountInfo> QueryMCTCount(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.QueryMCTCount(hashTable, sortBy, orderBy);
        }

        public IList<MCTDtlInfo> GetMaterialSubstances(string materialCode, string materialDesc, string supplierName, string sortBy, string orderBy)
        {
           return dal.GetMaterialSubstances(materialCode, materialDesc, supplierName, sortBy, orderBy);
        }

        public MemoryStream ExportMCTMTAnalysis(string title, IList<DictionaryEntry> paras, bool showProduct, ArrayList headerArray, IList<RptMCTMTAnalysisInfo> items)
        {
            //Define WorkBook
            HSSFWorkbook workbook = new HSSFWorkbook();
            Sheet sheet = workbook.CreateSheet("Sheet1");
            sheet.Autobreaks = true;
            int i, j;
            int rowNum = 0;
            int columnCount = headerArray.Count;

            //Define Cell Style
            CellStyle titleCellStyle, normalCellStyle, headerStringCellStyle, headerNumberCellStyle,
                rowStringCellStyle, rowNumberCellStyle_5digits, alterRowStringCellStyle, alterRowNumberCellStyle_5digits,
                rowNumberCellStyle_3digits, alterRowNumberCellStyle_3digits;
            titleCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 14, 0, 0, 0, 0);
            normalCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 10, 0, 0, 0, 0);
            headerStringCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.HeaderColor, 'L', 10, 1, 1, 1, 1);
            headerNumberCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.HeaderColor, 'R', 10, 1, 1, 1, 1);
            rowStringCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.RowColor, 'L', 10, 1, 1, 1, 1);
            alterRowStringCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.AlternatingRowColor, 'L', 10, 1, 1, 1, 1);

            rowNumberCellStyle_5digits = Helper.ExcelHelper.GetNumberCellStyle(workbook, Helper.ExcelHelper.RowColor, 'R', 10, 1, 1, 1, 1, "0.00000");
            alterRowNumberCellStyle_5digits = Helper.ExcelHelper.GetNumberCellStyle(workbook, Helper.ExcelHelper.AlternatingRowColor, 'R', 10, 1, 1, 1, 1, "0.00000");

            rowNumberCellStyle_3digits = Helper.ExcelHelper.GetNumberCellStyle(workbook, Helper.ExcelHelper.RowColor, 'R', 10, 1, 1, 1, 1, "0.000");
            alterRowNumberCellStyle_3digits = Helper.ExcelHelper.GetNumberCellStyle(workbook, Helper.ExcelHelper.AlternatingRowColor, 'R', 10, 1, 1, 1, 1, "0.000");

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
                    if (i < columnCount - 2)
                    {
                        headerCell.CellStyle = headerStringCellStyle;
                    }
                    else
                    {
                        headerCell.CellStyle = headerNumberCellStyle;
                    }

                    headerCell.SetCellType(CellType.STRING);

                    headerCell.SetCellValue(headerArray[i].ToString());
                }
                rowNum++;

                //Item Rows

                string pastProductDesc = "", pastMaterialTypeDesc = "", pastComponentDesc = "", pastHomoMaterialName = "";
                for (i = 0; i < items.Count; i++)
                {
                    Row row = sheet.CreateRow(rowNum);
                    for (j = 0; j < columnCount; j++)
                    {
                        Cell cell = row.CreateCell(j);
                        // Cell Style 
                        if (j < columnCount - 2)
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
                                if (j == columnCount - 2)
                                {
                                    cell.CellStyle = rowNumberCellStyle_5digits;
                                }
                                else
                                {
                                    cell.CellStyle = rowNumberCellStyle_3digits;
                                }

                            }
                            else
                            {
                                if (j == columnCount - 2)
                                {
                                    cell.CellStyle = alterRowNumberCellStyle_5digits;
                                }
                                else
                                {
                                    cell.CellStyle = alterRowNumberCellStyle_3digits;
                                }
                            }
                        }

                        //Column 
                        switch (j)
                        {
                            case 0:
                                if (showProduct == true)
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false)
                                    {
                                        cell.SetCellValue(items[i].ProductDesc);
                                    }
                                }
                                else
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                    string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false)
                                    {
                                        cell.SetCellValue(items[i].MaterialTypeDesc);
                                    }
                                }

                                break;
                            case 1:
                                if (showProduct == true)
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                    string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false)
                                    {
                                        cell.SetCellValue(items[i].MaterialTypeDesc);
                                    }
                                }
                                else
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                   string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false ||
                                   string.Equals(items[i].ComponentDesc, pastComponentDesc) == false)
                                    {
                                        cell.SetCellValue(items[i].ComponentDesc);
                                    }
                                }
                                break;
                            case 2:
                                if (showProduct == true)
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                    string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false ||
                                    string.Equals(items[i].ComponentDesc, pastComponentDesc) == false)
                                    {
                                        cell.SetCellValue(items[i].ComponentDesc);
                                    }
                                }
                                else
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                    string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false ||
                                    string.Equals(items[i].ComponentDesc, pastComponentDesc) == false ||
                                    string.Equals(items[i].HomoMaterialName, pastHomoMaterialName) == false)
                                    {
                                        cell.SetCellValue(items[i].HomoMaterialName);
                                    }
                                }

                                break;
                            case 3:
                                if (showProduct == true)
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                     string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false ||
                                     string.Equals(items[i].ComponentDesc, pastComponentDesc) == false ||
                                     string.Equals(items[i].HomoMaterialName, pastHomoMaterialName) == false)
                                    {
                                        cell.SetCellValue(items[i].HomoMaterialName);
                                    }
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].SubstanceName);
                                }

                                break;
                            case 4:
                                if (showProduct == true)
                                {
                                    cell.SetCellValue(items[i].SubstanceName);
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].CasNo);
                                }

                                break;
                            case 5:
                                if (showProduct == true)
                                {
                                    cell.SetCellValue(items[i].CasNo);
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].SubstanceMass);
                                }

                                break;
                            case 6:
                                if (showProduct == true)
                                {
                                    cell.SetCellValue(items[i].SubstanceMass);
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].ContentRate);
                                }

                                break;
                            case 7:
                                if (showProduct == true)
                                {
                                    cell.SetCellValue(items[i].ContentRate);
                                }
                                break;

                            default:
                                break;
                        }
                    }
                    rowNum++;

                    pastProductDesc = items[i].ProductDesc;
                    pastMaterialTypeDesc = items[i].MaterialTypeDesc;
                    pastComponentDesc = items[i].ComponentDesc;
                    pastHomoMaterialName = items[i].HomoMaterialName;
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

        public MemoryStream ExportMCTOriginal(string title, IList<DictionaryEntry> paras, bool showProduct, ArrayList headerArray, IList<RptMCTOriginalInfo> items)
        {
            //Define WorkBook
            HSSFWorkbook workbook = new HSSFWorkbook();
            Sheet sheet = workbook.CreateSheet("Sheet1");
            sheet.Autobreaks = true;
            int i, j;
            int rowNum = 0;
            int columnCount = headerArray.Count;

            //Define Cell Style
            CellStyle titleCellStyle, normalCellStyle, headerStringCellStyle, headerNumberCellStyle,
                rowStringCellStyle, rowNumberCellStyle_5digits, alterRowStringCellStyle, alterRowNumberCellStyle_5digits,
                rowNumberCellStyle_3digits, alterRowNumberCellStyle_3digits;
            titleCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'C', 14, 0, 0, 0, 0);
            normalCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.NormalColor, 'L', 10, 0, 0, 0, 0);
            headerStringCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.HeaderColor, 'L', 10, 1, 1, 1, 1);
            headerNumberCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.HeaderColor, 'R', 10, 1, 1, 1, 1);
            rowStringCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.RowColor, 'L', 10, 1, 1, 1, 1);
            alterRowStringCellStyle = Helper.ExcelHelper.GetCellStyle(workbook, Helper.ExcelHelper.AlternatingRowColor, 'L', 10, 1, 1, 1, 1);

            rowNumberCellStyle_5digits = Helper.ExcelHelper.GetNumberCellStyle(workbook, Helper.ExcelHelper.RowColor, 'R', 10, 1, 1, 1, 1, "0.00000");
            alterRowNumberCellStyle_5digits = Helper.ExcelHelper.GetNumberCellStyle(workbook, Helper.ExcelHelper.AlternatingRowColor, 'R', 10, 1, 1, 1, 1, "0.00000");

            rowNumberCellStyle_3digits = Helper.ExcelHelper.GetNumberCellStyle(workbook, Helper.ExcelHelper.RowColor, 'R', 10, 1, 1, 1, 1, "0.000");
            alterRowNumberCellStyle_3digits = Helper.ExcelHelper.GetNumberCellStyle(workbook, Helper.ExcelHelper.AlternatingRowColor, 'R', 10, 1, 1, 1, 1, "0.000");

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
                    if (i < columnCount - 2)
                    {
                        headerCell.CellStyle = headerStringCellStyle;
                    }
                    else
                    {
                        headerCell.CellStyle = headerNumberCellStyle;
                    }

                    headerCell.SetCellType(CellType.STRING);

                    headerCell.SetCellValue(headerArray[i].ToString());
                }
                rowNum++;

                //Item Rows

                string pastProductDesc = "", pastMaterialTypeDesc = "", pastMaterialCode = "", pastMaterialDesc = "", pastSupplierName = "", pastComponentDesc = "", pastHomoMaterialName = "";
                for (i = 0; i < items.Count; i++)
                {
                    Row row = sheet.CreateRow(rowNum);
                    for (j = 0; j < columnCount; j++)
                    {
                        Cell cell = row.CreateCell(j);
                        // Cell Style 
                        if (j < columnCount - 2)
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
                                if (j == columnCount - 2)
                                {
                                    cell.CellStyle = rowNumberCellStyle_5digits;
                                }
                                else
                                {
                                    cell.CellStyle = rowNumberCellStyle_3digits;
                                }

                            }
                            else
                            {
                                if (j == columnCount - 2)
                                {
                                    cell.CellStyle = alterRowNumberCellStyle_5digits;
                                }
                                else
                                {
                                    cell.CellStyle = alterRowNumberCellStyle_3digits;
                                }
                            }
                        }

                        //Column 
                        switch (j)
                        {
                            case 0:
                                if (showProduct == true)
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false)
                                    {
                                        cell.SetCellValue(items[i].ProductDesc);
                                    }
                                }
                                else
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                    string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false)
                                    {
                                        cell.SetCellValue(items[i].MaterialTypeDesc);
                                    }
                                }

                                break;
                            case 1:
                                if (showProduct == true)
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                    string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false)
                                    {
                                        cell.SetCellValue(items[i].MaterialTypeDesc);
                                    }
                                }
                                else
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                   string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false ||
                                   string.Equals(items[i].MaterialCode, pastMaterialCode) == false)
                                    {
                                        cell.SetCellValue(items[i].MaterialCode);
                                    }
                                }
                                break;
                            case 2:
                                if (showProduct == true)
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                   string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false ||
                                   string.Equals(items[i].MaterialCode, pastMaterialCode) == false)
                                    {
                                        cell.SetCellValue(items[i].MaterialCode);
                                    }
                                }
                                else
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                   string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false ||
                                   string.Equals(items[i].MaterialCode, pastMaterialCode) == false ||
                                   string.Equals(items[i].MaterialDesc, pastMaterialDesc) == false)
                                    {
                                        cell.SetCellValue(System.Web.HttpUtility.HtmlDecode(items[i].MaterialDesc));
                                    }
                                }
                                break;
                            case 3:
                                if (showProduct == true)
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                   string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false ||
                                   string.Equals(items[i].MaterialCode, pastMaterialCode) == false ||
                                   string.Equals(items[i].MaterialDesc, pastMaterialDesc) == false)
                                    {
                                        cell.SetCellValue(System.Web.HttpUtility.HtmlDecode(items[i].MaterialDesc));
                                    }
                                }
                                else
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                    string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false ||
                                    string.Equals(items[i].MaterialCode, pastMaterialCode) == false ||
                                    string.Equals(items[i].MaterialDesc, pastMaterialDesc) == false ||
                                    string.Equals(items[i].SupplierName, pastSupplierName) == false)
                                    {
                                        cell.SetCellValue(items[i].SupplierName);
                                    }
                                }

                                break;
                            case 4:
                                if (showProduct == true)
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                    string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false ||
                                    string.Equals(items[i].MaterialCode, pastMaterialCode) == false ||
                                    string.Equals(items[i].MaterialDesc, pastMaterialDesc) == false ||
                                    string.Equals(items[i].SupplierName, pastSupplierName) == false)
                                    {
                                        cell.SetCellValue(items[i].SupplierName);
                                    }
                                }
                                else
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                  string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false ||
                                  string.Equals(items[i].MaterialCode, pastMaterialCode) == false ||
                                  string.Equals(items[i].MaterialDesc, pastMaterialDesc) == false ||
                                  string.Equals(items[i].SupplierName, pastSupplierName) == false ||
                                  string.Equals(items[i].ComponentDesc, pastComponentDesc) == false)
                                    {
                                        cell.SetCellValue(items[i].ComponentDesc);
                                    }
                                }

                                break;
                            case 5:
                                if (showProduct == true)
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                   string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false ||
                                   string.Equals(items[i].MaterialCode, pastMaterialCode) == false ||
                                   string.Equals(items[i].MaterialDesc, pastMaterialDesc) == false ||
                                   string.Equals(items[i].SupplierName, pastSupplierName) == false ||
                                   string.Equals(items[i].ComponentDesc, pastComponentDesc) == false)
                                    {
                                        cell.SetCellValue(items[i].ComponentDesc);
                                    }
                                }
                                else
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                  string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false ||
                                  string.Equals(items[i].MaterialCode, pastMaterialCode) == false ||
                                  string.Equals(items[i].MaterialDesc, pastMaterialDesc) == false ||
                                  string.Equals(items[i].SupplierName, pastSupplierName) == false ||
                                  string.Equals(items[i].ComponentDesc, pastComponentDesc) == false ||
                                  string.Equals(items[i].HomoMaterialName, pastHomoMaterialName) == false)
                                    {
                                        cell.SetCellValue(items[i].HomoMaterialName);
                                    }
                                }

                                break;
                            case 6:
                                if (showProduct == true)
                                {
                                    if (string.Equals(items[i].ProductDesc, pastProductDesc) == false ||
                                   string.Equals(items[i].MaterialTypeDesc, pastMaterialTypeDesc) == false ||
                                   string.Equals(items[i].MaterialCode, pastMaterialCode) == false ||
                                   string.Equals(items[i].MaterialDesc, pastMaterialDesc) == false ||
                                   string.Equals(items[i].SupplierName, pastSupplierName) == false ||
                                   string.Equals(items[i].ComponentDesc, pastComponentDesc) == false ||
                                   string.Equals(items[i].HomoMaterialName, pastHomoMaterialName) == false)
                                    {
                                        cell.SetCellValue(items[i].HomoMaterialName);
                                    }
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].SubstanceName);
                                }

                                break;
                            case 7:
                                if (showProduct == true)
                                {
                                    cell.SetCellValue(items[i].SubstanceName);
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].CasNo);
                                }

                                break;
                            case 8:
                                if (showProduct == true)
                                {
                                    cell.SetCellValue(items[i].CasNo);

                                }
                                else
                                {
                                    cell.SetCellValue(items[i].SubstanceMass);
                                }
                                break;
                            case 9:
                                if (showProduct == true)
                                {
                                    cell.SetCellValue(items[i].SubstanceMass);
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].ContentRate);
                                }

                                break;
                            case 10:
                                if (showProduct == true)
                                {
                                    cell.SetCellValue(items[i].ContentRate);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    rowNum++;

                    pastProductDesc = items[i].ProductDesc;
                    pastMaterialTypeDesc = items[i].MaterialTypeDesc;
                    pastMaterialCode = items[i].MaterialCode;
                    pastMaterialDesc = items[i].MaterialDesc;
                    pastSupplierName = items[i].SupplierName;
                    pastComponentDesc = items[i].ComponentDesc;
                    pastHomoMaterialName = items[i].HomoMaterialName;
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

        public MemoryStream ExportMCTCount(string title, IList<DictionaryEntry> paras, bool showProduct, ArrayList headerArray, IList<RptMCTCountInfo> items)
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
                                if (showProduct == true)
                                {
                                    cell.SetCellValue(items[i].ProductItem.ProductDesc);
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].MaterialCode.Trim());
                                }

                                break;
                            case 1:
                                if (showProduct == true)
                                {
                                    cell.SetCellValue(items[i].MaterialCode.Trim());
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].MaterialTypeItem.MaterialTypeDesc);
                                }
                                break;
                            case 2:
                                if (showProduct == true)
                                {
                                    cell.SetCellValue(items[i].MaterialTypeItem.MaterialTypeDesc);
                                }
                                else
                                {
                                    cell.SetCellValue(System.Web.HttpUtility.HtmlDecode(items[i].MaterialDesc));
                                }
                                break;
                            case 3:
                                if (showProduct == true)
                                {
                                    cell.SetCellValue(System.Web.HttpUtility.HtmlDecode(items[i].MaterialDesc));
                                }
                                else
                                {
                                    cell.SetCellValue(items[i].SupplierName);
                                }

                                break;
                            case 4:
                                if (showProduct == true)
                                {
                                    cell.SetCellValue(items[i].SupplierName);
                                }
                                else
                                {
                                    cell.SetCellValue(Convert.ToString(items[i].Supplied));
                                }

                                break;
                            case 5:
                                if (showProduct == true)
                                {
                                    cell.SetCellValue(Convert.ToString(items[i].Supplied));
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

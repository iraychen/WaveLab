using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.POIFS;
using NPOI.Util;
using NPOI.SS.UserModel;

namespace WaveLab.Service.Helper
{
   public sealed class ExcelHelper
    {
       public static short NormalColor = NPOI.HSSF.Util.HSSFColor.WHITE.index;
       public static short HeaderColor = NPOI.HSSF.Util.HSSFColor.SKY_BLUE.index;
       public static short RowColor = NPOI.HSSF.Util.HSSFColor.WHITE.index;
       public static short AlternatingRowColor = NPOI.HSSF.Util.HSSFColor.GREY_25_PERCENT.index;

       public static CellStyle GetCellStyle(HSSFWorkbook workbook, short backgroundColor, Char align,short fontHeightInPoints, int borderTop, int borderRight, int borderBottom, int borderLeft)
        {
            CellStyle style = workbook.CreateCellStyle();
            style.FillForegroundColor = backgroundColor;
            style.FillPattern = FillPatternType.THIN_BACKWARD_DIAG;
       
            switch (align)
            {
                case 'L':
                    style.Alignment = HorizontalAlignment.LEFT;
                    break;
                case 'C':
                    style.Alignment = HorizontalAlignment.CENTER;
                    break;
                case 'R':
                    style.Alignment = HorizontalAlignment.RIGHT;
                    break;
                default:
                    break;
            }
            if (borderTop == 1)
            {
                style.BorderTop = CellBorderType.THIN;
            }
            if (borderRight == 1)
            {
                style.BorderRight = CellBorderType.THIN;
            }
            if (borderBottom == 1)
            {
                style.BorderBottom = CellBorderType.THIN;
            }
            if (borderLeft == 1)
            {
                style.BorderLeft = CellBorderType.THIN;
            }

            style.FillBackgroundColor = backgroundColor;
            style.SetFont(GetCellFont(workbook, fontHeightInPoints));
            return style;
        }


       public static CellStyle GetNumberCellStyle(HSSFWorkbook workbook, short backgroundColor, Char align, short fontHeightInPoints, int borderTop, int borderRight, int borderBottom, int borderLeft,string formatString)
       {
           CellStyle style = workbook.CreateCellStyle();
           style.FillForegroundColor = backgroundColor;
           style.FillPattern = FillPatternType.THIN_BACKWARD_DIAG;

           switch (align)
           {
               case 'L':
                   style.Alignment = HorizontalAlignment.LEFT;
                   break;
               case 'C':
                   style.Alignment = HorizontalAlignment.CENTER;
                   break;
               case 'R':
                   style.Alignment = HorizontalAlignment.RIGHT;
                   break;
               default:
                   break;
           }
           if (borderTop == 1)
           {
               style.BorderTop = CellBorderType.THIN;
           }
           if (borderRight == 1)
           {
               style.BorderRight = CellBorderType.THIN;
           }
           if (borderBottom == 1)
           {
               style.BorderBottom = CellBorderType.THIN;
           }
           if (borderLeft == 1)
           {
               style.BorderLeft = CellBorderType.THIN;
           }

         
           style.FillBackgroundColor = backgroundColor;
           style.SetFont(GetCellFont(workbook, fontHeightInPoints));



           if (HSSFDataFormat.GetBuiltinFormat(formatString)==-1)
           {
               DataFormat format = workbook.CreateDataFormat();
               style.DataFormat = format.GetFormat(formatString);
           }
           else
           {
               style.DataFormat = HSSFDataFormat.GetBuiltinFormat(formatString);
           }
           return style;
       }


       public static CellStyle GetDateCellStyle(HSSFWorkbook workbook, short fontHeightInPoints)
        {
            CellStyle style = workbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.LEFT;
            DataFormat format = workbook.CreateDataFormat();
            style.DataFormat = format.GetFormat("yyyy-mm-dd");
            style.SetFont(GetCellFont(workbook, fontHeightInPoints));
            return style;
        }

       public static Font GetCellFont(HSSFWorkbook workbook, short fontHeightInPoints)
        {
            Font font = workbook.CreateFont();
            font.FontHeightInPoints = fontHeightInPoints;
            font.FontName = "宋体";
            return font;
        }
    }
}

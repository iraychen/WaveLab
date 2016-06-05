using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WaveLab.Service.Helper
{
    public  sealed class PDFHelper
    {

        public static BaseFont bfChinese = BaseFont.CreateFont(Setting.simsunFontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

        public static iTextSharp.text.Font SimSunFont12 = new iTextSharp.text.Font(bfChinese, 12, iTextSharp.text.Font.NORMAL, new iTextSharp.text.Color(0, 0, 0));
        public static iTextSharp.text.Font SimSunFontUnderLine12 = new iTextSharp.text.Font(bfChinese, 12, iTextSharp.text.Font.UNDERLINE, new iTextSharp.text.Color(0, 0, 0));
        public static iTextSharp.text.Font FontUnderLine12 = new iTextSharp.text.Font(bfChinese, 12, iTextSharp.text.Font.UNDERLINE, new iTextSharp.text.Color(0, 0, 0));

        public static iTextSharp.text.Font SimSunFontItalic13= new iTextSharp.text.Font(bfChinese, 13, iTextSharp.text.Font.ITALIC, new iTextSharp.text.Color(0, 0, 0));

        public static iTextSharp.text.Font SimSunFont14 = new iTextSharp.text.Font(bfChinese, 14, iTextSharp.text.Font.NORMAL, new iTextSharp.text.Color(0, 0, 0));
        public static iTextSharp.text.Font SimSunFontUnderLine14 = new iTextSharp.text.Font(bfChinese, 14, iTextSharp.text.Font.UNDERLINE, new iTextSharp.text.Color(0, 0, 0));

        public static iTextSharp.text.Font SimSunFont16 = new iTextSharp.text.Font(bfChinese, 16, iTextSharp.text.Font.NORMAL, new iTextSharp.text.Color(0, 0, 0));

        public static iTextSharp.text.Font SimSunFont18 = new iTextSharp.text.Font(bfChinese, 18, iTextSharp.text.Font.NORMAL, new iTextSharp.text.Color(0, 0, 0));

        public static BaseFont bfChineseCour = BaseFont.CreateFont(Setting.courFontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        public static iTextSharp.text.Font courFont10 = new iTextSharp.text.Font(bfChineseCour, 10, iTextSharp.text.Font.NORMAL, new iTextSharp.text.Color(0, 0, 0));
        public static iTextSharp.text.Font courFont12 = new iTextSharp.text.Font(bfChineseCour, 12, iTextSharp.text.Font.NORMAL, new iTextSharp.text.Color(0, 0, 0));
        public static iTextSharp.text.Font courFontUnderLine12 = new iTextSharp.text.Font(bfChineseCour, 12, iTextSharp.text.Font.UNDERLINE, new iTextSharp.text.Color(0, 0, 0));


        public static  BaseFont barCodeBaseFont = BaseFont.CreateFont(Setting.free30F9FontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        public static iTextSharp.text.Font barCodeFont14 = new iTextSharp.text.Font(barCodeBaseFont, 14, iTextSharp.text.Font.NORMAL, new iTextSharp.text.Color(0, 0, 0));
        public static iTextSharp.text.Font barCodeFont20 = new iTextSharp.text.Font(barCodeBaseFont, 20, iTextSharp.text.Font.NORMAL, new iTextSharp.text.Color(0, 0, 0));


        public static  void PDFAddCell(PdfPTable pdfTable, string text, int colspan, int borderWidth, string align, iTextSharp.text.Font FontBase)
        {
            PdfPCell cell = new PdfPCell();
            cell.Colspan = colspan;
            cell.BorderWidth = borderWidth;
            switch (align)
            {
                case "L":
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
                case "C":
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case "R":
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                default:
                    break;
            }
            Phrase phrase = new Phrase(text, FontBase);
            cell.Phrase = phrase;
            pdfTable.AddCell(cell);
        }


        public static  void PDFAddCellWC(PdfPTable pdfTable, string text, int colspan, string align, iTextSharp.text.Font FontBase, iTextSharp.text.Color color)
        {
            PdfPCell cell = new PdfPCell();
            cell.Colspan = colspan;
            cell.BackgroundColor = color;
            switch (align)
            {
                case "L":
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    break;
                case "C":
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                case "R":
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    break;
                default:
                    break;
            }
            Phrase phrase = new Phrase(text, FontBase);
            cell.Phrase = phrase;
            pdfTable.AddCell(cell);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WaveLab.Service.Pdf
{
    class PageEventHelper:PdfPageEventHelper
    {
        public string headImage = Setting.ImagesPath + "logo_bg_white.jpg";

        public string footerImage=Setting.ImagesPath + "wavelab_bg_white.jpg";              

        public override void OnStartPage(PdfWriter writer, Document document)
        {
           
            Image imghead = iTextSharp.text.Image.GetInstance(headImage);
            Image imgfoot = iTextSharp.text.Image.GetInstance(footerImage);

            imgfoot.ScaleToFit(590, 225);
            imghead.ScaleToFit(170, 42);
            imgfoot.SetAbsolutePosition(0, 0);
            imghead.SetAbsolutePosition(30, 0);

            PdfContentByte cbhead = writer.DirectContent;
            PdfTemplate tp = cbhead.CreateTemplate(180, 42);
            tp.AddImage(imghead);

            PdfContentByte cbfoot = writer.DirectContent;
            PdfTemplate tpl = cbfoot.CreateTemplate(590, 225);
            tpl.AddImage(imgfoot);

            cbhead.AddTemplate(tp, 0, 765);
            cbfoot.AddTemplate(tpl, 0, 10);

            Phrase headPhraseImg = new Phrase(cbhead + "", Helper.PDFHelper.SimSunFont12);
            Phrase footPhraseImg = new Phrase(cbfoot + "", Helper.PDFHelper.SimSunFont12);

            HeaderFooter header = new HeaderFooter(headPhraseImg, true);
            HeaderFooter footer = new HeaderFooter(footPhraseImg, true);
            
            base.OnStartPage(writer, document);
        }
    }
}

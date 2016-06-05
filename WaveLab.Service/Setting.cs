using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections;
using System.Configuration;

namespace WaveLab.Service
{
    public sealed class Setting
    {

        public static string sampleExcelPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["sampleExcelpath"]);

        public static string TempFilePath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["temppath"]);

        public static string ImagesPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["imagepath"]);

        public static string courFontPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["fontpath"])+"cour.ttf";

        public static string simsunFontPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["fontpath"])+"simsun.ttc" + ",1";

        public static string free30F9FontPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["fontpath"]) + "FREE3OF9.TTF";
    }
}

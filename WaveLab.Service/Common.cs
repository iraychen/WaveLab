using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WaveLab.Service
{
    public sealed class Common
    {
       public  static string GetTempFileName(string ext)
       {
           Random random = new Random();
           StringBuilder builder = new StringBuilder();
           builder.Append(HttpContext.Current.User.Identity.Name + "_");
           builder.Append("SecurityMasterView_");
           builder.Append(DateTime.Now.ToString("yyyyMMddHHmmss") + "_");
           builder.Append(random.Next());
           builder.Append(ext);
           return builder.ToString();
       }
    }
}

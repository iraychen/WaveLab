using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace WaveLab.Service.Utility
{
   public sealed class WebUtitlity
    {
       public static string InputText(string text, int maxLength)
       {
           text = text.Trim();
           if (string.IsNullOrEmpty(text))
               return string.Empty;
           text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
           text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
           text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
           text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
           text = text.Replace("'", "''");
           if (text.Length > maxLength)
               text = text.Substring(0, maxLength);
           return text;
       }

       public static string LockScreen(string msg)
       {
           StringBuilder builder = new StringBuilder();
           builder.Append("<script type =\"text/javascript\">" + Convert.ToString((char)13));
           builder.Append("$(document).ready(function(){" + Convert.ToString((char)13));
           builder.Append("var overlayID=\"overlay\";" + Convert.ToString((char)13));
           builder.Append("var msgID = \"overlayMsg\";" + Convert.ToString((char)13));
           builder.Append("var scrolltop = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0;" + Convert.ToString((char)13));
           builder.Append("var _clientheight=0; " + Convert.ToString((char)13));
           builder.Append("_clientheight = Math.min(document.body.clientHeight , document.documentElement.clientHeight);" + Convert.ToString((char)13));
           builder.Append("if(_clientheight==0)" + Convert.ToString((char)13));
           builder.Append("_clientheight= Math.max(document.body.clientHeight , document.documentElement.clientHeight);" + Convert.ToString((char)13));
           builder.Append("var _clientwidth= document.documentElement.clientWidth || document.body.clientWidth;" + Convert.ToString((char)13));
           builder.Append("var _pageheight = Math.max(document.body.scrollHeight,document.documentElement.scrollHeight);" + Convert.ToString((char)13));
           builder.Append("var newDiv = document.createElement(\"div\");" + Convert.ToString((char)13));
           builder.Append("newDiv.id = msgID;" + Convert.ToString((char)13));
           builder.Append("newDiv.style.position = \"absolute\";" + Convert.ToString((char)13));
           builder.Append("newDiv.style.zIndex = \"100\";" + Convert.ToString((char)13));
           builder.Append("newDiv.style.width = \"300px\";" + Convert.ToString((char)13));
           builder.Append("newDiv.style.height = \"100px\";" + Convert.ToString((char)13));
           builder.Append("var msgtop = (scrolltop+(_clientheight-100)/2)+\"px\";" + Convert.ToString((char)13));
           builder.Append("var msgleft = (_clientwidth-300)/2+\"px\";" + Convert.ToString((char)13));
           builder.Append("newDiv.style.position = \"absolute\";" + Convert.ToString((char)13));
           builder.Append("newDiv.style.top =\"50%\";" + Convert.ToString((char)13));
           builder.Append("newDiv.style.left =\"50%\"; ");
           builder.Append("newDiv.style.marginTop = \"-50px\";" + Convert.ToString((char)13));
           builder.Append("newDiv.style.marginLeft =\"-150px\"; " + Convert.ToString((char)13));
           builder.Append("newDiv.style.background = \"#EFEFEF\";" + Convert.ToString((char)13));
           builder.Append("newDiv.style.border = \"1px solid #000000\";" + Convert.ToString((char)13));
           builder.Append("newDiv.style.padding = \"5px\";" + Convert.ToString((char)13));
           builder.Append("newDiv.innerHTML = \"<div style='width:260px; height:100px; float:left;'><image src='images/Dialog-Warning.png'/><div style='padding:10px 0px 0px 30px;vertical-align:top;text-align:center;font-size:14px;font-weight:bold;'>" + msg + "</div><br/></div>\";" + Convert.ToString((char)13));
           builder.Append("document.body.appendChild(newDiv);" + Convert.ToString((char)13));
           builder.Append("var newMask = document.createElement(\"div\");" + Convert.ToString((char)13));
           builder.Append(" newMask.id = overlayID;" + Convert.ToString((char)13));
           builder.Append(" newMask.style.position = \"absolute\";" + Convert.ToString((char)13));
           builder.Append(" newMask.style.zIndex = \"99\";" + Convert.ToString((char)13));
           builder.Append(" newMask.style.width = \"100%\";" + Convert.ToString((char)13));
           builder.Append(" newMask.style.height = \"100%\";" + Convert.ToString((char)13));
           builder.Append("newMask.style.top = \"0px\";" + Convert.ToString((char)13));
           builder.Append(" newMask.style.left = \"0px\";" + Convert.ToString((char)13));
           builder.Append(" newMask.style.background = \"#777\";" + Convert.ToString((char)13));
           builder.Append(" newMask.style.filter =\"progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75\";" + Convert.ToString((char)13));
           builder.Append(" newMask.innerHTML = \" <div style='width:100%; height::100%; position:relative'></div>\";" + Convert.ToString((char)13));
           builder.Append(" newMask.style.opacity = \"0.40\";" + Convert.ToString((char)13));
           builder.Append(" document.body.appendChild(newMask);" + Convert.ToString((char)13));
           builder.Append("});" + Convert.ToString((char)13));
           builder.Append("</script>");
           return builder.ToString();
       }

       public static bool IsDateFormat(string value)
       {
           if (string.IsNullOrEmpty(value) || value.Length == 0)
           {
               return true;
           }
           if (value.Length < 1 || value.Length != 10)
           {
               return false;
           }
           int year, month, day;
           string[] dateArray = value.Split('-');
           if (dateArray.Length != 3)
           {
               return false;
           }
           year = int.Parse(dateArray[0]);
           month = int.Parse(dateArray[1]);
           day = int.Parse(dateArray[2]);
           if (month > 12 || month < 1)
           {
               return false;
           }

           if ((month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) && (month > 31 || month < 1))
           {
               return false;
           }
           if ((month == 4 || month == 6 || month == 9 || month == 11) && (month > 30 || month < 1))
           {
               return false;
           }
           if (month == 2)
           {
               if (day < 1)
               {
                   return false;
               }
               if (LeapYear(year) == true)
               {
                   if (day > 29)
                   {
                       return false;
                   }
               }
               else
               {
                   if (day > 28)
                   {
                       return false;
                   }

               }
           }
           return true;

       }

       public static bool LeapYear(int year)
       {
           if (year % 100 == 0)
           {
               if (year % 400 == 0) { return true; }
           }
           else
           {
               if ((year % 4) == 0) { return true; }
           }
           return false;
       }

       public static void ShowStartUpMessage(System.Web.UI.Page page, string message)
       {
           page.ClientScript.RegisterStartupScript(page.GetType(), "msg", "<script type='text/javascript'>alert('" + message + "');</script>");
       }

       public static void ShowBlockMessage(System.Web.UI.Page page,string message)
       {
           page.ClientScript.RegisterClientScriptBlock(page.GetType(), "msg", "<script type='text/javascript'>alert('" + message + "');</script>");
       }
    }
}

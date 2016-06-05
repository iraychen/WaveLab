using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
   [Serializable]
   public class ItemInfo
    {
       private string _ItemValue;
       private string _ItemText;

       public string ItemValue
       {
           get
           {
               return this._ItemValue;
           }
           set
           {
               this._ItemValue = value;
           }
       }

       public string ItemText
       {
           get
           {
               return this._ItemText;
           }
           set
           {
               this._ItemText = value;
           }
       }

    }
}

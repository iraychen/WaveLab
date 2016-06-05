using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;
using System.Collections;
using System.IO;

namespace WaveLab.IService
{
    public  interface IProductBomReportService
    {
        MemoryStream Export(string title, Hashtable paras,bool showProduct, ArrayList arrayList, IList<WaveLab.Model.ProductBomInfo> items);
    }
}

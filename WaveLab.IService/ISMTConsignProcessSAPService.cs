using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ISMTConsignProcessSAPService
    {
        
       // MemoryStream Export(string templateFileName, List<ConsignProcessInfo> items);

        MemoryStream ExportForAufnr(string templateFileName, string aufnr, string bdmng,string vco, SMTFileInduceInfo item);
    }
}

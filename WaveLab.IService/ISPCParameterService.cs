using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ISPCParameterService
    {
        IList<SPCParameterInfo> Query();

        DataTable Upload(Stream excelFileStream, string SheetName);

        void Import(IList<SPCParameterInfo> items);

        SPCParameterInfo GetDetail(int n);
    }
}

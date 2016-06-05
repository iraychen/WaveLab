using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ISMTFileInduceImportService
    {
        DataTable Import(SYSModuleTypeInfo moduleTypeItem, Stream excelFileStream, string SheetName);
    }
}

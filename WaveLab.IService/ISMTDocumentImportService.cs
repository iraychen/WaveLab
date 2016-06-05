using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace WaveLab.IService
{
    public interface ISMTDocumentImportService
    {
        DataTable Import(Stream excelFileStream, string SheetName);
    }
}

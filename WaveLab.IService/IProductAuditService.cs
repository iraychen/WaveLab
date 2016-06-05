using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WaveLab.Model;

namespace WaveLab.IService
{
    public interface IProductAuditService
    {
         MemoryStream ExportProductAudit(string title, IList<DictionaryEntry> paras, ArrayList headerArray, IList<ProductAuditInfo> items);

    }
}

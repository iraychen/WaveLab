using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface IMCTReportService
    {
        IList<RptMCTMTAnalysisInfo> QueryMCTMTAnalysis(Hashtable hashTable, string sortBy, string orderBy);

        IList<RptMCTOriginalInfo> QueryMCTOriginal(Hashtable hashTable, string sortBy, string orderBy);

        IList<RptMCTCountInfo> QueryMCTCount(Hashtable hashTable, string sortBy, string orderBy);

        IList<MCTDtlInfo> GetMaterialSubstances(string materialCode, string materialDesc, string supplierName, string sortBy, string orderBy);


        MemoryStream ExportMCTMTAnalysis(string title, IList<DictionaryEntry> paras, bool showProduct, ArrayList headerArray, IList<WaveLab.Model.RptMCTMTAnalysisInfo> items);

        MemoryStream ExportMCTOriginal(string title, IList<DictionaryEntry> paras, bool showProduct, ArrayList headerArray, IList<WaveLab.Model.RptMCTOriginalInfo> items);

        MemoryStream ExportMCTCount(string title, IList<DictionaryEntry> paras, bool showProduct, ArrayList headerArray, IList<WaveLab.Model.RptMCTCountInfo> items);

    }
}

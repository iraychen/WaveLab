using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IMCTReport
    {
        IList<RptMCTCountInfo> QueryMCTCount( Hashtable hashTable, string sortBy, string orderBy);

        IList<RptMCTOriginalInfo> QueryMCTOriginal(Hashtable hashTable, string sortBy, string orderBy);

        IList<RptMCTMTAnalysisInfo> QueryMCTMTAnalysis(Hashtable hashTable, string sortBy, string orderBy);

        IList<MCTDtlInfo> GetMaterialSubstances(string materialCode, string materialDesc, string supplierName, string sortBy, string orderBy);

    }
}

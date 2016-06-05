using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCSDPartRxFreqPointXMR
    {
      
        int QueryHistory(Hashtable hashTable);

        IList<SPCSDPartRxFreqPointXMRInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        SPCSDPartRxFreqPointXMRInfo Get(int XMRPK);

        void SaveException(int XMRPK, IList<SPCSDPartRxFreqPointException> ExceptionItems);

    }
}

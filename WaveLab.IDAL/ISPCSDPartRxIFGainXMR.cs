using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCSDPartRxIFGainXMR
    {
      
        int QueryHistory(Hashtable hashTable);

        IList<SPCSDPartRxIFGainXMRInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        SPCSDPartRxIFGainXMRInfo Get(int XMRPK);

        void SaveException(int XMRPK, IList<SPCSDPartRxIFGainException> ExceptionItems);

    }
}

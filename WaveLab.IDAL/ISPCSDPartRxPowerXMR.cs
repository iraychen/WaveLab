using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCSDPartRxPowerXMR
    {
      
        int QueryHistory(Hashtable hashTable);

        IList<SPCSDPartRxPowerXMRInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        SPCSDPartRxPowerXMRInfo Get(int XMRPK);

        void SaveException(int XMRPK, IList<SPCSDPartRxPowerException> ExceptionItems);

    }
}

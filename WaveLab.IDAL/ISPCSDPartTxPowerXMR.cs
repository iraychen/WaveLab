using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCSDPartTxPowerXMR
    {
      
        int QueryHistory(Hashtable hashTable);

        IList<SPCSDPartTxPowerXMRInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        SPCSDPartTxPowerXMRInfo Get(int XMRPK);

        void SaveException(int XMRPK, IList<SPCSDPartTxPowerException> ExceptionItems);

    }
}

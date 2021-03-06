﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCSDPartTxGainXMR
    {
      
        int QueryHistory(Hashtable hashTable);

        IList<SPCSDPartTxGainXMRInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        SPCSDPartTxGainXMRInfo Get(int XMRPK);

        void SaveException(int XMRPK, IList<SPCSDPartTxGainException> ExceptionItems);

    }
}

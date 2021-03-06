﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface INTTxSpur
    {
        int Query(Hashtable hashTable);

        IList<NTTxSpurInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<NTTxSpurInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        NTTxSpurInfo GetDetail(int NTTxSpurId);
    }
}

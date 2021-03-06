﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface INTRxMicro
    {
        int Query(Hashtable hashTable);

        IList<NTRxMicroInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<NTRxMicroInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        NTRxMicroInfo GetDetail(int NTRxMicroPK);
    }
}

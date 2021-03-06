﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface INTRxPower
    {
        int Query(Hashtable hashTable);

        IList<NTRxPowerInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<NTRxPowerInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        NTRxPowerInfo GetDetail(int NTRxPowerId);
    }
}

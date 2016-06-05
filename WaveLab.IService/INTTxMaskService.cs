﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface INTTxMaskService
    {
        int Query(Hashtable hashTable);

        IList<NTTxMaskInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<NTTxMaskInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        NTTxMaskInfo GetDetail(int NTTxMaskId);
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface INTTxMaskFlatService
    {
        int Query(Hashtable hashTable);

        IList<NTTxMaskFlatInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<NTTxMaskFlatInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        NTTxMaskFlatInfo GetDetail(int NTTxMaskFlatId);
    }
}

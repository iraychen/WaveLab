﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ITemCirculation
    {
        int Query(Hashtable hashTable);

        IList<TemCirculationInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<TemCirculationInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        TemCirculationInfo GetDetail(int temCirculationId);
    }
}

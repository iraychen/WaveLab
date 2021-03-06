﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IFQATxPower
    {
        int Query(Hashtable hashTable);

        IList<FQATxPowerInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<FQATxPowerInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        FQATxPowerInfo GetDetail(int FQATxPowerId);
    }
}

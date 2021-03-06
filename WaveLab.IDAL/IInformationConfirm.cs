﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IInformationConfirm
    {
        int Query(Hashtable hashTable);

        IList<InformationConfirmInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<InformationConfirmInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        InformationConfirmInfo GetDetail(int confirmId);
    }
}

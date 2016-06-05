﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IIFBTestResult
    {
        int Query(Hashtable hashTable);

        IList<IFBTestResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<IFBTestResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        IFBTestResultInfo GetDetail(int IFBTestResultId);
    }
}

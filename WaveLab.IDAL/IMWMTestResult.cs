﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IMWMTestResult
    {
        int Query(Hashtable hashTable);

        IList<MWMTestResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<MWMTestResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        MWMTestResultInfo GetDetail(int MWMTestResultId);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IRxResult
    {
        int Query(Hashtable hashTable);

        IList<RxResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<RxResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        RxResultInfo GetDetail(int rxResultId);
    }
}

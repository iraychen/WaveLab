using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface IFQARxResultService
    {
        int Query(Hashtable hashTable);

        IList<FQARxResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<FQARxResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        FQARxResultInfo GetDetail(int FQARxResultId);
    }
}

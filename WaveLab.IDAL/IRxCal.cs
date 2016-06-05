using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IRxCal
    {
        int Query(Hashtable hashTable);

        IList<RxCalInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<RxCalInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        RxCalInfo GetDetail(int rxCalId);
    }
}

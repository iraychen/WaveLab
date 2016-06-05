using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface INTRxMSEService
    {
        int Query(Hashtable hashTable);

        IList<NTRxMSEInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<NTRxMSEInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        NTRxMSEInfo GetDetail(int NTRxMSEId);
    }
}

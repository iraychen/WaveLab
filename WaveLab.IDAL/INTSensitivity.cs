using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface INTSensitivity
    {
        int Query(Hashtable hashTable);

        IList<NTSensitivityInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<NTSensitivityInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        NTSensitivityInfo GetDetail(int NTSensitivityId);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface IGeneralInitService
    {
        int Query(Hashtable hashTable);

        IList<GeneralInitInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<GeneralInitInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        GeneralInitInfo GetDetail(int generalInitId);

        bool GeneralInitCheck(string serialNo);
    }
}

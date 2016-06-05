using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;


namespace WaveLab.IService
{
    public interface ITxPowerService
    {
        int Query(Hashtable hashTable);

        IList<TxPowerInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<TxPowerInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        TxPowerInfo GetDetail(int txPowerId);

     
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;


namespace WaveLab.IService
{
    public interface ITxCableService
    {
        int Query(Hashtable hashTable);

        IList<TxCableInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<TxCableInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        TxCableInfo GetDetail(int txCableId);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ITxCalService
    {
        int Query(Hashtable hashTable);

        IList<TxCalInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<TxCalInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        TxCalInfo GetDetail(int txCalId);
    }
}

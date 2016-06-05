using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;


namespace WaveLab.IService
{
    public interface IProtocolInitService
    {
        int Query(Hashtable hashTable);

        IList<ProtocolInitInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<ProtocolInitInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        ProtocolInitInfo GetDetail(int protocolInitId);
    }
}

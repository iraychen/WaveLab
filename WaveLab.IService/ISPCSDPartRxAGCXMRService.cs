using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;


namespace WaveLab.IService
{
    public interface ISPCSDPartRxAGCXMRService
    {

        int QueryHistory(Hashtable hashTable);

        IList<SPCSDPartRxAGCXMRInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        SPCSDPartRxAGCXMRInfo Get(int XMRPK);

        void SaveException(int XMRPK, IList<SPCSDPartRxAGCException> ExceptionItems);
    }
}

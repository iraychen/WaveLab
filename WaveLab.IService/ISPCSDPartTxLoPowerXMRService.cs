using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;


namespace WaveLab.IService
{
    public interface ISPCSDPartTxLoPowerXMRService
    {

        int QueryHistory(Hashtable hashTable);

        IList<SPCSDPartTxLoPowerXMRInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        SPCSDPartTxLoPowerXMRInfo Get(int XMRPK);

        void SaveException(int XMRPK, IList<SPCSDPartTxLoPowerException> ExceptionItems);
    }
}

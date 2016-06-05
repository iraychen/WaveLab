using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

namespace WaveLab.Service
{
    public class SPCSDPartTxGainXMRService : ISPCSDPartTxGainXMRService
    {
        public ISPCSDPartTxGainXMR dal;

        public int QueryHistory(Hashtable hashTable)
        {
            return dal.QueryHistory(hashTable);
        }

        public IList<SPCSDPartTxGainXMRInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.QueryHistory(hashTable, sortBy, orderBy, page, pageSize);
        }
      
        public SPCSDPartTxGainXMRInfo Get(int XMRPK)
        {
            return dal.Get(XMRPK);
        }

        public void SaveException(int ReturnLossPK, IList<SPCSDPartTxGainException> ExceptionItems)
        {
            dal.SaveException(ReturnLossPK, ExceptionItems);
        }
    }
}

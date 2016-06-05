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
    public class SPCSDPartRxPowerXMRService : ISPCSDPartRxPowerXMRService
    {
        public ISPCSDPartRxPowerXMR dal;

        public int QueryHistory(Hashtable hashTable)
        {
            return dal.QueryHistory(hashTable);
        }

        public IList<SPCSDPartRxPowerXMRInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.QueryHistory(hashTable, sortBy, orderBy, page, pageSize);
        }
      
        public SPCSDPartRxPowerXMRInfo Get(int XMRPK)
        {
            return dal.Get(XMRPK);
        }

        public void SaveException(int ReturnLossPK, IList<SPCSDPartRxPowerException> ExceptionItems)
        {
            dal.SaveException(ReturnLossPK, ExceptionItems);
        }
    }
}

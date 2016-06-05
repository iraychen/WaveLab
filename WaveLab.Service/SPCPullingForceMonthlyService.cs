using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.IDAL;
using WaveLab.IService;
using WaveLab.Model;

namespace WaveLab.Service
{
    public class SPCPullingForceMonthlyService : ISPCPullingForceMonthlyService
    {
        public ISPCPullingForceMonthly dal;

        public IList<SPCPullingForceMonthlyInfo> GetYearMonth()
        {
            return dal.GetYearMonth();
        }
        public int Query(Hashtable hashTable)
        {
            return dal.Query(hashTable);
        }

        public IList<SPCPullingForceMonthlyInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.Query(hashTable, sortBy, orderBy, page, pageSize);
        }

        public SPCPullingForceMonthlyInfo GetDetail(int PullingForceMonthlyPK)
        {
            return dal.GetDetail(PullingForceMonthlyPK);
        }

        public void Save(int PullingForceMonthlyPK, IList<SPCPullingForceMonthlyException> ExceptionItems)
        {
            dal.Save(PullingForceMonthlyPK, ExceptionItems);
        }
    }
}

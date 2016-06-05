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
    public class SPCPullingForceWeeklyService : ISPCPullingForceWeeklyService
    {
        public ISPCPullingForceWeekly dal;

        public int Query(Hashtable hashTable)
        {
            return dal.Query(hashTable);
        }

        public IList<SPCPullingForceWeeklyInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.Query(hashTable, sortBy, orderBy, page, pageSize);
        }

        public SPCPullingForceWeeklyInfo GetDetail(int PullingForceWeeklyPK)
        {
            return dal.GetDetail(PullingForceWeeklyPK);
        }

        public void Save(int PullingForceWeeklyPK, IList<SPCPullingForceWeeklyException> ExceptionItems)
        {
            dal.Save(PullingForceWeeklyPK, ExceptionItems);
        }
    }
}

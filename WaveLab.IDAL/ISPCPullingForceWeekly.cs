using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCPullingForceWeekly
    {
        int Query(Hashtable hashTable);

        IList<SPCPullingForceWeeklyInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        SPCPullingForceWeeklyInfo GetDetail(int PullingForceWeeklyPK);

        void Save(int PullingForceWeeklyPK, IList<SPCPullingForceWeeklyException> ExceptionItems);

    }
}

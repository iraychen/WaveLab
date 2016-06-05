using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCPullingForceMonthly
    {
        IList<SPCPullingForceMonthlyInfo> GetYearMonth();

        int Query(Hashtable hashTable);

        IList<SPCPullingForceMonthlyInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        SPCPullingForceMonthlyInfo GetDetail(int PullingForceMonthlyPK);

        void Save(int PullingForceMonthlyPK, IList<SPCPullingForceMonthlyException> ExceptionItems);
    }
}

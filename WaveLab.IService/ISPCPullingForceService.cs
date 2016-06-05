using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ISPCPullingForceService
    {
        int Query(Hashtable hashTable);

        IList<SPCPullingForceInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        bool CheckExists(string machineNo, string workingDate);

        void Save(SPCPullingForceInfo entity);

        SPCPullingForceInfo GetDetail(int PullingForcePK);

        void Update(SPCPullingForceInfo entity);

        void Delete(Int32 PullingForcePK);

    }
}

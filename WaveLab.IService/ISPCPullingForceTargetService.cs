using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ISPCPullingForceTargetService
    {
    
        IList<SPCPullingForceTargetInfo> Query(string sortBy, string orderBy);

        bool CheckExists(string machineNo, string effectiveDate);

        void Save(SPCPullingForceTargetInfo entity);

        SPCPullingForceTargetInfo GetDetail(int PullingForceTargetPK);

        void Update(SPCPullingForceTargetInfo entity);

        void Delete(Int32 PullingForceTargetPK);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

namespace WaveLab.Service
{
    public class SPCPullingForceTargetService : ISPCPullingForceTargetService
    {
        public ISPCPullingForceTarget dal;

        public IList<SPCPullingForceTargetInfo> Query(string sortBy, string orderBy)
        {
            return dal.Query(sortBy, orderBy);
        }

        public bool CheckExists(string machineNo, string effectiveDate)
        {
            return dal.CheckExists(machineNo, effectiveDate);
        }

        public void Save(SPCPullingForceTargetInfo entity)
        {
            dal.Save(entity);
        }

        public SPCPullingForceTargetInfo GetDetail(int PullingForceTargetPK)
        {
            return dal.GetDetail(PullingForceTargetPK);
        }

        public void Update(SPCPullingForceTargetInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(Int32 PullingForcePK)
        {
            dal.Delete(PullingForcePK);
        }
    }
}

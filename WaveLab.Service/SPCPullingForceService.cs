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
    public class SPCPullingForceService : ISPCPullingForceService
    {
        public ISPCPullingForce dal;

        public int Query(Hashtable hashTable)
        {
            return dal.Query(hashTable);
        }

        public IList<SPCPullingForceInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.Query(hashTable, sortBy, orderBy, page, pageSize);
        }

        public bool CheckExists(string machineNo, string workingDate)
        {
            return dal.CheckExists(machineNo, workingDate);
        }

        public void Save(SPCPullingForceInfo entity)
        {
            dal.Save(entity);
        }

        public SPCPullingForceInfo GetDetail(int PullingForcePK)
        {
            return dal.GetDetail(PullingForcePK);
        }

        public void Update(SPCPullingForceInfo entity)
        {
             dal.Update(entity);
        }

        public void Delete(Int32 PullingForcePK)
        {
            dal.Delete(PullingForcePK);
        }
    }
}

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
    public class SPCSDPartMAMService : ISPCSDPartMAMService
    {
        public ISPCSDPartMAM dal;

        public IList<string> GetStationItems()
        {
            return dal.GetStationItems();
        }



        public IList<SPCSDPartMAMInfo> Query(Hashtable hashTable,string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

        public int GetSDParts(Hashtable hashTable)
        {
            return dal.GetSDParts(hashTable);
        }

        public IList<SPCSDPartMAMInfo> GetSDParts(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.GetSDParts(hashTable, sortBy, orderBy, page, pageSize);
        }

        public bool CheckExists(string StationNo, string SerialNo)
        {
            return dal.CheckExists(StationNo, SerialNo);
        }

        public void Save(SPCSDPartMAMInfo entity)
        {
            dal.Save(entity);
        }

        public SPCSDPartMAMInfo Get(int SDPartPK)
        {
            return dal.Get(SDPartPK);
        }

        public void Update(SPCSDPartMAMInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SPCSDPartMAMInfo entity)
        {
            dal.Delete(entity);
        }
    }
}

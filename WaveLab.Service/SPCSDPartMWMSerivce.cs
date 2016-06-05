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
    public class SPCSDPartMWMService : ISPCSDPartMWMService
    {
        public ISPCSDPartMWM dal;

        public IList<string> GetStationItems()
        {
            return dal.GetStationItems();
        }



        public IList<SPCSDPartMWMInfo> Query(Hashtable hashTable,string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

        public int GetSDParts(Hashtable hashTable)
        {
            return dal.GetSDParts(hashTable);
        }

        public IList<SPCSDPartMWMInfo> GetSDParts(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.GetSDParts(hashTable, sortBy, orderBy, page, pageSize);
        }

        public bool CheckExists(string StationNo,  string TxIndex, string SerialNo)
        {
            return dal.CheckExists(StationNo,TxIndex, SerialNo);
        }

        public void Save(SPCSDPartMWMInfo entity)
        {
            dal.Save(entity);
        }

        public SPCSDPartMWMInfo Get(int SDPartPK)
        {
            return dal.Get(SDPartPK);
        }

        public void Update(SPCSDPartMWMInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SPCSDPartMWMInfo entity)
        {
            dal.Delete(entity);
        }
    }
}

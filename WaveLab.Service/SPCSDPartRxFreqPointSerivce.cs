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
    public class SPCSDPartRxFreqPointService : ISPCSDPartRxFreqPointService
    {
        public ISPCSDPartRxFreqPoint dal;

        public IList<string> GetStationItems()
        {
            return dal.GetStationItems();
        }

        public IList<string> GetCHNoItems()
        {
            return dal.GetCHNoItems();
        }

        public IList<SPCSDPartRxFreqPointInfo> Query(Hashtable hashTable,string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

        public int GetSDParts(Hashtable hashTable)
        {
            return dal.GetSDParts(hashTable);
        }

        public IList<SPCSDPartRxFreqPointInfo> GetSDParts(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.GetSDParts(hashTable, sortBy, orderBy, page, pageSize);
        }

        public bool CheckExists(string StationNo, char Divide, string CHNo, string CH, string PW, string SerialNo)
        {
            return dal.CheckExists(StationNo,Divide , CHNo, CH, PW, SerialNo);
        }

        public void Save(SPCSDPartRxFreqPointInfo entity)
        {
            dal.Save(entity);
        }

        public SPCSDPartRxFreqPointInfo Get(int SDPartPK)
        {
            return dal.Get(SDPartPK);
        }

        public void Update(SPCSDPartRxFreqPointInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SPCSDPartRxFreqPointInfo entity)
        {
            dal.Delete(entity);
        }
    }
}

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
    public class SYSStationService : ISYSStationService
    {
        public ISYSStation dal;

        public IList<SYSStationInfo> Query(Hashtable hashTable, string sortBy, string oderBy)
        {
            return dal.Query(hashTable, sortBy, oderBy);
        }

        public bool CheckExists(string stationNo)
        {
            return dal.CheckExists(stationNo);
        }

        public void Save(SYSStationInfo entity)
        {
            dal.Save(entity);
        }

        public SYSStationInfo Get(string stationNo)
        {
            return dal.Get(stationNo);
        }

        public void Update(SYSStationInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SYSStationInfo entity)
        {
            dal.Delete(entity);
        }
    }
}

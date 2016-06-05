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
    public class SPCSDPartTxPowerService : ISPCSDPartTxPowerService
    {
        public ISPCSDPartTxPower dal;

        public IList<string> GetStationItems()
        {
            return dal.GetStationItems();
        }

        public IList<string> GetCHNoItems()
        {
            return dal.GetCHNoItems();
        }

        public IList<SPCSDPartTxPowerInfo> Query(Hashtable hashTable,string sortBy, string orderBy)
        {
            return dal.Query(hashTable,sortBy, orderBy);
        }

        public int GetSDParts(Hashtable hashTable)
        {
            return dal.GetSDParts(hashTable);
        }

        public IList<SPCSDPartTxPowerInfo> GetSDParts(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.GetSDParts(hashTable, sortBy, orderBy, page, pageSize);
        }

        public bool CheckExists(string StationNo, char Divide, string CHNo, string Mode, string CH, string PW, string SerialNo)
        {
            return dal.CheckExists(StationNo,Divide , CHNo, Mode, CH, PW, SerialNo);
        }

        public void Save(SPCSDPartTxPowerInfo entity)
        {
            dal.Save(entity);
        }

        public SPCSDPartTxPowerInfo Get(int StationProjectPK)
        {
            return dal.Get(StationProjectPK);
        }

        public void Update(SPCSDPartTxPowerInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SPCSDPartTxPowerInfo entity)
        {
            dal.Delete(entity);
        }
    }
}

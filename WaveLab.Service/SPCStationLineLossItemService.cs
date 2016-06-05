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
    public class SPCStationLineLossItemService : ISPCStationLineLossItemService
    {
        public ISPCStationLineLossItem dal;

        public IList<SPCStationLineLossItemInfo> Query(Hashtable hashTable, string sortBy, string oderBy)
        {
            return dal.Query(hashTable, sortBy, oderBy);
        }

        public bool CheckExists(string stationNo, string CHNo, string frequencyBand, string item)
        {
            return dal.CheckExists(stationNo,CHNo,frequencyBand, item);
        }

        public void Save(SPCStationLineLossItemInfo entity)
        {
            dal.Save(entity);
        }

        public SPCStationLineLossItemInfo Get(int LineLossItemPK)
        {
            return dal.Get(LineLossItemPK);
        }

        public bool CheckExists(string stationNo, string CHNo, string frequencyBand, string item, int LineLossItemPK)
        {
            return dal.CheckExists(stationNo,CHNo,frequencyBand, item, LineLossItemPK);
        }

        public void Update(SPCStationLineLossItemInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SPCStationLineLossItemInfo entity)
        {
            dal.Delete(entity);
        }

        public IList<SPCStationLineLossItemLogInfo> GetLogs(int LineLossItemPK)
        {
            return dal.GetLogs(LineLossItemPK);
        }
    }
}

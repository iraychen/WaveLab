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
    public class SPCRxPowerItemService : ISPCRxPowerItemService
    {
        public ISPCRxPowerItem dal;

        public IList<SPCRxPowerItemInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

     
        public bool CheckExists(SPCRxPowerItemInfo entity)
        {
            return dal.CheckExists(entity);
        }

        public void Save(SPCRxPowerItemInfo entity)
        {
            dal.Save(entity);
        }

        public SPCRxPowerItemInfo Get(int RxPowerItemPK)
        {
            return dal.Get(RxPowerItemPK);
        }

        public void Update(SPCRxPowerItemInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SPCRxPowerItemInfo entity)
        {
            dal.Delete(entity);
        }

        public IList<SPCRxPowerItemLogInfo> GetLogs(int RxPowerItemPK)
        {
            return dal.GetLogs(RxPowerItemPK);
        }
    }
}

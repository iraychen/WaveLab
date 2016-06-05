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
    public class SPCTxPowerItemService : ISPCTxPowerItemService
    {
        public ISPCTxPowerItem dal;

        public IList<SPCTxPowerItemInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

     
        public bool CheckExists(SPCTxPowerItemInfo entity)
        {
            return dal.CheckExists(entity);
        }

        public void Save(SPCTxPowerItemInfo entity)
        {
            dal.Save(entity);
        }

        public SPCTxPowerItemInfo Get(int TxPowerItemPK)
        {
            return dal.Get(TxPowerItemPK);
        }

        public void Update(SPCTxPowerItemInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SPCTxPowerItemInfo entity)
        {
            dal.Delete(entity);
        }

        public IList<SPCTxPowerItemLogInfo> GetLogs(int TxPowerItemPK)
        {
            return dal.GetLogs(TxPowerItemPK);
        }
    }
}

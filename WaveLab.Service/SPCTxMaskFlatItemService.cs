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
    public class SPCTxMaskFlatItemService : ISPCTxMaskFlatItemService
    {
        public ISPCTxMaskFlatItem dal;

        public IList<SPCTxMaskFlatItemInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

     
        public bool CheckExists(SPCTxMaskFlatItemInfo entity)
        {
            return dal.CheckExists(entity);
        }

        public void Save(SPCTxMaskFlatItemInfo entity)
        {
            dal.Save(entity);
        }

        public SPCTxMaskFlatItemInfo Get(int TxMaskFlatItemPK)
        {
            return dal.Get(TxMaskFlatItemPK);
        }

        public void Update(SPCTxMaskFlatItemInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SPCTxMaskFlatItemInfo entity)
        {
            dal.Delete(entity);
        }

        public IList<SPCTxMaskFlatItemLogInfo> GetLogs(int TxMaskFlatItemPK)
        {
            return dal.GetLogs(TxMaskFlatItemPK);
        }
     
    }
}

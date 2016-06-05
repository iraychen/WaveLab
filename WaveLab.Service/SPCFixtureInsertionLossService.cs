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
    public class SPCFixtureInsertionLossService : ISPCFixtureInsertionLossService
    {
        public ISPCFixtureInsertionLoss dal;

        public void SaveSPC(SPCFixtureInsertionLossInfo entity)
        {
            dal.SaveSPC(entity);
        }

        public SPCFixtureInsertionLossInfo Get(int InsertionLossPK)
        {
            return dal.Get(InsertionLossPK);
        }

        public void SaveException(int InsertionLossPK, IList<SPCFixtureInsertionLossException> ExceptionItems)
        {
            dal.SaveException(InsertionLossPK, ExceptionItems);
        }

        public SPCFixtureInsertionLossInfo GetLastestInsertionLoss(int FixtureItemPK)
        {
            return dal.GetLastestInsertionLoss(FixtureItemPK);
        }

        public void DeleteSPC(int FixtureItemPK)
        {
            dal.DeleteSPC(FixtureItemPK);
        }

        public int QueryHistory(Hashtable hashTable)
        {
            return dal.QueryHistory(hashTable);
        }

        public IList<SPCFixtureInsertionLossInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.QueryHistory(hashTable, sortBy, orderBy, page, pageSize);
        }
    }
}

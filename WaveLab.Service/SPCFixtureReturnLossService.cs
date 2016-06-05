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
    public class SPCFixtureReturnLossService : ISPCFixtureReturnLossService
    {
        public ISPCFixtureReturnLoss dal;

        public void SaveSPC(SPCFixtureReturnLossInfo entity)
        {
            dal.SaveSPC(entity);
        }

        public SPCFixtureReturnLossInfo Get(int ReturnLossPK)
        {
            return dal.Get(ReturnLossPK);
        }

        public void SaveException(int ReturnLossPK, IList<SPCFixtureReturnLossException> ExceptionItems)
        {
            dal.SaveException(ReturnLossPK, ExceptionItems);
        }

        public SPCFixtureReturnLossInfo GetLastestReturnLoss(int FixtureItemPK)
        {
            return dal.GetLastestReturnLoss(FixtureItemPK);
        }

        public void DeleteSPC(int FixtureItemPK)
        {
            dal.DeleteSPC(FixtureItemPK);
        }

        public int QueryHistory(Hashtable hashTable)
        {
            return dal.QueryHistory(hashTable);
        }

        public IList<SPCFixtureReturnLossInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.QueryHistory(hashTable, sortBy, orderBy, page, pageSize);
        }
    }
}

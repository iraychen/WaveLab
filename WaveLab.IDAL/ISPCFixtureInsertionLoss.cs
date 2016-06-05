using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCFixtureInsertionLoss
    {
        void SaveSPC(SPCFixtureInsertionLossInfo entity);

        SPCFixtureInsertionLossInfo Get(int InsertionLossPK);

        void SaveException(int InsertionLossPK, IList<SPCFixtureInsertionLossException> ExceptionItems);

        SPCFixtureInsertionLossInfo GetLastestInsertionLoss(int FixtureItemPK);

        void DeleteSPC(int FixtureItemPK);

        int QueryHistory(Hashtable hashTable);

        IList<SPCFixtureInsertionLossInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);
    }
}

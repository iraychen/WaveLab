using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCFixtureReturnLoss
    {
        void SaveSPC(SPCFixtureReturnLossInfo entity);

        SPCFixtureReturnLossInfo Get(int ReturnLossPK);

        void SaveException(int ReturnLossPK, IList<SPCFixtureReturnLossException> ExceptionItems);

        SPCFixtureReturnLossInfo GetLastestReturnLoss(int FixtureItemPK);

        void DeleteSPC(int FixtureItemPK);

        int QueryHistory(Hashtable hashTable);

        IList<SPCFixtureReturnLossInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);
    }
}

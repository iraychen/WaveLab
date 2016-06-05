using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCRxPowerItem
    {
        IList<SPCRxPowerItemInfo> Query(Hashtable hashTable, string sortby, string orderby);

        bool CheckExists(SPCRxPowerItemInfo item);

        SPCRxPowerItemInfo Get(int RxPowerItemPK);

        void Save(SPCRxPowerItemInfo item);

        void Update(SPCRxPowerItemInfo item);

        void Delete(SPCRxPowerItemInfo item);

        IList<SPCRxPowerItemLogInfo> GetLogs(int RxPowerItemPK);
    }
}

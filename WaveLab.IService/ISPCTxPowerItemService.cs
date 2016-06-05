using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;


namespace WaveLab.IService
{
    public interface ISPCTxPowerItemService
    {
        IList<SPCTxPowerItemInfo> Query(Hashtable hashTable, string sortby, string orderby);

        bool CheckExists(SPCTxPowerItemInfo item);

        SPCTxPowerItemInfo Get(int TxPowerItemPK);

        void Save(SPCTxPowerItemInfo item);

        void Update(SPCTxPowerItemInfo item);

        void Delete(SPCTxPowerItemInfo item);

        IList<SPCTxPowerItemLogInfo> GetLogs(int TxPowerItemPK);
    }
}

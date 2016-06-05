using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCTxMaskFlatItem
    {
        IList<SPCTxMaskFlatItemInfo> Query(Hashtable hashTable, string sortby, string orderby);

        bool CheckExists(SPCTxMaskFlatItemInfo item);

        void Save(SPCTxMaskFlatItemInfo item);

        SPCTxMaskFlatItemInfo Get(int TxMaskFlatItemPK);

        void Update(SPCTxMaskFlatItemInfo item);

        void Delete(SPCTxMaskFlatItemInfo item);

        IList<SPCTxMaskFlatItemLogInfo> GetLogs(int TxMaskFlatItemPK);
    }
}

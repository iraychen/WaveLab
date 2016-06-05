using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;


namespace WaveLab.IService
{
    public interface ISPCTxMaskFlatItemService
    {
        IList<SPCTxMaskFlatItemInfo> Query(Hashtable hashTable, string sortby, string orderby);

        bool CheckExists(SPCTxMaskFlatItemInfo item);

        SPCTxMaskFlatItemInfo Get(int TxMaskFlatItemPK);

        void Save(SPCTxMaskFlatItemInfo item);

        void Update(SPCTxMaskFlatItemInfo item);

        void Delete(SPCTxMaskFlatItemInfo item);

        IList<SPCTxMaskFlatItemLogInfo> GetLogs(int TxMaskFlatItemPK);
    }
}

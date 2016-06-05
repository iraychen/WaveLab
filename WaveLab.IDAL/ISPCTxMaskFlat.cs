using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCTxMaskFlat
    {
        IList<SPCTxMaskFlatItemInfo> Query(Hashtable hashTable, string sortby, string orderby);

        IList<SPCTxMaskFlatDetail> GetGroupData_Manual(Hashtable hashTable, string sortby, string orderby);

        IList<SPCTxMaskFlatDetail> GetGroupData_Auto(Hashtable hashTable, string sortby, string orderby);

        int Save(SPCTxMaskFlatInfo entity);

        int Query(Hashtable hashTable);

        IList<SPCTxMaskFlatInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        SPCTxMaskFlatInfo GetDetail(int TxMaskFlatPK);

        void Delete(SPCTxMaskFlatInfo entity);

        IList<SPCTxMaskFlatDetail> GetOrignalData(int TxMaskFlatPK, int GroupNo);

        int GetAutoLatest(string type, string mode, string ch);

        int LastestTargetCount(string type, string mode, string ch);

        SPCTxMaskFlatInfo GetLatestTarget(string type, string mode, string ch);

        void SaveException(int TxMaskFlatPK, IList<SPCTxMaskFlatException> ExceptionItems);
    }
}

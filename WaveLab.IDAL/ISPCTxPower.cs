using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCTxPower
    {
        IList<SPCTxPowerItemInfo> Query(Hashtable hashTable, string sortby, string orderby);

        IList<SPCTxPowerDetail> GetGroupData_Manual(Hashtable hashTable, string sortby, string orderby);

        IList<SPCTxPowerDetail> GetGroupData_Auto(Hashtable hashTable, string sortby, string orderby);

        int Save(SPCTxPowerInfo entity);

        int Query(Hashtable hashTable);

        IList<SPCTxPowerInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        int GetAutoLatest(string type, string mode, string ch, string pw);

        SPCTxPowerInfo GetDetail(int TxPowerPK);

        void Delete(SPCTxPowerInfo entity);

        IList<SPCTxPowerDetail> GetOrignalData(int TxPowerPK, int GroupNo);

      
        int LastestTargetCount(string type, string mode, string ch, string pw);

        SPCTxPowerInfo GetLatestTarget(string type, string mode, string ch, string pw);

        void SaveException(int TxPowerPK, IList<SPCTxPowerException> ExceptionItems);
    }
}

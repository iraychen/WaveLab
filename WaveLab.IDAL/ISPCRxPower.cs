using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCRxPower
    {
        IList<SPCRxPowerItemInfo> Query(Hashtable hashTable, string sortby, string orderby);

        IList<SPCRxPowerDetail> GetGroupData_Manual(Hashtable hashTable, string sortby, string orderby);

        IList<SPCRxPowerDetail> GetGroupData_Auto(Hashtable hashTable, string sortby, string orderby);

        int Save(SPCRxPowerInfo entity);

        int Query(Hashtable hashTable);

        IList<SPCRxPowerInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        SPCRxPowerInfo GetDetail(int RxPowerPK);

        void Delete(SPCRxPowerInfo entity);

        IList<SPCRxPowerDetail> GetOrignalData(int RxPowerPK, int GroupNo);

        int GetAutoLatest(string type, string mode, string ch, string pw);

        int LastestTargetCount(string type, string mode, string ch, string pw);

        SPCRxPowerInfo GetLatestTarget(string type, string mode, string ch, string pw);

        void SaveException(int RxPowerPK, IList<SPCRxPowerException> ExceptionItems);
    }
}

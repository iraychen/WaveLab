using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ISPCStationLineLossService
    {
        IList<SPCStationLineLossInput> Query(Hashtable hashTable, string sortBy, string orderBy);

        void SaveInput(SPCStationLineLossInput entity);

        SPCStationLineLossInput Get(int StationPK, int NoOfTimes);

        void UpdateInput(SPCStationLineLossInput entity);

        void SaveSPC(SPCStationLineLossInfo entity);

       int GetMaxNoOfTimes(int StationPK);

        SPCStationLineLossInfo Get(int LineLossPK);

        void SaveException(int LineLossPK, IList<SPCStationLineLossException> ExceptionItems);

        SPCStationLineLossInfo GetLastestLineLoss(int StationPK);

        bool CheckExists(int StationPK, string TestingDate);

        void DeleteInput(int StationPK, int MaxTimes);

        void DeleteSPC(int StationPK);

        int QueryHistory(Hashtable hashTable);

        IList<SPCStationLineLossInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

    }
}

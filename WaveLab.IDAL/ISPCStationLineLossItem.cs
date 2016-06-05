using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCStationLineLossItem
    {
        IList<SPCStationLineLossItemInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string stationNo, string CHNo, string frequencyBand, string item);

        void Save(SPCStationLineLossItemInfo entity);

        SPCStationLineLossItemInfo Get(int LineLossItemPK);

        bool CheckExists(string stationNo, string CHNo, string frequencyBand, string item, int LineLossItemPK);

        void Update(SPCStationLineLossItemInfo entity);

        void Delete(SPCStationLineLossItemInfo entity);

        IList<SPCStationLineLossItemLogInfo> GetLogs(int LineLossItemPK);
    }
}

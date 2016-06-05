using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ISPCSDPartRxPowerService
    {
        IList<string> GetStationItems();

        IList<string> GetCHNoItems();

        IList<SPCSDPartRxPowerInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        int GetSDParts(Hashtable hashTable);

        IList<SPCSDPartRxPowerInfo> GetSDParts(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        bool CheckExists(string StationNo, char Divide, string CHNo, string Mode, string CH, string PW, string SerialNo);

        void Save(SPCSDPartRxPowerInfo entity);

        SPCSDPartRxPowerInfo Get(int StationProjectPK);

        void Update(SPCSDPartRxPowerInfo entity);

        void Delete(SPCSDPartRxPowerInfo entity);
    }
}

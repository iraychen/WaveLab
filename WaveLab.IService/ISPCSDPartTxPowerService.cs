using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ISPCSDPartTxPowerService
    {
        IList<string> GetStationItems();

        IList<string> GetCHNoItems();

        IList<SPCSDPartTxPowerInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        int GetSDParts(Hashtable hashTable);

        IList<SPCSDPartTxPowerInfo> GetSDParts(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        bool CheckExists(string StationNo, char Divide, string CHNo, string Mode, string CH, string PW, string SerialNo);

        void Save(SPCSDPartTxPowerInfo entity);

        SPCSDPartTxPowerInfo Get(int StationProjectPK);

        void Update(SPCSDPartTxPowerInfo entity);

        void Delete(SPCSDPartTxPowerInfo entity);
    }
}

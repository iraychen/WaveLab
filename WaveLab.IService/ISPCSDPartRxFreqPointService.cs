using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ISPCSDPartRxFreqPointService
    {
        IList<string> GetStationItems();

        IList<string> GetCHNoItems();

        IList<SPCSDPartRxFreqPointInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        int GetSDParts(Hashtable hashTable);

        IList<SPCSDPartRxFreqPointInfo> GetSDParts(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        bool CheckExists(string StationNo, char Divide, string CHNo,  string CH, string PW, string SerialNo);

        void Save(SPCSDPartRxFreqPointInfo entity);

        SPCSDPartRxFreqPointInfo Get(int SDPartPK);

        void Update(SPCSDPartRxFreqPointInfo entity);

        void Delete(SPCSDPartRxFreqPointInfo entity);
    }
}

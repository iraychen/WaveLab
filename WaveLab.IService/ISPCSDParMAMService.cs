using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ISPCSDPartMAMService
    {
        IList<string> GetStationItems();


        IList<SPCSDPartMAMInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        int GetSDParts(Hashtable hashTable);

        IList<SPCSDPartMAMInfo> GetSDParts(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        bool CheckExists(string StationNo,  string SerialNo);

        void Save(SPCSDPartMAMInfo entity);

        SPCSDPartMAMInfo Get(int SDPartPK);

        void Update(SPCSDPartMAMInfo entity);

        void Delete(SPCSDPartMAMInfo entity);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCSDPartMWM
    {
        IList<string> GetStationItems();

        IList<SPCSDPartMWMInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        int GetSDParts(Hashtable hashTable);

        IList<SPCSDPartMWMInfo> GetSDParts(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        bool CheckExists(string StationNo, string TxIndex, string SerialNo);

        void Save(SPCSDPartMWMInfo entity);

        SPCSDPartMWMInfo Get(int SDPartPK);

        void Update(SPCSDPartMWMInfo entity);

        void Delete(SPCSDPartMWMInfo entity);
    }
}

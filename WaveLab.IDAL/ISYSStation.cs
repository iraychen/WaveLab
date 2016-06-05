using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISYSStation
    {
        IList<SYSStationInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string stationNo);

        void Save(SYSStationInfo entity);

        SYSStationInfo Get(string stationNo);

        void Update(SYSStationInfo entity);

        void Delete(SYSStationInfo entity);
    }
}

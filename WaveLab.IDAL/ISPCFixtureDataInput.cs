using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCFixtureDataInput
    {
        IList<SPCFixtureDataInputInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        void SaveInput(SPCFixtureDataInputInfo entity);

        SPCFixtureDataInputInfo Get(int FixtureItemPK, int NoOfTimes);

        void UpdateInput(SPCFixtureDataInputInfo entity);

        bool CheckExists(int FixtureItemPK, string TestingDate);

        void DeleteInput(int FixtureItemPK, int MaxTimes);

        int GetMaxNoOfTimes(int FixtureItemPK);
    }
}

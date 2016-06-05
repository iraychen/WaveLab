using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCFixtureItem
    {
        IList<SPCFixtureItemInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string fixture, string frequencyBand, string ch);

        void Save(SPCFixtureItemInfo entity);

        SPCFixtureItemInfo Get(int fixtureItemPK);

        bool CheckExists(string fixture,string frequencyBand,string ch ,int fixtureItemPK);

        void Update(SPCFixtureItemInfo entity);

        void Delete(SPCFixtureItemInfo entity);
    }
}

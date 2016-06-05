using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

namespace WaveLab.Service
{
    public class SPCFixtureItemService : ISPCFixtureItemService
    {
        public ISPCFixtureItem dal;

        public IList<SPCFixtureItemInfo> Query(Hashtable hashTable, string sortBy, string oderBy)
        {
            return dal.Query(hashTable, sortBy, oderBy);
        }

        public bool CheckExists(string fixture, string frequencyBand, string ch)
        {
            return dal.CheckExists(fixture, frequencyBand, ch);
        }

        public void Save(SPCFixtureItemInfo entity)
        {
            dal.Save(entity);
        }

        public SPCFixtureItemInfo Get(int stationPK)
        {
            return dal.Get(stationPK);
        }

        public bool CheckExists(string fixture,string frequencyBand,string ch ,int fixtureItemPK)
        {
          return dal.CheckExists(fixture, frequencyBand, ch, fixtureItemPK);
        }

        public void Update(SPCFixtureItemInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SPCFixtureItemInfo entity)
        {
            dal.Delete(entity);
        }
    }
}

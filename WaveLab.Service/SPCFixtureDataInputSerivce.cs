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
    public class SPCFixtureDataInputService : ISPCFixtureDataInputService
    {
        public ISPCFixtureDataInput dal;

        public IList<SPCFixtureDataInputInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

        public void SaveInput(SPCFixtureDataInputInfo entity)
        {
            dal.SaveInput(entity);
        }

        public SPCFixtureDataInputInfo Get(int FixtureItemPK, int NoOfTimes)
        {
            return dal.Get(FixtureItemPK, NoOfTimes);
        }

        public void UpdateInput(SPCFixtureDataInputInfo entity)
        {
            UpdateInput(entity);
        }

        public bool CheckExists(int FixtureItemPK, string TestingDate)
        {
            return dal.CheckExists(FixtureItemPK, TestingDate);
        }

        public void DeleteInput(int FixtureItemPK, int MaxTimes)
        {
            dal.DeleteInput(FixtureItemPK,MaxTimes);
        }

        public int GetMaxNoOfTimes(int FixtureItemPK)
        {
            return dal.GetMaxNoOfTimes(FixtureItemPK);
        }
    }
}

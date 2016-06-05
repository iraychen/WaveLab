using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

namespace WaveLab.Service
{
    public class MAMDataRangeService : IMAMDataRangeService
    {
        public IMAMDataRange dal;

        public int Query(Hashtable hashTable)
        {
            return dal.Query(hashTable);
        }

        public IList<MAMDataRangeInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.Query(hashTable, sortBy, orderBy, page, pageSize);
        }

        public bool CheckExists(string MAMType, string data)
        {
            return dal.CheckExists(MAMType, data);
        }

        public void Save(IList<MAMDataRangeInfo> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                dal.Save(items[i]);
            }
        }

        public IList<MAMDataRangeInfo> GetDetail(string MAMType, string data)
        {
            return dal.GetDetail(MAMType, data);
        }

        public void Delete(string MAMType, string data)
        {
            dal.Delete(MAMType, data);
        }

        public bool CheckExists(string MAMType, string data, string frequency)
        {
            return dal.CheckExists(MAMType, data, frequency);
        }

        public void Update(IList<MAMDataRangeInfo> newItems, IList<MAMDataRangeInfo> editItems, IList<MAMDataRangeInfo> deleteItems)
        {
            for (int i = 0; i < newItems.Count; i++)
            {
                dal.Save(newItems[i]);
            }

            for (int i = 0; i < editItems.Count; i++)
            {
                dal.Update(editItems[i]);
            }

            for (int i = 0; i < deleteItems.Count; i++)
            {
                dal.Delete(deleteItems[i]);
            }
        }
    }
}

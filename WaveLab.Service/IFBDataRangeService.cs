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
    public class IFBDataRangeService : IIFBDataRangeService
    {
        public IIFBDataRange dal;

        public int Query(Hashtable hashTable)
        {
            return dal.Query(hashTable);
        }

        public IList<IFBDataRangeInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.Query(hashTable, sortBy, orderBy, page, pageSize);
        }

        public bool CheckExists( string data)
        {
            return dal.CheckExists(data);
        }

        public void Save(IList<IFBDataRangeInfo> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                dal.Save(items[i]);
            }
        }

        public IList<IFBDataRangeInfo> GetDetail(string data)
        {
            return dal.GetDetail(data);
        }

        public void Delete(string data)
        {
            dal.Delete( data);
        }

        public bool CheckExists(string data, string frequency)
        {
            return dal.CheckExists(data, frequency);
        }

        public void Update(IList<IFBDataRangeInfo> newItems, IList<IFBDataRangeInfo> editItems, IList<IFBDataRangeInfo> deleteItems)
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

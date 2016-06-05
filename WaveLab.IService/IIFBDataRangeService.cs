using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface IIFBDataRangeService
    {
        int Query(Hashtable hashTable);

        IList<IFBDataRangeInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        bool CheckExists(string data);

        void Save(IList<IFBDataRangeInfo> items);

        IList<IFBDataRangeInfo> GetDetail(string data);

        void Delete(string data);

        bool CheckExists(string data, string frequency);

        void Update(IList<IFBDataRangeInfo> newItems, IList<IFBDataRangeInfo> editItems, IList<IFBDataRangeInfo> deleteItems);
    }
}

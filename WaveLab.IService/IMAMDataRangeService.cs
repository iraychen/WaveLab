using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface IMAMDataRangeService
    {
        int Query(Hashtable hashTable);

        IList<MAMDataRangeInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        bool CheckExists(string MAMType, string data);

        void Save(IList<MAMDataRangeInfo> items);

        void Delete(string MAMType, string data);

        IList<MAMDataRangeInfo> GetDetail(string MAMType, string data);

        bool CheckExists(string MAMType, string data, string frequency);

        void Update(IList<MAMDataRangeInfo> newItems, IList<MAMDataRangeInfo> editItems, IList<MAMDataRangeInfo> deleteItems);
    }
}

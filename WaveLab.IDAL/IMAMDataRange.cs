using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IMAMDataRange
    {
        int Query(Hashtable hashTable);

        IList<MAMDataRangeInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        bool CheckExists(string MAMType,string data);

        bool CheckExists(string MAMType, string data,string frequency);

        void Save(MAMDataRangeInfo entity);

        IList<MAMDataRangeInfo> GetDetail(string MAMType, string data);

        void Update(MAMDataRangeInfo entity);

        void Delete(string MAMType, string data);

        void Delete(MAMDataRangeInfo entity);
    }
}

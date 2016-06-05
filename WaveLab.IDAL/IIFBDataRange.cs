using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IIFBDataRange
    {
        int Query(Hashtable hashTable);

        IList<IFBDataRangeInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        bool CheckExists(string data);

        bool CheckExists(string data, string frequency);

        void Save(IFBDataRangeInfo entity);

        IList<IFBDataRangeInfo> GetDetail(string data);

        void Update(IFBDataRangeInfo entity);

        void Delete(string data);

        void Delete(IFBDataRangeInfo entity);
    }
}

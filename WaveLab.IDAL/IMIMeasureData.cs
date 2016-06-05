using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IMIMeasureData
    {
        int Query(Hashtable hashTable);

        IList<MIMeasureDataInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        bool CheckExists(string serialNo);

        void Save(MIMeasureDataInfo entity);

        MIMeasureDataInfo GetDetail(int MIMeasureDataId);

        void Update(MIMeasureDataInfo entity);

        void Delete(MIMeasureDataInfo entity);
    }
}

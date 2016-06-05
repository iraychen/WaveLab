using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISMTModelFileInduce
    {
        int Query(Hashtable hashTable);

        IList<SMTModelFileInduceInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);             

        bool CheckExists(SMTModelFileInduceInfo entity);
      
        void Save(SMTModelFileInduceInfo entity);

        SMTModelFileInduceInfo GetDetail(int FileInducePK);

        void Update(SMTModelFileInduceInfo entity);

        void Delete(SMTModelFileInduceInfo entity);

        IList<SMTModelFileInduceInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        //int GetCount(string modelOrder);

        //SMTModelFileInduceInfo Get(string modelOrder);
    }
}

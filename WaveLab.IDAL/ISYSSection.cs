using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
   public interface ISYSSection
    {
        IList<SYSSectionInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string sectionId);

        void Save(SYSSectionInfo entity);

        SYSSectionInfo GetDetail(string sectionId);

        void Update(SYSSectionInfo entity);

        void Delete(SYSSectionInfo entity);

        IList<SYSSectionInfo> GetItems();
    }
}

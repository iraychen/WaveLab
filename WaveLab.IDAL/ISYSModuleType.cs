using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISYSModuleType
    {
        IList<SYSModuleTypeInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string moduleTypeId);

        void Save(SYSModuleTypeInfo entity);

        SYSModuleTypeInfo GetDetail(string moduleTypeId);

        void Update(SYSModuleTypeInfo entity);

        void Delete(SYSModuleTypeInfo entity);

        IList<SYSModuleTypeInfo> GetUploadModuleTypes(string sortBy, string orderBy);

        IList<SYSModuleTypeInfo> GetItems();

        bool CheckExistsByDesc(string moduleTypeDesc);
    }
}

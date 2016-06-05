using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IService
{
    public interface IMaterialTypeService
    {
        IList<MaterialTypeInfo> GetItems(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string materialTypeDesc);

        void Save(MaterialTypeInfo entity);

        MaterialTypeInfo GetDetail(int materialTypeId);

        bool CheckExists(MaterialTypeInfo entity, string materialTypeDesc);

        void Update(MaterialTypeInfo entity);

        void Delete(MaterialTypeInfo entity);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;
using WaveLab.IService;
using WaveLab.IDAL;

namespace WaveLab.Service
{
    public class MaterialTypeService: IMaterialTypeService
    {
        public IMaterialType dal;

        public IList<MaterialTypeInfo> GetItems(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.GetItems(hashTable, sortBy, orderBy);
        }

        public bool CheckExists(string materialTypeDesc)
        {
            return dal.CheckExists(materialTypeDesc);
        }

        public void Save(MaterialTypeInfo entity)
        {
            dal.Save(entity);
        }

        public MaterialTypeInfo GetDetail(int materialTypeId)
        {
            return dal.GetDetail(materialTypeId);
        }

        public void Update(MaterialTypeInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(MaterialTypeInfo entity)
        {
            dal.Delete(entity);
        }

        public bool CheckExists(MaterialTypeInfo entity, string materialTypeDesc)
        {
            return dal.CheckExists(entity, materialTypeDesc);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

namespace WaveLab.Service
{
   public class SYSModuleTypeService : ISYSModuleTypeService
    {
        public ISYSModuleType dal;

        public IList<SYSModuleTypeInfo> Query(Hashtable hashTable, string sortBy, string oderBy)
        {
            return dal.Query(hashTable, sortBy, oderBy);
        }

        public bool CheckExists(string moduleTypeId)
        {
            return dal.CheckExists(moduleTypeId);
        }

        public void  Save(SYSModuleTypeInfo entity)
        {
            dal.Save(entity);
        }

        public SYSModuleTypeInfo GetDetail(string moduleTypeId)
        {
            return dal.GetDetail(moduleTypeId);
        }

        public void Update(SYSModuleTypeInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SYSModuleTypeInfo entity)
        {
            dal.Delete(entity);
        }

        public IList<SYSModuleTypeInfo> GetUploadModuleTypes(string sortBy, string oderBy)
        {
            return dal.GetUploadModuleTypes(sortBy, oderBy);
        }

        public IList<SYSModuleTypeInfo> GetItems()
        {
            return dal.GetItems();
        }

        public bool CheckExistsByDesc(string moduleTypeDesc)
        {
            return dal.CheckExistsByDesc(moduleTypeDesc);
        }
    }
}

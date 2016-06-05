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
    public class InjurantTypeService: IInjurantTypeService
    {
        public IInjurantType dal;

        public IList<InjurantTypeInfo> GetItems(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.GetItems(hashTable, sortBy, orderBy);
        }

        public bool CheckExists(string injurantTypeDesc)
        {
            return dal.CheckExists(injurantTypeDesc);
        }

        public void Save(InjurantTypeInfo entity)
        {
            dal.Save(entity);
        }

        public InjurantTypeInfo GetDetail(int injurantTypeId)
        {
            return dal.GetDetail(injurantTypeId);
        }

        public void Update(InjurantTypeInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(InjurantTypeInfo entity)
        {
            dal.Delete(entity);
        }

        public bool CheckExists(InjurantTypeInfo entity, string injurantTypeDesc)
        {
            return dal.CheckExists(entity, injurantTypeDesc);
        }
    }
}

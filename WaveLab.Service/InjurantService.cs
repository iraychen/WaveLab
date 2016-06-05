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
    public class InjurantService: IInjurantService
    {
        public IInjurant dal;

        public IList<InjurantInfo> GetItems(Hashtable equalHashTable, Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.GetItems(equalHashTable, hashTable, sortBy, orderBy);
        }

        public bool CheckExists(string injurantDescCn, string injurantDescEn, string casNo)
        {
            return dal.CheckExists(injurantDescCn, injurantDescEn, casNo);
        }

        public bool CheckInjuct(string substanceName, string casNo)
        {
            return dal.CheckInjuct(substanceName, casNo);
        }
        public void Save(InjurantInfo entity)
        {
            dal.Save(entity);
        }

        public InjurantInfo GetDetail(int injurantId)
        {
            return dal.GetDetail(injurantId);
        }

        public void Update(InjurantInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(InjurantInfo entity)
        {
            dal.Delete(entity);
        }

        public bool CheckExists(InjurantInfo entity, string injurantDescCn, string injurantDescEn, string casNo)
        {
            return dal.CheckExists(entity, injurantDescCn, injurantDescEn, casNo);
        }
    }
}

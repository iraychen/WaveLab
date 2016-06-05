using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;
using WaveLab.IDAL;

namespace WaveLab.Service
{
    public class SYSActionService:WaveLab.IService.ISYSActionService 
    {
        public ISYSAction dal;

        public IList<SYSActionInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

        public bool CheckExists(string action,System.Nullable<int> actionId)
        {
            return dal.CheckExists(action, actionId);
        }

        public void Save(SYSActionInfo entity)
        {
            dal.Save(entity);
        }

        public SYSActionInfo GetDetail(int actionId)
        {
            return dal.GetDetail(actionId);
        }

        public void Update(SYSActionInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SYSActionInfo entity)
        {
            dal.Delete(entity);
        }

        public IList<SYSRoleInfo> GetRoles(int actionId)
        {
            return dal.GetRoles(actionId);
        }

        public void SaveRoleMapping(int actionId, IList<SYSRoleInfo> roleItems)
        {
            dal.SaveRoleMapping(actionId, roleItems);
        }
    }
}

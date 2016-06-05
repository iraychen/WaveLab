using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISYSAction
    {
        IList<SYSActionInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string action,System.Nullable<int> actionId);

        void Save(SYSActionInfo entity);

        SYSActionInfo GetDetail(int actionId);

        void Update(SYSActionInfo entity);

        void Delete(SYSActionInfo entity);
        
        IList<SYSRoleInfo> GetRoles(int actionId);

        void SaveRoleMapping(int actionId, IList<SYSRoleInfo> roleItems);
        
    }
}

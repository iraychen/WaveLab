using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ISYSRoleService
    {
       IList<SYSRoleInfo> Query(string sortBy, string orderBy);

        bool CheckExists(string roleDesc);

        void Save(SYSRoleInfo entity);

        SYSRoleInfo GetDetail(int roleId);

        bool CheckExists(SYSRoleInfo entity, string roleDesc);

        void Update(SYSRoleInfo entity);

        void Delete(SYSRoleInfo entity);

        IList<SYSRoleInfo> GetItems();

        IList<SYSMenuInfo> GetMenus(int roleId);

        void SaveMenus(int roleId, IList<SYSMenuInfo> menuItems);

        void DeleteMenus(int roleId, IList<SYSMenuInfo> menuItems);

        void SaveMenusRoleCopy(int sourceRoleId, int targetRoleId);

        IList<SYSActionInfo> GetActions(int roleId);

        void SaveActions(int roleId, IList<SYSActionInfo> actionItems);

        void SaveActionsRoleCopy(int sourceRoleId, int targetRoleId);

        bool GetActionACRight(string userId, string action);
    }
}

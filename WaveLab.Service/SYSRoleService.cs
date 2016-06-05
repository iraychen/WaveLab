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
    public class SYSRoleService: ISYSRoleService
    {
        public ISYSRole dal;
        public ISYSSecurityMaster smDal;

        public bool GetActionACRight(string userId,string action)
        {
            bool retVal = false;
            if (smDal.IsAdmin(userId) == true || dal.GetActionACRight(userId, action))
            {
                retVal = true;
            }
            return retVal;
        }

        public  IList<SYSRoleInfo> Query(string sortBy,string oderBy)
        {
            return dal.Query(sortBy, oderBy);
        }

        public  SYSRoleInfo GetDetail(int roleId)
        {
            return dal.GetDetail(roleId);
        }

        public  bool CheckExists(string roleDesc)
        {
            return dal.CheckExists(roleDesc);
        }

        public bool CheckExists(SYSRoleInfo entity,string roleDesc)
        {
            return dal.CheckExists(entity,roleDesc);
        }

        public void Save(SYSRoleInfo entity)
        {
             dal.Save(entity);
        }

        public void Update(SYSRoleInfo entity)
        {
             dal.Update(entity);
        }

        public void Delete(SYSRoleInfo entity)
        {
             dal.Delete(entity);
        }

        public IList<SYSRoleInfo> GetItems()
        {
            return dal.GetItems();
        }

        public IList<SYSMenuInfo> GetMenus(int roleId)
        {
            return dal.GetMenus(roleId);
        }

        public void SaveMenus(int roleId, IList<SYSMenuInfo> menuItems)
        {
            dal.SaveMenus(roleId, menuItems);
        }

        public void DeleteMenus(int roleId, IList<SYSMenuInfo> menuItems)
        {
            dal.DeleteMenus(roleId, menuItems);
        }

        public void SaveMenusRoleCopy(int sourceRoleId, int targetRoleId)
        {
            dal.SaveMenusRoleCopy(sourceRoleId, targetRoleId);
        }

        public IList<SYSActionInfo> GetActions(int roleId)
        {
            return dal.GetActions(roleId);
        }

        public void SaveActions(int roleId, IList<SYSActionInfo> actionItems)
        {
            dal.SaveActions(roleId, actionItems);
        }

        public void SaveActionsRoleCopy(int sourceRoleId, int targetRoleId)
        {
            dal.SaveActionsRoleCopy(sourceRoleId, targetRoleId);
        }
    }
}

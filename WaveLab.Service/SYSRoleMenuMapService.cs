using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

namespace WaveLab.Service
{
   public class SYSRoleMenuMapService:IRoleMenuMapService
    {
       public ISYSRoleMenuMap dal;

       public  bool CheckExists(string roleId, int menuId)
       {
           return dal.CheckExists(roleId, menuId);
       }

       public  bool Save(List<SYSRoleMenuMapInfo> items)
       {
           return dal.Save(items);
       }
       public  bool DeleteRoleMenus(string roleId, List<int> menuItems)
       {
           return dal.DeleteRoleMenus(roleId, menuItems);
       }

       public  bool  MenuRoleMapping(int menuId, List<string> roleItems, List<string> unRoleItems)
       {
           return dal.MenuRoleMapping(menuId, roleItems, unRoleItems);
       }
    }
}

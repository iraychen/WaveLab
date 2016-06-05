using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
   public interface ISYSRoleMenuMap
    {
        bool CheckExists(string roleId, int menuId);
        
        bool Save(List<SYSRoleMenuMapInfo> items);
       
        bool DeleteRoleMenus(string roleId, List<int> menuItems);

        bool MenuRoleMapping(int menuId, List<string> roleItems, List<string> unRoleItems);
    }
}

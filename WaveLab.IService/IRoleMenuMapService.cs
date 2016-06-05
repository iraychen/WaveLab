using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;
using System.Collections;

namespace WaveLab.IService
{
    public interface IRoleMenuMapService
    {
        bool CheckExists(string roleId, int menuId);
        
        bool Save(List<SYSRoleMenuMapInfo> items);
       
        bool DeleteRoleMenus(string roleId, List<int> menuItems);

        bool MenuRoleMapping(int menuId, List<string> roleItems, List<string> unRoleItems);
    }
}

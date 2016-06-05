using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
   public interface ISYSMenu
    {
        IList<SYSMenuInfo> Query();

        IList<SYSMenuInfo> GetItems();

        bool CheckExists(string menuDesc, System.Nullable<int> menuId,int parentId);

        bool CheckUrlExists(string url, System.Nullable<int> menuId);

        void Save(SYSMenuInfo entity);

        SYSMenuInfo GetDetail(int menuId);

        void Update(SYSMenuInfo entity, bool transform, IList<DictionaryEntry> mappings);

        void Delete(SYSMenuInfo entity);

        void UpdateSequence(Hashtable hashTable);



        IList<SYSMenuInfo> GetMenuByParentId(int parentId);

        IList<SYSMenuInfo> GetSubMenu();
       
        string GetMenuPath(int menuId);
        
        string GetMenuNavigatePath(int menuId);

        bool HasChild(int parentId);
        
        void GetParents(List<int> items, int menuId);
        
        void GetChilds(List<int> childs, int menuId);

        IList<SYSRoleInfo> GetRoles(int menuId);

        void SaveRoles(IList<DictionaryEntry> mappings, IList<DictionaryEntry> unMappings);
    }
}

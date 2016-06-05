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
   public class SYSMenuService:ISYSMenuService
    {
       public ISYSMenu dal;

       public IList<SYSMenuInfo> Query()
       {
           return dal.Query();
       }
       public IList<SYSMenuInfo> GetItems()
       {
           return dal.GetItems();
       }

       public  SYSMenuInfo GetDetail(int menuId)
       {
           return dal.GetDetail(menuId);
       }

       public  string GetMenuNavigatePath(int menuId)
       {
           return dal.GetMenuNavigatePath(menuId);
       }
       public  IList<SYSMenuInfo> GetMenuByParentId(int parentId)
       {
           return dal.GetMenuByParentId(parentId);
       }

       public  IList<SYSMenuInfo> GetSubMenu()
       {
           return dal.GetSubMenu();
       }

       public  bool CheckExists(string menuDesc,System.Nullable<int> menuId,int parentId)
       {
           return dal.CheckExists(menuDesc, menuId,parentId);
       }

       public bool CheckUrlExists(string url, System.Nullable<int> menuId)
       {
           return dal.CheckUrlExists(url,menuId);
       }

       public  void Save(SYSMenuInfo entity)
       {
          dal.Save(entity);
       }

       public void Delete(SYSMenuInfo entity)
       {
           dal.Delete(entity);
       }

       public void Update(SYSMenuInfo entity, bool transform, IList<DictionaryEntry> mappings)
       {
           dal.Update(entity, transform, mappings);
       }

       public  string GetMenuPath(int menuId)
       {
           return dal.GetMenuPath(menuId);
       }

       public void UpdateSequence(System.Collections.Hashtable hashTable)
       {
           dal.UpdateSequence(hashTable);
       }

       public  bool HasChild(int parentId)
       {
           return dal.HasChild(parentId);
       }

       public void GetParents(List<int> items, int menuId)
       {
           dal.GetParents(items, menuId);
       }
       public void GetChilds(List<int> childs, int menuId)
       {
           dal.GetChilds(childs, menuId);
       }

       public IList<SYSRoleInfo> GetRoles(int menuId)
       {
           return dal.GetRoles(menuId);
       }

       public void SaveRoles(IList<DictionaryEntry> mappings, IList<DictionaryEntry> unMappings)
       {
           dal.SaveRoles(mappings, unMappings);
       }
    }
}

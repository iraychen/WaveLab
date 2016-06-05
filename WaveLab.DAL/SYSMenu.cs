using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data ;
using System.Data.SqlClient;
using System.Web;

using WaveLab.Model;
using WaveLab.IDAL;

using Spring.Data.Common;
using Spring.Data.Generic;


namespace WaveLab.DAL
{
    public class SYSMenu : AdoDaoSupport, WaveLab.IDAL.ISYSMenu
    {
       #region Basic Operation
        public IList<SYSMenuInfo> Query()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT * FROM SYS_menus");

            return AdoTemplate.QueryWithRowMapperDelegate<SYSMenuInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSMenuInfo item = new SYSMenuInfo();
                item.MenuId = Convert.ToInt32(reader["menu_id"]);
                item.MenuDesc = Convert.ToString(reader["menu_desc"]);
                item.ParentId = Convert.ToInt32(reader["parent_id"]);
                item.MenuItem = Convert.ToChar(reader["menuitem"]);
                item.Url = Convert.ToString(reader["url"]);
                item.Enabled = Convert.ToChar(reader["enabled"]);
                item.Sequence = Convert.ToInt32(reader["sequence"]);
                item.ImageUrl = Convert.ToString(reader["imageurl"]);
                return item;
            });
        }

        public bool CheckExists(string menuDesc, System.Nullable<int> menuId,int parentId)
       {
           bool retVal;
           StringBuilder cmdText =new StringBuilder();
           cmdText.Append("select count(*) from SYS_menus where upper(menu_desc)=upper(@menu_desc) and parent_id=@parent_id");

           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("menu_desc").Type(DbType.String).Size(50).Value(menuDesc);
        
           if (  menuId!=null)
           {
               cmdText.Append(" AND menu_id!=@menu_id");
               paras.Create().Name("menu_id").Type(DbType.Int32).Size(4).Value(menuId);
           }
           paras.Create().Name("parent_id").Type(DbType.Int32).Size(4).Value(parentId);

           if ((int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters()) > 0)
            {
                retVal = true;
            }
            else
            {
                retVal = false;
            }
           return retVal;
       }

        public bool CheckUrlExists(string url, System.Nullable<int> menuId)
       {
           bool retVal;
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append("select count(*) from SYS_menus where upper(url)=upper(@url)");

           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("url").Type(DbType.String).Size(50).Value(url);

           if (menuId != null)
           {
               cmdText.Append(" AND menu_id!=@menu_id");
               paras.Create().Name("menu_id").Type(DbType.Int32).Size(4).Value(menuId);
           }

           if ((int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters()) > 0)
           {
               retVal = true;
           }
           else
           {
               retVal = false;
           }
           return retVal;
       }

       public IList<SYSMenuInfo> GetSubMenu()
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append("SELECT * FROM SYS_menus WHERE   menuitem='N' order by parent_id,sequence ");
           return AdoTemplate.QueryWithRowMapperDelegate<SYSMenuInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
           {
               SYSMenuInfo item = new SYSMenuInfo();
               item.MenuId = Convert.ToInt32(reader["menu_id"]);
               item.MenuDesc = GetMenuPath(Convert.ToInt32(reader["menu_id"]));
               item.ParentId = Convert.ToInt32(reader["parent_id"]);
               return item;
           });
       }

       public string GetMenuPath(int menuId)
       {
           string path = "";
           SYSMenuInfo entity = this.GetDetail(menuId);
           if (entity.ParentId != 0)
           {
               path = GetMenuPath(entity.ParentId) + "->";
           }
           path = path + entity.MenuDesc;

           return path;
       }

       public void Save(SYSMenuInfo entity)
       {
          StringBuilder cmdText = new StringBuilder();
          cmdText.Append(" declare @sequence int;" );
          cmdText.Append(" select @sequence=isnull(max(sequence),0)+1 from SYS_menus where parent_id=@parent_id;" );
          cmdText.Append(" insert into SYS_menus(last_update_date,last_updated_by,creation_date,created_by,menu_desc,parent_id,menuitem,url,enabled,sequence,imageurl) ");
          cmdText.Append(" values(@last_update_date,@last_updated_by,@creation_date,@created_by,@menu_desc,@parent_id,@menuitem,@url,@enabled,@sequence,@imageurl);");
         
          IDbParametersBuilder paras = base.CreateDbParametersBuilder();
          paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
          paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
          paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
          paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
          paras.Create().Name("menu_desc").Type(DbType.String).Size(50).Value(entity.MenuDesc);
          paras.Create().Name("parent_id").Type(DbType.Int32).Size(4).Value(entity.ParentId);
          paras.Create().Name("menuitem").Type(DbType.StringFixedLength).Size(1).Value(entity.MenuItem);
          paras.Create().Name("url").Type(DbType.String).Size(100).Value(entity.Url);
          paras.Create().Name("enabled").Type(DbType.StringFixedLength).Size(1).Value(entity.Enabled);
          paras.Create().Name("imageurl").Type(DbType.String).Size(50).Value(entity.ImageUrl);

          AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
       }

       public SYSMenuInfo GetDetail(int menuId)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append("SELECT * FROM  SYS_menus  WHERE  menu_id =@menu_id order by sequence ");

           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("menu_id").Type(DbType.Int32).Size(4).Value(menuId);

           return AdoTemplate.QueryForObjectDelegate<SYSMenuInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
           {
               SYSMenuInfo entity = new SYSMenuInfo();
               entity.MenuId = Convert.ToInt32(reader["menu_id"]);
               entity.MenuDesc = Convert.ToString(reader["menu_desc"]);
               entity.ParentId = Convert.ToInt32(reader["parent_id"]);
               entity.MenuItem = Convert.ToChar(reader["menuitem"]);
               entity.Url = Convert.ToString(reader["url"]);
               entity.Enabled = Convert.ToChar(reader["enabled"]);
               entity.Sequence = Convert.ToInt32(reader["sequence"]);
               entity.ImageUrl = Convert.ToString(reader["imageurl"]);
               return entity;
           }, paras.GetParameters());
       }

       public void Update(SYSMenuInfo entity, bool transform, IList<DictionaryEntry> mappings)
       { 
           //Update Menu
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append(" update SYS_menus set last_update_date=@last_update_date,");
           cmdText.Append(" last_updated_by=@last_updated_by,");
           cmdText.Append(" menu_desc=@menu_desc,");
           cmdText.Append(" parent_id=@parent_id,");
           cmdText.Append(" menuitem=@menuitem,");
           cmdText.Append(" url=@url,");
           cmdText.Append(" enabled=@enabled, ");
           cmdText.Append(" imageurl=@imageurl ");
           cmdText.Append(" where menu_id=@menu_id");

           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
           paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
           paras.Create().Name("menu_desc").Type(DbType.String).Size(50).Value(entity.MenuDesc);
           paras.Create().Name("parent_id").Type(DbType.Int32).Size(4).Value(entity.ParentId);
           paras.Create().Name("menuitem").Type(DbType.StringFixedLength).Size(1).Value(entity.MenuItem);
           paras.Create().Name("url").Type(DbType.String).Size(100).Value(entity.Url);
           paras.Create().Name("enabled").Type(DbType.StringFixedLength).Size(1).Value(entity.Enabled);
           paras.Create().Name("imageurl").Type(DbType.String).Size(50).Value(entity.ImageUrl);
           paras.Create().Name("menu_id").Type(DbType.Int32).Size(4).Value(entity.MenuId);

           AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());


           //change parent_id,it should add new parent_id to role menu mapping table 
           foreach (DictionaryEntry entry in mappings)
           {
               StringBuilder roleCmdText = new StringBuilder();
               roleCmdText.Append(" insert into SYS_role_menu_mapping(role_id,menu_id,creation_date,created_by,last_update_date,last_updated_by) values( ");
               roleCmdText.Append(" @role_id,@menu_id,@creation_date,@created_by,@last_update_date,@last_updated_by)");

               IDbParametersBuilder param = base.CreateDbParametersBuilder();
               param.Create().Name("menu_id").Type(DbType.Int32).Size(4).Value(Convert.ToInt32(entry.Key));

               SYSRoleInfo roleItem = (SYSRoleInfo)entry.Value;
               param.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(roleItem.RoleId);
               param.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(roleItem.CreationDate);
               param.Create().Name("created_by").Type(DbType.String).Size(50).Value(roleItem.CreatedBy);
               param.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(roleItem.LastUpdateDate);
               param.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(roleItem.LastUpdatedBy);

               AdoTemplate.ExecuteNonQuery(CommandType.Text, roleCmdText.ToString(), param.GetParameters());
           }
       }

       public void Delete(SYSMenuInfo entity)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append(" delete from SYS_menus ");
           cmdText.Append(" where menu_id=@menu_id");

           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("menu_id").Type(DbType.Int32).Size(4).Value(entity.MenuId);

           AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
       }

       public string GetMenuNavigatePath(int menuId)
       {
           string path = "";
           if (menuId == 0)
           {
               path = System.Web.HttpContext.GetGlobalResourceObject("globalResource", "topItem").ToString();
           }
           else
           {
               SYSMenuInfo entity = this.GetDetail(menuId);
               if (entity.ParentId != 0)
               {
                   path = GetMenuPath(entity.ParentId) + "->";
               }
               path = path + entity.MenuDesc;
           }
           return path;
       }

       public void GetParents(List<int> items, int menuId)
       {
           if (menuId != 0)
           {
               SYSMenuInfo entity = GetDetail(menuId);
               items.Add(menuId);
               if (entity.ParentId != 0)
               {
                   GetParents(items, entity.ParentId);
               }
           } 
       }

       public void GetChilds(List<int> childs, int menuId)
       {
           childs.Add(menuId);

           StringBuilder cmdText = new StringBuilder();
           cmdText.Append("select menu_id from SYS_menus where parent_id=@parent_id");

           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("parent_id").Type(DbType.Int32).Size(4).Value(menuId);

           IList<int> items= AdoTemplate.QueryWithRowMapperDelegate<int>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
           {
               return Convert.ToInt32(reader["menu_id"]);
           },paras.GetParameters());

           if (items.Count > 0)
           {
               foreach (int item in items)
               {
                   //childs.Add(item);
                   this.GetChilds(childs, item);
               }
           }
       }

       public IList<SYSMenuInfo> GetMenuByParentId(int parentId)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append("SELECT * FROM SYS_menus WHERE  parent_id =@parent_id order by sequence ");

           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("parent_id").Type(DbType.Int32).Size(4).Value(parentId);

           return AdoTemplate.QueryWithRowMapperDelegate<SYSMenuInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
           {
               SYSMenuInfo item = new SYSMenuInfo();
               item.MenuId = Convert.ToInt32(reader["menu_id"]);
               item.MenuDesc = Convert.ToString(reader["menu_desc"]);
               item.ParentId = Convert.ToInt32(reader["parent_id"]);
               item.MenuItem = Convert.ToChar(reader["menuitem"]);
               item.Url = Convert.ToString(reader["url"]);
               item.Enabled = Convert.ToChar(reader["enabled"]);
               item.Sequence = Convert.ToInt32(reader["sequence"]);
               item.ImageUrl = Convert.ToString(reader["imageurl"]);
               return item;
           }, paras.GetParameters());
       }

       public void UpdateSequence(Hashtable hashTable)
       {
           foreach (DictionaryEntry item in hashTable)
           {
               StringBuilder cmdText = new StringBuilder();
               cmdText.Append("update SYS_menus set last_update_date=@last_update_date,last_updated_by=@last_updated_by,sequence=@sequence where menu_id=@menu_id");

               IDbParametersBuilder paras = base.CreateDbParametersBuilder();

               SYSMenuInfo entity = (SYSMenuInfo)item.Key;
               paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
               paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
               paras.Create().Name("sequence").Type(DbType.Int32).Size(4).Value((int)item.Value);
               paras.Create().Name("menu_id").Type(DbType.Int32).Size(4).Value(entity.MenuId);

               AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
           }
       }

       public bool HasChild(int parentId)
       {
           bool retVal;
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append("select count(*) childcount from SYS_menus where parent_id=@parent_id");

           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("parent_id").Type(DbType.String).Size(50).Value(parentId);

           if ((int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters()) > 0)
           {
               retVal = true;
           }
           else
           {
               retVal = false;
           }
           return retVal;
       }

       public IList<SYSMenuInfo> GetItems()
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append("SELECT * FROM SYS_menus where enabled='Y'");

           return AdoTemplate.QueryWithRowMapperDelegate<SYSMenuInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
           {
               SYSMenuInfo item = new SYSMenuInfo();
               item.MenuId = Convert.ToInt32(reader["menu_id"]);
               item.MenuDesc = Convert.ToString(reader["menu_desc"]);
               item.ParentId = Convert.ToInt32(reader["parent_id"]);
               item.MenuItem = Convert.ToChar(reader["menuitem"]);
               item.Url = Convert.ToString(reader["url"]);
               item.Sequence = Convert.ToInt32(reader["sequence"]);
               item.ImageUrl = Convert.ToString(reader["imageurl"]);
               return item;
           });
       }

       public IList<SYSRoleInfo> GetRoles(int menuId)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append(" SELECT a.* ");
           cmdText.Append(" FROM   SYS_role_list a,SYS_role_menu_mapping b ");
           cmdText.Append(" WHERE  a.role_id=b.role_id ");
           cmdText.Append(" and b.menu_id=@menu_id ");

           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("menu_id").Type(DbType.Int32).Size(4).Value(menuId);

           return AdoTemplate.QueryWithRowMapperDelegate<SYSRoleInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
           {
               SYSRoleInfo item = new SYSRoleInfo();
               item.RoleId = Convert.ToInt32(reader["role_id"]);
               item.RoleDesc = Convert.ToString(reader["role_desc"]);
               return item;
           }, paras.GetParameters());
       }

       public void SaveRoles(IList<DictionaryEntry> mappings, IList<DictionaryEntry> unMappings)
       {
           foreach (DictionaryEntry entry in mappings)
           {
               StringBuilder cmdText = new StringBuilder();
               cmdText.Append(" insert into SYS_role_menu_mapping(role_id,menu_id,creation_date,created_by,last_update_date,last_updated_by) values( ");
               cmdText.Append(" @role_id,@menu_id,@creation_date,@created_by,@last_update_date,@last_updated_by)");

               IDbParametersBuilder paras = base.CreateDbParametersBuilder();
               paras.Create().Name("menu_id").Type(DbType.Int32).Size(4).Value(Convert.ToInt32(entry.Key));

               SYSRoleInfo roleItem =(SYSRoleInfo) entry.Value;
               paras.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(roleItem.RoleId);
               paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(roleItem.CreationDate);
               paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(roleItem.CreatedBy);
               paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(roleItem.LastUpdateDate);
               paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(roleItem.LastUpdatedBy);

               AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
           }

           foreach (DictionaryEntry unEntry in unMappings)
           {
               StringBuilder unCmdText = new StringBuilder();
               unCmdText.Append("delete from SYS_role_menu_mapping where role_id=@role_id and menu_id=@menu_id");

               IDbParametersBuilder unParas = base.CreateDbParametersBuilder();
               unParas.Create().Name("menu_id").Type(DbType.Int32).Size(4).Value(Convert.ToInt32(unEntry.Key));

               SYSRoleInfo roleItem =(SYSRoleInfo) unEntry.Value;
               unParas.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(roleItem.RoleId);

               AdoTemplate.ExecuteNonQuery(CommandType.Text, unCmdText.ToString(), unParas.GetParameters());
           } 
       }
        #endregion
    }
}

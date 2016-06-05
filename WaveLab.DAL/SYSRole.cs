using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

using WaveLab.Model;
using WaveLab.IDAL;

using Spring.Data.Common;
using Spring.Data.Generic;

namespace WaveLab.DAL
{
    public class SYSRole : AdoDaoSupport, ISYSRole
   {

       #region Basic Operation
       public IList<SYSRoleInfo> Query(string sortBy, string orderBy)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append(" SELECT  role_id,role_desc ");
           cmdText.Append(" FROM    SYS_role_list");
           if (!string.IsNullOrEmpty(sortBy))
           {
               cmdText.Append(" order by ");
               cmdText.Append(sortBy);
           }
           if (!string.IsNullOrEmpty(orderBy))
           {
               cmdText.Append(" ");
               cmdText.Append(orderBy);
           }
           return AdoTemplate.QueryWithRowMapperDelegate<SYSRoleInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
           {
               SYSRoleInfo item = new SYSRoleInfo();
               item.RoleId = Convert.ToInt32(reader["role_id"]);
               item.RoleDesc = Convert.ToString(reader["role_desc"]);
               return item;
           });
       }

       public bool CheckExists(string roleDesc)
       {
           bool retVal;
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append("select count(*) from SYS_role_list where upper(role_desc)=upper(@role_desc)");

           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("role_desc").Type(DbType.String).Size(50).Value(roleDesc);

           int recordCount = (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
           if (recordCount > 0)
           {
               retVal = true;
           }
           else
           {
               retVal = false;
           }
           return retVal;
       }

       public void Save(SYSRoleInfo entity)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append("insert into SYS_role_list(role_desc,last_update_date,last_updated_by,creation_date,created_by)");
           cmdText.Append("values(@role_desc,@last_update_date,@last_updated_by,@creation_date,@created_by)");

           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("role_desc").Type(DbType.String).Size(50).Value(entity.RoleDesc);
           paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
           paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
           paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
           paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);

           AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
       }

       public SYSRoleInfo GetDetail(int roleId)
       {
           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(roleId);
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append("select * from SYS_role_list where upper(role_id)=upper(@role_id)");

           return AdoTemplate.QueryForObjectDelegate<SYSRoleInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
           {
               SYSRoleInfo entity = new SYSRoleInfo();
               entity.RoleId = Convert.ToInt32(reader["role_id"]);
               entity.RoleDesc = Convert.ToString(reader["role_desc"]);
               return entity;
           },paras.GetParameters());
       }

       public bool CheckExists(SYSRoleInfo entity, string roleDesc)
       {
           bool retVal;
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append("select count(*) from SYS_role_list where upper(role_desc)=upper(@role_desc) and role_id<>@role_id ");

           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("role_desc").Type(DbType.String).Size(50).Value(roleDesc);
           paras.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(entity.RoleId);

           int recordCount = (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
           if (recordCount > 0)
           {
               retVal = true;
           }
           else
           {
               retVal = false;
           }
           return retVal;
       }

       public void Update(SYSRoleInfo entity)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append(" update SYS_role_list set");
           cmdText.Append(" role_desc=@role_desc,last_update_date=@last_update_date,last_updated_by=@last_updated_by");
           cmdText.Append(" where role_id=@role_id");

           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("role_desc").Type(DbType.String).Size(50).Value(entity.RoleDesc);
           paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
           paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
           paras.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(entity.RoleId);
           AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
       }

       public void Delete(SYSRoleInfo entity)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append(" delete from SYS_role_list where role_id=@role_id");
           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(entity.RoleId);
           AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
       }

       public IList<SYSRoleInfo> GetItems()
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append(" SELECT  role_id,role_desc ");
           cmdText.Append(" FROM    SYS_role_list");
           cmdText.Append(" order by role_desc");
           return AdoTemplate.QueryWithRowMapperDelegate<SYSRoleInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
           {
               SYSRoleInfo item = new SYSRoleInfo();
               item.RoleId = Convert.ToInt32(reader["role_id"]);
               item.RoleDesc = Convert.ToString(reader["role_desc"]);
               return item;
           });
       }
       #endregion

       #region Role Menu Mapping
       public IList<SYSMenuInfo> GetMenus(int roleId)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append(" SELECT a.* ");
           cmdText.Append(" FROM   SYS_menus a,SYS_role_menu_mapping b ");
           cmdText.Append(" WHERE  a.menu_id=b.menu_id ");
           cmdText.Append(" and b.role_id=@role_id ");
           cmdText.Append(" and a.enabled='Y'");
           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(roleId);

           return AdoTemplate.QueryWithRowMapperDelegate<SYSMenuInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
           {
               SYSMenuInfo item = new SYSMenuInfo();
               item.MenuId = Convert.ToInt32(reader["menu_id"]);
               item.MenuDesc = Convert.ToString(reader["menu_desc"]);
               item.ParentId = Convert.ToInt32(reader["parent_id"]);
               item.MenuItem = Convert.ToChar(reader["menuitem"]);
               item.Sequence = Convert.ToInt32(reader["sequence"]);
               return item;
           },paras.GetParameters());
       }

       public void SaveMenus(int roleId,IList<SYSMenuInfo> menuItems)
       {
           foreach (SYSMenuInfo menuItem in menuItems)
           {
               StringBuilder cmdText = new StringBuilder();
               cmdText.Append(" insert into SYS_role_menu_mapping(role_id,menu_id,creation_date,created_by,last_update_date,last_updated_by) values( ");
               cmdText.Append(" @role_id,@menu_id,@creation_date,@created_by,@last_update_date,@last_updated_by)");

               IDbParametersBuilder paras = base.CreateDbParametersBuilder();
               paras.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(roleId);
               paras.Create().Name("menu_id").Type(DbType.Int32).Size(4).Value(menuItem.MenuId);
               paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(menuItem.CreationDate);
               paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(menuItem.CreatedBy);
               paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(menuItem.LastUpdateDate);
               paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(menuItem.LastUpdatedBy);

               AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
           }
       }

       public void DeleteMenus(int roleId, IList<SYSMenuInfo> menuItems)
       {
           foreach (SYSMenuInfo menuItem in menuItems)
           {
               StringBuilder cmdText = new StringBuilder();
               cmdText.Append(" delete from SYS_role_menu_mapping where role_id=@role_id and menu_id=@menu_id ");

               IDbParametersBuilder paras = base.CreateDbParametersBuilder();
               paras.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(roleId);
               paras.Create().Name("menu_id").Type(DbType.Int32).Size(4).Value(menuItem.MenuId);

               AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
           }
       }

       public void SaveMenusRoleCopy(int sourceRoleId, int targetRoleId)
       {
           string sql;
           sql = "delete from SYS_role_menu_mapping where upper(role_id)=upper(@role_id)";
           IDbParametersBuilder param = base.CreateDbParametersBuilder();
           param.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(targetRoleId);
           AdoTemplate.ExecuteNonQuery(CommandType.Text, sql, param.GetParameters());

           sql = "insert into SYS_role_menu_mapping " +
                 "select distinct @targetRoleId,menu_id,@creation_date,@created_by,@last_update_date,@last_updated_by from SYS_role_menu_mapping where upper(role_id)=upper(@sourceRoleId)";
           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("targetRoleId").Type(DbType.Int32).Size(4).Value(targetRoleId);
           paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(DateTime.Now);
           paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(System.Web.HttpContext.Current.User.Identity.Name);
           paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(DateTime.Now);
           paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(System.Web.HttpContext.Current.User.Identity.Name);
           paras.Create().Name("sourceRoleId").Type(DbType.Int32).Size(4).Value(sourceRoleId);
           AdoTemplate.ExecuteNonQuery(CommandType.Text, sql, paras.GetParameters());
       }
       #endregion

       #region Role Action Mapping
       public IList<SYSActionInfo> GetActions(int roleId)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append(" SELECT a.* ");
           cmdText.Append(" FROM   SYS_actions a,SYS_role_action_mapping b ");
           cmdText.Append(" WHERE  a.action_id=b.action_id ");
           cmdText.Append(" and b.role_id=@role_id ");
           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(roleId);

           return AdoTemplate.QueryWithRowMapperDelegate<SYSActionInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
           {
               SYSActionInfo item = new SYSActionInfo();
               item.ActionId = Convert.ToInt32(reader["action_id"]);
               item.Action =Convert.ToString(reader["action"]);
               item.ActionName = Convert.ToString(reader["action_name"]);
               return item;
           }, paras.GetParameters());
       }

       public void SaveActions(int roleId, IList<SYSActionInfo> actionItems)
       {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from SYS_role_action_mapping where role_id=@role_id ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(roleId);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());

           foreach (SYSActionInfo actionItem in actionItems)
           {
               StringBuilder actionCmdText = new StringBuilder();
                actionCmdText.Append(" insert into SYS_role_action_mapping(action_id,role_id,creation_date,created_by,last_update_date,last_updated_by) values( ");
                actionCmdText.Append(" @action_id,@role_id,@creation_date,@created_by,@last_update_date,@last_updated_by)");

                IDbParametersBuilder param = base.CreateDbParametersBuilder();
                param.Create().Name("action_id").Type(DbType.Int32).Size(4).Value(actionItem.ActionId);
                param.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(roleId);
                param.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(actionItem.CreationDate);
                param.Create().Name("created_by").Type(DbType.String).Size(50).Value(actionItem.CreatedBy);
                param.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(actionItem.LastUpdateDate);
                param.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(actionItem.LastUpdatedBy);

                AdoTemplate.ExecuteNonQuery(CommandType.Text, actionCmdText.ToString(), param.GetParameters());
           }
       }
      
       public void SaveActionsRoleCopy(int sourceRoleId, int targetRoleId)
       {
           string sql;
           sql = "delete from SYS_role_action_mapping where upper(role_id)=upper(@role_id)";
           IDbParametersBuilder param = base.CreateDbParametersBuilder();
           param.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(targetRoleId);
           AdoTemplate.ExecuteNonQuery(CommandType.Text, sql, param.GetParameters());

           sql = "insert into SYS_role_action_mapping " +
                 "select distinct @targetRoleId,action_id,@creation_date,@created_by,@last_update_date,@last_updated_by from SYS_role_action_mapping where upper(role_id)=upper(@sourceRoleId)";
           IDbParametersBuilder paras = base.CreateDbParametersBuilder();
           paras.Create().Name("targetRoleId").Type(DbType.Int32).Size(4).Value(targetRoleId);
           paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(DateTime.Now);
           paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(System.Web.HttpContext.Current.User.Identity.Name);
           paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(DateTime.Now);
           paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(System.Web.HttpContext.Current.User.Identity.Name);
           paras.Create().Name("sourceRoleId").Type(DbType.Int32).Size(4).Value(sourceRoleId);
           AdoTemplate.ExecuteNonQuery(CommandType.Text, sql, paras.GetParameters());
       }

       public bool GetActionACRight(string userId, string action)
       {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SYS_role_action_mapping t ");
            cmdText.Append("where  ");
            cmdText.Append("exists ");
            cmdText.Append("( ");
            cmdText.Append("select 'x' ");
            cmdText.Append("from SYS_security_master a,SYS_master_role_mapping b ");
            cmdText.Append("where a.user_id=b.user_id ");
            cmdText.Append("and upper(a.user_id)=upper(@user_id) ");
            cmdText.Append("and a.admin='N' ");
            cmdText.Append("and b.role_id=t.role_id ");
            cmdText.Append(")");
            cmdText.Append("and action_id=(");
            cmdText.Append("select action_id from SYS_actions  ");
            cmdText.Append("where upper(action)=upper(@action)");
            cmdText.Append(")");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("user_id").Type(DbType.String).Size(50).Value(userId);
            paras.Create().Name("action").Type(DbType.String).Size(50).Value(action);

            int recordCount = (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            if (recordCount > 0)
            {
               retVal = true;
            }
            else
            {
               retVal = false;
            }
            return retVal;
       }
       #endregion
   }
}

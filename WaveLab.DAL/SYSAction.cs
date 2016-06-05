using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;

using WaveLab.Model;
using WaveLab.IDAL;

using Spring.Data.Common;
using Spring.Data.Generic;

namespace WaveLab.DAL
{
    public class SYSAction : AdoDaoSupport, ISYSAction
    {
        public IList<SYSActionInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  action_id,action,action_name,module_id ");
            cmdText.Append(" FROM   SYS_actions ");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                cmdText.Append(" AND " + entry.Key + " =@" + entry.Key + "");
                paras.Create().Name(entry.Key.ToString()).Type(DbType.Int32).Size(4).Value(entry.Value);
            }
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
            return AdoTemplate.QueryWithRowMapperDelegate<SYSActionInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSActionInfo item = new SYSActionInfo();
                item.ActionId = Convert.ToInt32(reader["action_id"]);
                item.Action = Convert.ToString(reader["action"]);
                item.ActionName= Convert.ToString(reader["action_name"]);
                item.ModuleItem = new SYSMenuInfo()
                {
                    MenuId=Convert.ToInt32(reader["module_id"])
                };
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string action, System.Nullable<int> actionId)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select count(*) from SYS_actions where upper(action)=upper(@action) ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("action").Type(DbType.String).Size(50).Value(action);
            if (actionId != null)
            {
                cmdText.Append("and action_id!=@action_id");
                paras.Create().Name("action_id").Type(DbType.Int32).Size(4).Value(actionId);
            }
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

        public void Save(SYSActionInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into SYS_actions");
            cmdText.Append("(");
            cmdText.Append("action,action_name,module_id,last_update_date,last_updated_by,creation_date,created_by");
            cmdText.Append(")");
            cmdText.Append("values");
            cmdText.Append("(");
            cmdText.Append("@action,@action_name,@module_id,@last_update_date,@last_updated_by,@creation_date,@created_by");
            cmdText.Append(")");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("action").Type(DbType.String).Size(50).Value(entity.Action);
            paras.Create().Name("action_name").Type(DbType.String).Size(50).Value(entity.ActionName);
            paras.Create().Name("module_id").Type(DbType.Int32).Size(4).Value(entity.ModuleItem.MenuId);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
         

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SYSActionInfo GetDetail(int actionId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("action_id").Type(DbType.Int32).Size(4).Value(actionId);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  action_id,action,action_name,module_id ");
            cmdText.Append(" from SYS_actions ");
            cmdText.Append(" where action_id=@action_id");

            return AdoTemplate.QueryForObjectDelegate<SYSActionInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSActionInfo entity = new SYSActionInfo();
                entity.ActionId = Convert.ToInt32(reader["action_id"]);
                entity.Action = Convert.ToString(reader["action"]);
                entity.ActionName = Convert.ToString(reader["action_name"]);
                entity.ModuleItem = new SYSMenuInfo()
                {
                    MenuId = Convert.ToInt32(reader["module_id"])
                };
                return entity;
            }, paras.GetParameters());
        }

        public void Update(SYSActionInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update SYS_actions set ");
            cmdText.Append(" last_update_date=@last_update_date,");
            cmdText.Append(" last_updated_by=@last_updated_by,");
            cmdText.Append(" action=@action,");
            cmdText.Append(" action_name=@action_name,");
            cmdText.Append(" module_id=@module_id");
            cmdText.Append(" where upper(action_id)=upper(@action_id)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("action").Type(DbType.String).Size(50).Value(entity.Action);
            paras.Create().Name("action_name").Type(DbType.String).Size(50).Value(entity.ActionName);
            paras.Create().Name("module_id").Type(DbType.Int32).Size(4).Value(entity.ModuleItem.MenuId);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("action_id").Type(DbType.Int32).Size(4).Value(entity.ActionId);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(SYSActionInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from SYS_actions where action_id=@action_id");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("action_id").Type(DbType.Int32).Size(4).Value(entity.ActionId);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SYSRoleInfo> GetRoles(int actionId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("action_id").Type(DbType.Int32).Size(4).Value(actionId);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select role_id,role_desc from SYS_role_list t ");
            cmdText.Append(" where exists ( ");
            cmdText.Append(" select 'x' from SYS_role_action_mapping ");
            cmdText.Append(" where role_id=t.role_id ");
            cmdText.Append(" and action_id=@action_id");
            cmdText.Append(" ) ");

            return AdoTemplate.QueryWithRowMapperDelegate<SYSRoleInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSRoleInfo item = new SYSRoleInfo()
                {
                    RoleId = Convert.ToInt32(reader["role_id"]),
                    RoleDesc = Convert.ToString(reader["role_desc"])
                };
                return item;
            }, paras.GetParameters());
        }

        public void SaveRoleMapping(int actionId, IList<SYSRoleInfo> roleItems)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from SYS_role_action_mapping where action_id=@action_id ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("action_id").Type(DbType.Int32).Size(4).Value(actionId);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());

            foreach (SYSRoleInfo roleItem in roleItems)
            {

                StringBuilder roleCmdText = new StringBuilder();
                roleCmdText.Append(" insert into SYS_role_action_mapping(action_id,role_id,creation_date,created_by,last_update_date,last_updated_by) values( ");
                roleCmdText.Append(" @action_id,@role_id,@creation_date,@created_by,@last_update_date,@last_updated_by)");

                IDbParametersBuilder param = base.CreateDbParametersBuilder();
                param.Create().Name("action_id").Type(DbType.Int32).Size(4).Value(actionId);
                param.Create().Name("role_id").Type(DbType.Int32).Size(4).Value(roleItem.RoleId);
                param.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(roleItem.CreationDate);
                param.Create().Name("created_by").Type(DbType.String).Size(50).Value(roleItem.CreatedBy);
                param.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(roleItem.LastUpdateDate);
                param.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(roleItem.LastUpdatedBy);

                AdoTemplate.ExecuteNonQuery(CommandType.Text, roleCmdText.ToString(), param.GetParameters());
            }
        }
    }
}

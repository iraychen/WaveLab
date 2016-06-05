using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using WaveLab.Model;
using WaveLab.IDAL;

using Spring.Data.Common;
using Spring.Data.Generic;

namespace WaveLab.DAL
{
    public class InjurantType : AdoDaoSupport, IInjurantType
    {
        public IList<InjurantTypeInfo> GetItems(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  injurant_type_id,injurant_type_desc ");
            cmdText.Append(" FROM    injurant_type_list");
            cmdText.Append(" WHERE 1=1 ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                cmdText.Append(" AND upper(" + entry.Key + ") like upper('%'+@" + entry.Key + "+'%')");
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
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
            return AdoTemplate.QueryWithRowMapperDelegate<InjurantTypeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                InjurantTypeInfo item = new InjurantTypeInfo();
                item.InjurantTypeId = Convert.ToInt32(reader["injurant_type_id"]);
                item.InjurantTypeDesc = Convert.ToString(reader["injurant_type_desc"]);
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string injurantTypeDesc)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from injurant_type_list where upper(injurant_type_desc)=upper(@injurant_type_desc)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("injurant_type_desc").Type(DbType.String).Size(50).Value(injurantTypeDesc);

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

        public void Save(InjurantTypeInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into injurant_type_list(injurant_type_desc,last_update_date,last_updated_by,creation_date,created_by)");
            cmdText.Append("values(@injurant_type_desc,@last_update_date,@last_updated_by,@creation_date,@created_by)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("injurant_type_desc").Type(DbType.String).Size(50).Value(entity.InjurantTypeDesc);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());

        }

        public InjurantTypeInfo GetDetail(int injurantTypeId)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select * from injurant_type_list where upper(injurant_type_id)=upper(@injurant_type_id)");

            return AdoTemplate.QueryForObjectDelegate<InjurantTypeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                InjurantTypeInfo entity = new InjurantTypeInfo();
                entity.InjurantTypeId = Convert.ToInt32(reader["injurant_type_id"]);
                entity.InjurantTypeDesc = Convert.ToString(reader["injurant_type_desc"]);
                return entity;
            },
            "injurant_type_id", DbType.String, 50, injurantTypeId);
        }

        public bool CheckExists(InjurantTypeInfo entity, string injurantTypeDesc)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from injurant_type_list where upper(injurant_type_desc)=upper(@injurant_type_desc) and injurant_type_id<>@injurant_type_id ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("injurant_type_desc").Type(DbType.String).Size(50).Value(injurantTypeDesc);
            paras.Create().Name("injurant_type_id").Type(DbType.Int32).Size(4).Value(entity.InjurantTypeId);

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

        public void Update(InjurantTypeInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update injurant_type_list set");
            cmdText.Append(" injurant_type_desc=@injurant_type_desc,last_update_date=@last_update_date,last_updated_by=@last_updated_by");
            cmdText.Append(" where injurant_type_id=@injurant_type_id");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("injurant_type_desc").Type(DbType.String).Size(50).Value(entity.InjurantTypeDesc);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("injurant_type_id").Type(DbType.Int32).Size(4).Value(entity.InjurantTypeId);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(InjurantTypeInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from injurant_type_list ");
            cmdText.Append(" where injurant_type_id=@injurant_type_id");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("injurant_type_id").Type(DbType.Int32).Size(4).Value(entity.InjurantTypeId);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

    }
}

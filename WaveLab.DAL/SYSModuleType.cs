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
    public class SYSModuleType : AdoDaoSupport, ISYSModuleType
    {
        public IList<SYSModuleTypeInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  module_type_id,module_type_desc,hasgenboard,hasspeboard,hassmtfabrication,");
            cmdText.Append ("hascomponentpart,hasgrouppart,hasbondingfabrication");
            cmdText.Append(" FROM    SYS_module_type_list");
            cmdText.Append(" WHERE   1=1");
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
            return AdoTemplate.QueryWithRowMapperDelegate<SYSModuleTypeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSModuleTypeInfo item = new SYSModuleTypeInfo();
                item.ModuleTypeId = Convert.ToString(reader["module_type_id"]);
                item.ModuleTypeDesc = Convert.ToString(reader["module_type_desc"]);
                item.HasGenBoard = Convert.ToChar(reader["hasgenboard"]);
                item.HasSpeBoard = Convert.ToChar(reader["hasspeboard"]);
                item.HasSMTFabrication = Convert.ToChar(reader["hassmtfabrication"]);
                item.HasComponentPart = Convert.ToChar(reader["hascomponentpart"]);
                item.HasGroupPart = Convert.ToChar(reader["hasgrouppart"]);
                item.HasBondingFabrication = Convert.ToChar(reader["hasbondingfabrication"]);
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string moduleTypeId)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SYS_module_type_list where upper(module_type_id)=upper(@module_type_id)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(moduleTypeId);

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

        public void Save(SYSModuleTypeInfo entity)
        {
            StringBuilder cmdText=new StringBuilder();
            cmdText.Append( " insert into SYS_module_type_list ");
            cmdText.Append(" ( ");
            cmdText.Append("    module_type_id,last_update_date,last_updated_by,creation_date,created_by,module_type_desc,hasgenboard,hasspeboard,hassmtfabrication,hascomponentpart,hasgrouppart,hasbondingfabrication ");
            cmdText.Append(" ) ");
            cmdText.Append(" values");
            cmdText.Append(" ( ");
            cmdText.Append("    @module_type_id,@last_update_date,@last_updated_by,@creation_date,@created_by,@module_type_desc,@hasgenboard,@hasspeboard,@hassmtfabrication,@hascomponentpart,@hasgrouppart,@hasbondingfabrication");
            cmdText.Append(" ) ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(entity.ModuleTypeId.ToUpper());
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("module_type_desc").Type(DbType.String).Size(50).Value(entity.ModuleTypeDesc);
            paras.Create().Name("hasgenboard").Type(DbType.StringFixedLength).Size(1).Value(entity.HasGenBoard);
            paras.Create().Name("hasspeboard").Type(DbType.StringFixedLength).Size(1).Value(entity.HasSpeBoard);
            paras.Create().Name("hassmtfabrication").Type(DbType.StringFixedLength).Size(1).Value(entity.HasSMTFabrication);
            paras.Create().Name("hascomponentpart").Type(DbType.StringFixedLength).Size(1).Value(entity.HasComponentPart);
            paras.Create().Name("hasgrouppart").Type(DbType.StringFixedLength).Size(1).Value(entity.HasGroupPart);
            paras.Create().Name("hasbondingfabrication").Type(DbType.StringFixedLength).Size(1).Value(entity.HasBondingFabrication);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SYSModuleTypeInfo GetDetail(string moduleTypeId)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  module_type_id,module_type_desc,hasgenboard,hasspeboard,hassmtfabrication,");
            cmdText.Append(" hascomponentpart,hasgrouppart,hasbondingfabrication");
            cmdText.Append(" FROM    SYS_module_type_list");
            cmdText.Append(" where upper(module_type_id)=upper(@module_type_id)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(moduleTypeId);

            return AdoTemplate.QueryForObjectDelegate<SYSModuleTypeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSModuleTypeInfo entity = new SYSModuleTypeInfo();
                entity.ModuleTypeId = Convert.ToString(reader["module_type_id"]);
                entity.ModuleTypeDesc = Convert.ToString(reader["module_type_desc"]);
                entity.HasGenBoard = Convert.ToChar(reader["hasgenboard"]);
                entity.HasSpeBoard = Convert.ToChar(reader["hasspeboard"]);
                entity.HasSMTFabrication = Convert.ToChar(reader["hassmtfabrication"]);
                entity.HasComponentPart = Convert.ToChar(reader["hascomponentpart"]);
                entity.HasGroupPart = Convert.ToChar(reader["hasgrouppart"]);
                entity.HasBondingFabrication = Convert.ToChar(reader["hasbondingfabrication"]);
                return entity;
            }, paras.GetParameters());
        }

        public void Update(SYSModuleTypeInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update SYS_module_type_list set last_update_date=@last_update_date,");
            cmdText.Append(" last_updated_by=@last_updated_by,");
            cmdText.Append(" module_type_desc=@module_type_desc,");
            cmdText.Append(" hasgenboard=@hasgenboard,");
            cmdText.Append(" hasspeboard=@hasspeboard,");
            cmdText.Append(" hassmtfabrication=@hassmtfabrication,");
            cmdText.Append(" hascomponentpart=@hascomponentpart,");
            cmdText.Append(" hasgrouppart=@hasgrouppart,");
            cmdText.Append(" hasbondingfabrication=@hasbondingfabrication");
            cmdText.Append(" where upper(module_type_id)=upper(@module_type_id)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("module_type_desc").Type(DbType.String).Size(50).Value(entity.ModuleTypeDesc);
            paras.Create().Name("hasgenboard").Type(DbType.StringFixedLength).Size(1).Value(entity.HasGenBoard);
            paras.Create().Name("hasspeboard").Type(DbType.StringFixedLength).Size(1).Value(entity.HasSpeBoard);
            paras.Create().Name("hassmtfabrication").Type(DbType.StringFixedLength).Size(1).Value(entity.HasSMTFabrication);
            paras.Create().Name("hascomponentpart").Type(DbType.StringFixedLength).Size(1).Value(entity.HasComponentPart);
            paras.Create().Name("hasgrouppart").Type(DbType.StringFixedLength).Size(1).Value(entity.HasGroupPart);
            paras.Create().Name("hasbondingfabrication").Type(DbType.StringFixedLength).Size(1).Value(entity.HasBondingFabrication);
            paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(entity.ModuleTypeId);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(SYSModuleTypeInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from SYS_module_type_list where upper(module_type_id)=upper(@module_type_id)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(entity.ModuleTypeId);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SYSModuleTypeInfo> GetUploadModuleTypes(string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  module_type_id,module_type_desc,hasgenboard,hasspeboard,hassmtfabrication,");
            cmdText.Append(" hascomponentpart,hasgrouppart,hasbondingfabrication");
            cmdText.Append(" FROM   SYS_module_type_list");
            cmdText.Append(" WHERE  module_type_id in('MAM','PLM','IFB','MWM')");

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
            return AdoTemplate.QueryWithRowMapperDelegate<SYSModuleTypeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSModuleTypeInfo item = new SYSModuleTypeInfo();
                item.ModuleTypeId = Convert.ToString(reader["module_type_id"]);
                item.ModuleTypeDesc = Convert.ToString(reader["module_type_desc"]);
                item.HasGenBoard = Convert.ToChar(reader["hasgenboard"]);
                item.HasSpeBoard = Convert.ToChar(reader["hasspeboard"]);
                item.HasSMTFabrication = Convert.ToChar(reader["hassmtfabrication"]);
                item.HasComponentPart = Convert.ToChar(reader["hascomponentpart"]);
                item.HasGroupPart = Convert.ToChar(reader["hasgrouppart"]);
                item.HasBondingFabrication = Convert.ToChar(reader["hasbondingfabrication"]);
                return item;
            });
        }

        public IList<SYSModuleTypeInfo> GetItems()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  module_type_id,module_type_desc");
            cmdText.Append(" FROM    SYS_module_type_list");
            cmdText.Append(" ORDER BY module_type_desc asc");
            return AdoTemplate.QueryWithRowMapperDelegate<SYSModuleTypeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSModuleTypeInfo item = new SYSModuleTypeInfo();
                item.ModuleTypeId = Convert.ToString(reader["module_type_id"]);
                item.ModuleTypeDesc = Convert.ToString(reader["module_type_desc"]);
                return item;
            });
        }

        public bool CheckExistsByDesc(string moduleTypeDesc)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SYS_module_type_list where upper(module_type_desc)=upper(@module_type_desc)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("module_type_desc").Type(DbType.String).Size(50).Value(moduleTypeDesc);

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

    }
}

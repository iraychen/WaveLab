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
    public class MaterialType : AdoDaoSupport, IMaterialType
    {
        public IList<MaterialTypeInfo> GetItems(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  material_type_id,material_type_desc,cal_by_quantity ");
            cmdText.Append(" FROM    material_type_list");
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
            return AdoTemplate.QueryWithRowMapperDelegate<MaterialTypeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                MaterialTypeInfo item = new MaterialTypeInfo
                {
                    MaterialTypeId = Convert.ToInt32(reader["material_type_id"]),
                    MaterialTypeDesc = Convert.ToString(reader["material_type_desc"]),
                    CalByQuantity = Convert.ToChar(reader["cal_by_quantity"])
                };
                return item;
            }, paras.GetParameters());

        }

        public bool CheckExists(string materialTypeDesc)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from material_type_list where upper(material_type_desc)=upper(@material_type_desc)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("material_type_desc").Type(DbType.String).Size(50).Value(materialTypeDesc);

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

        public void Save(MaterialTypeInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into material_type_list(material_type_desc,last_update_date,last_updated_by,creation_date,created_by,cal_by_quantity)");
            cmdText.Append("values(@material_type_desc,@last_update_date,@last_updated_by,@creation_date,@created_by,@cal_by_quantity)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("material_type_desc").Type(DbType.String).Size(50).Value(entity.MaterialTypeDesc);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("cal_by_quantity").Type(DbType.StringFixedLength).Size(1).Value(entity.CalByQuantity);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());

        }

        public MaterialTypeInfo GetDetail(int materialTypeId)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select * from material_type_list where upper(material_type_id)=upper(@material_type_id)");

            return AdoTemplate.QueryForObjectDelegate<MaterialTypeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                MaterialTypeInfo entity = new MaterialTypeInfo
                {
                    MaterialTypeId = Convert.ToInt32(reader["material_type_id"]),
                    MaterialTypeDesc = Convert.ToString(reader["material_type_desc"]),
                    CalByQuantity = Convert.ToChar(reader["cal_by_quantity"])
                };
                return entity;
            },
            "material_type_id", DbType.String, 50, materialTypeId);
        }

        public bool CheckExists(MaterialTypeInfo entity, string materialTypeDesc)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from material_type_list where upper(material_type_desc)=upper(@material_type_desc) and material_type_id<>@material_type_id ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("material_type_desc").Type(DbType.String).Size(50).Value(materialTypeDesc);
            paras.Create().Name("material_type_id").Type(DbType.Int32).Size(4).Value(entity.MaterialTypeId);

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

        public void Update(MaterialTypeInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update material_type_list set");
            cmdText.Append(" material_type_desc=@material_type_desc,last_update_date=@last_update_date,last_updated_by=@last_updated_by,cal_by_quantity=@cal_by_quantity");
            cmdText.Append(" where material_type_id=@material_type_id");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("material_type_desc").Type(DbType.String).Size(50).Value(entity.MaterialTypeDesc);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("material_type_id").Type(DbType.Int32).Size(4).Value(entity.MaterialTypeId);
            paras.Create().Name("cal_by_quantity").Type(DbType.StringFixedLength).Size(1).Value(entity.CalByQuantity);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(MaterialTypeInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from material_type_list ");
            cmdText.Append(" where material_type_id=@material_type_id");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("material_type_id").Type(DbType.Int32).Size(4).Value(entity.MaterialTypeId);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }
    }
}

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
    public class SYSSection : AdoDaoSupport, ISYSSection
    {

        #region Basic Operation
        public IList<SYSSectionInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  section_id,section_desc ");
            cmdText.Append(" FROM    SYS_section_list");
            cmdText.Append(" WHERE   1=1 ");

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
            return AdoTemplate.QueryWithRowMapperDelegate<SYSSectionInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSSectionInfo item = new SYSSectionInfo();
                item.SectionId = Convert.ToString(reader["section_id"]);
                item.SectionDesc = Convert.ToString(reader["section_desc"]);
                return item;
            },paras.GetParameters());
        }

        public bool CheckExists(string sectionId)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SYS_section_list where upper(section_id)=upper(@section_id)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("section_id").Type(DbType.String).Size(50).Value(sectionId);

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

        public void Save(SYSSectionInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into SYS_section_list(section_id,section_desc,last_update_date,last_updated_by,creation_date,created_by)");
            cmdText.Append("values(@section_id,@section_desc,@last_update_date,@last_updated_by,@creation_date,@created_by)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("section_id").Type(DbType.String).Size(50).Value(entity.SectionId);
            paras.Create().Name("section_desc").Type(DbType.String).Size(50).Value(entity.SectionDesc);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SYSSectionInfo GetDetail(string sectionId)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select * from SYS_section_list where upper(section_id)=upper(@section_id)");

            return AdoTemplate.QueryForObjectDelegate<SYSSectionInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSSectionInfo entity = new SYSSectionInfo();
                entity.SectionId = Convert.ToString(reader["section_id"]);
                entity.SectionDesc = Convert.ToString(reader["section_desc"]);
                return entity;
            },
            "section_id", DbType.String, 50, sectionId);
        }

        public void Update(SYSSectionInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update SYS_section_list set");
            cmdText.Append(" section_desc=@section_desc,last_update_date=@last_update_date,last_updated_by=@last_updated_by");
            cmdText.Append(" where section_id=@section_id");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("section_desc").Type(DbType.String).Size(50).Value(entity.SectionDesc);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("section_id").Type(DbType.String).Size(50).Value(entity.SectionId);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(SYSSectionInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from SYS_section_list where section_id=@section_id");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("section_id").Type(DbType.String).Size(50).Value(entity.SectionId);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SYSSectionInfo> GetItems()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  section_id,section_desc ");
            cmdText.Append(" FROM    SYS_section_list");
            cmdText.Append(" ORDER BY section_desc");
            return AdoTemplate.QueryWithRowMapperDelegate<SYSSectionInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSSectionInfo item = new SYSSectionInfo();
                item.SectionId = Convert.ToString(reader["section_id"]);
                item.SectionDesc = Convert.ToString(reader["section_desc"]);
                return item;
            });
        }

        #endregion
    }
}

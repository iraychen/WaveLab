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
    public class SampleTemplate : AdoDaoSupport, ISampleTemplate
    {
        #region Basic Operation

        public IList<SampleTemplateInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append(" SELECT  sample_template_id,effective_date,document_path ");
           cmdText.Append(" FROM    sample_template_list");
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
           return AdoTemplate.QueryWithRowMapperDelegate<SampleTemplateInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
           {
               SampleTemplateInfo item = new SampleTemplateInfo();
               item.SampleTemplateId = Convert.ToString(reader["sample_template_id"]);
               item.EffectiveDate = (DateTime)reader["effective_date"];
               item.DocumentPath = Convert.ToString(reader["document_path"]);
               return item;
           },paras.GetParameters());
       }

        public bool CheckExists(string sampleTemplateId,string effectiveDate)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from sample_template_list ");
            cmdText.Append(" where samplel_template_id=upper(@samplel_template_id) ");
            cmdText.Append(" and convert(varchar(10),effective_date,120)=@effetive_date");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("samplel_template_id").Type(DbType.String).Size(50).Value(sampleTemplateId);
            paras.Create().Name("effetive_date").Type(DbType.String).Size(50).Value(effectiveDate);
  
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

        public void Save(SampleTemplateInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into sample_template_list(sample_template_id,effective_date,last_update_date,last_updated_by,creation_date,created_by,document_path) " );
            cmdText.Append("values(@sample_template_id,@effective_date,@last_update_date,@last_updated_by,@creation_date,@created_by,@document_path);");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("sample_template_id").Type(DbType.String).Size(50).Value(entity.SampleTemplateId); 
            paras.Create().Name("effective_date").Type(DbType.DateTime).Size(4).Value(entity.EffectiveDate);            
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("document_path").Type(DbType.String).Size(50).Value(entity.DocumentPath);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(SampleTemplateInfo entity)
        {
            StringBuilder cmdText = new StringBuilder(); 
            cmdText.Append("delete from sample_template_list where sample_template_id=upper(@sample_template_id) ");
            cmdText.Append(" and convert(varchar(10),effective_date,120)=upper(@effective_date)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("sample_template_id").Type(DbType.String).Size(50).Value(entity.SampleTemplateId);
            paras.Create().Name("effective_date").Type(DbType.String).Size(50).Value(entity.EffectiveDate.ToString("yyyy-MM-dd"));
          
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SampleTemplateInfo GetDetail(string sampleTemplateId,string effectiveDate)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  sample_template_id,effective_date,document_path ");
            cmdText.Append(" FROM    sample_template_list ");
            cmdText.Append(" WHERE  sample_template_id=upper(@sample_template_id) ");
            cmdText.Append(" and convert(varchar(10),effective_date,120)=@effective_date ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("sample_template_id").Type(DbType.String).Size(50).Value(sampleTemplateId);
            paras.Create().Name("effective_date").Type(DbType.String).Size(50).Value(effectiveDate);

            return AdoTemplate.QueryForObjectDelegate<SampleTemplateInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SampleTemplateInfo entity = new SampleTemplateInfo();
                entity.SampleTemplateId = Convert.ToString(reader["sample_template_id"]);
                entity.EffectiveDate = (DateTime)reader["effective_date"];
                entity.DocumentPath = Convert.ToString(reader["document_path"]);
                return entity;
            }, paras.GetParameters());
        }

        public SampleTemplateInfo GetSampleTemplate(string sampleTemplateId)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  a.document_path ");
            cmdText.Append(" FROM    sample_template_list a");
            cmdText.Append(" WHERE  a.sample_template_id=upper(@sample_template_id) ");
            cmdText.Append("  and a.effective_date=(");
            cmdText.Append("  select max(effective_date) from sample_template_list ");
            cmdText.Append("  where sample_template_id=a.sample_template_id ");
            cmdText.Append("  and convert(varchar(10),effective_date,120)<=convert(varchar(10),getdate(),120) ");
            cmdText.Append(")");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("sample_template_id").Type(DbType.String).Size(50).Value(sampleTemplateId); 

            return AdoTemplate.QueryForObjectDelegate<SampleTemplateInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SampleTemplateInfo entity = new SampleTemplateInfo();
                entity.DocumentPath = Convert.ToString(reader["document_path"]);
                return entity;
            },paras.GetParameters());
        }
        #endregion
    }
}

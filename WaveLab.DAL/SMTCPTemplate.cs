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
    public class SMTCPTemplate : AdoDaoSupport, ISMTCPTemplate
    {
        #region Basic Operation

        public  IList<SMTCPTemplateInfo> Query(string sortBy, string orderBy)
       {
           StringBuilder cmdText = new StringBuilder();
           cmdText.Append(" SELECT  effective_date,document_path ");
           cmdText.Append(" FROM    SMT_CP_Template");
           cmdText.Append(" WHERE   1=1");

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
           return AdoTemplate.QueryWithRowMapperDelegate<SMTCPTemplateInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
           {
               SMTCPTemplateInfo item = new SMTCPTemplateInfo();
               item.EffectiveDate = (DateTime)reader["effective_date"];
               item.DocumentPath = Convert.ToString(reader["document_path"]);
               return item;
           });
       }

        public bool CheckExists(string effectiveDate)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SMT_CP_Template where convert(varchar(10),effective_date,120)=@effetive_date");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
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

        public void Save(SMTCPTemplateInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into SMT_CP_Template(effective_date,last_update_date,last_updated_by,creation_date,created_by,document_path) " );
            cmdText.Append("values(@effective_date,@last_update_date,@last_updated_by,@creation_date,@created_by,@document_path);");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("effective_date").Type(DbType.DateTime).Size(4).Value(entity.EffectiveDate);            
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("document_path").Type(DbType.String).Size(50).Value(entity.DocumentPath);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void  Delete(SMTCPTemplateInfo entity)
        {
            StringBuilder cmdText = new StringBuilder(); 
            cmdText.Append("delete from SMT_CP_Template where convert(varchar(10),effective_date,120)=upper(@effective_date)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("effective_date").Type(DbType.String).Size(50).Value(entity.EffectiveDate.ToString("yyyy-MM-dd"));
          
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public  SMTCPTemplateInfo GetExportTemplate()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  effective_date,document_path ");
            cmdText.Append(" FROM    SMT_CP_Template");
            cmdText.Append(" WHERE   effective_date=(");
            cmdText.Append("  select max(effective_date) from SMT_CP_Template ");
            cmdText.Append("  where convert(varchar(10),effective_date,120)<=convert(varchar(10),getdate(),120) ");
            cmdText.Append(")");
         
            return AdoTemplate.QueryForObjectDelegate<SMTCPTemplateInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTCPTemplateInfo entity = new SMTCPTemplateInfo();
                entity.EffectiveDate = (DateTime)reader["effective_date"];
                entity.DocumentPath = Convert.ToString(reader["document_path"]);
                return entity;
            });
        }
        #endregion
    }
}

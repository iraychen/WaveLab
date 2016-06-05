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
    public class SMTDocument : AdoDaoSupport, ISMTDocument
    {
        public IList<SMTDocumentInfo> Query(Hashtable hashTable,string sortBy, string orderBy)
        {          
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  documentno,version " );
            cmdText.Append(" FROM    SMT_document_list  ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<SMTDocumentInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTDocumentInfo item = new SMTDocumentInfo();
                item.DocumentNo = Convert.ToString(reader["documentno"]);
                item.Version = Convert.ToString(reader["version"]);
                return item;
            }, paras.GetParameters());
        }

        public void Import(IList<SMTDocumentInfo> items)
        {
            string Sql;
            Sql = "delete from SMT_document_list;";
            AdoTemplate.ExecuteNonQuery(CommandType.Text, Sql);

            foreach (SMTDocumentInfo item in items)
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(" insert into SMT_document_list ");
                cmdText.Append("(documentno,version,last_update_date,last_updated_by,creation_date,created_by)");
                cmdText.Append(" values");
                cmdText.Append("(@documentno,@version,@last_update_date,@last_updated_by,@creation_date,@created_by)");

                IDbParametersBuilder paras = base.CreateDbParametersBuilder();
                paras.Create().Name("documentno").Type(DbType.String).Size(50).Value(item.DocumentNo);
                paras.Create().Name("version").Type(DbType.StringFixedLength).Size(2).Value(item.Version);
                paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(item.LastUpdateDate);
                paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(item.LastUpdatedBy);
                paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(item.CreationDate);
                paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(item.CreatedBy);

                AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            }
        }
    }
}

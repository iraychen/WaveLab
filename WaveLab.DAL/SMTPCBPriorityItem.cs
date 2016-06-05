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
    public class SMTPCBPriorityItem : AdoDaoSupport, ISMTPCBPriorityItem
    {
        public  IList<SMTPCBPriorityItemInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  distinct a.pcb,isnull(b.priorityitem,'N') priorityitem ");
            cmdText.Append(" FROM    SMT_file_induce_list a left join SMT_PCB_PriorityItem_List b ");
            cmdText.Append(" on a.pcb=b.pcb ");
            cmdText.Append(" WHERE   1=1");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                cmdText.Append(" AND upper(a." + entry.Key + ") like upper('%'+@" + entry.Key + "+'%')");
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

            return AdoTemplate.QueryWithRowMapperDelegate<SMTPCBPriorityItemInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTPCBPriorityItemInfo item = new SMTPCBPriorityItemInfo();
                item.PCB = Convert.ToString(reader["pcb"]);
                item.PriorityItem = Convert.ToChar(reader["priorityitem"]);
                return item;
            }, paras.GetParameters());
        }

        public SMTPCBPriorityItemInfo GetDetail(string pcb)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  distinct pcb, priorityitem ");
            cmdText.Append(" FROM    SMT_PCB_PriorityItem_List ");
            cmdText.Append(" WHERE   1=1");
            cmdText.Append(" and upper(pcb)=upper(@pcb)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("pcb").Type(DbType.String).Size(40).Value(pcb);

            return AdoTemplate.QueryForObjectDelegate<SMTPCBPriorityItemInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTPCBPriorityItemInfo entity = new SMTPCBPriorityItemInfo();
                entity.PCB = Convert.ToString(reader["pcb"]);
                entity.PriorityItem = Convert.ToChar(reader["priority"]);
                return entity;
            }, paras.GetParameters());
        }

        public  bool CheckExists(string pcb)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT count(*) ");
            cmdText.Append(" FROM SMT_PCB_PriorityItem_List ");
            cmdText.Append(" where upper(pcb)=upper(@pcb)");
       
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("pcb").Type(DbType.String).Size(40).Value(pcb);

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

        public void SavePriorityItem(IList<SMTPCBPriorityItemInfo> newItems, IList<SMTPCBPriorityItemInfo> editItems)
        {
            foreach (SMTPCBPriorityItemInfo item in newItems)
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(" insert into SMT_PCB_PriorityItem_List");
                cmdText.Append("(pcb, priorityitem, last_update_date,last_updated_by,creation_date,created_by)");
                cmdText.Append(" values");
                cmdText.Append("(@pcb, @priorityitem, @last_update_date,@last_updated_by,@creation_date,@created_by)");

                IDbParametersBuilder paras = base.CreateDbParametersBuilder();
                paras.Create().Name("pcb").Type(DbType.String).Size(40).Value(item.PCB);
                paras.Create().Name("priorityitem").Type(DbType.StringFixedLength).Size(1).Value(item.PriorityItem);
                paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(item.LastUpdateDate);
                paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(item.LastUpdatedBy);
                paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(item.CreationDate);
                paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(item.CreatedBy);

                AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            }

            foreach (SMTPCBPriorityItemInfo item in editItems)
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(" update SMT_PCB_PriorityItem_List set ");
                cmdText.Append(" last_update_date=@last_update_date,last_updated_by=@last_updated_by, priorityitem=@priorityitem ");
                cmdText.Append(" where pcb=@pcb");

                IDbParametersBuilder paras = base.CreateDbParametersBuilder();
                paras.Create().Name("priorityitem").Type(DbType.StringFixedLength).Size(1).Value(item.PriorityItem);
                paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(item.LastUpdateDate);
                paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(item.LastUpdatedBy);
                paras.Create().Name("pcb").Type(DbType.String).Size(40).Value(item.PCB);

                AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            }

        }
    }
}

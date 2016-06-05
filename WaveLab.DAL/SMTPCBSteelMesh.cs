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
    public class SMTPCBSteelMesh:AdoDaoSupport,ISMTPCBSteelMesh
    {
        public IList<SMTPCBSteelMeshInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  pcb,steelmesh,facture_date,serialno,documentno,comments,defect");
            cmdText.Append(" FROM    SMT_pcb_steelmesh_list");
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
            return AdoTemplate.QueryWithRowMapperDelegate<SMTPCBSteelMeshInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTPCBSteelMeshInfo item = new SMTPCBSteelMeshInfo();
                item.PCB = Convert.ToString(reader["pcb"]);
                item.SteelMesh = Convert.ToString(reader["steelmesh"]);
                if (reader["facture_date"] !=null)
                {
                    item.FactureDate = Convert.ToDateTime(reader["facture_date"]);
                }
                item.SerialNo = Convert.ToString(reader["serialno"]);
                item.DocumentNo = Convert.ToString(reader["documentno"]);
                item.Comments = Convert.ToString(reader["comments"]);
                item.Defect = Convert.ToString(reader["defect"]);
                return item;
            }, paras.GetParameters());
        }

        public  bool CheckExists(string pcb)
        {
            bool retVal;

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SMT_pcb_steelmesh_list where upper(pcb)=upper(@pcb)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(pcb);

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

        public void Save(SMTPCBSteelMeshInfo entity)
        {

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" insert into SMT_pcb_steelmesh_list(pcb,last_update_date,last_updated_by,creation_date,created_by,steelmesh,facture_date,serialno,documentno,comments,defect) ");
            cmdText.Append(" values(@pcb,@last_update_date,@last_updated_by,@creation_date,@created_by,@steelmesh,@facture_date,@serialno,@documentno,@comments,@defect);");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(entity.PCB);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("steelmesh").Type(DbType.String).Size(50).Value(entity.SteelMesh);
            paras.Create().Name("facture_date").Type(DbType.DateTime).Size(4).Value(entity.FactureDate);
            paras.Create().Name("serialno").Type(DbType.String).Size(10).Value(entity.SerialNo);
            paras.Create().Name("documentno").Type(DbType.String).Size(50).Value(entity.DocumentNo);
            paras.Create().Name("comments").Type(DbType.String).Size(50).Value(entity.Comments);
            paras.Create().Name("defect").Type(DbType.String).Size(50).Value(entity.Defect);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SMTPCBSteelMeshInfo GetDetail(string pcb)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  pcb,steelmesh,facture_date,serialno,documentno,comments,defect");
            cmdText.Append(" FROM    SMT_pcb_steelmesh_list");
            cmdText.Append(" WHERE   1=1");
            cmdText.Append(" AND  upper(pcb)=upper(@pcb)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(pcb);

            return AdoTemplate.QueryForObjectDelegate<SMTPCBSteelMeshInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader,int rowNum)
            {
                SMTPCBSteelMeshInfo entity = new SMTPCBSteelMeshInfo();
                entity.PCB = Convert.ToString(reader["pcb"]);
                entity.SteelMesh = Convert.ToString(reader["steelmesh"]);
                if (reader["facture_date"] != null)
                {
                    entity.FactureDate = Convert.ToDateTime(reader["facture_date"]);
                }
                entity.SerialNo = Convert.ToString(reader["serialno"]);
                entity.DocumentNo = Convert.ToString(reader["documentno"]);
                entity.Comments = Convert.ToString(reader["comments"]);
                entity.Defect = Convert.ToString(reader["defect"]);
                return entity;
            }, paras.GetParameters());

        }

        public void Update(SMTPCBSteelMeshInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update SMT_pcb_steelmesh_list set steelmesh=@steelmesh,");
            cmdText.Append(" last_update_date=@last_update_date,last_updated_by=@last_updated_by,");
            cmdText.Append(" facture_date=@facture_date,serialno=@serialno,");
            cmdText.Append(" documentno=@documentno,comments=@comments,");
            cmdText.Append(" defect=@defect");
            cmdText.Append(" where upper(pcb)=upper(@pcb)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("steelmesh").Type(DbType.String).Size(50).Value(entity.SteelMesh);
            paras.Create().Name("facture_date").Type(DbType.DateTime).Size(4).Value(entity.FactureDate);
            paras.Create().Name("serialno").Type(DbType.String).Size(10).Value(entity.SerialNo);
            paras.Create().Name("documentno").Type(DbType.String).Size(50).Value(entity.DocumentNo);
            paras.Create().Name("comments").Type(DbType.String).Size(50).Value(entity.Comments);
            paras.Create().Name("defect").Type(DbType.String).Size(50).Value(entity.Defect);
            paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(entity.PCB);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public  void  Delete(SMTPCBSteelMeshInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from SMT_pcb_steelmesh_list where upper(pcb)=upper(@pcb)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(entity.PCB);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SMTPCBSteelMeshInfo> Export(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  pcb,steelmesh,facture_date,serialno,documentno,comments,defect");
            cmdText.Append(" FROM    SMT_pcb_steelmesh_list");
            cmdText.Append(" WHERE   1=1");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                cmdText.Append(" AND upper(" + entry.Key + ")= upper(@" + entry.Key + ")");
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
            return AdoTemplate.QueryWithRowMapperDelegate<SMTPCBSteelMeshInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTPCBSteelMeshInfo item = new SMTPCBSteelMeshInfo();
                item.PCB = Convert.ToString(reader["pcb"]);
                item.SteelMesh = Convert.ToString(reader["steelmesh"]);
                if (reader["facture_date"] != null)
                {
                    item.FactureDate = Convert.ToDateTime(reader["facture_date"]);
                }
                item.SerialNo = Convert.ToString(reader["serialno"]);
                item.DocumentNo = Convert.ToString(reader["documentno"]);
                item.Comments = Convert.ToString(reader["comments"]);
                item.Defect = Convert.ToString(reader["defect"]);
                return item;
            }, paras.GetParameters());
        }

    }
}

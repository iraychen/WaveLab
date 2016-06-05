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
    public class SMTBomCoorPattern : AdoDaoSupport, ISMTBomCoorPattern
    {
        public IList<SMTBomCoorPatternInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  module,bomdn,bomdvs,coorpattern,comments");
            cmdText.Append(" FROM    SMT_bom_coorpattern_list");
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
            return AdoTemplate.QueryWithRowMapperDelegate<SMTBomCoorPatternInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTBomCoorPatternInfo item = new SMTBomCoorPatternInfo();
                item.Module = Convert.ToString(reader["module"]);
                item.BomDN = Convert.ToString(reader["bomdn"]);
                item.BomDVS = Convert.ToString(reader["bomdvs"]);
                item.CoorPattern = Convert.ToString(reader["coorpattern"]);
                item.Comments = Convert.ToString(reader["comments"]);
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string module, string bomdn, string bomdvs)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SMT_bom_coorpattern_list where 1=1");
            cmdText.Append(" AND  upper(module)=upper(@module)");
            cmdText.Append(" AND  upper(bomdn)=upper(@bomdn)");
            cmdText.Append(" AND  upper(bomdvs)=upper(@bomdvs)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("module").Type(DbType.String).Size(50).Value(module);
            paras.Create().Name("bomdn").Type(DbType.String).Size(50).Value(bomdn);
            paras.Create().Name("bomdvs").Type(DbType.String).Size(50).Value(bomdvs);

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

        public void Save(SMTBomCoorPatternInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" insert into SMT_bom_coorpattern_list(module,bomdn,bomdvs,last_update_date,last_updated_by,creation_date,created_by,coorpattern,comments) ");
            cmdText.Append(" values(@module,@bomdn,@bomdvs,@last_update_date,@last_updated_by,@creation_date,@created_by,@coorpattern,@comments);");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("module").Type(DbType.String).Size(50).Value(entity.Module);
            paras.Create().Name("bomdn").Type(DbType.String).Size(50).Value(entity.BomDN);
            paras.Create().Name("bomdvs").Type(DbType.String).Size(50).Value(entity.BomDVS);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("coorpattern").Type(DbType.String).Size(50).Value(entity.CoorPattern);
            paras.Create().Name("comments").Type(DbType.String).Size(100).Value(entity.Comments);
           
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SMTBomCoorPatternInfo GetDetail(string module, string bomdn, string bomdvs)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  module,bomdn,bomdvs,coorpattern,comments");
            cmdText.Append(" FROM    SMT_bom_coorpattern_list");
            cmdText.Append(" WHERE   1=1");
            cmdText.Append(" AND  upper(module)=upper(@module)");
            cmdText.Append(" AND  upper(bomdn)=upper(@bomdn)");
            cmdText.Append(" AND  upper(bomdvs)=upper(@bomdvs)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("module").Type(DbType.String).Size(50).Value(module);
            paras.Create().Name("bomdn").Type(DbType.String).Size(50).Value(bomdn);
            paras.Create().Name("bomdvs").Type(DbType.String).Size(50).Value(bomdvs);

            return AdoTemplate.QueryForObjectDelegate<SMTBomCoorPatternInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTBomCoorPatternInfo entity = new SMTBomCoorPatternInfo();
                entity.Module = Convert.ToString(reader["module"]);
                entity.BomDN = Convert.ToString(reader["bomdn"]);
                entity.BomDVS = Convert.ToString(reader["bomdvs"]);
                entity.CoorPattern = Convert.ToString(reader["coorpattern"]);
                entity.Comments = Convert.ToString(reader["comments"]);
                return entity;
            }, paras.GetParameters());
        }

        public void Update(SMTBomCoorPatternInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update SMT_bom_coorpattern_list set");
            cmdText.Append(" last_update_date=@last_update_date,last_updated_by=@last_updated_by,");
            cmdText.Append(" coorpattern=@coorpattern,comments=@comments");
            cmdText.Append(" WHERE   1=1");
            cmdText.Append(" AND  upper(module)=upper(@module)");
            cmdText.Append(" AND  upper(bomdn)=upper(@bomdn)");
            cmdText.Append(" AND  upper(bomdvs)=upper(@bomdvs)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("coorpattern").Type(DbType.String).Size(50).Value(entity.CoorPattern);
            paras.Create().Name("comments").Type(DbType.String).Size(100).Value(entity.Comments);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("module").Type(DbType.String).Size(50).Value(entity.Module);
            paras.Create().Name("bomdn").Type(DbType.String).Size(50).Value(entity.BomDN);
            paras.Create().Name("bomdvs").Type(DbType.String).Size(50).Value(entity.BomDVS);
           
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(SMTBomCoorPatternInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from SMT_bom_coorpattern_list where 1=1");
            cmdText.Append(" AND  upper(module)=upper(@module)");
            cmdText.Append(" AND  upper(bomdn)=upper(@bomdn)");
            cmdText.Append(" AND  upper(bomdvs)=upper(@bomdvs)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("module").Type(DbType.String).Size(50).Value(entity.Module);
            paras.Create().Name("bomdn").Type(DbType.String).Size(50).Value(entity.BomDN);
            paras.Create().Name("bomdvs").Type(DbType.String).Size(50).Value(entity.BomDVS);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }
    }
}

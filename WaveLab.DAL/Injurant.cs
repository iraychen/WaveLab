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
    public class Injurant : AdoDaoSupport,  IInjurant
    {
        public IList<InjurantInfo> GetItems( Hashtable equalHashTable,Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  a.injurant_id,a.injurant_desc_en,a.injurant_desc_cn,a.molecular_formula,a.cas_no,a.injurant_type_id,a.main_purpose,b.injurant_type_desc");
            cmdText.Append(" FROM    injurant_list a left join injurant_type_list b ");
            cmdText.Append(" on   a.injurant_type_id=b.injurant_type_id ");
            cmdText.Append(" WHERE 1=1 ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in equalHashTable)
            {
                cmdText.Append(" AND upper(a." + entry.Key + ") = upper(@" + entry.Key + ")");
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }
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
            return AdoTemplate.QueryWithRowMapperDelegate<InjurantInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                InjurantTypeInfo injurantTypeItem = new InjurantTypeInfo
                {
                    InjurantTypeId = Convert.ToInt32(reader["injurant_type_id"]),
                    InjurantTypeDesc = Convert.ToString(reader["injurant_type_desc"])
                };

                InjurantInfo item = new InjurantInfo{
                   InjurantId = Convert.ToInt32(reader["injurant_id"]),
                   InjurantDescEn = Convert.ToString(reader["injurant_desc_en"]),
                   InjurantDescCn = Convert.ToString(reader["injurant_desc_cn"]),
                   MolecularFormula = Convert.ToString(reader["molecular_formula"]),
                   CasNo = Convert.ToString(reader["cas_no"]),
                   MainPurpose =Convert.ToString(reader["main_purpose"]),
                   InjurantTypeItem=injurantTypeItem
                };
                return item;
            }, paras.GetParameters());

        }

        public bool CheckExists(string injurantDescCn,string injurantDescEn,string casNo)
        {
            bool retVal;
            bool addOR = false;

            StringBuilder cmdText = new StringBuilder();
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            cmdText.Append("select count(*) from injurant_list ");
            cmdText.Append("where  ");

            if (string.IsNullOrEmpty(injurantDescCn) == false || injurantDescCn.Length > 0)
            {
                cmdText.Append("upper(injurant_desc_cn)=upper(@injurant_desc_cn)");
                paras.Create().Name("injurant_desc_cn").Type(DbType.String).Size(50).Value(injurantDescCn);
                addOR =true;
            }
            if (string.IsNullOrEmpty(injurantDescEn)==false || injurantDescEn.Length > 0)
            {
                if (addOR == true)
                {
                    cmdText.Append("or ");
                }
                cmdText.Append("upper(injurant_desc_en)=upper(@injurant_desc_en)");
                paras.Create().Name("injurant_desc_en").Type(DbType.String).Size(50).Value(injurantDescEn);
                addOR = true;
            }

            if (string.IsNullOrEmpty(casNo) == false || casNo.Length > 0)
            {
                if (addOR == true)
                {
                    cmdText.Append("or ");
                }
                cmdText.Append("upper(cas_no)=upper(@cas_no)");
                paras.Create().Name("cas_no").Type(DbType.String).Size(50).Value(casNo);
            }
            
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

        public bool CheckExists(InjurantInfo entity, string injurantDescCn, string injurantDescEn, string casNo)
        {
            bool retVal;
            bool addOR = false;

            StringBuilder cmdText = new StringBuilder();
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            cmdText.Append("select count(*) from injurant_list ");
            cmdText.Append("where  ");

            if (string.IsNullOrEmpty(injurantDescCn) == false || injurantDescCn.Length > 0)
            {
                cmdText.Append("(injurant_id<>@injurant_id and upper(injurant_desc_cn)=upper(@injurant_desc_cn))");
                paras.Create().Name("injurant_desc_cn").Type(DbType.String).Size(50).Value(injurantDescCn);
                addOR =true;
            }
            if (string.IsNullOrEmpty(injurantDescEn) == false || injurantDescEn.Length > 0)
            {
                if (addOR == true)
                {
                    cmdText.Append("or ");
                }
                cmdText.Append("(injurant_id<>@injurant_id and  upper(injurant_desc_en)=upper(@injurant_desc_en))");
                paras.Create().Name("injurant_desc_en").Type(DbType.String).Size(50).Value(injurantDescEn);
                addOR = true;
            }

            if (string.IsNullOrEmpty(casNo) == false || casNo.Length > 0)
            {
                if (addOR == true)
                {
                    cmdText.Append("or ");
                }
                cmdText.Append("(injurant_id<>@injurant_id and upper(cas_no)=upper(@cas_no))");
                paras.Create().Name("cas_no").Type(DbType.String).Size(50).Value(casNo);
            }
           
            paras.Create().Name("injurant_id").Type(DbType.Int32).Size(4).Value(entity.InjurantId);

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

        public bool CheckInjuct(string substanceName,string casNo)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from injurant_list ");
            cmdText.Append("where  ");
            cmdText.Append("(injurant_desc_cn is not null and len(injurant_desc_cn)>0 and upper(injurant_desc_cn)!=upper('') and  upper(injurant_desc_cn)=upper(@substance_name)) ");
            cmdText.Append("or (injurant_desc_en is not null and len(injurant_desc_en)>0 and upper(injurant_desc_en)!=upper('') and upper(injurant_desc_en)=upper(@substance_name)) ");
            cmdText.Append("or (molecular_formula is not null and len(molecular_formula)>0 and upper(molecular_formula)!=upper('') and upper(molecular_formula)=upper(@substance_name))  ");
            cmdText.Append("or (cas_no is not null and len(rtrim(ltrim(cas_no)))>0 and upper(cas_no)!=upper('') and upper(cas_no)=upper(@cas_no)) ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("substance_name").Type(DbType.String).Size(50).Value(substanceName);
            paras.Create().Name("cas_no").Type(DbType.String).Size(50).Value(casNo);

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

        public void Save(InjurantInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into injurant_list(injurant_desc_en,last_update_date,last_updated_by,creation_date,created_by,injurant_desc_cn,molecular_formula,cas_no,injurant_type_id,main_purpose)");
            cmdText.Append("values(@injurant_desc_en,@last_update_date,@last_updated_by,@creation_date,@created_by,@injurant_desc_cn,@molecular_formula,@cas_no,@injurant_type_id,@main_purpose)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("injurant_desc_en").Type(DbType.String).Size(100).Value(entity.InjurantDescEn);
            paras.Create().Name("injurant_desc_cn").Type(DbType.String).Size(50).Value(entity.InjurantDescCn);
            paras.Create().Name("molecular_formula").Type(DbType.String).Size(50).Value(entity.MolecularFormula);
            paras.Create().Name("cas_no").Type(DbType.String).Size(50).Value(entity.CasNo);
            paras.Create().Name("injurant_type_id").Type(DbType.Int32).Size(50).Value(entity.InjurantTypeItem.InjurantTypeId);
            paras.Create().Name("main_purpose").Type(DbType.String).Size(100).Value(entity.MainPurpose);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());

        }

        public InjurantInfo GetDetail(int injurantId)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  a.injurant_id,a.injurant_desc_en,a.injurant_desc_cn,a.molecular_formula,a.cas_no,a.injurant_type_id,a.main_purpose,b.injurant_type_desc");
            cmdText.Append(" FROM    injurant_list a left join injurant_type_list b ");
            cmdText.Append(" on   a.injurant_type_id=b.injurant_type_id ");
            cmdText.Append(" WHERE 1=1 ");
            cmdText.Append(" AND upper(injurant_id)=upper(@injurant_id)");

            return AdoTemplate.QueryForObjectDelegate<InjurantInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                InjurantTypeInfo injurantTypeEntity = new InjurantTypeInfo
                {
                    InjurantTypeId = Convert.ToInt32(reader["injurant_type_id"]),
                    InjurantTypeDesc = Convert.ToString(reader["injurant_type_desc"])
                };

                InjurantInfo entity = new InjurantInfo
                {
                    InjurantId = Convert.ToInt32(reader["injurant_id"]),
                    InjurantDescEn = Convert.ToString(reader["injurant_desc_en"]),
                    InjurantDescCn = Convert.ToString(reader["injurant_desc_cn"]),
                    MolecularFormula = Convert.ToString(reader["molecular_formula"]),
                    CasNo = Convert.ToString(reader["cas_no"]),
                    MainPurpose = Convert.ToString(reader["main_purpose"]),
                    InjurantTypeItem = injurantTypeEntity
                };
                return entity;
            },
            "injurant_id", DbType.String, 50, injurantId);
        }

        public void Update(InjurantInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update injurant_list set");
            cmdText.Append(" injurant_desc_en=@injurant_desc_en,last_update_date=@last_update_date,last_updated_by=@last_updated_by,injurant_desc_cn=@injurant_desc_cn");
            cmdText.Append(",molecular_formula=@molecular_formula,cas_no=@cas_no,injurant_type_id=@injurant_type_id,main_purpose=@main_purpose");
            cmdText.Append(" where injurant_id=@injurant_id");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("injurant_desc_en").Type(DbType.String).Size(100).Value(entity.InjurantDescEn);
            paras.Create().Name("injurant_desc_cn").Type(DbType.String).Size(50).Value(entity.InjurantDescCn);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("molecular_formula").Type(DbType.String).Size(50).Value(entity.MolecularFormula);
            paras.Create().Name("cas_no").Type(DbType.String).Size(50).Value(entity.CasNo);
            paras.Create().Name("injurant_type_id").Type(DbType.Int32).Size(50).Value(entity.InjurantTypeItem.InjurantTypeId);
            paras.Create().Name("main_purpose").Type(DbType.String).Size(100).Value(entity.MainPurpose);
            paras.Create().Name("injurant_id").Type(DbType.Int32).Size(4).Value(entity.InjurantId);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(InjurantInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from injurant_list ");
            cmdText.Append(" where injurant_id=@injurant_id");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("injurant_id").Type(DbType.Int32).Size(4).Value(entity.InjurantId);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }
    }
}

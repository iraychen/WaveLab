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
    public class SMTFileInduce : AdoDaoSupport, ISMTFileInduce
    {
        #region  Basic Function
        public IList<SMTFileInduceInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  material_code, material_desc, pcb, module_type_id,(select module_type_desc from SYS_module_type_list where module_type_id=a.module_type_id) module_type_desc ,");
            cmdText.Append(" genboard, genboarddn, genboarddvs, speboard, speboarddn, speboarddvs, smtfabricationdn, smtfabricationdvs,");
            cmdText.Append(" componentpart, componentpartdn, componentpartdvs, grouppart, grouppartdn, grouppartdvs, bondingfabricationdn, bondingfabricationdvs,");
            cmdText.Append(" comments, explanation");
            cmdText.Append(" FROM   SMT_file_induce_list a ");
            cmdText.Append(" WHERE  1=1");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                if (string.Equals(entry.Key, "module_type_id") == true)
                {
                    cmdText.Append(" AND upper(" + entry.Key + ") = upper(@" + entry.Key + ")");
                }
                else
                {
                    cmdText.Append(" AND upper(" + entry.Key + ") like upper('%'+@" + entry.Key + "+'%')");
                }
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

            return AdoTemplate.QueryWithRowMapperDelegate<SMTFileInduceInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTFileInduceInfo item = new SMTFileInduceInfo();
                item.MaterialCode = Convert.ToString(reader["material_code"]);
                item.MaterialDesc = Convert.ToString(reader["material_desc"]);
                item.PCB = Convert.ToString(reader["pcb"]);

                SYSModuleTypeInfo moduleTypeItem = new SYSModuleTypeInfo();
                moduleTypeItem.ModuleTypeId = Convert.ToString(reader["module_type_id"]);
                moduleTypeItem.ModuleTypeDesc = Convert.ToString(reader["module_type_desc"]);
                item.ModuleTypeItem = moduleTypeItem;

                item.GenBoard = Convert.ToString(reader["genboard"]);
                item.GenBoardDN = Convert.ToString(reader["genboarddn"]);
                item.GenBoardDVS = Convert.ToString(reader["genboarddvs"]);

                item.SpeBoard = Convert.ToString(reader["speboard"]);
                item.SpeBoardDN = Convert.ToString(reader["speboarddn"]);
                item.SpeBoardDVS = Convert.ToString(reader["speboarddvs"]);

                item.SMTFabricationDN = Convert.ToString(reader["smtfabricationdn"]);
                item.SMTFabricationDVS = Convert.ToString(reader["smtfabricationdvs"]);

                item.ComponentPart = Convert.ToString(reader["componentpart"]);
                item.ComponentPartDN = Convert.ToString(reader["componentpartdn"]);
                item.ComponentPartDVS = Convert.ToString(reader["componentpartdvs"]);

                item.GroupPart = Convert.ToString(reader["grouppart"]);
                item.GroupPartDN = Convert.ToString(reader["grouppartdn"]);
                item.GroupPartDVS = Convert.ToString(reader["grouppartdvs"]);

                item.BondingFabricationDN = Convert.ToString(reader["bondingfabricationdn"]);
                item.BondingFabricationDVS = Convert.ToString(reader["bondingfabricationdvs"]);

                item.Comments = Convert.ToString(reader["comments"]);
                item.Explanation = Convert.ToString(reader["explanation"]);
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string materialCode, string materialDesc, string pcb)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT count(*) ");
            cmdText.Append(" FROM SMT_file_induce_list");
            cmdText.Append(" WHERE   1=1");
            cmdText.Append(" AND  upper(material_code)=upper(@material_code)");
            cmdText.Append(" AND  upper(material_desc)=upper(@material_desc)");
            cmdText.Append(" AND  upper(pcb)=upper(@pcb)"); ;

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("material_code").Type(DbType.String).Size(50).Value(materialCode);
            paras.Create().Name("material_desc").Type(DbType.String).Size(50).Value(materialDesc);
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

        public void Save(SMTFileInduceInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" insert into SMT_file_induce_list");
            cmdText.Append("(");
            cmdText.Append(" material_code, material_desc, pcb, last_update_date,last_updated_by,creation_date,created_by,");
            cmdText.Append(" module_type_id, genboard, genboarddn, genboarddvs, speboard, speboarddn, speboarddvs, smtfabricationdn, smtfabricationdvs,");
            cmdText.Append(" componentpart, componentpartdn, componentpartdvs, grouppart, grouppartdn, grouppartdvs, bondingfabricationdn, bondingfabricationdvs, ");
            cmdText.Append(" comments, explanation");
            cmdText.Append(") ");
            cmdText.Append(" values");
            cmdText.Append("(");
            cmdText.Append(" @material_code, @material_desc, @pcb, @last_update_date,@last_updated_by,@creation_date,@created_by,");
            cmdText.Append(" @module_type_id, @genboard, @genboarddn, @genboarddvs, @speboard, @speboarddn, @speboarddvs, @smtfabricationdn, @smtfabricationdvs,");
            cmdText.Append(" @componentpart, @componentpartdn, @componentpartdvs, @grouppart, @grouppartdn, @grouppartdvs, @bondingfabricationdn, @bondingfabricationdvs, ");
            cmdText.Append(" @comments,@explanation");
            cmdText.Append(")");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("material_code").Type(DbType.StringFixedLength).Size(13).Value(entity.MaterialCode);
            paras.Create().Name("material_desc").Type(DbType.String).Size(40).Value(entity.MaterialDesc);
            paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(entity.PCB);

            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(entity.ModuleTypeItem.ModuleTypeId);
            paras.Create().Name("genboard").Type(DbType.String).Size(50).Value(entity.GenBoard);
            paras.Create().Name("genboarddn").Type(DbType.String).Size(50).Value(entity.GenBoardDN);
            paras.Create().Name("genboarddvs").Type(DbType.StringFixedLength).Size(2).Value(entity.GenBoardDVS);
            paras.Create().Name("speboard").Type(DbType.String).Size(50).Value(entity.SpeBoard);
            paras.Create().Name("speboarddn").Type(DbType.String).Size(50).Value(entity.SpeBoardDN);
            paras.Create().Name("speboarddvs").Type(DbType.StringFixedLength).Size(2).Value(entity.SpeBoardDVS);
            paras.Create().Name("smtfabricationdn").Type(DbType.String).Size(50).Value(entity.SMTFabricationDN);
            paras.Create().Name("smtfabricationdvs").Type(DbType.StringFixedLength).Size(2).Value(entity.SMTFabricationDVS);
            
            paras.Create().Name("componentpart").Type(DbType.String).Size(50).Value(entity.ComponentPart);
            paras.Create().Name("componentpartdn").Type(DbType.String).Size(50).Value(entity.ComponentPartDN);
            paras.Create().Name("componentpartdvs").Type(DbType.StringFixedLength).Size(2).Value(entity.ComponentPartDVS);
            paras.Create().Name("grouppart").Type(DbType.String).Size(50).Value(entity.GroupPart);
            paras.Create().Name("grouppartdn").Type(DbType.String).Size(100).Value(entity.GroupPartDN);
            paras.Create().Name("grouppartdvs").Type(DbType.StringFixedLength).Size(2).Value(entity.GroupPartDVS);
            paras.Create().Name("bondingfabricationdn").Type(DbType.String).Size(50).Value(entity.BondingFabricationDN);
            paras.Create().Name("bondingfabricationdvs").Type(DbType.StringFixedLength).Size(2).Value(entity.BondingFabricationDVS);
         
            paras.Create().Name("comments").Type(DbType.String).Size(100).Value(entity.Comments);
            paras.Create().Name("explanation").Type(DbType.String).Size(100).Value(entity.Explanation);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SMTFileInduceInfo GetDetail(string materialCode, string materialDesc, string pcb)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  material_code, material_desc, pcb, module_type_id,(select module_type_desc from SYS_module_type_list where module_type_id=a.module_type_id) module_type_desc ,");
            cmdText.Append(" genboard, genboarddn, genboarddvs, speboard, speboarddn, speboarddvs, smtfabricationdn, smtfabricationdvs,");
            cmdText.Append(" componentpart, componentpartdn, componentpartdvs, grouppart, grouppartdn, grouppartdvs, bondingfabricationdn, bondingfabricationdvs,");
            cmdText.Append(" comments, explanation");
            cmdText.Append(" FROM   SMT_file_induce_list a ");
            cmdText.Append(" WHERE  1=1");
            cmdText.Append(" AND  upper(material_code)=upper(@material_code)");
            cmdText.Append(" AND  upper(material_desc)=upper(@material_desc)");
            cmdText.Append(" AND  upper(pcb)=upper(@pcb)"); ;

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("material_code").Type(DbType.String).Size(50).Value(materialCode);
            paras.Create().Name("material_desc").Type(DbType.String).Size(50).Value(materialDesc);
            paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(pcb);

            return AdoTemplate.QueryForObjectDelegate<SMTFileInduceInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTFileInduceInfo entity = new SMTFileInduceInfo();
                entity.MaterialCode = Convert.ToString(reader["material_code"]);
                entity.MaterialDesc = Convert.ToString(reader["material_desc"]);
                entity.PCB = Convert.ToString(reader["pcb"]);

                SYSModuleTypeInfo moduleTypeItem = new SYSModuleTypeInfo();
                moduleTypeItem.ModuleTypeId = Convert.ToString(reader["module_type_id"]);
                moduleTypeItem.ModuleTypeDesc = Convert.ToString(reader["module_type_desc"]);
                entity.ModuleTypeItem = moduleTypeItem;

                entity.GenBoard = Convert.ToString(reader["genboard"]);
                entity.GenBoardDN = Convert.ToString(reader["genboarddn"]);
                entity.GenBoardDVS = Convert.ToString(reader["genboarddvs"]);

                entity.SpeBoard = Convert.ToString(reader["speboard"]);
                entity.SpeBoardDN = Convert.ToString(reader["speboarddn"]);
                entity.SpeBoardDVS = Convert.ToString(reader["speboarddvs"]);

                entity.SMTFabricationDN = Convert.ToString(reader["smtfabricationdn"]);
                entity.SMTFabricationDVS = Convert.ToString(reader["smtfabricationdvs"]);

                entity.ComponentPart = Convert.ToString(reader["componentpart"]);
                entity.ComponentPartDN = Convert.ToString(reader["componentpartdn"]);
                entity.ComponentPartDVS = Convert.ToString(reader["componentpartdvs"]);

                entity.GroupPart = Convert.ToString(reader["grouppart"]);
                entity.GroupPartDN = Convert.ToString(reader["grouppartdn"]);
                entity.GroupPartDVS = Convert.ToString(reader["grouppartdvs"]);

                entity.BondingFabricationDN = Convert.ToString(reader["bondingfabricationdn"]);
                entity.BondingFabricationDVS = Convert.ToString(reader["bondingfabricationdvs"]);

                entity.Comments = Convert.ToString(reader["comments"]);
                entity.Explanation = Convert.ToString(reader["explanation"]);
                return entity;
            }, paras.GetParameters());
        }

        public void Update(SMTFileInduceInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update SMT_file_induce_list set");
            cmdText.Append(" last_update_date=@last_update_date,last_updated_by=@last_updated_by,");
            cmdText.Append(" genboard=@genboard,genboarddn=@genboarddn,genboarddvs=@genboarddvs,");
            cmdText.Append(" speboard=@speboard,speboarddn=@speboarddn,speboarddvs=@speboarddvs,");
            cmdText.Append(" smtfabricationdn=@smtfabricationdn,smtfabricationdvs=@smtfabricationdvs,");
            cmdText.Append(" componentpart=@componentpart,componentpartdn=@componentpartdn,componentpartdvs=@componentpartdvs,");
            cmdText.Append(" grouppart=@grouppart,grouppartdn=@grouppartdn,grouppartdvs=@grouppartdvs,");
            cmdText.Append(" bondingfabricationdn=@bondingfabricationdn,bondingfabricationdvs=@bondingfabricationdvs,");
            cmdText.Append(" comments=@comments,explanation=@explanation");
            cmdText.Append(" WHERE   1=1");
            cmdText.Append(" AND  upper(material_code)=upper(@material_code)");
            cmdText.Append(" AND  upper(material_desc)=upper(@material_desc)");
            cmdText.Append(" AND  upper(pcb)=upper(@pcb)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);          
            paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(entity.ModuleTypeItem.ModuleTypeId);
            paras.Create().Name("genboard").Type(DbType.String).Size(50).Value(entity.GenBoard);
            paras.Create().Name("genboarddn").Type(DbType.String).Size(50).Value(entity.GenBoardDN);
            paras.Create().Name("genboarddvs").Type(DbType.StringFixedLength).Size(2).Value(entity.GenBoardDVS);
            paras.Create().Name("speboard").Type(DbType.String).Size(50).Value(entity.SpeBoard);
            paras.Create().Name("speboarddn").Type(DbType.String).Size(50).Value(entity.SpeBoardDN);
            paras.Create().Name("speboarddvs").Type(DbType.StringFixedLength).Size(2).Value(entity.SpeBoardDVS);
            paras.Create().Name("smtfabricationdn").Type(DbType.String).Size(50).Value(entity.SMTFabricationDN);
            paras.Create().Name("smtfabricationdvs").Type(DbType.StringFixedLength).Size(2).Value(entity.SMTFabricationDVS);

            paras.Create().Name("componentpart").Type(DbType.String).Size(50).Value(entity.ComponentPart);
            paras.Create().Name("componentpartdn").Type(DbType.String).Size(50).Value(entity.ComponentPartDN);
            paras.Create().Name("componentpartdvs").Type(DbType.StringFixedLength).Size(2).Value(entity.ComponentPartDVS);
            paras.Create().Name("grouppart").Type(DbType.String).Size(50).Value(entity.GroupPart);
            paras.Create().Name("grouppartdn").Type(DbType.String).Size(100).Value(entity.GroupPartDN);
            paras.Create().Name("grouppartdvs").Type(DbType.StringFixedLength).Size(2).Value(entity.GroupPartDVS);
            paras.Create().Name("bondingfabricationdn").Type(DbType.String).Size(50).Value(entity.BondingFabricationDN);
            paras.Create().Name("bondingfabricationdvs").Type(DbType.StringFixedLength).Size(2).Value(entity.BondingFabricationDVS);

            paras.Create().Name("comments").Type(DbType.String).Size(100).Value(entity.Comments);
            paras.Create().Name("explanation").Type(DbType.String).Size(100).Value(entity.Explanation);

            paras.Create().Name("material_code").Type(DbType.StringFixedLength).Size(13).Value(entity.MaterialCode);
            paras.Create().Name("material_desc").Type(DbType.String).Size(40).Value(entity.MaterialDesc);
            paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(entity.PCB);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(SMTFileInduceInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from SMT_file_induce_list where 1=1");
            cmdText.Append(" AND  upper(material_code)=upper(@material_code)");
            cmdText.Append(" AND  upper(material_desc)=upper(@material_desc)");
            cmdText.Append(" AND  upper(pcb)=upper(@pcb)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("material_code").Type(DbType.StringFixedLength).Size(13).Value(entity.MaterialCode);
            paras.Create().Name("material_desc").Type(DbType.String).Size(40).Value(entity.MaterialDesc);
            paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(entity.PCB);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        #endregion

        #region Update DV,New PCB

        public IList<SMTFileInduceNewDVSInfo> GetNewDVSItems(string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("  select distinct ");
            cmdText.Append(" a.module_type_id, ");
            cmdText.Append("(");
            cmdText.Append(" select module_type_desc from SYS_module_type_list");
            cmdText.Append(" where module_type_id=a.module_type_id ");
            cmdText.Append(") module_type_desc,");
            cmdText.Append(" a.material_code, ");
            cmdText.Append(" a.material_desc, ");
            cmdText.Append(" a.pcb, ");
            cmdText.Append(" a.genboard, ");
            cmdText.Append(" a.genboarddn, ");
            cmdText.Append(" a.genboarddvs, ");
            cmdText.Append(" ( ");
            cmdText.Append(" select upper(version) ");
            cmdText.Append(" from SMT_document_list ");
            cmdText.Append(" where documentno=a.genboarddn ");
            cmdText.Append(" ) newgenboarddvs, ");

            cmdText.Append(" a.speboard, ");
            cmdText.Append(" a.speboarddn, ");
            cmdText.Append(" a.speboarddvs, ");
            cmdText.Append(" ( ");
            cmdText.Append(" select upper(version) ");
            cmdText.Append(" from SMT_document_list ");
            cmdText.Append(" where documentno=a.speboarddn ");
            cmdText.Append(" ) newspeboarddvs, ");

            cmdText.Append(" a.smtfabricationdn, ");
            cmdText.Append(" a.smtfabricationdvs, ");
            cmdText.Append(" ( ");
            cmdText.Append(" select upper(version) ");
            cmdText.Append(" from SMT_document_list ");
            cmdText.Append(" where documentno=a.smtfabricationdn ");
            cmdText.Append(" ) newsmtfabricationdvs, ");

            cmdText.Append(" a.componentpart, ");
            cmdText.Append(" a.componentpartdn, ");
            cmdText.Append(" a.componentpartdvs, ");
            cmdText.Append(" ( ");
            cmdText.Append(" select upper(version) ");
            cmdText.Append(" from SMT_document_list ");
            cmdText.Append(" where documentno=a.componentpartdn ");
            cmdText.Append(" ) newcomponentpartdvs, ");

            cmdText.Append(" a.grouppart, ");
            cmdText.Append(" a.grouppartdn, ");
            cmdText.Append(" a.grouppartdvs, ");
            cmdText.Append(" ( ");
            cmdText.Append(" select upper(version) ");
            cmdText.Append(" from SMT_document_list ");
            cmdText.Append(" where documentno=a.grouppartdn ");
            cmdText.Append(" ) newgrouppartdvs, ");

            cmdText.Append(" a.bondingfabricationdn, ");
            cmdText.Append(" a.bondingfabricationdvs, ");
            cmdText.Append(" ( ");
            cmdText.Append(" select upper(version) ");
            cmdText.Append(" from SMT_document_list ");
            cmdText.Append(" where documentno=a.bondingfabricationdn ");
            cmdText.Append(" ) newbondingfabricationdvs ");

            cmdText.Append(" from  SMT_file_induce_list a ");

            cmdText.Append(" where 1=1 ");
            cmdText.Append(" and exists ");
            cmdText.Append(" ( ");
            cmdText.Append(" select 'x' ");
            cmdText.Append(" from SMT_PCB_PriorityItem_List ");
            cmdText.Append(" where pcb=a.pcb ");
            cmdText.Append(" and priorityitem='Y' ");
            cmdText.Append(" ) ");
            cmdText.Append(" and  ");
            cmdText.Append(" ( ");
            cmdText.Append(" 	( ");
            cmdText.Append(" 		upper(a.genboarddvs)<> ");
            cmdText.Append(" 		( ");
            cmdText.Append(" 		select upper(version) ");
            cmdText.Append(" 		from SMT_document_list ");
            cmdText.Append(" 		where documentno=a.genboarddn ");
            cmdText.Append(" 		) ");
            cmdText.Append(" 	) ");
            cmdText.Append(" 	or ");
            cmdText.Append(" 	( ");
            cmdText.Append(" 		upper(a.speboarddvs)<> ");
            cmdText.Append(" 		( ");
            cmdText.Append(" 		select upper(version) ");
            cmdText.Append(" 		from SMT_document_list ");
            cmdText.Append(" 		where upper(documentno)=upper(a.speboarddn) ");
            cmdText.Append(" 		) ");
            cmdText.Append(" 	) ");
            cmdText.Append(" 	or ");
            cmdText.Append(" 	( ");
            cmdText.Append(" 		upper(a.smtfabricationdvs)<> ");
            cmdText.Append(" 		( ");
            cmdText.Append(" 		select upper(version) ");
            cmdText.Append(" 		from SMT_document_list ");
            cmdText.Append(" 		where upper(documentno)=upper(a.smtfabricationdn) ");
            cmdText.Append(" 		) ");
            cmdText.Append(" 	) ");
            cmdText.Append(" 	or ");
            cmdText.Append(" 	( ");
            cmdText.Append(" 		upper(a.componentpartdvs)<> ");
            cmdText.Append(" 		( ");
            cmdText.Append(" 		select upper(version) ");
            cmdText.Append(" 		from SMT_document_list ");
            cmdText.Append(" 		where documentno=a.componentpartdn ");
            cmdText.Append(" 		) ");
            cmdText.Append(" 	) ");
            cmdText.Append(" 	or ");
            cmdText.Append(" 	( ");
            cmdText.Append(" 		upper(a.grouppartdvs)<> ");
            cmdText.Append(" 		( ");
            cmdText.Append(" 		select upper(version) ");
            cmdText.Append(" 		from SMT_document_list ");
            cmdText.Append(" 		where documentno=a.grouppartdn ");
            cmdText.Append(" 		) ");
            cmdText.Append(" 	) ");
            cmdText.Append(" 	or ");
            cmdText.Append(" 	( ");
            cmdText.Append(" 		upper(a.bondingfabricationdvs)<> ");
            cmdText.Append(" 		( ");
            cmdText.Append(" 		select upper(version) ");
            cmdText.Append(" 		from SMT_document_list ");
            cmdText.Append(" 		where documentno=a.bondingfabricationdn ");
            cmdText.Append(" 		) ");
            cmdText.Append(" 	) ");
            cmdText.Append(" ) ");
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
            return AdoTemplate.QueryWithRowMapperDelegate<SMTFileInduceNewDVSInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTFileInduceNewDVSInfo item = new SMTFileInduceNewDVSInfo();

                item.MaterialCode = Convert.ToString(reader["material_code"]);
                item.MaterialDesc = Convert.ToString(reader["material_desc"]);
                item.PCB = Convert.ToString(reader["pcb"]);

                SYSModuleTypeInfo moduleTypeItem = new SYSModuleTypeInfo();
                moduleTypeItem.ModuleTypeId = Convert.ToString(reader["module_type_id"]);
                moduleTypeItem.ModuleTypeDesc = Convert.ToString(reader["module_type_desc"]);
                item.ModuleTypeItem = moduleTypeItem;

                item.GenBoard = Convert.ToString(reader["genboard"]);
                item.GenBoardDN = Convert.ToString(reader["genboarddn"]);
                item.GenBoardDVS = Convert.ToString(reader["genboarddvs"]);
                item.NewGenBoardDVS = Convert.ToString(reader["newgenboarddvs"]);

                item.SpeBoard = Convert.ToString(reader["speboard"]);
                item.SpeBoardDN = Convert.ToString(reader["speboarddn"]);
                item.SpeBoardDVS = Convert.ToString(reader["speboarddvs"]);
                item.NewSpeBoardDVS = Convert.ToString(reader["newspeboarddvs"]);

                item.SMTFabricationDN = Convert.ToString(reader["smtfabricationdn"]);
                item.SMTFabricationDVS = Convert.ToString(reader["smtfabricationdvs"]);
                item.NewSMTFabricationDVS = Convert.ToString(reader["newsmtfabricationdvs"]);

                item.ComponentPart = Convert.ToString(reader["componentpart"]);
                item.ComponentPartDN = Convert.ToString(reader["componentpartdn"]);
                item.ComponentPartDVS = Convert.ToString(reader["componentpartdvs"]);
                item.NewComponentPartDVS = Convert.ToString(reader["newcomponentpartdvs"]);

                item.GroupPart = Convert.ToString(reader["grouppart"]);
                item.GroupPartDN = Convert.ToString(reader["grouppartdn"]);
                item.GroupPartDVS = Convert.ToString(reader["grouppartdvs"]);
                item.NewGroupPartDVS = Convert.ToString(reader["newgrouppartdvs"]);

                item.BondingFabricationDN = Convert.ToString(reader["bondingfabricationdn"]);
                item.BondingFabricationDVS = Convert.ToString(reader["bondingfabricationdvs"]);
                item.NewBondingFabricationDVS = Convert.ToString(reader["newbondingfabricationdvs"]);
                return item;
            });
        }

        public void UpdateNewDVS(IList<SMTFileInduceInfo> items)
        {
            foreach (SMTFileInduceInfo item in items)
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(" update SMT_file_induce_list set");
                cmdText.Append(" last_update_date=@last_update_date,last_updated_by=@last_updated_by,");
                cmdText.Append(" genboarddvs=@genboarddvs,");
                cmdText.Append(" speboarddvs=@speboarddvs,");
                cmdText.Append(" smtfabricationdvs=@smtfabricationdvs,");
                cmdText.Append(" componentpartdvs=@componentpartdvs,");
                cmdText.Append(" grouppartdvs=@grouppartdvs,");
                cmdText.Append(" bondingfabricationdvs=@bondingfabricationdvs");
                cmdText.Append(" WHERE   1=1");
                cmdText.Append(" AND  upper(material_code)=upper(@material_code)");
                cmdText.Append(" AND  upper(material_desc)=upper(@material_desc)");
                cmdText.Append(" AND  upper(pcb)=upper(@pcb)");

                IDbParametersBuilder paras = base.CreateDbParametersBuilder();
                paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(item.LastUpdateDate);
                paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(item.LastUpdatedBy);
                paras.Create().Name("genboarddvs").Type(DbType.StringFixedLength).Size(2).Value(item.GenBoardDVS);
                paras.Create().Name("speboarddvs").Type(DbType.StringFixedLength).Size(2).Value(item.SpeBoardDVS);
                paras.Create().Name("smtfabricationdvs").Type(DbType.StringFixedLength).Size(2).Value(item.SMTFabricationDVS);
                paras.Create().Name("componentpartdvs").Type(DbType.StringFixedLength).Size(2).Value(item.ComponentPartDVS);
                paras.Create().Name("grouppartdvs").Type(DbType.StringFixedLength).Size(2).Value(item.GroupPartDVS);
                paras.Create().Name("bondingfabricationdvs").Type(DbType.StringFixedLength).Size(2).Value(item.BondingFabricationDVS);

                paras.Create().Name("material_code").Type(DbType.StringFixedLength).Size(13).Value(item.MaterialCode);
                paras.Create().Name("material_desc").Type(DbType.String).Size(40).Value(item.MaterialDesc);
                paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(item.PCB);

                AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            }
        }

        public IList<SMTFileInduceInfo> Query(string moduleTypeId, string pcb, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  material_code, material_desc, pcb, module_type_id,(select module_type_desc from SYS_module_type_list where module_type_id=a.module_type_id) module_type_desc ,");
            cmdText.Append(" genboard, genboarddn, genboarddvs, speboard, speboarddn, speboarddvs, smtfabricationdn, smtfabricationdvs,");
            cmdText.Append(" componentpart, componentpartdn, componentpartdvs, grouppart, grouppartdn, grouppartdvs, bondingfabricationdn, bondingfabricationdvs,");
            cmdText.Append(" comments, explanation");
            cmdText.Append(" FROM   SMT_file_induce_list a ");
            cmdText.Append(" WHERE  1=1");
            cmdText.Append(" AND   upper(a.module_type_id)=upper(@module_type_id) ");
            cmdText.Append(" AND   upper(a.pcb)=upper(@pcb) ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(moduleTypeId);
            paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(pcb);

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
            return AdoTemplate.QueryWithRowMapperDelegate<SMTFileInduceInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTFileInduceInfo item = new SMTFileInduceInfo();
                item.MaterialCode = Convert.ToString(reader["material_code"]);
                item.MaterialDesc = Convert.ToString(reader["material_desc"]);
                item.PCB = Convert.ToString(reader["pcb"]);

                SYSModuleTypeInfo moduleTypeItem = new SYSModuleTypeInfo();
                moduleTypeItem.ModuleTypeId = Convert.ToString(reader["module_type_id"]);
                moduleTypeItem.ModuleTypeDesc = Convert.ToString(reader["module_type_desc"]);
                item.ModuleTypeItem = moduleTypeItem;

                item.GenBoard = Convert.ToString(reader["genboard"]);
                item.GenBoardDN = Convert.ToString(reader["genboarddn"]);
                item.GenBoardDVS = Convert.ToString(reader["genboarddvs"]);

                item.SpeBoard = Convert.ToString(reader["speboard"]);
                item.SpeBoardDN = Convert.ToString(reader["speboarddn"]);
                item.SpeBoardDVS = Convert.ToString(reader["speboarddvs"]);

                item.SMTFabricationDN = Convert.ToString(reader["smtfabricationdn"]);
                item.SMTFabricationDVS = Convert.ToString(reader["smtfabricationdvs"]);

                item.ComponentPart = Convert.ToString(reader["componentpart"]);
                item.ComponentPartDN = Convert.ToString(reader["componentpartdn"]);
                item.ComponentPartDVS = Convert.ToString(reader["componentpartdvs"]);

                item.GroupPart = Convert.ToString(reader["grouppart"]);
                item.GroupPartDN = Convert.ToString(reader["grouppartdn"]);
                item.GroupPartDVS = Convert.ToString(reader["grouppartdvs"]);

                item.BondingFabricationDN = Convert.ToString(reader["bondingfabricationdn"]);
                item.BondingFabricationDVS = Convert.ToString(reader["bondingfabricationdvs"]);

                item.Comments = Convert.ToString(reader["comments"]);
                item.Explanation = Convert.ToString(reader["explanation"]);
                return item;
            }, paras.GetParameters());
        }

        public IList<SMTFileInduceInfo> GetNewPCBItems(string moduleTypeId, string pcb, string newPCB, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();

            cmdText.Append(" SELECT  m.material_code, m.material_desc, m.pcb, m.module_type_id,n.module_type_desc,");
            cmdText.Append(" m.genboard, m.genboarddn, m.genboarddvs, m.speboard, m.speboarddn, m.speboarddvs,m.smtfabricationdn, m.smtfabricationdvs,");
            cmdText.Append(" m.componentpart,m.componentpartdn,m.componentpartdvs,m.grouppart,m.grouppartdn,m.grouppartdvs,m.bondingfabricationdn,m.bondingfabricationdvs");
            cmdText.Append(" FROM (");
            cmdText.Append(" SELECT  a.material_code, a.material_desc, a.pcb, a.module_type_id,");
            cmdText.Append(" a.genboard, a.genboarddn, a.genboarddvs, a.speboard, a.speboarddn, a.speboarddvs, a.smtfabricationdn, a.smtfabricationdvs,");
            cmdText.Append(" a.componentpart,a.componentpartdn,a.componentpartdvs,a.grouppart,a.grouppartdn,a.grouppartdvs,a.bondingfabricationdn,a.bondingfabricationdvs");
            cmdText.Append(" FROM   SMT_file_induce_list a ");
            cmdText.Append(" WHERE  upper(a.pcb)=upper(@pcb) ");

            cmdText.Append(" union ");

            cmdText.Append(" SELECT  b.material_code, b.material_desc, @newpcb as pcb, b.module_type_id, ");
            cmdText.Append(" b.genboard, b.genboarddn, b.genboarddvs, b.speboard, b.speboarddn, b.speboarddvs, b.smtfabricationdn, b.smtfabricationdvs,");
            cmdText.Append(" b.componentpart,b.componentpartdn,b.componentpartdvs,b.grouppart,b.grouppartdn,b.grouppartdvs,b.bondingfabricationdn,b.bondingfabricationdvs");
           
            cmdText.Append(" FROM   SMT_file_induce_list b ");
            cmdText.Append(" WHERE  upper(b.pcb)=upper(@pcb) ");
            cmdText.Append(" ) m ,SYS_module_type_list n ");
            cmdText.Append(" Where m.module_type_id=n.module_type_id ");
            cmdText.Append(" AND   upper(m.module_type_id)=upper(@module_type_id) ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(moduleTypeId);
            paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(pcb);
            paras.Create().Name("newpcb").Type(DbType.String).Size(50).Value(newPCB);

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

            return AdoTemplate.QueryWithRowMapperDelegate<SMTFileInduceInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTFileInduceInfo item = new SMTFileInduceInfo();
                item.MaterialCode = Convert.ToString(reader["material_code"]);
                item.MaterialDesc = Convert.ToString(reader["material_desc"]);
                item.PCB = Convert.ToString(reader["pcb"]);

                SYSModuleTypeInfo moduleTypeItem = new SYSModuleTypeInfo();
                moduleTypeItem.ModuleTypeId = Convert.ToString(reader["module_type_id"]);
                moduleTypeItem.ModuleTypeDesc = Convert.ToString(reader["module_type_desc"]);
                item.ModuleTypeItem = moduleTypeItem;

                item.GenBoard = Convert.ToString(reader["genboard"]);
                item.GenBoardDN = Convert.ToString(reader["genboarddn"]);
                item.GenBoardDVS = Convert.ToString(reader["genboarddvs"]);

                item.SpeBoard = Convert.ToString(reader["speboard"]);
                item.SpeBoardDN = Convert.ToString(reader["speboarddn"]);
                item.SpeBoardDVS = Convert.ToString(reader["speboarddvs"]);

                item.SMTFabricationDN = Convert.ToString(reader["smtfabricationdn"]);
                item.SMTFabricationDVS = Convert.ToString(reader["smtfabricationdvs"]);

                item.ComponentPart = Convert.ToString(reader["componentpart"]);
                item.ComponentPartDN = Convert.ToString(reader["componentpartdn"]);
                item.ComponentPartDVS = Convert.ToString(reader["componentpartdvs"]);

                item.GroupPart = Convert.ToString(reader["grouppart"]);
                item.GroupPartDN = Convert.ToString(reader["grouppartdn"]);
                item.GroupPartDVS = Convert.ToString(reader["grouppartdvs"]);

                item.BondingFabricationDN = Convert.ToString(reader["bondingfabricationdn"]);
                item.BondingFabricationDVS = Convert.ToString(reader["bondingfabricationdvs"]);

                return item;
            }, paras.GetParameters());
 
        }

        public void SaveNewPCB(SMTPCBPriorityItemInfo pcbPriorityItem, SMTPCBPriorityItemInfo newPCBPriorityItem, IList<SMTFileInduceInfo> items)
        {
            StringBuilder pcbCmdText = new StringBuilder();
            pcbCmdText.Append(" update SMT_PCB_PriorityItem_List set  last_update_date=@last_update_date,last_updated_by=@last_updated_by,");
            pcbCmdText.Append(" priorityitem=@priorityitem where upper(pcb)=upper(@pcb)");

            IDbParametersBuilder para = base.CreateDbParametersBuilder();
            para.Create().Name("pcb").Type(DbType.String).Size(40).Value(pcbPriorityItem.PCB);
            para.Create().Name("priorityitem").Type(DbType.StringFixedLength).Size(1).Value(pcbPriorityItem.PriorityItem);
            para.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(pcbPriorityItem.LastUpdateDate);
            para.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(pcbPriorityItem.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, pcbCmdText.ToString(), para.GetParameters());

            StringBuilder newPCBCmdText = new StringBuilder();
            newPCBCmdText.Append(" delete from SMT_PCB_PriorityItem_List where pcb=(@newpcb);");
            newPCBCmdText.Append(" insert into SMT_PCB_PriorityItem_List");
            newPCBCmdText.Append("(pcb, priorityitem, last_update_date,last_updated_by,creation_date,created_by)");
            newPCBCmdText.Append(" values");
            newPCBCmdText.Append("(@newpcb, @priorityitem, @last_update_date,@last_updated_by,@creation_date,@created_by)");

            IDbParametersBuilder param = base.CreateDbParametersBuilder();
            param.Create().Name("newpcb").Type(DbType.String).Size(40).Value(newPCBPriorityItem.PCB);
            param.Create().Name("priorityitem").Type(DbType.StringFixedLength).Size(1).Value(newPCBPriorityItem.PriorityItem);
            param.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(newPCBPriorityItem.LastUpdateDate);
            param.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(newPCBPriorityItem.LastUpdatedBy);
            param.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(newPCBPriorityItem.CreationDate);
            param.Create().Name("created_by").Type(DbType.String).Size(50).Value(newPCBPriorityItem.CreatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, newPCBCmdText.ToString(), param.GetParameters());

            foreach (SMTFileInduceInfo item in items)
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(" insert into SMT_file_induce_list");
                cmdText.Append("(");
                cmdText.Append(" material_code, material_desc, pcb, last_update_date,last_updated_by,creation_date,created_by,");
                cmdText.Append(" module_type_id, genboard, genboarddn, genboarddvs, speboard, speboarddn, speboarddvs, smtfabricationdn, smtfabricationdvs,");
                cmdText.Append(" componentpart, componentpartdn, componentpartdvs, grouppart, grouppartdn, grouppartdvs, bondingfabricationdn, bondingfabricationdvs, ");
                cmdText.Append(" comments");
                cmdText.Append(") ");
                cmdText.Append(" values");
                cmdText.Append("(");
                cmdText.Append(" @material_code, @material_desc, @pcb, @last_update_date,@last_updated_by,@creation_date,@created_by,");
                cmdText.Append(" @module_type_id, @genboard, @genboarddn, @genboarddvs, @speboard, @speboarddn, @speboarddvs, @smtfabricationdn, @smtfabricationdvs,");
                cmdText.Append(" @componentpart, @componentpartdn, @componentpartdvs, @grouppart, @grouppartdn, @grouppartdvs, @bondingfabricationdn, @bondingfabricationdvs, ");
                cmdText.Append(" @comments");
                cmdText.Append(")");

                IDbParametersBuilder paras = base.CreateDbParametersBuilder();
                paras.Create().Name("material_code").Type(DbType.StringFixedLength).Size(13).Value(item.MaterialCode);
                paras.Create().Name("material_desc").Type(DbType.String).Size(40).Value(item.MaterialDesc);
                paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(item.PCB);

                paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(item.LastUpdateDate);
                paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(item.LastUpdatedBy);
                paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(item.CreationDate);
                paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(item.CreatedBy);
                paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(item.ModuleTypeItem.ModuleTypeId);
                paras.Create().Name("genboard").Type(DbType.String).Size(50).Value(item.GenBoard);
                paras.Create().Name("genboarddn").Type(DbType.String).Size(50).Value(item.GenBoardDN);
                paras.Create().Name("genboarddvs").Type(DbType.StringFixedLength).Size(2).Value(item.GenBoardDVS);
                paras.Create().Name("speboard").Type(DbType.String).Size(50).Value(item.SpeBoard);
                paras.Create().Name("speboarddn").Type(DbType.String).Size(50).Value(item.SpeBoardDN);
                paras.Create().Name("speboarddvs").Type(DbType.StringFixedLength).Size(2).Value(item.SpeBoardDVS);
                paras.Create().Name("smtfabricationdn").Type(DbType.String).Size(50).Value(item.SMTFabricationDN);
                paras.Create().Name("smtfabricationdvs").Type(DbType.StringFixedLength).Size(2).Value(item.SMTFabricationDVS);

                paras.Create().Name("componentpart").Type(DbType.String).Size(50).Value(item.ComponentPart);
                paras.Create().Name("componentpartdn").Type(DbType.String).Size(50).Value(item.ComponentPartDN);
                paras.Create().Name("componentpartdvs").Type(DbType.StringFixedLength).Size(2).Value(item.ComponentPartDVS);
                paras.Create().Name("grouppart").Type(DbType.String).Size(50).Value(item.GroupPart);
                paras.Create().Name("grouppartdn").Type(DbType.String).Size(100).Value(item.GroupPartDN);
                paras.Create().Name("grouppartdvs").Type(DbType.StringFixedLength).Size(2).Value(item.GroupPartDVS);
                paras.Create().Name("bondingfabricationdn").Type(DbType.String).Size(50).Value(item.BondingFabricationDN);
                paras.Create().Name("bondingfabricationdvs").Type(DbType.StringFixedLength).Size(2).Value(item.BondingFabricationDVS);

                paras.Create().Name("comments").Type(DbType.String).Size(100).Value(item.Comments);
              
                AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            }
        }

        //public void UpdateComentsBatch(string moduleTypeId, string pcb, string comments)
        //{
        //    StringBuilder cmdText = new StringBuilder();
        //    cmdText.Append(" update SMT_file_induce_list set");
        //    cmdText.Append(" last_update_date=@last_update_date,last_updated_by=@last_updated_by,");
        //    cmdText.Append(" comments=@comments");
        //    cmdText.Append(" WHERE   1=1");
        //    cmdText.Append(" AND  upper(module_type_id)=upper(@module_type_id)");
        //    cmdText.Append(" AND  upper(pcb)=upper(@pcb)");

        //    IDbParametersBuilder paras = base.CreateDbParametersBuilder();
        //    paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(DateTime.Now);
        //    paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(System.Web.HttpContext.Current.User.Identity.Name);
        //    paras.Create().Name("comments").Type(DbType.String).Size(50).Value(comments);
        //    paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(moduleTypeId);
        //    paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(pcb);

        //    AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());             
        //}
        public void UpdateComentsBatch(IList<SMTFileInduceInfo> items, string comments)
        {
            foreach (SMTFileInduceInfo item in items)
            {
                StringBuilder cmdText = new StringBuilder();

                cmdText.Append(" update SMT_file_induce_list set");
                cmdText.Append(" last_update_date=@last_update_date,last_updated_by=@last_updated_by,");
                cmdText.Append(" comments=@comments");
                cmdText.Append(" WHERE   1=1");
                cmdText.Append(" AND  upper(material_code)=upper(@material_code)");
                cmdText.Append(" AND  upper(material_desc)=upper(@material_desc)");
                cmdText.Append(" AND  upper(pcb)=upper(@pcb)");

                IDbParametersBuilder paras = base.CreateDbParametersBuilder();
                paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(item.LastUpdateDate);
                paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(item.LastUpdatedBy);
                paras.Create().Name("comments").Type(DbType.String).Size(50).Value(comments);
                paras.Create().Name("material_code").Type(DbType.String).Size(50).Value(item.MaterialCode);
                paras.Create().Name("material_desc").Type(DbType.String).Size(50).Value(item.MaterialDesc);
                paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(item.PCB);

                AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            }
        }
        #endregion

        #region Report
        public bool CheckExists(string moduleTypeId, string materialCode, string materialDesc, string pcb)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT count(*) ");
            cmdText.Append(" FROM SMT_file_induce_list");
            cmdText.Append(" WHERE  1=1");
          
            cmdText.Append(" AND  upper(material_code)=upper(@material_code)");
            cmdText.Append(" AND  upper(pcb)=upper(@pcb)"); ;

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            if (string.IsNullOrEmpty(moduleTypeId) == false)
            {
                cmdText.Append(" AND  module_type_id=@module_type_id");
                paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(moduleTypeId);
            }
            paras.Create().Name("material_code").Type(DbType.String).Size(50).Value(materialCode);
            if (string.IsNullOrEmpty(materialDesc) == false)
            {
                cmdText.Append(" AND  upper(material_desc)=upper(@material_desc)");
                paras.Create().Name("material_desc").Type(DbType.String).Size(50).Value(materialDesc);
            }
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

        public SMTFileInduceInfo QueryReport(string moduleTypeId, string materialCode, string materialDesc, string pcb)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  material_code, material_desc, pcb, module_type_id,(select module_type_desc from SYS_module_type_list where module_type_id=a.module_type_id) module_type_desc ,");
            cmdText.Append(" genboard, genboarddn, genboarddvs, speboard, speboarddn, speboarddvs, smtfabricationdn, smtfabricationdvs,");
            cmdText.Append(" componentpart, componentpartdn, componentpartdvs, grouppart, grouppartdn, grouppartdvs, bondingfabricationdn, bondingfabricationdvs,");
            cmdText.Append(" comments, explanation");
            cmdText.Append(" FROM   SMT_file_induce_list a ");
            cmdText.Append(" WHERE  1=1");
            cmdText.Append(" AND  upper(material_code)=upper(@material_code)");
            cmdText.Append(" AND  upper(pcb)=upper(@pcb)"); ;

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            if (string.IsNullOrEmpty(moduleTypeId)==false)
            {
                cmdText.Append(" AND  module_type_id=@module_type_id");
                paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(moduleTypeId);
            }
            paras.Create().Name("material_code").Type(DbType.String).Size(50).Value(materialCode);
            if (string.IsNullOrEmpty(materialDesc) == false)
            {
                cmdText.Append(" AND  upper(material_desc)=upper(@material_desc)");
                paras.Create().Name("material_desc").Type(DbType.String).Size(50).Value(materialDesc);
            }
            paras.Create().Name("pcb").Type(DbType.String).Size(50).Value(pcb);

            return AdoTemplate.QueryForObjectDelegate<SMTFileInduceInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTFileInduceInfo entity = new SMTFileInduceInfo();
                entity.MaterialCode = Convert.ToString(reader["material_code"]);
                entity.MaterialDesc = Convert.ToString(reader["material_desc"]);
                entity.PCB = Convert.ToString(reader["pcb"]);

                SYSModuleTypeInfo moduleTypeItem = new SYSModuleTypeInfo();
                moduleTypeItem.ModuleTypeId = Convert.ToString(reader["module_type_id"]);
                moduleTypeItem.ModuleTypeDesc = Convert.ToString(reader["module_type_desc"]);
                entity.ModuleTypeItem = moduleTypeItem;

                entity.GenBoard = Convert.ToString(reader["genboard"]);
                entity.GenBoardDN = Convert.ToString(reader["genboarddn"]);
                entity.GenBoardDVS = Convert.ToString(reader["genboarddvs"]);

                entity.SpeBoard = Convert.ToString(reader["speboard"]);
                entity.SpeBoardDN = Convert.ToString(reader["speboarddn"]);
                entity.SpeBoardDVS = Convert.ToString(reader["speboarddvs"]);

                entity.SMTFabricationDN = Convert.ToString(reader["smtfabricationdn"]);
                entity.SMTFabricationDVS = Convert.ToString(reader["smtfabricationdvs"]);

                entity.ComponentPart = Convert.ToString(reader["componentpart"]);
                entity.ComponentPartDN = Convert.ToString(reader["componentpartdn"]);
                entity.ComponentPartDVS = Convert.ToString(reader["componentpartdvs"]);

                entity.GroupPart = Convert.ToString(reader["grouppart"]);
                entity.GroupPartDN = Convert.ToString(reader["grouppartdn"]);
                entity.GroupPartDVS = Convert.ToString(reader["grouppartdvs"]);

                entity.BondingFabricationDN = Convert.ToString(reader["bondingfabricationdn"]);
                entity.BondingFabricationDVS = Convert.ToString(reader["bondingfabricationdvs"]);

                return entity;
            }, paras.GetParameters());
        }
        #endregion
    }
}

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
    public class MCT : AdoDaoSupport, IMCT
    {
        public IList<MCTQueryInfo> Query( Hashtable hashTable, string sortBy, string orderBy)
        {

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select distinct ");
            cmdText.Append("a.mct_id, ");
            cmdText.Append("a.supplier_name, ");
            cmdText.Append("c.part_no, ");
            cmdText.Append("c.model, ");
            cmdText.Append("a.completed_date,");
            cmdText.Append("a.department,");
            cmdText.Append("a.completed_by,");
            cmdText.Append("a.email, ");
            cmdText.Append("a.tel,");
            cmdText.Append("a.fax, ");
            cmdText.Append("a.creation_date ");
            //cmdText.Append("b.username created_by ");
            cmdText.Append("from material_composition_table  a ,material_composition_dtl c ");
            cmdText.Append("where 1=1 ");
            cmdText.Append("and a.mct_id=c.mct_id ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "supplier_name":
                        cmdText.Append(" AND UPPER(a." + entry.Key + ")   = UPPER(@" + entry.Key + ")");
                        break;
                    case "creation_date":
                        cmdText.Append(" AND CONVERT(varchar(10),a." + entry.Key + ", 120 )   = @" + entry.Key + "");
                        break;
                    //case "username":
                    //    cmdText.Append(" AND UPPER(b." + entry.Key + ")   = UPPER(@" + entry.Key + ")");
                    //    break;
                    case "part_no":
                        cmdText.Append(" AND UPPER(c." + entry.Key + ")   = UPPER(@" + entry.Key + ")");
                        break;
                    case "model":
                        cmdText.Append(" AND UPPER(c." + entry.Key + ")   = UPPER(@" + entry.Key + ")");
                        break;
                    default:
                        break;
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

            return AdoTemplate.QueryWithRowMapperDelegate<MCTQueryInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                MCTQueryInfo item = new MCTQueryInfo();
                item.MCTId = Convert.ToInt32(reader["mct_id"]);
                item.SupplierName = Convert.ToString(reader["supplier_name"]);

                if (reader["completed_date"] != null)
                {
                    item.CompletedDate = Convert.ToDateTime(reader["completed_date"]);
                }
                item.Department = Convert.ToString(reader["department"]);
                item.CompletedBy = Convert.ToString(reader["completed_by"]);
                item.Email = Convert.ToString(reader["email"]);
                item.Tel = Convert.ToString(reader["tel"]);
                item.Fax = Convert.ToString(reader["fax"]);
                item.CreationDate = Convert.ToDateTime(reader["creation_date"]);
                //item.CreatedBy = Convert.ToString(reader["created_by"]);
                item.PartNo = Convert.ToString(reader["part_no"]);
                item.Model = Convert.ToString(reader["model"]);
                return item;
            }, paras.GetParameters());

        }

        public IList<MCTInfo> GetItems(Hashtable equalHashTable, Hashtable hashTable, string sortBy, string orderBy)
        {

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select ");
            cmdText.Append("a.mct_id, ");
            cmdText.Append("a.supplier_name, ");
            cmdText.Append("a.completed_date,");
            cmdText.Append("a.department,");
            cmdText.Append("a.completed_by,");
            cmdText.Append("a.email, ");
            cmdText.Append("a.tel,");
            cmdText.Append("a.fax, ");
            cmdText.Append("a.creation_date, ");
            cmdText.Append("b.username created_by ");
            cmdText.Append("from material_composition_table  a ,SYS_security_master b ");
            cmdText.Append("where upper(b.userid)=upper(a.created_by) ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in equalHashTable)
            {
                if (string.Equals(entry.Key.ToString(), "creation_date") == true)
                {
                    cmdText.Append(" AND CONVERT(varchar(10),a." + entry.Key + ", 120 )   = @" + entry.Key + "");
                }
                else
                {
                    cmdText.Append(" AND upper(b." + entry.Key + ") =upper( @" + entry.Key + ")");
                }
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

            StringBuilder innerCmdText = new StringBuilder();
            innerCmdText.Append("select ");
            innerCmdText.Append("mct_id, ");
            innerCmdText.Append("material_desc, ");
            innerCmdText.Append("model, ");
            innerCmdText.Append("part_no, ");
            innerCmdText.Append("component_desc,");
            innerCmdText.Append("homo_material_name, ");
            innerCmdText.Append("substance_name,");
            innerCmdText.Append("cas_no, ");
            innerCmdText.Append("substance_mass, ");
            innerCmdText.Append("content_rate ");
            innerCmdText.Append("from material_composition_dtl ");
            innerCmdText.Append("where 1=1 ");
            innerCmdText.Append("and mct_id=@mct_id ");
            innerCmdText.Append("order by material_desc asc ");
           
            return AdoTemplate.QueryWithRowMapperDelegate<MCTInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {

                IDbParameters dbParameters = base.CreateDbParameters();
                dbParameters.Add("mct_id", DbType.Int32).Value = Convert.ToInt32(reader["mct_id"]);
                IList<MCTDtlInfo> mctDtlItem = AdoTemplate.QueryWithRowMapperDelegate<MCTDtlInfo>(CommandType.Text, innerCmdText.ToString(), delegate(IDataReader DR, int row)
                {
                    MCTDtlInfo innerItem = new MCTDtlInfo();
                    innerItem.MCTId = Convert.ToInt32(DR["mct_id"]);
                    innerItem.MaterialDesc = Convert.ToString(DR["material_desc"]);
                    innerItem.Model = Convert.ToString(DR["model"]);
                    innerItem.PartNo = Convert.ToString(DR["part_no"]);
                    innerItem.ComponentDesc = Convert.ToString(DR["component_desc"]);
                    innerItem.HomoMaterialName = Convert.ToString(DR["homo_material_name"]);
                    innerItem.SubstanceName = Convert.ToString(DR["substance_name"]);
                    innerItem.CASNo = Convert.ToString(DR["cas_no"]);
                    innerItem.SubstanceMass = Convert.ToDouble(DR["substance_mass"]);
                    innerItem.ContentRate = Convert.ToDouble(DR["content_rate"]);
                    //innerItem.Comment=Convert.ToString(DR["comment"]);
                    return innerItem;
                }, dbParameters);
                MCTInfo item = new MCTInfo();
                item.MCTId = Convert.ToInt32(reader["mct_id"]);
                item.SupplierName=Convert.ToString(reader["supplier_name"]);
                
                if(reader["completed_date"]!=null)
                {
                    item.CompletedDate = Convert.ToDateTime(reader["completed_date"]);
                }
                item.Department = Convert.ToString(reader["department"]);
                item.CompletedBy = Convert.ToString(reader["completed_by"]);
                item.Email = Convert.ToString(reader["email"]);
                item.Tel = Convert.ToString(reader["tel"]);
                item.Fax = Convert.ToString(reader["fax"]);
                item.CreationDate = Convert.ToDateTime(reader["creation_date"]);
                item.CreatedBy = Convert.ToString(reader["created_by"]);
                item.MCTDtlItem = mctDtlItem;
                return item;
            }, paras.GetParameters());

        }

        public bool CheckExists(string supplierName, string partNo, string model)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*)  " );
            cmdText.Append("from material_composition_table a,material_composition_dtl b ");
            cmdText.Append("where a.mct_id=b.mct_id ");
            cmdText.Append("and upper(a.supplier_name)=upper(@supplier_name) ");
            cmdText.Append("and upper(b.part_no)=upper(@part_no) ");
            cmdText.Append("and upper(b.model)=upper(@model) ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("supplier_name").Type(DbType.String).Size(50).Value(supplierName);
            paras.Create().Name("part_no").Type(DbType.String).Size(50).Value(partNo);
            paras.Create().Name("model").Type(DbType.String).Size(50).Value(model);
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

        public void Save(MCTInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("Declare @ID int; Declare @ERR int; ");
            cmdText.Append("insert into material_composition_table ");
            cmdText.Append("(");
            cmdText.Append("last_update_date,last_updated_by,creation_date,created_by,");
            cmdText.Append("supplier_name,");
            cmdText.Append("completed_date,");
            cmdText.Append("department,");
            cmdText.Append("completed_by,");
            cmdText.Append("email,");
            cmdText.Append("tel,");
            cmdText.Append("fax ");
            cmdText.Append(")");
            cmdText.Append("values");
            cmdText.Append("(");
            cmdText.Append("@last_update_date,@last_updated_by,@creation_date,@created_by,");
            cmdText.Append("@supplier_name,");
            cmdText.Append("@completed_date,");
            cmdText.Append("@department,");
            cmdText.Append("@completed_by,");
            cmdText.Append("@email,");
            cmdText.Append("@tel,");
            cmdText.Append("@fax ");
            cmdText.Append(");");
            cmdText.Append("SELECT @ID=@@IDENTITY;");
            cmdText.Append("SELECT @ERR=@@ERROR;");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("supplier_name").Type(DbType.String).Size(50).Value(entity.SupplierName);
            paras.Create().Name("completed_date").Type(DbType.DateTime).Size(4).Value(entity.CompletedDate);
            paras.Create().Name("department").Type(DbType.String).Size(50).Value(entity.Department);
            paras.Create().Name("completed_by").Type(DbType.String).Size(50).Value(entity.CompletedBy);
            paras.Create().Name("email").Type(DbType.String).Size(50).Value(entity.Email);
            paras.Create().Name("tel").Type(DbType.String).Size(50).Value(entity.Tel);
            paras.Create().Name("fax").Type(DbType.String).Size(50).Value(entity.Fax);


            int i = 0;
            foreach (MCTDtlInfo item in entity.MCTDtlItem)
            {
                cmdText.Append("insert into material_composition_dtl ");
                cmdText.Append("(");
                cmdText.Append("last_update_date,last_updated_by,creation_date,created_by,");
                cmdText.Append("mct_id, ");
                cmdText.Append("material_desc, ");
                cmdText.Append("model, ");
                cmdText.Append("part_no, ");
                cmdText.Append("component_desc,");
                cmdText.Append("homo_material_name, ");
                cmdText.Append("substance_name,");
                cmdText.Append("cas_no, ");
                cmdText.Append("substance_mass, ");
                cmdText.Append("content_rate ");
                //cmdText.Append("comment ");
                cmdText.Append(")");
                cmdText.Append("values");
                cmdText.Append("(");
                cmdText.Append("@last_update_date_").Append(i).Append(",");
                cmdText.Append("@last_updated_by_").Append(i).Append(",");
                cmdText.Append("@creation_date_").Append(i).Append(",");
                cmdText.Append("@created_by_").Append(i).Append(",");
                cmdText.Append("@ID").Append(",");
                cmdText.Append("@material_desc_").Append(i).Append(",");
                cmdText.Append("@model_").Append(i).Append(",");
                cmdText.Append("@part_no_").Append(i).Append(",");
                cmdText.Append("@component_desc_").Append(i).Append(",");
                cmdText.Append("@homo_material_name_").Append(i).Append(",");
                cmdText.Append("@substance_name_").Append(i).Append(",");
                cmdText.Append("@cas_no_").Append(i).Append(",");
                cmdText.Append("@substance_mass_").Append(i).Append(",");
                cmdText.Append("@content_rate_").Append(i);
                //cmdText.Append("@comment_").Append(i);
                cmdText.Append(");");
                cmdText.Append("SELECT @ERR=@ERR+@@ERROR;");

                paras.Create().Name("last_update_date_" + i.ToString()).Type(DbType.DateTime).Size(4).Value(item.LastUpdateDate);
                paras.Create().Name("last_updated_by_" + i.ToString()).Type(DbType.String).Size(50).Value(item.LastUpdatedBy);
                paras.Create().Name("creation_date_" + i.ToString()).Type(DbType.DateTime).Size(4).Value(item.CreationDate);
                paras.Create().Name("created_by_" + i.ToString()).Type(DbType.String).Size(50).Value(item.CreatedBy);
                paras.Create().Name("material_desc_" + i.ToString()).Type(DbType.String).Size(50).Value(item.MaterialDesc);
                paras.Create().Name("model_" + i.ToString()).Type(DbType.String).Size(50).Value(item.Model);
                paras.Create().Name("part_no_" + i.ToString()).Type(DbType.String).Size(50).Value(item.PartNo);
                paras.Create().Name("component_desc_" + i.ToString()).Type(DbType.StringFixedLength).Size(50).Value(item.ComponentDesc);
                paras.Create().Name("homo_material_name_" + i.ToString()).Type(DbType.String).Size(50).Value(item.HomoMaterialName);
                paras.Create().Name("substance_name_" + i.ToString()).Type(DbType.String).Size(50).Value(item.SubstanceName);
                paras.Create().Name("cas_no_" + i.ToString()).Type(DbType.String).Size(50).Value(item.CASNo);
                paras.Create().Name("substance_mass_" + i.ToString()).Type(DbType.Double).Size(8).Value(item.SubstanceMass);
                paras.Create().Name("content_rate_" + i.ToString()).Type(DbType.Double).Size(8).Value(item.ContentRate);
                //paras.Create().Name("comment_" + i.ToString()).Type(DbType.String).Size(100).Value(item.Comment);
                i++;
            }

            cmdText.Append("SELECT @ERR ");

            int error = (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            if (error != 0)
            {
                throw new ApplicationException("DATA INTEGRITY ERROR ON ORDER INSERT - ROLLBACK ISSUED");
            }
        }

        public MCTInfo GetDetail(int mctId)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select ");
            cmdText.Append("mct_id, ");
            cmdText.Append("supplier_name, ");
            cmdText.Append("completed_date,");
            cmdText.Append("department,");
            cmdText.Append("completed_by,");
            cmdText.Append("email, ");
            cmdText.Append("tel,");
            cmdText.Append("fax ");
            cmdText.Append("from material_composition_table ");
            cmdText.Append("where 1=1 ");
            cmdText.Append("and mct_id=@mct_id");

            StringBuilder innerCmdText = new StringBuilder();
            innerCmdText.Append("select ");
            innerCmdText.Append("mct_id, ");
            innerCmdText.Append("material_desc, ");
            innerCmdText.Append("model, ");
            innerCmdText.Append("part_no, ");
            innerCmdText.Append("component_desc,");
            innerCmdText.Append("homo_material_name, ");
            innerCmdText.Append("substance_name,");
            innerCmdText.Append("cas_no, ");
            innerCmdText.Append("substance_mass, ");
            innerCmdText.Append("content_rate ");
            //innerCmdText.Append("comment ");
            innerCmdText.Append("from material_composition_dtl ");
            innerCmdText.Append("where 1=1 ");
            innerCmdText.Append("and mct_id=@mct_id ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("mct_id").Type(DbType.Int32).Size(4).Value(mctId);

            IList<MCTDtlInfo> mctDtlItem = AdoTemplate.QueryWithRowMapperDelegate<MCTDtlInfo>(CommandType.Text, innerCmdText.ToString(), delegate(IDataReader DR, int row)
            {
                MCTDtlInfo innerItem = new MCTDtlInfo();
                innerItem.MCTId = Convert.ToInt32(DR["mct_id"]);
                innerItem.MaterialDesc = Convert.ToString(DR["material_desc"]);
                innerItem.Model = Convert.ToString(DR["model"]);
                innerItem.PartNo = Convert.ToString(DR["part_no"]);
                innerItem.ComponentDesc = Convert.ToString(DR["component_desc"]);
                innerItem.HomoMaterialName = Convert.ToString(DR["homo_material_name"]);
                innerItem.SubstanceName = Convert.ToString(DR["substance_name"]);
                innerItem.CASNo = Convert.ToString(DR["cas_no"]);
                innerItem.SubstanceMass = Convert.ToDouble(DR["substance_mass"]);
                innerItem.ContentRate = Convert.ToDouble(DR["content_rate"]);
                //innerItem.Comment = Convert.ToString(DR["comment"]);
                return innerItem;
            }, paras.GetParameters());

            return AdoTemplate.QueryForObjectDelegate<MCTInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                MCTInfo entity = new MCTInfo();
                entity.MCTId = Convert.ToInt32(reader["mct_id"]);
                entity.SupplierName = Convert.ToString(reader["supplier_name"]);
                if (reader["completed_date"] != null)
                {
                    entity.CompletedDate = Convert.ToDateTime(reader["completed_date"]);
                }
                entity.Department = Convert.ToString(reader["department"]);
                entity.CompletedBy = Convert.ToString(reader["completed_by"]);
                entity.Email = Convert.ToString(reader["email"]);
                entity.Tel = Convert.ToString(reader["tel"]);
                entity.Fax = Convert.ToString(reader["fax"]);
                entity.MCTDtlItem = mctDtlItem;
                return entity;
            },paras.GetParameters());
        }

        public void Update(string supplierName,string partNo,string model,MCTInfo entity)
        {

            StringBuilder cmdText = new StringBuilder();
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            cmdText.Append("Declare @ERR int; ");

            cmdText.Append("delete from material_composition_table  ");
            cmdText.Append("where mct_id = ");
            cmdText.Append("( ");
            cmdText.Append("select distinct a.mct_id ");
            cmdText.Append("from  material_composition_table a,material_composition_dtl b ");
            cmdText.Append("where a.mct_id=b.mct_id ");
            cmdText.Append("and upper(a.supplier_name)=upper(@suppiler_name) ");
            cmdText.Append("and upper(b.part_no)=upper(@part_no) ");
            cmdText.Append("and upper(b.model)=upper(@model) ");
            cmdText.Append("); ");

            cmdText.Append("SELECT @ERR=@@ERROR;");

            paras.Create().Name("suppiler_name").Type(DbType.String).Size(50).Value(supplierName);
            paras.Create().Name("part_no").Type(DbType.String).Size(50).Value(partNo);
            paras.Create().Name("model").Type(DbType.String).Size(50).Value(model);

            cmdText.Append("Declare @ID int;");
            cmdText.Append("insert into material_composition_table ");
            cmdText.Append("(");
            cmdText.Append("last_update_date,last_updated_by,creation_date,created_by,");
            cmdText.Append("supplier_name,");
            cmdText.Append("completed_date,");
            cmdText.Append("department,");
            cmdText.Append("completed_by,");
            cmdText.Append("email,");
            cmdText.Append("tel,");
            cmdText.Append("fax ");
            cmdText.Append(")");
            cmdText.Append("values");
            cmdText.Append("(");
            cmdText.Append("@last_update_date,@last_updated_by,@creation_date,@created_by,");
            cmdText.Append("@supplier_name,");
            cmdText.Append("@completed_date,");
            cmdText.Append("@department,");
            cmdText.Append("@completed_by,");
            cmdText.Append("@email,");
            cmdText.Append("@tel,");
            cmdText.Append("@fax ");
            cmdText.Append(");");
            cmdText.Append("SELECT @ID=@@IDENTITY;");
            cmdText.Append("SELECT @ERR=@ERR+@@ERROR;");

           
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("supplier_name").Type(DbType.String).Size(50).Value(entity.SupplierName);
            paras.Create().Name("completed_date").Type(DbType.DateTime).Size(4).Value(entity.CompletedDate);
            paras.Create().Name("department").Type(DbType.String).Size(50).Value(entity.Department);
            paras.Create().Name("completed_by").Type(DbType.String).Size(50).Value(entity.CompletedBy);
            paras.Create().Name("email").Type(DbType.String).Size(50).Value(entity.Email);
            paras.Create().Name("tel").Type(DbType.String).Size(50).Value(entity.Tel);
            paras.Create().Name("fax").Type(DbType.String).Size(50).Value(entity.Fax);


            int i = 0;
            foreach (MCTDtlInfo item in entity.MCTDtlItem)
            {
                cmdText.Append("insert into material_composition_dtl ");
                cmdText.Append("(");
                cmdText.Append("last_update_date,last_updated_by,creation_date,created_by,");
                cmdText.Append("mct_id, ");
                cmdText.Append("material_desc, ");
                cmdText.Append("model, ");
                cmdText.Append("part_no, ");
                cmdText.Append("component_desc,");
                cmdText.Append("homo_material_name, ");
                cmdText.Append("substance_name,");
                cmdText.Append("cas_no, ");
                cmdText.Append("substance_mass, ");
                cmdText.Append("content_rate ");
                //cmdText.Append("comment ");
                cmdText.Append(")");
                cmdText.Append("values");
                cmdText.Append("(");
                cmdText.Append("@last_update_date_").Append(i).Append(",");
                cmdText.Append("@last_updated_by_").Append(i).Append(",");
                cmdText.Append("@creation_date_").Append(i).Append(",");
                cmdText.Append("@created_by_").Append(i).Append(",");
                cmdText.Append("@ID").Append(",");
                cmdText.Append("@material_desc_").Append(i).Append(",");
                cmdText.Append("@model_").Append(i).Append(",");
                cmdText.Append("@part_no_").Append(i).Append(",");
                cmdText.Append("@component_desc_").Append(i).Append(",");
                cmdText.Append("@homo_material_name_").Append(i).Append(",");
                cmdText.Append("@substance_name_").Append(i).Append(",");
                cmdText.Append("@cas_no_").Append(i).Append(",");
                cmdText.Append("@substance_mass_").Append(i).Append(",");
                cmdText.Append("@content_rate_").Append(i);
                //cmdText.Append("@comment_").Append(i);
                cmdText.Append(");");
                cmdText.Append("SELECT @ERR=@ERR+@@ERROR;");

                paras.Create().Name("last_update_date_" + i.ToString()).Type(DbType.DateTime).Size(4).Value(item.LastUpdateDate);
                paras.Create().Name("last_updated_by_" + i.ToString()).Type(DbType.String).Size(50).Value(item.LastUpdatedBy);
                paras.Create().Name("creation_date_" + i.ToString()).Type(DbType.DateTime).Size(4).Value(item.CreationDate);
                paras.Create().Name("created_by_" + i.ToString()).Type(DbType.String).Size(50).Value(item.CreatedBy);
                paras.Create().Name("material_desc_" + i.ToString()).Type(DbType.String).Size(50).Value(item.MaterialDesc);
                paras.Create().Name("model_" + i.ToString()).Type(DbType.String).Size(50).Value(item.Model);
                paras.Create().Name("part_no_" + i.ToString()).Type(DbType.String).Size(50).Value(item.PartNo);
                paras.Create().Name("component_desc_" + i.ToString()).Type(DbType.StringFixedLength).Size(50).Value(item.ComponentDesc);
                paras.Create().Name("homo_material_name_" + i.ToString()).Type(DbType.String).Size(50).Value(item.HomoMaterialName);
                paras.Create().Name("substance_name_" + i.ToString()).Type(DbType.String).Size(50).Value(item.SubstanceName);
                paras.Create().Name("cas_no_" + i.ToString()).Type(DbType.String).Size(50).Value(item.CASNo);
                paras.Create().Name("substance_mass_" + i.ToString()).Type(DbType.Double).Size(8).Value(item.SubstanceMass);
                paras.Create().Name("content_rate_" + i.ToString()).Type(DbType.Double).Size(8).Value(item.ContentRate);
                //paras.Create().Name("comment_" + i.ToString()).Type(DbType.String).Size(100).Value(item.Comment);
                i++;
            }

            cmdText.Append("SELECT @ERR ");

            int error = (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            if (error != 0)
            {
                throw new ApplicationException("DATA INTEGRITY ERROR ON ORDER INSERT - ROLLBACK ISSUED");
            }
        }

        public void Delete(MCTInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from material_composition_table ");
            cmdText.Append(" where mct_id=@mct_id");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("mct_id").Type(DbType.Int32).Size(4).Value(entity.MCTId);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }
    }
}

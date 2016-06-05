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
    public class SMTModelFileInduce : AdoDaoSupport, ISMTModelFileInduce
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM SMT_Model_File_Induce_List a left join SYS_Module_Type_List b on a.Module_Type_Id=b.Module_Type_Id ");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                if (string.Equals(entry.Key, "Module_Type_Id") == true)
                {
                    cmdText.Append(" AND upper(a." + entry.Key + ") = upper(@" + entry.Key + ")");
                }
                else
                {
                    cmdText.Append(" AND upper(a." + entry.Key + ") like upper('%'+@" + entry.Key + "+'%')");
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SMTModelFileInduceInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");
            cmdText.Append("SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append("a.File_Induce_PK,a.Module_Type_Id,a.Bill_Serial_Number,a.Module_Desc ,a.PCB,a.Serial_Number,a.Version, ");
            cmdText.Append("a.SpeBoard ,a.SpeBoardDN,a.SpeBoardDVS,a.FabricationDN,a.FabricationDVS,a.SteelMesh,a.CoorPattern,a.Comments ,b.Module_Type_Desc ");
            cmdText.Append("FROM SMT_Model_File_Induce_List a left join SYS_Module_Type_List b on a.Module_Type_Id=b.Module_Type_Id ");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                if (string.Equals(entry.Key, "Module_Type_Id") == true)
                {
                    cmdText.Append(" AND upper(a." + entry.Key + ") = upper(@" + entry.Key + ")");
                }
                else
                {
                    cmdText.Append(" AND upper(a." + entry.Key + ") like upper('%'+@" + entry.Key + "+'%')");
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            int startRowNum = (page - 1) * pageSize + 1;
            int endRowNum = startRowNum + pageSize - 1;

            cmdText.Append(" ) t_pager where rowindex between " + startRowNum.ToString() + " and " + endRowNum.ToString());

            return AdoTemplate.QueryWithRowMapperDelegate<SMTModelFileInduceInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SMTModelFileInduceInfo item = new SMTModelFileInduceInfo();
                item.FileInducePK = Convert.ToInt32(reader["File_Induce_PK"]);
                item.BillSerialNumber = Convert.ToString(reader["Bill_Serial_Number"]);
                item.ModuleDesc = Convert.ToString(reader["Module_Desc"]);
                item.PCB = Convert.ToString(reader["pcb"]);

                item.SerialNumber = Convert.ToString(reader["Serial_Number"]);
                item.Version = Convert.ToString(reader["Version"]);

                item.SpeBoard = Convert.ToString(reader["SpeBoard"]);
                item.SpeBoardDN = Convert.ToString(reader["SpeBoardDN"]);
                item.SpeBoardDVS = Convert.ToString(reader["SpeBoardDVS"]);

                item.FabricationDN = Convert.ToString(reader["FabricationDN"]);
                item.FabricationDVS = Convert.ToString(reader["FabricationDVS"]);

                item.SteelMesh = Convert.ToString(reader["SteelMesh"]);
                item.CoorPattern = Convert.ToString(reader["CoorPattern"]);
              
                item.Comments = Convert.ToString(reader["comments"]);

                SYSModuleTypeInfo moduleTypeItem = new SYSModuleTypeInfo()
                {
                    ModuleTypeId = Convert.ToString(reader["module_type_id"]),
                    ModuleTypeDesc = Convert.ToString(reader["module_type_desc"])
                };
                item.ModuleTypeItem = moduleTypeItem;
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(SMTModelFileInduceInfo entity)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT count(*) ");
            cmdText.Append(" FROM SMT_Model_File_Induce_List");
            cmdText.Append(" WHERE   1=1");
            cmdText.Append(" AND  upper(Bill_Serial_Number)=upper(@Bill_Serial_Number)");
            cmdText.Append(" AND  upper(Module_Desc)=upper(@Module_Desc)");
            cmdText.Append(" AND  upper(PCB)=upper(@PCB)");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Bill_Serial_Number").Type(DbType.String).Size(50).Value(entity.BillSerialNumber);
            paras.Create().Name("Module_Desc").Type(DbType.String).Size(50).Value(entity.ModuleDesc);
            paras.Create().Name("PCB").Type(DbType.String).Size(50).Value(entity.PCB);
            if (entity.FileInducePK != 0)
            {
                cmdText.Append(" AND  File_Induce_PK<>@File_Induce_PK");
                paras.Create().Name("File_Induce_PK").Type(DbType.Int32).Value(entity.FileInducePK);
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

        public void Save(SMTModelFileInduceInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" insert into SMT_Model_File_Induce_List");
            cmdText.Append("(");
            cmdText.Append(" Module_Type_Id,Bill_Serial_Number,Module_Desc,PCB,Serial_Number,Version,SpeBoard ,SpeBoardDN,SpeBoardDVS,");
            cmdText.Append(" FabricationDN,FabricationDVS,SteelMesh,CoorPattern,Comments,Last_Update_Date,Last_Updated_By");            
            cmdText.Append(") ");
            cmdText.Append(" values");
            cmdText.Append("(");
            cmdText.Append(" @Module_Type_Id,@Bill_Serial_Number,@Module_Desc ,@PCB,@Serial_Number,@Version,@SpeBoard ,@SpeBoardDN,@SpeBoardDVS,");
            cmdText.Append(" @FabricationDN,@FabricationDVS,@SteelMesh,@CoorPattern,@Comments,@Last_Update_Date,@Last_Updated_By");
            cmdText.Append(")");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Module_Type_Id").Type(DbType.String).Value(entity.ModuleTypeId);
            paras.Create().Name("Bill_Serial_Number").Type(DbType.String).Size(50).Value(entity.BillSerialNumber);
            paras.Create().Name("Module_Desc").Type(DbType.String).Size(50).Value(entity.ModuleDesc);
            paras.Create().Name("PCB").Type(DbType.String).Size(50).Value(entity.PCB);
            paras.Create().Name("Serial_Number").Type(DbType.String).Size(50).Value(entity.SerialNumber);
            paras.Create().Name("Version").Type(DbType.String).Size(50).Value(entity.Version);
            paras.Create().Name("SpeBoard").Type(DbType.String).Size(50).Value(entity.SpeBoard);
            paras.Create().Name("SpeBoardDN").Type(DbType.String).Size(50).Value(entity.SpeBoardDN);
            paras.Create().Name("SpeBoardDVS").Type(DbType.String).Size(50).Value(entity.SpeBoardDVS);
            paras.Create().Name("FabricationDN").Type(DbType.String).Size(50).Value(entity.FabricationDN);
            paras.Create().Name("FabricationDVS").Type(DbType.StringFixedLength).Size(50).Value(entity.FabricationDVS);
            paras.Create().Name("SteelMesh").Type(DbType.String).Size(100).Value(entity.SteelMesh);
            paras.Create().Name("CoorPattern").Type(DbType.String).Size(100).Value(entity.CoorPattern);
            paras.Create().Name("Comments").Type(DbType.String).Size(100).Value(entity.Comments);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SMTModelFileInduceInfo GetDetail(int FileInducePK)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT a.File_Induce_PK,a.Module_Type_Id,a.Bill_Serial_Number,a.Module_Desc ,a.PCB,a.Serial_Number,a.Version, ");
            cmdText.Append("a.SpeBoard ,a.SpeBoardDN,a.SpeBoardDVS,a.FabricationDN,a.FabricationDVS,a.SteelMesh,a.CoorPattern,a.Comments ,b.Module_Type_Desc ");
            cmdText.Append("FROM SMT_Model_File_Induce_List a left join SYS_Module_Type_List b on a.Module_Type_Id=b.Module_Type_Id ");
            cmdText.Append("WHERE 1=1 ");
            cmdText.Append("AND File_Induce_PK=upper(@File_Induce_PK)");
         
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("File_Induce_PK").Type(DbType.Int32).Value(FileInducePK);
         
            return AdoTemplate.QueryForObjectDelegate<SMTModelFileInduceInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTModelFileInduceInfo entity = new SMTModelFileInduceInfo();
              
                entity.FileInducePK = Convert.ToInt32(reader["File_Induce_PK"]);
                entity.ModuleTypeId = Convert.ToString(reader["Module_Type_Id"]);
                entity.BillSerialNumber = Convert.ToString(reader["Bill_Serial_Number"]);
                entity.ModuleDesc = Convert.ToString(reader["Module_Desc"]);
                entity.PCB = Convert.ToString(reader["pcb"]);

                entity.SerialNumber = Convert.ToString(reader["Serial_Number"]);
                entity.Version = Convert.ToString(reader["Version"]);

                entity.SpeBoard = Convert.ToString(reader["SpeBoard"]);
                entity.SpeBoardDN = Convert.ToString(reader["SpeBoardDN"]);
                entity.SpeBoardDVS = Convert.ToString(reader["SpeBoardDVS"]);

                entity.FabricationDN = Convert.ToString(reader["FabricationDN"]);
                entity.FabricationDVS = Convert.ToString(reader["FabricationDVS"]);

                entity.SteelMesh = Convert.ToString(reader["SteelMesh"]);
                entity.CoorPattern = Convert.ToString(reader["CoorPattern"]);

                entity.Comments = Convert.ToString(reader["comments"]);

                SYSModuleTypeInfo moduleTypeItem = new SYSModuleTypeInfo()
                {
                    ModuleTypeId = Convert.ToString(reader["module_type_id"]),
                    ModuleTypeDesc = Convert.ToString(reader["module_type_desc"])
                };
                entity.ModuleTypeItem = moduleTypeItem;
                return entity;
            }, paras.GetParameters());
        }

        public void Update(SMTModelFileInduceInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("UPDATE SMT_Model_File_Induce_List SET ");
            cmdText.Append("Module_Type_Id=@Module_Type_Id,Bill_Serial_Number=@Bill_Serial_Number,Module_Desc=@Module_Desc ,PCB=@PCB,Serial_Number=@Serial_Number,Version=@Version, ");
            cmdText.Append("SpeBoard =@SpeBoard,SpeBoardDN=@SpeBoardDN,SpeBoardDVS=@SpeBoardDVS,FabricationDN=@FabricationDN,FabricationDVS=@FabricationDVS, ");
            cmdText.Append("SteelMesh=@SteelMesh,CoorPattern=@CoorPattern,Comments=@Comments,Last_Update_Date=@Last_Update_Date,Last_Updated_By=@Last_Updated_By ");
            cmdText.Append("WHERE File_Induce_PK=@File_Induce_PK");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Module_Type_Id").Type(DbType.String).Value(entity.ModuleTypeId);
            paras.Create().Name("Bill_Serial_Number").Type(DbType.String).Size(50).Value(entity.BillSerialNumber);
            paras.Create().Name("Module_Desc").Type(DbType.String).Size(50).Value(entity.ModuleDesc);
            paras.Create().Name("PCB").Type(DbType.String).Size(50).Value(entity.PCB);
            paras.Create().Name("Serial_Number").Type(DbType.String).Size(50).Value(entity.SerialNumber);
            paras.Create().Name("Version").Type(DbType.String).Size(50).Value(entity.Version);
            paras.Create().Name("SpeBoard").Type(DbType.String).Size(50).Value(entity.SpeBoard);
            paras.Create().Name("SpeBoardDN").Type(DbType.String).Size(50).Value(entity.SpeBoardDN);
            paras.Create().Name("SpeBoardDVS").Type(DbType.String).Size(50).Value(entity.SpeBoardDVS);
            paras.Create().Name("FabricationDN").Type(DbType.String).Size(50).Value(entity.FabricationDN);
            paras.Create().Name("FabricationDVS").Type(DbType.StringFixedLength).Size(50).Value(entity.FabricationDVS);
            paras.Create().Name("SteelMesh").Type(DbType.String).Size(100).Value(entity.SteelMesh);
            paras.Create().Name("CoorPattern").Type(DbType.String).Size(100).Value(entity.CoorPattern);
            paras.Create().Name("Comments").Type(DbType.String).Size(100).Value(entity.Comments);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("File_Induce_PK").Type(DbType.Int32).Value(entity.FileInducePK);
         
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(SMTModelFileInduceInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" DELETE FROM SMT_Model_File_Induce_List where 1=1");
            cmdText.Append(" AND  File_Induce_PK=@File_Induce_PK");
          
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("File_Induce_PK").Type(DbType.Int32).Value(entity.FileInducePK);         

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SMTModelFileInduceInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT a.File_Induce_PK,a.Module_Type_Id,a.Bill_Serial_Number,a.Module_Desc ,a.PCB,a.Serial_Number,a.Version, ");
            cmdText.Append("a.SpeBoard ,a.SpeBoardDN,a.SpeBoardDVS,a.FabricationDN,a.FabricationDVS,a.SteelMesh,a.CoorPattern,a.Comments ,b.Module_Type_Desc ");
            cmdText.Append("FROM SMT_Model_File_Induce_List a left join SYS_Module_Type_List b on a.Module_Type_Id=b.Module_Type_Id ");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                if (string.Equals(entry.Key, "Module_Type_Id") == true)
                {
                    cmdText.Append(" AND upper(a." + entry.Key + ") = upper(@" + entry.Key + ")");
                }
                else
                {
                    cmdText.Append(" AND upper(a." + entry.Key + ") like upper('%'+@" + entry.Key + "+'%')");
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }
            

            return AdoTemplate.QueryWithRowMapperDelegate<SMTModelFileInduceInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SMTModelFileInduceInfo item = new SMTModelFileInduceInfo();
                item.FileInducePK = Convert.ToInt32(reader["File_Induce_PK"]);
                item.ModuleTypeId = Convert.ToString(reader["Module_Type_Id"]);
                item.BillSerialNumber = Convert.ToString(reader["Bill_Serial_Number"]);
                item.ModuleDesc = Convert.ToString(reader["Module_Desc"]);
                item.PCB = Convert.ToString(reader["pcb"]);

                item.SerialNumber = Convert.ToString(reader["Serial_Number"]);
                item.Version = Convert.ToString(reader["Version"]);

                item.SpeBoard = Convert.ToString(reader["SpeBoard"]);
                item.SpeBoardDN = Convert.ToString(reader["SpeBoardDN"]);
                item.SpeBoardDVS = Convert.ToString(reader["SpeBoardDVS"]);

                item.FabricationDN = Convert.ToString(reader["FabricationDN"]);
                item.FabricationDVS = Convert.ToString(reader["FabricationDVS"]);

                item.SteelMesh = Convert.ToString(reader["SteelMesh"]);
                item.CoorPattern = Convert.ToString(reader["CoorPattern"]);

                item.Comments = Convert.ToString(reader["comments"]);

                SYSModuleTypeInfo moduleTypeItem = new SYSModuleTypeInfo()
                {
                    ModuleTypeId = Convert.ToString(reader["module_type_id"]),
                    ModuleTypeDesc = Convert.ToString(reader["module_type_desc"])
                };
                item.ModuleTypeItem = moduleTypeItem;
                return item;
            }, paras.GetParameters());
        }

        //public int GetCount(string modelOrder)
        //{
        //    StringBuilder cmdText = new StringBuilder();
        //    cmdText.Append(" SELECT distinct count(*) ");
        //    cmdText.Append(" FROM SMT_Model_File_Induce_List ");
        //    cmdText.Append(" WHERE Bill_Serial_Number=@Bill_Serial_Number ");

        //    IDbParametersBuilder paras = base.CreateDbParametersBuilder();
        //    paras.Create().Name("Bill_Serial_Number").Type(DbType.String).Size(50).Value(modelOrder);

        //    return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        //}

        //public SMTModelFileInduceInfo Get(string modelOrder)
        //{
        //    StringBuilder cmdText = new StringBuilder();
        //    cmdText.Append(" SELECT * ");
        //    cmdText.Append(" FROM SMT_Model_File_Induce_List ");
        //    cmdText.Append(" WHERE Bill_Serial_Number=@Bill_Serial_Number ");

        //    IDbParametersBuilder paras = base.CreateDbParametersBuilder();
        //    paras.Create().Name("Bill_Serial_Number").Type(DbType.String).Size(50).Value(modelOrder);

        //    return AdoTemplate.QueryForObjectDelegate<SMTModelFileInduceInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
        //    {
        //        SMTModelFileInduceInfo entity = new SMTModelFileInduceInfo();

        //        entity.FileInducePK = Convert.ToInt32(reader["File_Induce_PK"]);
        //        entity.BillSerialNumber = Convert.ToString(reader["Bill_Serial_Number"]);
        //        entity.ModuleDesc = Convert.ToString(reader["Module_Desc"]);
        //        entity.PCB = Convert.ToString(reader["pcb"]);

        //        entity.SerialNumber = Convert.ToString(reader["SerialNumber"]);
        //        entity.Version = Convert.ToString(reader["Version"]);

        //        entity.SpeBoard = Convert.ToString(reader["SpeBoard"]);
        //        entity.SpeBoardDN = Convert.ToString(reader["SpeBoardDN"]);
        //        entity.SpeBoardDVS = Convert.ToString(reader["SpeBoardDVS"]);

        //        entity.FabricationDN = Convert.ToString(reader["FabricationDN"]);
        //        entity.FabricationDVS = Convert.ToString(reader["FabricationDVS"]);

        //        entity.SteelMesh = Convert.ToString(reader["SteelMesh"]);
        //        entity.CoorPattern = Convert.ToString(reader["CoorPattern"]);

        //        entity.Comments = Convert.ToString(reader["comments"]);

        //        SYSModuleTypeInfo moduleTypeItem = new SYSModuleTypeInfo()
        //        {
        //            ModuleTypeId = Convert.ToString(reader["module_type_id"]),
        //            ModuleTypeDesc = Convert.ToString(reader["module_type_desc"])
        //        };
        //        entity.ModuleTypeItem = moduleTypeItem;
        //        return entity;
        //    }, paras.GetParameters());
        //}
    }
}

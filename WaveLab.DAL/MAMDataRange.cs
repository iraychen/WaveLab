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
    public class MAMDataRange : AdoDaoSupport, IMAMDataRange
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT DISTINCT COUNT(*) ");
            cmdText.Append(" FROM  ( SELECT DISTINCT MAM_TYPE ,DATA ,DESCRIPTION,UNIT FROM MAM_DATA_RANGE) A");
            cmdText.Append(" WHERE 1=1 ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "MAM_TYPE":
                        cmdText.Append(" AND UPPER(A.MAM_TYPE) = UPPER(@" + entry.Key + ")");
                        break;
                    case "DATA":
                        cmdText.Append(" AND UPPER(A.DATA) = UPPER(@" + entry.Key + ")");
                        break;
                    case "DESC":
                        cmdText.Append(" AND UPPER(A.DESCRIPTION) = UPPER(@" + entry.Key + ")");
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<MAMDataRangeInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");
            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" A.MAM_TYPE,(SELECT mam_type_desc from mam_type_list where mam_type=A.MAM_TYPE) MAM_TYPE_DESC ,A.DATA ,A.DESCRIPTION,A.UNIT ");
            cmdText.Append(" FROM (SELECT DISTINCT MAM_TYPE ,DATA ,DESCRIPTION,UNIT FROM MAM_DATA_RANGE) A");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "MAM_TYPE":
                        cmdText.Append(" AND UPPER(A.MAM_TYPE) = UPPER(@" + entry.Key + ")");
                        break;
                    case "DATA":
                        cmdText.Append(" AND UPPER(A.DATA) = UPPER(@" + entry.Key + ")");
                        break;
                    case "DESC":
                        cmdText.Append(" AND UPPER(A.DESCRIPTION) = UPPER(@" + entry.Key + ")");
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            int startRowNum = (page - 1) * pageSize + 1;
            int endRowNum = startRowNum + pageSize - 1;

            cmdText.Append(" ) t_pager where rowindex between " + startRowNum.ToString() + " and " + endRowNum.ToString());

            return AdoTemplate.QueryWithRowMapperDelegate<MAMDataRangeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                MAMDataRangeInfo item = new MAMDataRangeInfo();
                item.MAMType = Convert.ToString(reader["MAM_TYPE"]);
                item.MAMTypeDesc = Convert.ToString(reader["MAM_TYPE_Desc"]);
                item.Data = Convert.ToString(reader["DATA"]);
                item.Description= Convert.ToString(reader["DESCRIPTION"]);
                item.Unit = Convert.ToString(reader["UNIT"]);
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string MAMType,string data)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from mam_data_range where upper(mam_type)=upper(@mam_type) and upper(data)=upper(@data)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("mam_type").Type(DbType.String).Size(50).Value(MAMType);
            paras.Create().Name("data").Type(DbType.String).Size(50).Value(data);

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

        public bool CheckExists(string MAMType, string data,string frequency)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from mam_data_range where upper(mam_type)=upper(@mam_type) and upper(data)=upper(@data) and upper(frequency)=upper(@frequency)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("mam_type").Type(DbType.String).Size(50).Value(MAMType);
            paras.Create().Name("data").Type(DbType.String).Size(50).Value(data);
            paras.Create().Name("frequency").Type(DbType.String).Size(50).Value(frequency);

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

        public void Save(MAMDataRangeInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" INSERT INTO MAM_Data_Range");
            cmdText.Append("(");
            cmdText.Append(" MAM_Type");
            cmdText.Append(",Frequency");
            cmdText.Append(",Data");
            cmdText.Append(",Description");
            cmdText.Append(",Unit");
            cmdText.Append(",LowerBound");
            cmdText.Append(",UpperBound");
            cmdText.Append(",Target");
            cmdText.Append(",Last_Update_Date");
            cmdText.Append(",Last_Updated_By");
            cmdText.Append(")");
            cmdText.Append("VALUES");
            cmdText.Append("(");
            cmdText.Append(" @MAM_Type");
            cmdText.Append(",@Frequency");
            cmdText.Append(",@Data");
            cmdText.Append(",@Description");
            cmdText.Append(",@Unit");
            cmdText.Append(",@LowerBound");
            cmdText.Append(",@UpperBound");
            cmdText.Append(",@Target");
            cmdText.Append(",@Last_Update_Date");
            cmdText.Append(",@Last_Updated_By");
            cmdText.Append(")");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("MAM_Type").Type(DbType.String).Size(50).Value(entity.MAMType);
            paras.Create().Name("Frequency").Type(DbType.String).Size(50).Value(entity.Frequency);
            paras.Create().Name("Data").Type(DbType.String).Size(50).Value(entity.Data);
            paras.Create().Name("Description").Type(DbType.String).Size(50).Value(entity.Description);
            paras.Create().Name("Unit").Type(DbType.String).Size(50).Value(entity.Unit);
            paras.Create().Name("LowerBound").Type(DbType.String).Size(50).Value(entity.LowerBound);
            paras.Create().Name("UpperBound").Type(DbType.String).Size(50).Value(entity.UpperBound);
            paras.Create().Name("Target").Type(DbType.String).Size(50).Value(entity.Target);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<MAMDataRangeInfo> GetDetail(string MAMType, string data)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT MAM_Data_Range_ID");
            cmdText.Append(",MAM_Type");
            cmdText.Append(",Frequency");
            cmdText.Append(",Data");
            cmdText.Append(",Description");
            cmdText.Append(",Unit");
            cmdText.Append(",LowerBound");
            cmdText.Append(",UpperBound");
            cmdText.Append(",Target");
            cmdText.Append(",Last_Update_Date");
            cmdText.Append(",Last_Updated_By");
            cmdText.Append(" FROM MAM_Data_Range ");
            cmdText.Append(" WHERE upper(MAM_Type)=upper(@MAM_Type)");
            cmdText.Append(" AND upper(data)=upper(@data)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("MAM_Type").Type(DbType.String).Size(50).Value(MAMType);
            paras.Create().Name("data").Type(DbType.String).Size(50).Value(data);

            return AdoTemplate.QueryWithRowMapperDelegate<MAMDataRangeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                MAMDataRangeInfo item = new MAMDataRangeInfo();
                item.MAMDataRangeID = Convert.ToInt32(reader["MAM_Data_Range_ID"]);
                item.MAMType = Convert.ToString(reader["MAM_Type"]);
                item.Data = Convert.ToString(reader["Data"]);
                item.Description = Convert.ToString(reader["Description"]);
                item.Frequency = Convert.ToString(reader["Frequency"]);
                item.Unit = Convert.ToString(reader["Unit"]);
                item.LowerBound = Convert.ToString(reader["LowerBound"]);
                item.UpperBound = Convert.ToString(reader["UpperBound"]);
                item.Target = Convert.ToString(reader["Target"]);
                return item;
            }, paras.GetParameters());
        }

        public void Update(MAMDataRangeInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" UPDATE MAM_Data_Range");
            cmdText.Append(" SET ");
            cmdText.Append(" Description = @Description");
            cmdText.Append(",Unit = @Unit");
            cmdText.Append(",LowerBound = @LowerBound");
            cmdText.Append(",UpperBound = @UpperBound");
            cmdText.Append(",Target = @Target");
            cmdText.Append(",Last_Update_Date =@Last_Update_Date");
            cmdText.Append(",Last_Updated_By =@Last_Updated_By");
            cmdText.Append(" WHERE MAM_Type = @MAM_Type");
            cmdText.Append(" and Frequency = @Frequency");
            cmdText.Append(" and Data = @Data");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Description").Type(DbType.String).Size(50).Value(entity.Description);
            paras.Create().Name("Unit").Type(DbType.String).Size(50).Value(entity.Unit);
            paras.Create().Name("LowerBound").Type(DbType.String).Size(50).Value(entity.LowerBound);
            paras.Create().Name("UpperBound").Type(DbType.String).Size(50).Value(entity.UpperBound);
            paras.Create().Name("Target").Type(DbType.String).Size(50).Value(entity.Target);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("MAM_Type").Type(DbType.String).Size(50).Value(entity.MAMType);
            paras.Create().Name("Frequency").Type(DbType.String).Size(50).Value(entity.Frequency);
            paras.Create().Name("Data").Type(DbType.String).Size(50).Value(entity.Data);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(string MAMType, string data)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" DELETE FROM MAM_Data_Range where upper(mam_type)=upper(@mam_type) and upper(data)=upper(@data)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("mam_type").Type(DbType.String).Size(50).Value(MAMType);
            paras.Create().Name("data").Type(DbType.String).Size(50).Value(data);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(MAMDataRangeInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" DELETE FROM MAM_Data_Range where upper(mam_type)=upper(@mam_type) and upper(data)=upper(@data) and upper(frequency)=upper(@frequency)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("mam_type").Type(DbType.String).Size(50).Value(entity.MAMType);
            paras.Create().Name("data").Type(DbType.String).Size(50).Value(entity.Data);
            paras.Create().Name("frequency").Type(DbType.String).Size(50).Value(entity.Frequency);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }
    }
}

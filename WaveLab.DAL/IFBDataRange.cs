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
    public class IFBDataRange : AdoDaoSupport, IIFBDataRange
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT DISTINCT COUNT(*) ");
            cmdText.Append(" FROM  ( SELECT DISTINCT DATA ,DESCRIPTION,UNIT FROM IFB_DATA_RANGE) A");
            cmdText.Append(" WHERE 1=1 ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
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

        public IList<IFBDataRangeInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");
            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" A.DATA ,A.DESCRIPTION,A.UNIT ");
            cmdText.Append(" FROM (SELECT DISTINCT DATA ,DESCRIPTION,UNIT FROM IFB_DATA_RANGE) A");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {                  
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

            return AdoTemplate.QueryWithRowMapperDelegate<IFBDataRangeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                IFBDataRangeInfo item = new IFBDataRangeInfo();
                item.Data = Convert.ToString(reader["DATA"]);
                item.Description = Convert.ToString(reader["DESCRIPTION"]);
                item.Unit = Convert.ToString(reader["UNIT"]);
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string data)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from ifb_data_range where upper(data)=upper(@data)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
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

        public bool CheckExists( string data, string frequency)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from ifb_data_range where upper(data)=upper(@data) and upper(frequency)=upper(@frequency)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
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

        public void Save(IFBDataRangeInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" INSERT INTO IFB_Data_Range");
            cmdText.Append("(");
            cmdText.Append(" Frequency");
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
            cmdText.Append(" @Frequency");
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

        public IList<IFBDataRangeInfo> GetDetail(string data)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT IFB_Data_Range_ID");
            cmdText.Append(",Frequency");
            cmdText.Append(",Data");
            cmdText.Append(",Description");
            cmdText.Append(",Unit");
            cmdText.Append(",LowerBound");
            cmdText.Append(",UpperBound");
            cmdText.Append(",Target");
            cmdText.Append(",Last_Update_Date");
            cmdText.Append(",Last_Updated_By");
            cmdText.Append(" FROM IFB_Data_Range ");
            cmdText.Append(" WHERE upper(data)=upper(@data)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("data").Type(DbType.String).Size(50).Value(data);

            return AdoTemplate.QueryWithRowMapperDelegate<IFBDataRangeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                IFBDataRangeInfo item = new IFBDataRangeInfo();
                item.IFBDataRangeID = Convert.ToInt32(reader["IFB_Data_Range_ID"]);
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

        public void Update(IFBDataRangeInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" UPDATE IFB_Data_Range");
            cmdText.Append(" SET ");
            cmdText.Append(" Description = @Description");
            cmdText.Append(",Unit = @Unit");
            cmdText.Append(",LowerBound = @LowerBound");
            cmdText.Append(",UpperBound = @UpperBound");
            cmdText.Append(",Target = @Target");
            cmdText.Append(",Last_Update_Date =@Last_Update_Date");
            cmdText.Append(",Last_Updated_By =@Last_Updated_By");
            cmdText.Append(" WHERE Frequency = @Frequency");
            cmdText.Append(" and Data = @Data");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Description").Type(DbType.String).Size(50).Value(entity.Description);
            paras.Create().Name("Unit").Type(DbType.String).Size(50).Value(entity.Unit);
            paras.Create().Name("LowerBound").Type(DbType.String).Size(50).Value(entity.LowerBound);
            paras.Create().Name("UpperBound").Type(DbType.String).Size(50).Value(entity.UpperBound);
            paras.Create().Name("Target").Type(DbType.String).Size(50).Value(entity.Target);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("Frequency").Type(DbType.String).Size(50).Value(entity.Frequency);
            paras.Create().Name("Data").Type(DbType.String).Size(50).Value(entity.Data);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete( string data)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" DELETE FROM IFB_Data_Range where upper(data)=upper(@data)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("data").Type(DbType.String).Size(50).Value(data);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(IFBDataRangeInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" DELETE FROM IFB_Data_Range where upper(data)=upper(@data) and upper(frequency)=upper(@frequency)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("data").Type(DbType.String).Size(50).Value(entity.Data);
            paras.Create().Name("frequency").Type(DbType.String).Size(50).Value(entity.Frequency);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }
    }
}

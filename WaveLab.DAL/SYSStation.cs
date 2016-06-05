using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

using WaveLab.Model;
using WaveLab.IDAL;

using Spring.Data.Common;
using Spring.Data.Generic;

namespace WaveLab.DAL
{
    public class SYSStation : AdoDaoSupport, ISYSStation
    {
        #region Basic Operation
        public IList<SYSStationInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT  Station_No,Position ");
            cmdText.Append("FROM    SYS_Station_List " );
            cmdText.Append("WHERE   1=1 ");

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
            return AdoTemplate.QueryWithRowMapperDelegate<SYSStationInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSStationInfo item = new SYSStationInfo();
                item.StationNo = Convert.ToString(reader["Station_No"]);
                item.Position = Convert.ToString(reader["Position"]);
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string stationNo)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SYS_Station_List where upper(Station_No)=upper(@Station_No)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Station_No").Type(DbType.String).Size(50).Value(stationNo);         
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

        public void Save(SYSStationInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into SYS_Station_List(Station_No,Position,Last_Update_Date,Last_Updated_By) ");
            cmdText.Append("values(@Station_No,@Position,@Last_Update_Date,@Last_Updated_By) ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Station_No").Type(DbType.String).Size(50).Value(entity.StationNo);
            paras.Create().Name("Position").Type(DbType.String).Size(100).Value(entity.Position);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SYSStationInfo Get(string stationNo)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select Station_No,Position from SYS_Station_List where upper(Station_No)=upper(@Station_No)");

            return AdoTemplate.QueryForObjectDelegate<SYSStationInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSStationInfo entity = new SYSStationInfo();
                entity.StationNo = Convert.ToString(reader["Station_No"]);
                entity.Position = Convert.ToString(reader["Position"]);
             
                return entity;
            },
            "Station_No", DbType.String, 50, stationNo);
        }        

        public void Update(SYSStationInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("update SYS_Station_List set ");
            cmdText.Append("Position=@Position,Last_Update_Date=@Last_Update_Date,Last_Updated_By=@Last_Updated_By ");
            cmdText.Append("where upper(Station_No)=upper(@Station_No)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Position").Type(DbType.String).Size(100).Value(entity.Position);   
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("Station_No").Type(DbType.String).Size(50).Value(entity.StationNo);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(SYSStationInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from SYS_Station_List where Station_No=@Station_No");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Station_No").Type(DbType.String).Size(50).Value(entity.StationNo);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        #endregion
    }
}

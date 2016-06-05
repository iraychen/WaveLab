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
    public class SPCStationLineLossItem: AdoDaoSupport, ISPCStationLineLossItem
    {
        #region Basic Operation
        public IList<SPCStationLineLossItemInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  Line_Loss_Item_PK,Station_No,CH_No,Frequency_Band,Item ");
            cmdText.Append(" FROM    SPC_Station_Line_Loss_Item");
            cmdText.Append(" WHERE   1=1 ");

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
            return AdoTemplate.QueryWithRowMapperDelegate<SPCStationLineLossItemInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SPCStationLineLossItemInfo item = new SPCStationLineLossItemInfo();
                item.LineLossItemPK= Convert.ToInt32(reader["Line_Loss_Item_PK"]);
                item.StationNo = Convert.ToString(reader["Station_No"]);
                item.CHNo = Convert.ToString(reader["CH_No"]);
                item.FrequencyBand = Convert.ToString(reader["Frequency_Band"]);
                item.Item = Convert.ToString(reader["Item"]);
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string stationNo, string CHNo, string frequencyBand, string item)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SPC_Station_Line_Loss_Item ");
            cmdText.Append("where upper(Station_No)=upper(@Station_No) ");
            cmdText.Append("and upper(CH_No)=upper(@CH_No) ");
            cmdText.Append("and upper(Frequency_Band)=upper(@Frequency_Band) ");
            cmdText.Append("and upper(Item)=upper(@Item) ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Station_No").Type(DbType.String).Size(50).Value(stationNo);
            paras.Create().Name("CH_No").Type(DbType.String).Size(50).Value(CHNo);
            paras.Create().Name("Frequency_Band").Type(DbType.String).Size(50).Value(frequencyBand);
            paras.Create().Name("Item").Type(DbType.String).Size(50).Value(item);

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

        public void Save(SPCStationLineLossItemInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into SPC_Station_Line_Loss_Item(Station_No,CH_No,Frequency_Band,Item,Machine_Info,Modified_Log,Last_Update_Date,Last_Updated_By)");
            cmdText.Append("values(@Station_No,@CH_No,@Frequency_Band,@Item,@Machine_Info,@Modified_Log,@Last_Update_Date,@Last_Updated_By)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Station_No").Type(DbType.String).Size(50).Value(entity.StationNo);
            paras.Create().Name("CH_No").Type(DbType.String).Size(50).Value(entity.CHNo);
            paras.Create().Name("Frequency_Band").Type(DbType.String).Size(50).Value(entity.FrequencyBand);
            paras.Create().Name("Item").Type(DbType.String).Size(50).Value(entity.Item);
            paras.Create().Name("Machine_Info").Type(DbType.String).Value(entity.MachineInfo);
            paras.Create().Name("Modified_Log").Type(DbType.String).Value(entity.ModifiedLog);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SPCStationLineLossItemInfo Get(int LineLossItemPK)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select * from SPC_Station_Line_Loss_Item where Line_Loss_Item_PK=@Line_Loss_Item_PK");

            return AdoTemplate.QueryForObjectDelegate<SPCStationLineLossItemInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SPCStationLineLossItemInfo entity = new SPCStationLineLossItemInfo();
                entity.LineLossItemPK= Convert.ToInt32(reader["Line_Loss_Item_PK"]);
                entity.StationNo = Convert.ToString(reader["Station_No"]);
                entity.CHNo = Convert.ToString(reader["CH_No"]);
                entity.FrequencyBand = Convert.ToString(reader["Frequency_Band"]);
                entity.Item = Convert.ToString(reader["Item"]);
                entity.MachineInfo = Convert.ToString(reader["Machine_Info"]);
                entity.ModifiedLog = Convert.ToString(reader["Modified_Log"]);

                if (reader["LCL_X"] != DBNull.Value && reader["LCL_X"] != null)
                {
                    entity.LCL_X = Convert.ToDouble(reader["LCL_X"]);
                }
                else
                {
                    entity.LCL_X = null;
                }
                if (reader["UCL_X"] != DBNull.Value && reader["UCL_X"] != null)
                {
                    entity.UCL_X = Convert.ToDouble(reader["UCL_X"]);
                }
                else
                {
                    entity.UCL_X = null;
                }
                if (reader["LCL_MR"] != DBNull.Value && reader["LCL_MR"] != null)
                {
                    entity.LCL_MR = Convert.ToDouble(reader["LCL_MR"]);
                }
                else
                {
                    entity.LCL_MR = null;
                }
                if (reader["UCL_MR"] != DBNull.Value && reader["UCL_MR"] != null)
                {
                    entity.UCL_MR = Convert.ToDouble(reader["UCL_MR"]);
                }
                else
                {
                    entity.UCL_MR = null;
                }
                return entity;
            },
            "Line_Loss_Item_PK", DbType.Int32, 4, LineLossItemPK);
        }

        public bool CheckExists(string stationNo,string CHNo,string frequencyBand, string item,int LineLossItemPK)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SPC_Station_Line_Loss_Item where upper(Station_No)=upper(@Station_No) ");
            cmdText.Append("and upper(CH_No)=upper(@CH_No) ");
            cmdText.Append("and upper(Frequency_Band)=upper(@Frequency_Band) ");
            cmdText.Append("and upper(Item)=upper(@Item) and Line_Loss_Item_PK<>@Line_Loss_Item_PK ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Station_No").Type(DbType.String).Size(50).Value(stationNo);
            paras.Create().Name("CH_No").Type(DbType.String).Size(50).Value(CHNo);
            paras.Create().Name("Frequency_Band").Type(DbType.String).Size(50).Value(frequencyBand);
            paras.Create().Name("Item").Type(DbType.String).Size(50).Value(item);
            paras.Create().Name("Line_Loss_Item_PK").Type(DbType.Int32).Size(4).Value(LineLossItemPK);
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

        public void Update(SPCStationLineLossItemInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update SPC_Station_Line_Loss_Item set");
            cmdText.Append(" Station_No=@Station_No,CH_No=@CH_No,Frequency_Band=@Frequency_Band,Item=@Item,Machine_Info=@Machine_Info,Modified_Log=@Modified_Log,");
            cmdText.Append(" LCL_X=@LCL_X,UCL_X=@UCL_X,LCL_MR=@LCL_MR,UCL_MR=@UCL_MR,Last_Update_Date=@Last_Update_Date,Last_Updated_By=@Last_Updated_By");
            cmdText.Append(" where Line_Loss_Item_PK=@Line_Loss_Item_PK");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Station_No").Type(DbType.String).Size(50).Value(entity.StationNo);
            paras.Create().Name("CH_No").Type(DbType.String).Size(50).Value(entity.CHNo);
            paras.Create().Name("Frequency_Band").Type(DbType.String).Size(50).Value(entity.FrequencyBand);
            paras.Create().Name("Item").Type(DbType.String).Size(50).Value(entity.Item);
            paras.Create().Name("Machine_Info").Type(DbType.String).Value(entity.MachineInfo);
            paras.Create().Name("Modified_Log").Type(DbType.String).Value(entity.ModifiedLog);
            paras.Create().Name("LCL_X").Type(DbType.Double).Value(entity.LCL_X);
            paras.Create().Name("UCL_X").Type(DbType.Double).Value(entity.UCL_X);
            paras.Create().Name("LCL_MR").Type(DbType.Double).Value(entity.LCL_MR);
            paras.Create().Name("UCL_MR").Type(DbType.Double).Value(entity.UCL_MR);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("Line_Loss_Item_PK").Type(DbType.Int32).Size(4).Value(entity.LineLossItemPK);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(SPCStationLineLossItemInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from SPC_Station_Line_Loss_Item where Line_Loss_Item_PK=@Line_Loss_Item_PK");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Line_Loss_Item_PK").Type(DbType.Int32).Size(4).Value(entity.LineLossItemPK);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SPCStationLineLossItemLogInfo> GetLogs(int LineLossItemPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Line_Loss_Item_PK").Type(DbType.Int32).Value(LineLossItemPK);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT Log_Id,LCL_X,UCL_X,LCL_MR,UCL_MR,Last_Update_Date ");
            cmdText.Append("FROM SPC_Station_Line_Loss_Item_Log ");
            cmdText.Append("WHERE 1=1 ");
            cmdText.Append("AND Line_Loss_Item_PK=@Line_Loss_Item_PK ");
            cmdText.Append("ORDER BY Last_Update_Date Desc ");

            return AdoTemplate.QueryWithRowMapperDelegate<SPCStationLineLossItemLogInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCStationLineLossItemLogInfo item = new SPCStationLineLossItemLogInfo();
                item.LogId = Convert.ToInt32(reader["Log_Id"]);              
                if (reader["LCL_X"] != DBNull.Value && reader["LCL_X"] != null)
                {
                    item.LCL_X = Convert.ToDouble(reader["LCL_X"]);
                }
                else
                {
                    item.LCL_X = null;
                }
                if (reader["UCL_X"] != DBNull.Value && reader["UCL_X"] != null)
                {
                    item.UCL_X = Convert.ToDouble(reader["UCL_X"]);
                }
                else
                {
                    item.UCL_X = null;
                }
                if (reader["LCL_MR"] != DBNull.Value && reader["LCL_MR"] != null)
                {
                    item.LCL_MR = Convert.ToDouble(reader["LCL_MR"]);
                }
                else
                {
                    item.LCL_MR = null;
                }
                if (reader["UCL_MR"] != DBNull.Value && reader["UCL_MR"] != null)
                {
                    item.UCL_MR = Convert.ToDouble(reader["UCL_MR"]);
                }
                else
                {
                    item.UCL_MR = null;
                }
                item.LastUpdateDate = Convert.ToDateTime(reader["Last_Update_Date"]);
                //item.LastUpdatedBy = Convert.ToString(reader["Last_Updated_By"]);
                return item;
            }, paras.GetParameters());
        }
        #endregion
    }
}

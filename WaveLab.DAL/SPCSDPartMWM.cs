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
    public class SPCSDPartMWM : AdoDaoSupport, ISPCSDPartMWM
    {
        public IList<string> GetStationItems()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT distinct Station_No ");
            cmdText.Append("FROM MWM_Test_Result_List   ");
            cmdText.Append("WHERE Station_No is not null ");
            cmdText.Append("AND Station_No in(SELECT Station_No FROM Sys_Station_List) ");
            return AdoTemplate.QueryWithRowMapperDelegate<string>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                return reader["Station_No"].ToString();
            });
        }

        public IList<SPCSDPartMWMInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT distinct  a.Station_No,b.Tx_Index,a.Serial_No ");
            cmdText.Append("FROM  MWM_Test_Result_LIst a inner join MWM_Test_Result_Detail b on a.MWM_Test_Result_ID =b.MWM_Test_Result_ID ");
            cmdText.Append("WHERE  1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "Station_No":
                        cmdText.Append(" AND upper(" + entry.Key + ") =(@" + entry.Key + ")");
                        break;
                    //case "Index":
                    //    cmdText.Append(" AND b.Tx_Index=@" + entry.Key + "");
                    //    break;
                    case "Serial_No":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE '%'+@" + entry.Key + "+'%'");
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            cmdText.Append(" order by ");
            cmdText.Append(sortBy);
            cmdText.Append(" ");
            cmdText.Append(orderBy);

            return AdoTemplate.QueryWithRowMapperDelegate<SPCSDPartMWMInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCSDPartMWMInfo item = new SPCSDPartMWMInfo();
                item.StationNo = Convert.ToString(reader["Station_No"]);

                item.TxIndex = Convert.ToString(reader["Tx_Index"]);
                item.SerialNo = Convert.ToString(reader["Serial_No"]);
                return item;
            }, paras.GetParameters());
        }

        public int GetSDParts(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT DISTINCT COUNT(*) ");
            cmdText.Append("FROM SPC_SDPart_MWM ");
            cmdText.Append("WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "Station_No":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE UPPER('%'+@" + entry.Key + "+'%')");
                        break;
                    //case "Index":
                    //    cmdText.Append(" AND b.Tx_Index=@" + entry.Key + "");
                    //    break;
                    case "Serial_No":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE '%'+@" + entry.Key + "+'%'");
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SPCSDPartMWMInfo> GetSDParts(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT * FROM ( ");
            cmdText.Append("SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append("SDPart_PK,Station_No,Tx_Index,Serial_No,Enable ");
            cmdText.Append("FROM SPC_SDPart_MWM ");
            cmdText.Append("WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "Station_No":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE UPPER('%'+@" + entry.Key + "+'%')");
                        break;
                    //case "Index":
                    //    cmdText.Append(" AND b.Tx_Index=@" + entry.Key + "");
                    //    break;
                    case "Serial_No":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE '%'+@" + entry.Key + "+'%'");
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            int startRowNum = (page - 1) * pageSize + 1;
            int endRowNum = startRowNum + pageSize - 1;

            cmdText.Append(" ) t_pager where rowindex between " + startRowNum.ToString() + " and " + endRowNum.ToString());

            return AdoTemplate.QueryWithRowMapperDelegate<SPCSDPartMWMInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCSDPartMWMInfo item = new SPCSDPartMWMInfo();
                item.SDPartPK = Convert.ToInt32(reader["SDPart_PK"]);
                item.StationNo = Convert.ToString(reader["Station_No"]);

                item.TxIndex = Convert.ToString(reader["Tx_Index"]);
                item.SerialNo = Convert.ToString(reader["Serial_No"]);
               
                item.Enable = Convert.ToChar(reader["Enable"]);
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string StationNo,  string TxIndex, string SerialNo)
        {
            bool retVal;

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT COUNT(*) FROM SPC_SDPart_MWM ");
            cmdText.Append("WHERE Station_No=@Station_No ");
            cmdText.Append("AND  Tx_Index=@Tx_Index ");
            cmdText.Append("AND  Serial_No=@Serial_No "); 
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Station_No").Type(DbType.String).Size(50).Value(StationNo);
            paras.Create().Name("Tx_Index").Type(DbType.String).Size(50).Value(TxIndex);
            paras.Create().Name("Serial_No").Type(DbType.String).Size(50).Value(SerialNo);
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

        public void Save(SPCSDPartMWMInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("INSERT INTO SPC_SDPart_MWM ");
            cmdText.Append("(Station_No,Tx_Index,Serial_No,LSL_Tx_Gain,USL_Tx_Gain,LSL_RxIF_Gain,USL_RxIF_Gain,Enable,Last_Update_Date,Last_Updated_By) ");
            cmdText.Append("VALUES ");
            cmdText.Append("(@Station_No,@Tx_Index,@Serial_No,@LSL_Tx_Gain,@USL_Tx_Gain,@LSL_RxIF_Gain,@USL_RxIF_Gain,@Enable,@Last_Update_Date,@Last_Updated_By) ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            paras.Create().Name("Station_No").Type(DbType.String).Size(50).Value(entity.StationNo);
            paras.Create().Name("Tx_Index").Type(DbType.String).Size(50).Value(entity.TxIndex);
        
            paras.Create().Name("Serial_No").Type(DbType.String).Size(50).Value(entity.SerialNo);
            paras.Create().Name("LSL_Tx_Gain").Type(DbType.Double).Value(entity.LSL_TxGain);
            paras.Create().Name("USL_Tx_Gain").Type(DbType.Double).Value(entity.USL_TxGain);
            paras.Create().Name("LSL_RxIF_Gain").Type(DbType.Double).Value(entity.LSL_RxIFGain);
            paras.Create().Name("USL_RxIF_Gain").Type(DbType.Double).Value(entity.USL_RxIFGain);
            paras.Create().Name("Enable").Type(DbType.String).Value(entity.Enable);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SPCSDPartMWMInfo Get(int SDPartPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("SDPart_PK").Type(DbType.Int32).Value(SDPartPK);
         
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT SDPart_PK,Station_No,Tx_Index,Serial_No,LSL_Tx_Gain,USL_Tx_Gain,LSL_RxIF_Gain,USL_RxIF_Gain,Enable ");
            cmdText.Append("FROM SPC_SDPart_MWM ");
            cmdText.Append("WHERE 1=1 ");
            cmdText.Append("AND SDPart_PK=@SDPart_PK ");


            return AdoTemplate.QueryForObjectDelegate<SPCSDPartMWMInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCSDPartMWMInfo entity = new SPCSDPartMWMInfo();
                entity.SDPartPK = Convert.ToInt32(reader["SDPart_PK"]);
                entity.StationNo = Convert.ToString(reader["Station_No"]);

                entity.TxIndex = Convert.ToString(reader["Tx_Index"]);
                entity.SerialNo = Convert.ToString(reader["Serial_No"]);
                if (reader["LSL_Tx_Gain"] != DBNull.Value && reader["LSL_Tx_Gain"] != null)
                {
                    entity.LSL_TxGain = Convert.ToDouble(reader["LSL_Tx_Gain"]);
                }
                else
                {
                    entity.LSL_TxGain = null;
                }
                if (reader["USL_Tx_Gain"] != DBNull.Value && reader["USL_Tx_Gain"] != null)
                {
                    entity.USL_TxGain = Convert.ToDouble(reader["USL_Tx_Gain"]);
                }
                else
                {
                    entity.USL_TxGain = null;
                }

                if (reader["LSL_RxIF_Gain"] != DBNull.Value && reader["LSL_RxIF_Gain"] != null)
                {
                    entity.LSL_RxIFGain = Convert.ToDouble(reader["LSL_RxIF_Gain"]);
                }
                else
                {
                    entity.LSL_RxIFGain = null;
                }
                if (reader["USL_RxIF_Gain"] != DBNull.Value && reader["USL_RxIF_Gain"] != null)
                {
                    entity.USL_RxIFGain = Convert.ToDouble(reader["USL_RxIF_Gain"]);
                }
                else
                {
                    entity.USL_RxIFGain = null;
                }
                entity.Enable = Convert.ToChar(reader["Enable"]);
                return entity;
            }, paras.GetParameters());
        }

        public void Update(SPCSDPartMWMInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("UPDATE SPC_SDPart_MWM ");
            cmdText.Append("SET ");
            cmdText.Append("LSL_Tx_Gain=@LSL_Tx_Gain,USL_Tx_Gain=@USL_Tx_Gain,LSL_RxIF_Gain=@LSL_RxIF_Gain,USL_RxIF_Gain=@USL_RxIF_Gain,Enable=@Enable,Last_Update_Date=@Last_Update_Date,Last_Updated_By =@Last_Updated_By ");
            cmdText.Append("WHERE ");
            cmdText.Append("SDPart_PK=@SDPart_PK ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("LSL_Tx_Gain").Type(DbType.Double).Value(entity.LSL_TxGain);
            paras.Create().Name("USL_Tx_Gain").Type(DbType.Double).Value(entity.USL_TxGain);
            paras.Create().Name("LSL_RxIF_Gain").Type(DbType.Double).Value(entity.LSL_RxIFGain);
            paras.Create().Name("USL_RxIF_Gain").Type(DbType.Double).Value(entity.USL_RxIFGain);
            paras.Create().Name("Enable").Type(DbType.String).Value(entity.Enable);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            paras.Create().Name("SDPart_PK").Type(DbType.Int32).Value(entity.SDPartPK);
         
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(SPCSDPartMWMInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("DELETE  FROM SPC_SDPart_MWM  ");
            cmdText.Append("WHERE SDPart_PK=@SDPart_PK ");
          
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("SDPart_PK").Type(DbType.Int32).Value(entity.SDPartPK);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

    }
}

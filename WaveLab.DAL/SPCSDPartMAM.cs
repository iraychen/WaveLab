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
    public class SPCSDPartMAM : AdoDaoSupport, ISPCSDPartMAM
    {
        public IList<string> GetStationItems()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT distinct Station_No ");
            cmdText.Append("FROM MAM_Test_Result_List   ");
            cmdText.Append("WHERE Station_No is not null ");
            cmdText.Append("AND Station_No in(SELECT Station_No FROM Sys_Station_List) ");
            return AdoTemplate.QueryWithRowMapperDelegate<string>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                return reader["Station_No"].ToString();
            });
        }

        public IList<SPCSDPartMAMInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT distinct  a.Station_No,a.MB_Serial_No as Serial_No ");
            cmdText.Append("FROM  MAM_Test_Result_LIst a ");
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
                    case "MB_Serial_No":
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

            return AdoTemplate.QueryWithRowMapperDelegate<SPCSDPartMAMInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCSDPartMAMInfo item = new SPCSDPartMAMInfo();
                item.StationNo = Convert.ToString(reader["Station_No"]);

               
                item.SerialNo = Convert.ToString(reader["Serial_No"]);
                return item;
            }, paras.GetParameters());
        }

        public int GetSDParts(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT DISTINCT COUNT(*) ");
            cmdText.Append("FROM SPC_SDPart_MAM ");
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

        public IList<SPCSDPartMAMInfo> GetSDParts(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT * FROM ( ");
            cmdText.Append("SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append("SDPart_PK,Station_No,Serial_No,Enable ");
            cmdText.Append("FROM SPC_SDPart_MAM ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<SPCSDPartMAMInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCSDPartMAMInfo item = new SPCSDPartMAMInfo();
                item.SDPartPK = Convert.ToInt32(reader["SDPart_PK"]);
                item.StationNo = Convert.ToString(reader["Station_No"]);

                
                item.SerialNo = Convert.ToString(reader["Serial_No"]);
               
                item.Enable = Convert.ToChar(reader["Enable"]);
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string StationNo,  string SerialNo)
        {
            bool retVal;

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT COUNT(*) FROM SPC_SDPart_MAM ");
            cmdText.Append("WHERE Station_No=@Station_No ");
         
            cmdText.Append("AND  Serial_No=@Serial_No "); 
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Station_No").Type(DbType.String).Size(50).Value(StationNo);
 
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

        public void Save(SPCSDPartMAMInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("INSERT INTO SPC_SDPart_MAM ");
            cmdText.Append("(Station_No,Serial_No,LSL_Tx_LoPower,USL_Tx_LoPower,LSL_Rx_AGC,USL_Rx_AGC,Enable,Last_Update_Date,Last_Updated_By) ");
            cmdText.Append("VALUES ");
            cmdText.Append("(@Station_No,@Serial_No,@LSL_Tx_LoPower,@USL_Tx_LoPower,@LSL_Rx_AGC,@USL_Rx_AGC,@Enable,@Last_Update_Date,@Last_Updated_By) ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            paras.Create().Name("Station_No").Type(DbType.String).Size(50).Value(entity.StationNo);

        
            paras.Create().Name("Serial_No").Type(DbType.String).Size(50).Value(entity.SerialNo);
            paras.Create().Name("LSL_Tx_LoPower").Type(DbType.Double).Value(entity.LSL_TxLoPower);
            paras.Create().Name("USL_Tx_LoPower").Type(DbType.Double).Value(entity.USL_TxLoPower);
            paras.Create().Name("LSL_Rx_AGC").Type(DbType.Double).Value(entity.LSL_RxAGC);
            paras.Create().Name("USL_Rx_AGC").Type(DbType.Double).Value(entity.USL_RxAGC);
            paras.Create().Name("Enable").Type(DbType.String).Value(entity.Enable);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SPCSDPartMAMInfo Get(int SDPartPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("SDPart_PK").Type(DbType.Int32).Value(SDPartPK);
         
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT SDPart_PK,Station_No,Serial_No,LSL_Tx_LoPower,USL_Tx_LoPower,LSL_Rx_AGC,USL_Rx_AGC,Enable ");
            cmdText.Append("FROM SPC_SDPart_MAM ");
            cmdText.Append("WHERE 1=1 ");
            cmdText.Append("AND SDPart_PK=@SDPart_PK ");


            return AdoTemplate.QueryForObjectDelegate<SPCSDPartMAMInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCSDPartMAMInfo entity = new SPCSDPartMAMInfo();
                entity.SDPartPK = Convert.ToInt32(reader["SDPart_PK"]);
                entity.StationNo = Convert.ToString(reader["Station_No"]);

          
                entity.SerialNo = Convert.ToString(reader["Serial_No"]);
                if (reader["LSL_Tx_LoPower"] != DBNull.Value && reader["LSL_Tx_LoPower"] != null)
                {
                    entity.LSL_TxLoPower = Convert.ToDouble(reader["LSL_Tx_LoPower"]);
                }
                else
                {
                    entity.LSL_TxLoPower = null;
                }
                if (reader["USL_Tx_LoPower"] != DBNull.Value && reader["USL_Tx_LoPower"] != null)
                {
                    entity.USL_TxLoPower = Convert.ToDouble(reader["USL_Tx_LoPower"]);
                }
                else
                {
                    entity.USL_TxLoPower = null;
                }

                if (reader["LSL_Rx_AGC"] != DBNull.Value && reader["LSL_Rx_AGC"] != null)
                {
                    entity.LSL_RxAGC = Convert.ToDouble(reader["LSL_Rx_AGC"]);
                }
                else
                {
                    entity.LSL_RxAGC = null;
                }
                if (reader["USL_Rx_AGC"] != DBNull.Value && reader["USL_Rx_AGC"] != null)
                {
                    entity.USL_RxAGC = Convert.ToDouble(reader["USL_Rx_AGC"]);
                }
                else
                {
                    entity.USL_RxAGC = null;
                }
                entity.Enable = Convert.ToChar(reader["Enable"]);
                return entity;
            }, paras.GetParameters());
        }

        public void Update(SPCSDPartMAMInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("UPDATE SPC_SDPart_MAM ");
            cmdText.Append("SET ");
            cmdText.Append("LSL_Tx_LoPower=@LSL_Tx_LoPower,USL_Tx_LoPower=@USL_Tx_LoPower,LSL_Rx_AGC=@LSL_Rx_AGC,USL_Rx_AGC=@USL_Rx_AGC,Enable=@Enable,Last_Update_Date=@Last_Update_Date,Last_Updated_By =@Last_Updated_By ");
            cmdText.Append("WHERE ");
            cmdText.Append("SDPart_PK=@SDPart_PK ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("LSL_Tx_LoPower").Type(DbType.Double).Value(entity.LSL_TxLoPower);
            paras.Create().Name("USL_Tx_LoPower").Type(DbType.Double).Value(entity.USL_TxLoPower);
            paras.Create().Name("LSL_Rx_AGC").Type(DbType.Double).Value(entity.LSL_RxAGC);
            paras.Create().Name("USL_Rx_AGC").Type(DbType.Double).Value(entity.USL_RxAGC);
            paras.Create().Name("Enable").Type(DbType.String).Value(entity.Enable);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            paras.Create().Name("SDPart_PK").Type(DbType.Int32).Value(entity.SDPartPK);
         
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(SPCSDPartMAMInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("DELETE  FROM SPC_SDPart_MAM  ");
            cmdText.Append("WHERE SDPart_PK=@SDPart_PK ");
          
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("SDPart_PK").Type(DbType.Int32).Value(entity.SDPartPK);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

    }
}

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
    public class SPCSDPartTxPower : AdoDaoSupport, ISPCSDPartTxPower
    {
        public IList<string> GetStationItems()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT distinct Station_No ");
            cmdText.Append("FROM tx_Power_List  ");
            cmdText.Append("WHERE Station_No is not null ");
            cmdText.Append("AND Station_No in(SELECT Station_No FROM Sys_Station_List) ");
            return AdoTemplate.QueryWithRowMapperDelegate<string>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                return reader["Station_No"].ToString();
            });
        }

        public IList<string> GetCHNoItems()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT distinct CH_No ");
            cmdText.Append("FROM tx_Power_List  ");
            cmdText.Append("WHERE CH_No is not null OR LEN(CH_No)>0 Order By CH_No ");
            return AdoTemplate.QueryWithRowMapperDelegate<string>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                return reader["CH_No"].ToString();
            });
        }

        public IList<SPCSDPartTxPowerInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct a.Station_No,'" + hashTable["Divide"].ToString() + "' as Divide");
            if (hashTable["Divide"].ToString() == "Y")
            {
                cmdText.Append(" ,a.CH_No");
            }
            else
            {
                cmdText.Append(" ,null as CH_No");
            }
            cmdText.Append(" ,'128QAM' as Mode,b.CH,b.PW,a.Serial_No ");
            cmdText.Append(" FROM  Tx_power_list  a ");
            cmdText.Append(" inner join Tx_power_table b on a.Tx_Power_ID=b.Tx_Power_ID");
            cmdText.Append(" WHERE  1=1");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "Station_No":
                        cmdText.Append(" AND upper(" + entry.Key + ") =(@" + entry.Key + ")");
                        break;
                    case "CH_No":
                        cmdText.Append(" AND " + entry.Key + "=@" + entry.Key + "");
                        break;
                    case "Mode":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE '%'+@" + entry.Key + "+'%'");
                        break;
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

            return AdoTemplate.QueryWithRowMapperDelegate<SPCSDPartTxPowerInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCSDPartTxPowerInfo item = new SPCSDPartTxPowerInfo();
                item.StationNo = Convert.ToString(reader["Station_No"]);
                item.Divide = Convert.ToChar(reader["Divide"]);
                item.CHNo = Convert.ToString(reader["CH_No"]);
                item.Mode = Convert.ToString(reader["Mode"]);
                item.CH = Convert.ToString(reader["CH"]);
                item.PW = Convert.ToString(reader["PW"]);
                item.SerialNo = Convert.ToString(reader["Serial_No"]);
                return item;
            }, paras.GetParameters());
        }

        public int GetSDParts(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT DISTINCT COUNT(*) ");
            cmdText.Append("FROM SPC_SDPart_Tx_Power ");
            cmdText.Append("WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "Station_No":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE UPPER('%'+@" + entry.Key + "+'%')");
                        break;
                    case "Divide":
                        cmdText.Append(" AND " + entry.Key + " = @" + entry.Key + "");
                        break;
                    case "Mode":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE '%'+@" + entry.Key + "+'%'");
                        break;
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

        public IList<SPCSDPartTxPowerInfo> GetSDParts(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT * FROM ( ");
            cmdText.Append("SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append("SDPart_PK,Station_No,Divide,CH_No,Mode,CH,PW,Serial_No,LSL,USL,Enable ");
            cmdText.Append("FROM SPC_SDPart_Tx_Power ");
            cmdText.Append("WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "Station_No":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE UPPER('%'+@" + entry.Key + "+'%')");
                        break;
                    case "Divide":
                        cmdText.Append(" AND " + entry.Key + " = @" + entry.Key + "");
                        break;
                    case "Mode":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE '%'+@" + entry.Key + "+'%'");
                        break;
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

            return AdoTemplate.QueryWithRowMapperDelegate<SPCSDPartTxPowerInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCSDPartTxPowerInfo item = new SPCSDPartTxPowerInfo();
                item.SDPartPK = Convert.ToInt32(reader["SDPart_PK"]);
                item.StationNo = Convert.ToString(reader["Station_No"]);
                item.CHNo = Convert.ToString(reader["CH_No"]);
                item.Mode = Convert.ToString(reader["Mode"]);
                item.CH = Convert.ToString(reader["CH"]);
                item.PW = Convert.ToString(reader["PW"]);
                item.SerialNo = Convert.ToString(reader["Serial_No"]);
                if (reader["LSL"] != DBNull.Value && reader["LSL"] != null)
                {
                    item.LSL = Convert.ToDouble(reader["LSL"]);
                }
                else
                {
                    item.LSL = null;
                }
                if (reader["USL"] != DBNull.Value && reader["USL"] != null)
                {
                    item.USL = Convert.ToDouble(reader["USL"]);
                }
                else
                {
                    item.USL = null;
                }
                item.Enable = Convert.ToChar(reader["Enable"]);
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string StationNo, char Divide,string CHNo, string Mode, string CH, string PW, string SerialNo)
        {
            bool retVal;

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT COUNT(*) FROM SPC_SDPart_Tx_Power ");
            cmdText.Append("WHERE Station_No=@Station_No ");
            if (Divide == 'Y')
            {
                cmdText.Append("AND  CH_No=@CH_No ");
            }
            cmdText.Append("AND  Mode=@Mode ");
            cmdText.Append("AND  CH=@CH ");
            cmdText.Append("AND  PW=@PW ");
            cmdText.Append("AND  Serial_No=@Serial_No "); 
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Station_No").Type(DbType.String).Size(50).Value(StationNo);
            if (Divide == 'Y')
            {
                paras.Create().Name("CH_No").Type(DbType.String).Size(50).Value(CHNo);
            }
            paras.Create().Name("Mode").Type(DbType.String).Size(50).Value(Mode);
            paras.Create().Name("CH").Type(DbType.String).Size(50).Value(CH);
            paras.Create().Name("PW").Type(DbType.String).Size(50).Value(PW);
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

        public void Save(SPCSDPartTxPowerInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("INSERT INTO SPC_SDPart_Tx_Power ");
            cmdText.Append("(Station_No,Divide,CH_No,Mode,CH,PW,Serial_No,LSL,USL,Enable,Last_Update_Date,Last_Updated_By) ");
            cmdText.Append("VALUES ");
            cmdText.Append("(@Station_No,@Divide,@CH_No,@Mode,@CH,@PW,@Serial_No,@LSL,@USL,@Enable,@Last_Update_Date,@Last_Updated_By) ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            paras.Create().Name("Station_No").Type(DbType.String).Size(50).Value(entity.StationNo);
            paras.Create().Name("Divide").Type(DbType.String).Size(1).Value(entity.Divide);
            paras.Create().Name("CH_No").Type(DbType.String).Size(50).Value(entity.CHNo);
            paras.Create().Name("Mode").Type(DbType.String).Size(50).Value(entity.Mode);
            paras.Create().Name("CH").Type(DbType.String).Size(50).Value(entity.CH);
            paras.Create().Name("PW").Type(DbType.String).Size(50).Value(entity.PW);
            paras.Create().Name("Serial_No").Type(DbType.String).Size(50).Value(entity.SerialNo);
            paras.Create().Name("LSL").Type(DbType.Double).Value(entity.LSL);
            paras.Create().Name("USL").Type(DbType.Double).Value(entity.USL);
            paras.Create().Name("Enable").Type(DbType.String).Value(entity.Enable);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SPCSDPartTxPowerInfo Get(int SDPartPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("SDPart_PK").Type(DbType.Int32).Value(SDPartPK);
         
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT SDPart_PK,Station_No,Divide,CH_No,Mode,CH,PW,Serial_No,LSL,USL,Enable ");
            cmdText.Append("FROM SPC_SDPart_Tx_Power ");
            cmdText.Append("WHERE 1=1 ");
            cmdText.Append("AND SDPart_PK=@SDPart_PK ");


            return AdoTemplate.QueryForObjectDelegate<SPCSDPartTxPowerInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCSDPartTxPowerInfo entity = new SPCSDPartTxPowerInfo();
                entity.SDPartPK = Convert.ToInt32(reader["SDPart_PK"]);
                entity.StationNo = Convert.ToString(reader["Station_No"]);
                entity.Divide = Convert.ToChar(reader["Divide"]);
                entity.CHNo = Convert.ToString(reader["CH_No"]);
                entity.Mode = Convert.ToString(reader["Mode"]);
                entity.CH = Convert.ToString(reader["CH"]);
                entity.PW = Convert.ToString(reader["PW"]);
                entity.SerialNo = Convert.ToString(reader["Serial_No"]);
                if (reader["LSL"] != DBNull.Value && reader["LSL"] != null)
                {
                    entity.LSL = Convert.ToDouble(reader["LSL"]);
                }
                else
                {
                    entity.LSL = null;
                }
                if (reader["USL"] != DBNull.Value && reader["USL"] != null)
                {
                    entity.USL = Convert.ToDouble(reader["USL"]);
                }
                else
                {
                    entity.USL = null;
                }
                entity.Enable = Convert.ToChar(reader["Enable"]);
                return entity;
            }, paras.GetParameters());
        }

        public void Update(SPCSDPartTxPowerInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("UPDATE SPC_SDPart_Tx_Power ");
            cmdText.Append("SET ");
            cmdText.Append("LSL=@LSL,USL=@USL,Enable=@Enable,Last_Update_Date=@Last_Update_Date,Last_Updated_By =@Last_Updated_By ");
            cmdText.Append("WHERE ");
            cmdText.Append("SDPart_PK=@SDPart_PK ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("LSL").Type(DbType.Double).Value(entity.LSL);
            paras.Create().Name("USL").Type(DbType.Double).Value(entity.USL);
            paras.Create().Name("Enable").Type(DbType.String).Value(entity.Enable);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            paras.Create().Name("SDPart_PK").Type(DbType.Int32).Value(entity.SDPartPK);
         
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(SPCSDPartTxPowerInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("DELETE  FROM SPC_SDPart_Tx_Power  ");
            cmdText.Append("WHERE SDPart_PK=@SDPart_PK ");
          
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("SDPart_PK").Type(DbType.Int32).Value(entity.SDPartPK);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

    }
}

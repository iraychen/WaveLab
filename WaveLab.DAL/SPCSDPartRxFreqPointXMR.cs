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
    public class SPCSDPartRxFreqPointXMR : AdoDaoSupport, ISPCSDPartRxFreqPointXMR
    {
        public int QueryHistory(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT DISTINCT COUNT(*) ");
            cmdText.Append(" FROM SPC_SDPart_Rx_FreqPoint_XMR ");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "Station_No":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "Divide":
                        cmdText.Append(" AND " + entry.Key + "=@" + entry.Key + "");
                        break;
                    case "Type":
                        cmdText.Append(" AND " + entry.Key + "=@" + entry.Key + "");
                        break;
                    case "Serial_No":
                        cmdText.Append(" AND upper(a." + entry.Key + ") LIKE upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "Date_From":
                        cmdText.Append(" AND convert(varchar(10),a.Date_To,120) >= @" + entry.Key);
                        break;
                    case "Date_To":
                        cmdText.Append(" AND convert(varchar(10),a.Date_To,120)<= @" + entry.Key);
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SPCSDPartRxFreqPointXMRInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT * FROM ( ");
            cmdText.Append("SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) , ");
            cmdText.Append("a.XMR_PK,a.Station_No,a.Divide,a.CH_No,a.Type,a.CH,a.PW,a.Serial_No,a.Date_From,a.Date_To ");
            cmdText.Append("FROM SPC_SDPart_Rx_FreqPoint_XMR a ");
            cmdText.Append("WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "Station_No":
                        cmdText.Append(" AND upper(a." + entry.Key + ") LIKE upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "Divide":
                        cmdText.Append(" AND a." + entry.Key + "=@" + entry.Key + "");
                        break;
                    case "Type":
                        cmdText.Append(" AND " + entry.Key + "=@" + entry.Key + "");
                        break;
                    case "Serial_No":
                        cmdText.Append(" AND upper(a." + entry.Key + ") LIKE upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "Date_From":
                        cmdText.Append(" AND convert(varchar(10),a.Date_To,120) >= @" + entry.Key);
                        break;
                    case "Date_To":
                        cmdText.Append(" AND convert(varchar(10),a.Date_To,120)<= @" + entry.Key);
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            int startRowNum = (page - 1) * pageSize + 1;
            int endRowNum = startRowNum + pageSize - 1;

            cmdText.Append(" ) t_pager where rowindex between " + startRowNum.ToString() + " and " + endRowNum.ToString());

            return AdoTemplate.QueryWithRowMapperDelegate<SPCSDPartRxFreqPointXMRInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCSDPartRxFreqPointXMRInfo item = new SPCSDPartRxFreqPointXMRInfo();
                item.XMRPK = Convert.ToInt32(reader["XMR_PK"]);
                item.StationNo = Convert.ToString(reader["Station_No"]);
                item.Divide = Convert.ToChar(reader["Divide"]);
                item.CHNo = Convert.ToString(reader["CH_No"]);
                item.Type = Convert.ToString(reader["Type"]);
                item.CH = Convert.ToString(reader["CH"]);
                item.PW = Convert.ToString(reader["PW"]);
                item.SerialNo = Convert.ToString(reader["Serial_No"]);
                item.DateFrom = Convert.ToDateTime(reader["Date_From"]);
                item.DateTo = Convert.ToDateTime(reader["Date_To"]);
                return item;
            }, paras.GetParameters());
        }

        public SPCSDPartRxFreqPointXMRInfo Get(int XMRPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("XMR_PK").Type(DbType.Int32).Value(XMRPK);

            StringBuilder DetailCmdText = new StringBuilder();
            DetailCmdText.Append("SELECT  No_Of_Times,Testing_Date,Testing_Value,MR,Last_Update_Date,Last_Updated_By ");
            DetailCmdText.Append("FROM SPC_SDPart_Rx_FreqPoint_Detail ");
            DetailCmdText.Append("WHERE XMR_PK=@XMR_PK ");
            DetailCmdText.Append("ORDER BY No_Of_Times ASC ");

            IList<SPCSDPartRxFreqPointDetail> DetailItems = AdoTemplate.QueryWithRowMapperDelegate<SPCSDPartRxFreqPointDetail>(CommandType.Text, DetailCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCSDPartRxFreqPointDetail item = new SPCSDPartRxFreqPointDetail();
                item.NoOfTimes = Convert.ToInt32(reader["No_Of_Times"]);
                item.TestingDate = Convert.ToDateTime(reader["Testing_Date"]);
                item.TestingValue = Convert.ToDouble(reader["Testing_Value"]);
                if (reader["MR"] != null)
                {
                    item.MR = Convert.ToDouble(reader["MR"]);
                }
                else
                {
                    item.MR = null;
                }
                return item;
            }, paras.GetParameters());

            StringBuilder ExceptionCmdText = new StringBuilder();
            ExceptionCmdText.Append("SELECT No_Of_Times, Testing_Date,Chart_Type,Comment ");
            ExceptionCmdText.Append("FROM SPC_SDPart_Rx_FreqPoint_Exception ");
            ExceptionCmdText.Append("WHERE XMR_PK=@XMR_PK ");

            IList<SPCSDPartRxFreqPointException> ExceptionItems = AdoTemplate.QueryWithRowMapperDelegate<SPCSDPartRxFreqPointException>(CommandType.Text, ExceptionCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCSDPartRxFreqPointException item = new SPCSDPartRxFreqPointException();
                item.NoOfTimes = Convert.ToInt32(reader["No_Of_Times"]);
                item.TestingDate = Convert.ToDateTime(reader["Testing_Date"]);
                item.ChartType = Convert.ToChar(reader["Chart_Type"]);
                item.Comment = Convert.ToString(reader["Comment"]);
                return item;
            }, paras.GetParameters());

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT XMR_PK,Station_No,Divide,CH_No,Type,CH,PW,Serial_No,Date_From,Date_To,X,R,CL_X,UCL_X,LCL_X,CL_R,UCL_R,LCL_R ");
            cmdText.Append("FROM SPC_SDPart_Rx_FreqPoint_XMR ");
            cmdText.Append("WHERE XMR_PK=@XMR_PK ");

            return AdoTemplate.QueryForObjectDelegate<SPCSDPartRxFreqPointXMRInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCSDPartRxFreqPointXMRInfo entity = new SPCSDPartRxFreqPointXMRInfo();
                entity.XMRPK = Convert.ToInt32(reader["XMR_PK"]);
                entity.StationNo = Convert.ToString(reader["Station_No"]);
                entity.Divide = Convert.ToChar(reader["Divide"]);
                entity.CHNo = Convert.ToString(reader["CH_No"]);
                entity.Type = Convert.ToString(reader["Type"]);
                entity.CH = Convert.ToString(reader["CH"]);
                entity.PW = Convert.ToString(reader["PW"]);
                entity.SerialNo = Convert.ToString(reader["Serial_No"]);
                entity.DateFrom = Convert.ToDateTime(reader["Date_From"]);
                entity.DateTo = Convert.ToDateTime(reader["Date_To"]);
                entity.X = Convert.ToDouble(reader["X"]);
                entity.R = Convert.ToDouble(reader["R"]);
                
                entity.LCL_X = Convert.ToDouble(reader["LCL_X"]);
                entity.CL_X = Convert.ToDouble(reader["CL_X"]);
                entity.UCL_X = Convert.ToDouble(reader["UCL_X"]);
                entity.LCL_R = Convert.ToDouble(reader["LCL_R"]);
                entity.CL_R = Convert.ToDouble(reader["CL_R"]);
                entity.UCL_R = Convert.ToDouble(reader["UCL_R"]);
               
                entity.DetailItems = DetailItems;
                entity.ExceptionItems = ExceptionItems;
                return entity;
            }, paras.GetParameters());
        }

        public void SaveException(int XMRPK, IList<SPCSDPartRxFreqPointException> ExceptionItems)
        {
            StringBuilder cmdText = new StringBuilder();
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            //cmdText.Append(" DELETE FROM SPC_Fixture_Return_Loss_Exception WHERE Return_Loss_PK=@Return_Loss_PK;");

            paras.Create().Name("XMR_PK").Type(DbType.Int32).Value(XMRPK);

            for (int i = 0; i < ExceptionItems.Count; i++)
            {
                cmdText.Append(" INSERT INTO SPC_SDPart_Rx_FreqPoint_Exception");
                cmdText.Append(" (XMR_PK,No_Of_Times,Testing_Date,Chart_Type,Comment,Last_Update_Date,Last_Updated_By)");
                cmdText.Append(" VALUES");
                cmdText.Append(" (@XMR_PK,@No_Of_Times_" + i.ToString() + ",@Testing_Date_" + i.ToString() + ",@Chart_Type_" + i.ToString() + ",@Comment_" + i.ToString() + "," +
                    "@Last_Update_Date_" + i.ToString() + ",@Last_Updated_By_" + i.ToString() + ")");
                paras.Create().Name("No_Of_Times_" + i.ToString()).Type(DbType.Int32).Value(ExceptionItems[i].NoOfTimes);
                paras.Create().Name("Testing_Date_" + i.ToString()).Type(DbType.DateTime).Value(ExceptionItems[i].TestingDate);
                paras.Create().Name("Chart_Type_" + i.ToString()).Type(DbType.StringFixedLength).Size(1).Value(ExceptionItems[i].ChartType);
                paras.Create().Name("Comment_" + i.ToString()).Type(DbType.String).Size(100).Value(ExceptionItems[i].Comment);
                paras.Create().Name("Last_Update_Date_" + i.ToString()).Type(DbType.DateTime).Value(ExceptionItems[i].LastUpdateDate);
                paras.Create().Name("Last_Updated_By_" + i.ToString()).Type(DbType.String).Value(ExceptionItems[i].LastUpdatedBy);
            }
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        } 
    }
}

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
    public class SPCStationLineLoss : AdoDaoSupport,ISPCStationLineLoss
    {
        public IList<SPCStationLineLossInput> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT Line_Loss_Item_PK,No_Of_Times,Testing_Date,Testing_Value ");
            cmdText.Append("FROM SPC_Station_Line_Loss_Input ");
            cmdText.Append("WHERE 1=1 ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "Line_Loss_Item_PK":
                        cmdText.Append(" AND " + entry.Key + " = @" + entry.Key + "");
                        break;                  
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.Int32).Size(4).Value(entry.Value);
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

            return AdoTemplate.QueryWithRowMapperDelegate<SPCStationLineLossInput>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCStationLineLossInput item = new SPCStationLineLossInput();
                item.LineLossItemPK= Convert.ToInt32(reader["Line_Loss_Item_PK"]);
                item.NoOfTimes = Convert.ToInt32(reader["No_Of_Times"]);
                item.TestingDate = Convert.ToDateTime(reader["Testing_Date"]);
                item.TestingValue = Convert.ToDouble(reader["Testing_Value"]);               
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(int LineLossItemPK,string TestingDate)
        {
            bool retVal;

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT COUNT(*) FROM SPC_Station_Line_Loss_Input WHERE Line_Loss_Item_PK=@Line_Loss_Item_PK AND CONVERT(VARCHAR(10),Testing_Date,120)=@Testing_Date");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Line_Loss_Item_PK").Type(DbType.Int32).Value(LineLossItemPK);
            paras.Create().Name("Testing_Date").Type(DbType.String).Size(50).Value(TestingDate);
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

        public void SaveInput(SPCStationLineLossInput entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("INSERT INTO SPC_Station_Line_Loss_Input ");
            cmdText.Append("( ");
            cmdText.Append("Line_Loss_Item_PK,No_Of_Times,Testing_Date,Testing_Value,Last_Update_Date,Last_Updated_By ");
            cmdText.Append(") ");
            cmdText.Append("SELECT ");
            cmdText.Append("@Line_Loss_Item_PK,ISNULL(MAX(No_Of_Times),0)+1 No_Of_Times,@Testing_Date,@Testing_Value,@Last_Update_Date,@Last_Updated_By ");
            cmdText.Append("FROM SPC_Station_Line_Loss_Input WHERE Line_Loss_Item_PK=@Line_Loss_Item_PK ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Line_Loss_Item_PK").Type(DbType.Int32).Value(entity.LineLossItemPK);
            paras.Create().Name("Testing_Date").Type(DbType.DateTime).Value(entity.TestingDate);
            paras.Create().Name("Testing_Value").Type(DbType.Double).Value(entity.TestingValue);          
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SPCStationLineLossInput Get(int LineLossItemPK, int NoOfTimes)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Line_Loss_Item_PK").Type(DbType.Int32).Value(LineLossItemPK);
            paras.Create().Name("No_Of_Times").Type(DbType.Int32).Value(NoOfTimes);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT Line_Loss_Item_PK,No_Of_Times,Testing_Date,Testing_Value ");
            cmdText.Append("FROM SPC_Station_Line_Loss_Input  ");
            cmdText.Append("WHERE Line_Loss_Item_PK=@Line_Loss_Item_PK ");
            cmdText.Append("AND No_Of_Times=@No_Of_Times ");

            return AdoTemplate.QueryForObjectDelegate<SPCStationLineLossInput>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCStationLineLossInput entity = new SPCStationLineLossInput();           
                entity.LineLossItemPK= Convert.ToInt32(reader["Line_Loss_Item_PK"]);
                entity.NoOfTimes = Convert.ToInt32(reader["No_Of_Times"]);
                entity.TestingDate = Convert.ToDateTime(reader["Testing_Date"]);               
                entity.TestingValue = Convert.ToDouble(reader["Testing_Value"]);               
                return entity;
            }, paras.GetParameters());
        }

        public void UpdateInput(SPCStationLineLossInput entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("UPDATE SPC_Station_Line_Loss_Input ");
            cmdText.Append("SET ");
            cmdText.Append("Testing_Date=@Testing_Date,Testing_Value=@Testing_Value,Last_Update_Date=@Last_Update_Date,Last_Updated_By =@Last_Updated_By ");
            cmdText.Append("WHERE ");
            cmdText.Append("Line_Loss_Item_PK=@Line_Loss_Item_PK AND No_Of_Times=@No_Of_Times");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Testing_Date").Type(DbType.DateTime).Value(entity.TestingDate);
            paras.Create().Name("Testing_Value").Type(DbType.Double).Value(entity.TestingValue);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("Line_Loss_Item_PK").Type(DbType.Int32).Value(entity.LineLossItemPK);
            paras.Create().Name("No_Of_Times").Type(DbType.Int32).Value(entity.NoOfTimes);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public int GetMaxNoOfTimes(int LineLossItemPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Line_Loss_Item_PK").Type(DbType.Int32).Value(LineLossItemPK);
         
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT  ISNULL(Max(No_Of_Times),0) ");
            cmdText.Append("FROM SPC_Station_Line_Loss_Input  ");
            cmdText.Append("WHERE Line_Loss_Item_PK=@Line_Loss_Item_PK ");
           
            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void SaveSPC(SPCStationLineLossInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            cmdText.Append(" declare @Line_Loss_PK int;");

            cmdText.Append(" INSERT INTO SPC_Station_Line_Loss(");
            cmdText.Append(" Line_Loss_Item_PK,Date_From,Date_To,");
            cmdText.Append(" X,R,CL_X,UCL_X,LCL_X,CL_R,UCL_R,LCL_R,Last_Update_Date,Last_Updated_By)");
            cmdText.Append(" VALUES");
            cmdText.Append(" (@Line_Loss_Item_PK,@Date_From,@Date_To,");
            cmdText.Append(" @X,@R,@CL_X,@UCL_X,@LCL_X,@CL_R,@UCL_R,@LCL_R,@Last_Update_Date,@Last_Updated_By);");

            paras.Create().Name("Line_Loss_Item_PK").Type(DbType.Int32).Size(4).Value(entity.LineLossItemPK);          
            paras.Create().Name("Date_From").Type(DbType.DateTime).Size(4).Value(entity.DateFrom);
            paras.Create().Name("Date_To").Type(DbType.DateTime).Size(4).Value(entity.DateTo);         
            paras.Create().Name("X").Type(DbType.Double).Size(8).Value(entity.X);
            paras.Create().Name("R").Type(DbType.Double).Size(8).Value(entity.R);
            paras.Create().Name("CL_X").Type(DbType.Double).Size(8).Value(entity.CL_X);
            paras.Create().Name("UCL_X").Type(DbType.Double).Size(8).Value(entity.UCL_X);
            paras.Create().Name("LCL_X").Type(DbType.Double).Size(8).Value(entity.LCL_X);
            paras.Create().Name("CL_R").Type(DbType.Double).Size(8).Value(entity.CL_R);
            paras.Create().Name("UCL_R").Type(DbType.Double).Size(8).Value(entity.UCL_R);
            paras.Create().Name("LCL_R").Type(DbType.Double).Size(8).Value(entity.LCL_R);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            cmdText.Append(" SELECT @Line_Loss_PK=SCOPE_IDENTITY();");

            for (int i = 0; i < entity.DetailItems.Count; i++)
            {
                cmdText.Append(" INSERT INTO SPC_Station_Line_Loss_Detail");
                cmdText.Append(" (Line_Loss_PK,No_Of_Times,Testing_Date ,Testing_Value,MR,Last_Update_Date,Last_Updated_By)");
                cmdText.Append(" VALUES(@Line_Loss_PK,@No_Of_Times_" + i.ToString() + ",@Testing_Date_" + i.ToString() + " ,@Testing_Value_" + i.ToString());
                
                if(entity.DetailItems[i].MR==null)
                {
                    cmdText.Append(",null");
                }
                else
                {
                    cmdText.Append(",@MR_" + i.ToString() );
                }
                cmdText.Append(",@Last_Update_Date,@Last_Updated_By)");
                paras.Create().Name("No_Of_Times_" + i.ToString()).Type(DbType.Int32).Value(entity.DetailItems[i].NoOfTimes);
                paras.Create().Name("Testing_Date_" + i.ToString()).Type(DbType.DateTime).Value(entity.DetailItems[i].TestingDate);
                paras.Create().Name("Testing_Value_" + i.ToString()).Type(DbType.Double).Value(entity.DetailItems[i].TestingValue);
                if (entity.DetailItems[i].MR != null)
                {                  
                    paras.Create().Name("MR_" + i.ToString()).Type(DbType.Double).Value(entity.DetailItems[i].MR);
                }
            }
        
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());

           
        }

        public void DeleteInput(int LineLossItemPK,int MaxTimes)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("DELETE t FROM SPC_Station_Line_Loss_Input t ");
            cmdText.Append("WHERE t.Line_Loss_Item_PK=@Line_Loss_Item_PK ");
            cmdText.Append("AND EXISTS( ");
            cmdText.Append("SELECT 'x' From  SPC_Station_Line_Loss_Input WHERE Line_Loss_Item_PK=t.Line_Loss_Item_PK AND No_Of_Times=" + MaxTimes.ToString());
            cmdText.Append(") ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Line_Loss_Item_PK").Type(DbType.Int32).Value(LineLossItemPK);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void DeleteSPC(int LineLossItemPK)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("DELETE t FROM SPC_Station_Line_Loss t ");
            cmdText.Append("WHERE t.Line_Loss_Item_PK=@Line_Loss_Item_PK ");
            cmdText.Append("AND t.Line_Loss_PK=( ");
            cmdText.Append("SELECT MAX(Line_Loss_PK) From  SPC_Station_Line_Loss WHERE Line_Loss_Item_PK=t.Line_Loss_Item_PK");
            cmdText.Append(") ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Line_Loss_Item_PK").Type(DbType.Int32).Value(LineLossItemPK);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void SaveException(int LineLossPK, IList<SPCStationLineLossException> ExceptionItems)
        {
            StringBuilder cmdText = new StringBuilder();
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            cmdText.Append(" DELETE FROM SPC_Station_Line_Loss_Exception WHERE Line_Loss_PK=@Line_Loss_PK;");

            paras.Create().Name("Line_Loss_PK").Type(DbType.Int32).Value(LineLossPK);

            for (int i = 0; i < ExceptionItems.Count; i++)
            {
                cmdText.Append(" INSERT INTO SPC_Station_Line_Loss_Exception");
                cmdText.Append(" (Line_Loss_PK,No_Of_Times,Testing_Date,Chart_Type,Comment,Last_Update_Date,Last_Updated_By)");
                cmdText.Append(" VALUES");
                cmdText.Append(" (@Line_Loss_PK,@No_Of_Times_" + i.ToString() + ",@Testing_Date_" + i.ToString() + ",@Chart_Type_" + i.ToString() + ",@Comment_" + i.ToString() + "," +
                    "@Last_Update_Date_" + i.ToString()+",@Last_Updated_By_" + i.ToString()+")");
                paras.Create().Name("No_Of_Times_" + i.ToString()).Type(DbType.Int32).Value(ExceptionItems[i].NoOfTimes);
                paras.Create().Name("Testing_Date_" + i.ToString()).Type(DbType.DateTime).Value(ExceptionItems[i].TestingDate);               
                paras.Create().Name("Chart_Type_" + i.ToString()).Type(DbType.StringFixedLength).Size(1).Value(ExceptionItems[i].ChartType);
                paras.Create().Name("Comment_" + i.ToString()).Type(DbType.String).Size(100).Value(ExceptionItems[i].Comment);
                paras.Create().Name("Last_Update_Date_" + i.ToString()).Type(DbType.DateTime).Value(ExceptionItems[i].LastUpdateDate);
                paras.Create().Name("Last_Updated_By_" + i.ToString()).Type(DbType.String).Value(ExceptionItems[i].LastUpdatedBy);
            }         
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SPCStationLineLossInfo Get(int LineLossPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Line_Loss_PK").Type(DbType.Int32).Value(LineLossPK);

            StringBuilder DetailCmdText = new StringBuilder();
            DetailCmdText.Append("SELECT  No_Of_Times,Testing_Date,Testing_Value,MR,Last_Update_Date,Last_Updated_By ");
            DetailCmdText.Append("FROM SPC_Station_Line_Loss_Detail ");
            DetailCmdText.Append("WHERE Line_Loss_PK=@Line_Loss_PK ");
            DetailCmdText.Append("ORDER BY No_Of_Times ASC ");

            IList<SPCStationLineLossDetail> DetailItems = AdoTemplate.QueryWithRowMapperDelegate<SPCStationLineLossDetail>(CommandType.Text, DetailCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCStationLineLossDetail item = new SPCStationLineLossDetail();
                item.NoOfTimes= Convert.ToInt32(reader["No_Of_Times"]);
                item.TestingDate = Convert.ToDateTime(reader["Testing_Date"]);
                item.TestingValue = Convert.ToDouble(reader["Testing_Value"]);
                if (reader["MR"] == null)
                {
                    item.MR = null;
                }
                else
                {
                    item.MR = Convert.ToDouble(reader["MR"]);
                }
                return item;
            }, paras.GetParameters());

            StringBuilder ExceptionCmdText = new StringBuilder();
            ExceptionCmdText.Append("SELECT No_Of_Times,Testing_Date, Chart_Type,Comment ");
            ExceptionCmdText.Append("FROM SPC_Station_Line_Loss_Exception ");
            ExceptionCmdText.Append("WHERE Line_Loss_PK=@Line_Loss_PK ");

            IList<SPCStationLineLossException> ExceptionItems = AdoTemplate.QueryWithRowMapperDelegate<SPCStationLineLossException>(CommandType.Text, ExceptionCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCStationLineLossException item = new SPCStationLineLossException();
                item.NoOfTimes= Convert.ToInt32(reader["No_Of_Times"]);
                item.TestingDate = Convert.ToDateTime(reader["Testing_Date"]);
                item.ChartType = Convert.ToChar(reader["Chart_Type"]);
                item.Comment = Convert.ToString(reader["Comment"]);
                return item;
            }, paras.GetParameters());

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT a.Line_Loss_PK,a.Line_Loss_Item_PK,b.Station_No,b.CH_No,b.Frequency_Band,b.Item,a.Date_From,a.Date_To,a.X,a.R,a.CL_X,a.UCL_X,a.LCL_X,a.CL_R,a.UCL_R,a.LCL_R ");
            cmdText.Append("FROM SPC_Station_Line_Loss a INNER JOIN SPC_Station_Line_Loss_Item b ON a.Line_Loss_Item_PK=b.Line_Loss_Item_PK ");
            cmdText.Append("WHERE Line_Loss_PK=@Line_Loss_PK ");

            return AdoTemplate.QueryForObjectDelegate<SPCStationLineLossInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCStationLineLossInfo entity = new SPCStationLineLossInfo();
                entity.LineLossPK = Convert.ToInt32(reader["Line_Loss_PK"]);
                entity.LineLossItemPK= Convert.ToInt32(reader["Line_Loss_Item_PK"]);
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
                //entity.LastUpdateDate = Convert.ToDateTime(reader["Last_Update_Date"]);
                //entity.LastUpdatedBy = Convert.ToString(reader["Last_Updated_By"]);

                entity.LineLossItem = new SPCStationLineLossItemInfo() {
                    LineLossItemPK= Convert.ToInt32(reader["Line_Loss_Item_PK"]),
                    CHNo = Convert.ToString(reader["CH_No"]),
                    StationNo = Convert.ToString(reader["Station_No"]),
                    FrequencyBand = Convert.ToString(reader["Frequency_Band"]),
                    Item = Convert.ToString(reader["Item"])
                  };
                entity.DetailItems = DetailItems;
                entity.ExceptionItems = ExceptionItems;
                return entity;
            }, paras.GetParameters());
        }

        public SPCStationLineLossInfo GetLastestLineLoss(int LineLossItemPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Line_Loss_Item_PK").Type(DbType.Int32).Value(LineLossItemPK);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select ISNULL(MAX( b.Line_Loss_PK ),0)  Line_Loss_PK  ");
            cmdText.Append("FROM SPC_Station_Line_Loss b    ");
            cmdText.Append("WHERE b.Line_Loss_Item_PK=@Line_Loss_Item_PK     ");
            cmdText.Append("AND Line_Loss_PK=( ");
            cmdText.Append("select MAX(Line_Loss_PK)  ");
            cmdText.Append("from SPC_Station_Line_Loss	  ");
            cmdText.Append("Where Line_Loss_Item_PK=b.Line_Loss_Item_PK ");
            cmdText.Append(")   ");
            return AdoTemplate.QueryForObjectDelegate<SPCStationLineLossInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCStationLineLossInfo entity = new SPCStationLineLossInfo();
                entity.LineLossPK = Convert.ToInt32(reader["Line_Loss_PK"]);              
                return entity;
            }, paras.GetParameters());
        }

        public int QueryHistory(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT DISTINCT COUNT(*) ");
            cmdText.Append(" FROM SPC_Station_Line_Loss a,SPC_Station_Line_Loss_Item b");
            cmdText.Append(" WHERE a.Line_Loss_Item_PK=b.Line_Loss_Item_PK");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "Station_No":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE upper('%'+@" + entry.Key + "+'%')");
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

        public IList<SPCStationLineLossInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");
            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" a.Line_Loss_PK,a.Line_Loss_Item_PK,b.Station_No,b.CH_No,b.Frequency_Band,b.Item,a.Date_From,a.Date_To");
            cmdText.Append(" FROM SPC_Station_Line_Loss a,SPC_Station_Line_Loss_Item b");
            cmdText.Append(" WHERE a.Line_Loss_Item_PK=b.Line_Loss_Item_PK");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "Station_No":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE UPPER('%'+@" + entry.Key + "+'%')");
                        break;
                    case "CH_No":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE UPPER('%'+@" + entry.Key + "+'%')");
                        break;
                    case "Frequency_Band":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE UPPER('%'+@" + entry.Key + "+'%')");
                        break;
                    case "Item":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE UPPER('%'+@" + entry.Key + "+'%')");
                        break;
                    case "Date_From":
                        cmdText.Append(" AND convert(varchar(10),Date_To,120) >= @" + entry.Key);
                        break;
                    case "Date_To":
                        cmdText.Append(" AND convert(varchar(10),Date_To,120)<= @" + entry.Key);
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            int startRowNum = (page - 1) * pageSize + 1;
            int endRowNum = startRowNum + pageSize - 1;

            cmdText.Append(" ) t_pager where rowindex between " + startRowNum.ToString() + " and " + endRowNum.ToString());

            return AdoTemplate.QueryWithRowMapperDelegate<SPCStationLineLossInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCStationLineLossInfo item = new SPCStationLineLossInfo();
                item.LineLossPK = Convert.ToInt32(reader["Line_Loss_PK"]);
                item.LineLossItemPK= Convert.ToInt32(reader["Line_Loss_Item_PK"]);
                item.LineLossItem = new SPCStationLineLossItemInfo() {
                    LineLossItemPK= Convert.ToInt32(reader["Line_Loss_Item_PK"]),
                    CHNo=Convert.ToString(reader["CH_No"]),
                    StationNo=Convert.ToString(reader["Station_No"]),
                    FrequencyBand = Convert.ToString(reader["Frequency_Band"]),
                    Item = Convert.ToString(reader["Item"])
                };
                item.DateFrom = Convert.ToDateTime(reader["Date_From"]);
                item.DateTo = Convert.ToDateTime(reader["Date_To"]);
                
                return item;
            }, paras.GetParameters());
        }


    }
}

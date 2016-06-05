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
    public class SPCFixtureInsertionLoss : AdoDaoSupport, ISPCFixtureInsertionLoss
    {
        public void SaveSPC(SPCFixtureInsertionLossInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            cmdText.Append(" declare @Insertion_Loss_PK int;");

            cmdText.Append(" INSERT INTO SPC_Fixture_Insertion_Loss(");
            cmdText.Append(" Fixture_Item_PK,Date_From,Date_To,");
            cmdText.Append(" X,R,CL_X,UCL_X,LCL_X,CL_R,UCL_R,LCL_R,Last_Update_Date,Last_Updated_By)");
            cmdText.Append(" VALUES");
            cmdText.Append(" (@Fixture_Item_PK,@Date_From,@Date_To,");
            cmdText.Append(" @X,@R,@CL_X,@UCL_X,@LCL_X,@CL_R,@UCL_R,@LCL_R,@Last_Update_Date,@Last_Updated_By);");

            paras.Create().Name("Fixture_Item_PK").Type(DbType.Int32).Size(4).Value(entity.FixtureItemPK);
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

            cmdText.Append(" SELECT @Insertion_Loss_PK=SCOPE_IDENTITY();");

            for (int i = 0; i < entity.DetailItems.Count; i++)
            {
                cmdText.Append(" INSERT INTO SPC_Fixture_Insertion_Loss_Detail");
                cmdText.Append(" (Insertion_Loss_PK,No_Of_Times,Testing_Date ,Testing_Value,MR,Last_Update_Date,Last_Updated_By)");
                cmdText.Append(" VALUES(@Insertion_Loss_PK,@No_Of_Times_" + i.ToString() + ",@Testing_Date_" + i.ToString() + " ,@Testing_Value_" + i.ToString());
                if (entity.DetailItems[i].MR == null)
                {
                    cmdText.Append(",null");
                }
                else
                {
                    cmdText.Append(",@MR_" + i.ToString());
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

        public void DeleteSPC(int FixtureItemPK)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("DELETE t FROM SPC_Fixture_Insertion_Loss t ");
            cmdText.Append("WHERE t.Fixture_Item_PK=@Fixture_Item_PK ");
            cmdText.Append("AND t.Insertion_Loss_PK=( ");
            cmdText.Append("SELECT MAX(Insertion_Loss_PK) From  SPC_Fixture_Insertion_Loss WHERE Fixture_Item_PK=t.Fixture_Item_PK ");
            cmdText.Append(") ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Fixture_Item_PK").Type(DbType.Int32).Value(FixtureItemPK);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void SaveException(int InsertionLossPK, IList<SPCFixtureInsertionLossException> ExceptionItems)
        {
            StringBuilder cmdText = new StringBuilder();
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            cmdText.Append(" DELETE FROM SPC_Fixture_Insertion_Loss_Exception WHERE Insertion_Loss_PK=@Insertion_Loss_PK;");

            paras.Create().Name("Insertion_Loss_PK").Type(DbType.Int32).Value(InsertionLossPK);

            for (int i = 0; i < ExceptionItems.Count; i++)
            {
                cmdText.Append(" INSERT INTO SPC_Fixture_Insertion_Loss_Exception");
                cmdText.Append(" (Insertion_Loss_PK,No_Of_Times,Testing_Date,Chart_Type,Comment,Last_Update_Date,Last_Updated_By)");
                cmdText.Append(" VALUES");
                cmdText.Append(" (@Insertion_Loss_PK,@No_Of_Times_" + i.ToString() + ",@Testing_Date_" + i.ToString() + ",@Chart_Type_" + i.ToString() + ",@Comment_" + i.ToString() + "," +
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

        public SPCFixtureInsertionLossInfo Get(int InsertionLossPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Insertion_Loss_PK").Type(DbType.Int32).Value(InsertionLossPK);

            StringBuilder DetailCmdText = new StringBuilder();
            DetailCmdText.Append("SELECT  No_Of_Times,Testing_Date,Testing_Value,MR,Last_Update_Date,Last_Updated_By ");
            DetailCmdText.Append("FROM SPC_Fixture_Insertion_Loss_Detail ");
            DetailCmdText.Append("WHERE Insertion_Loss_PK=@Insertion_Loss_PK ");
            DetailCmdText.Append("ORDER BY No_Of_Times ASC ");

            IList<SPCFixtureInsertionLossDetail> DetailItems = AdoTemplate.QueryWithRowMapperDelegate<SPCFixtureInsertionLossDetail>(CommandType.Text, DetailCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCFixtureInsertionLossDetail item = new SPCFixtureInsertionLossDetail();
                item.NoOfTimes = Convert.ToInt32(reader["No_Of_Times"]);
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
            ExceptionCmdText.Append("FROM SPC_Fixture_Insertion_Loss_Exception ");
            ExceptionCmdText.Append("WHERE Insertion_Loss_PK=@Insertion_Loss_PK ");

            IList<SPCFixtureInsertionLossException> ExceptionItems = AdoTemplate.QueryWithRowMapperDelegate<SPCFixtureInsertionLossException>(CommandType.Text, ExceptionCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCFixtureInsertionLossException item = new SPCFixtureInsertionLossException();
                item.NoOfTimes = Convert.ToInt32(reader["No_Of_Times"]);
                item.TestingDate = Convert.ToDateTime(reader["Testing_Date"]);
                item.ChartType = Convert.ToChar(reader["Chart_Type"]);
                item.Comment = Convert.ToString(reader["Comment"]);
                return item;
            }, paras.GetParameters());

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT a.Insertion_Loss_PK,a.Fixture_Item_PK,b.Fixture,b.CH,b.Frequency_Band,a.Date_From,a.Date_To,a.X,a.R,a.CL_X,a.UCL_X,a.LCL_X,a.CL_R,a.UCL_R,a.LCL_R ");
            cmdText.Append("FROM SPC_Fixture_Insertion_Loss a INNER JOIN SPC_Fixture_Item b ON a.Fixture_Item_PK=b.Fixture_Item_PK ");
            cmdText.Append("WHERE Insertion_Loss_PK=@Insertion_Loss_PK ");

            return AdoTemplate.QueryForObjectDelegate<SPCFixtureInsertionLossInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCFixtureInsertionLossInfo entity = new SPCFixtureInsertionLossInfo();
                entity.InsertionLossPK = Convert.ToInt32(reader["Insertion_Loss_PK"]);
                entity.FixtureItemPK = Convert.ToInt32(reader["Fixture_Item_PK"]);
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

                entity.FixtureItem = new SPCFixtureItemInfo()
                {
                    FixtureItemPK = Convert.ToInt32(reader["Fixture_Item_PK"]),
                    Fixture = Convert.ToString(reader["Fixture"]),
                    CH = Convert.ToString(reader["CH"]),
                    FrequencyBand = Convert.ToString(reader["Frequency_Band"])
                };
                entity.DetailItems = DetailItems;
                entity.ExceptionItems = ExceptionItems;
                return entity;
            }, paras.GetParameters());
        }

        public SPCFixtureInsertionLossInfo GetLastestInsertionLoss(int FixtureItemPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Fixture_Item_PK").Type(DbType.Int32).Value(FixtureItemPK);
           
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select ISNULL(MAX( b.Insertion_Loss_PK ),0)  Insertion_Loss_PK  ");
            cmdText.Append("FROM SPC_Fixture_Insertion_Loss b    ");
            cmdText.Append("WHERE b.Fixture_Item_PK=@Fixture_Item_PK      ");
            cmdText.Append("AND Insertion_Loss_PK=( ");
            cmdText.Append("select MAX(Insertion_Loss_PK)  ");
            cmdText.Append("from SPC_Fixture_Insertion_Loss 	  ");
            cmdText.Append("Where Fixture_Item_PK=b.Fixture_Item_PK  ");
            cmdText.Append(")   ");
            return AdoTemplate.QueryForObjectDelegate<SPCFixtureInsertionLossInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCFixtureInsertionLossInfo entity = new SPCFixtureInsertionLossInfo();
                entity.InsertionLossPK = Convert.ToInt32(reader["Insertion_Loss_PK"]);
                return entity;
            }, paras.GetParameters());
        }

        public int QueryHistory(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT DISTINCT COUNT(*) ");
            cmdText.Append(" FROM SPC_Fixture_Insertion_Loss a,SPC_Fixture_Item b");
            cmdText.Append(" WHERE a.Fixture_Item_PK=b.Fixture_Item_PK ");

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

        public IList<SPCFixtureInsertionLossInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");
            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" a.Insertion_Loss_PK,a.Fixture_Item_PK,b.Fixture,b.CH,b.Frequency_Band,a.Date_From,a.Date_To");
            cmdText.Append(" FROM SPC_Fixture_Insertion_Loss a,SPC_Fixture_Item b");
            cmdText.Append(" WHERE a.Fixture_Item_PK=b.Fixture_Item_PK ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "Fixture":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE UPPER('%'+@" + entry.Key + "+'%')");
                        break;
                    case "Item":
                        cmdText.Append(" AND upper(" + entry.Key + ") LIKE UPPER('%'+@" + entry.Key + "+'%')");
                        break;
                    case "Frequency_Band":
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

            return AdoTemplate.QueryWithRowMapperDelegate<SPCFixtureInsertionLossInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCFixtureInsertionLossInfo item = new SPCFixtureInsertionLossInfo();
                item.InsertionLossPK = Convert.ToInt32(reader["Insertion_Loss_PK"]);
                item.FixtureItemPK = Convert.ToInt32(reader["Fixture_Item_PK"]);
                item.FixtureItem = new SPCFixtureItemInfo()
                {
                    FixtureItemPK = Convert.ToInt32(reader["Fixture_Item_PK"]),
                    Fixture = Convert.ToString(reader["Fixture"]),
                    CH = Convert.ToString(reader["CH"]),
                    FrequencyBand = Convert.ToString(reader["Frequency_Band"])
                };
                item.DateFrom = Convert.ToDateTime(reader["Date_From"]);
                item.DateTo = Convert.ToDateTime(reader["Date_To"]);

                return item;
            }, paras.GetParameters());
        }

    }
}

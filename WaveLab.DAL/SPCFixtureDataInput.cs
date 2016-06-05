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
    public class SPCFixtureDataInput: AdoDaoSupport,ISPCFixtureDataInput
    {
        public IList<SPCFixtureDataInputInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT Fixture_Item_PK,No_Of_Times,Testing_Date,Return_Loss_Value,Insertion_Loss_Value");
            cmdText.Append(" FROM SPC_Fixture_Data_Input");
            cmdText.Append(" WHERE 1=1 ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "Fixture_Item_PK":
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

            return AdoTemplate.QueryWithRowMapperDelegate<SPCFixtureDataInputInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCFixtureDataInputInfo item = new SPCFixtureDataInputInfo();
                item.FixtureItemPK = Convert.ToInt32(reader["Fixture_Item_PK"]);
                item.NoOfTimes = Convert.ToInt32(reader["No_Of_Times"]);
                item.TestingDate = Convert.ToDateTime(reader["Testing_Date"]);
                item.ReturnLossValue = Convert.ToDouble(reader["Return_Loss_Value"]);
                item.InsertionLossValue = Convert.ToDouble(reader["Insertion_Loss_Value"]);
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(int FixtureItemPK, string TestingDate)
        {
            bool retVal;

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT COUNT(*) FROM SPC_Fixture_Data_Input WHERE Fixture_Item_PK=@Fixture_Item_PK AND CONVERT(VARCHAR(10),Testing_Date,120)=@Testing_Date");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Fixture_Item_PK").Type(DbType.Int32).Value(FixtureItemPK);
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

        public void SaveInput(SPCFixtureDataInputInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("INSERT INTO SPC_Fixture_Data_Input ");
            cmdText.Append("( ");
            cmdText.Append("Fixture_Item_PK,No_Of_Times,Testing_Date,Return_Loss_Value,Insertion_Loss_Value,Last_Update_Date,Last_Updated_By ");
            cmdText.Append(") ");
            cmdText.Append("SELECT ");
            cmdText.Append("@Fixture_Item_PK,ISNULL(MAX(No_Of_Times),0)+1 No_Of_Times,@Testing_Date,@Return_Loss_Value,@Insertion_Loss_Value,@Last_Update_Date,@Last_Updated_By ");
            cmdText.Append("FROM SPC_Fixture_Data_Input WHERE Fixture_Item_PK=@Fixture_Item_PK ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Fixture_Item_PK").Type(DbType.Int32).Value(entity.FixtureItemPK);
            paras.Create().Name("Testing_Date").Type(DbType.DateTime).Value(entity.TestingDate);
            paras.Create().Name("Return_Loss_Value").Type(DbType.Double).Value(entity.ReturnLossValue);
            paras.Create().Name("Insertion_Loss_Value").Type(DbType.Double).Value(entity.InsertionLossValue);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SPCFixtureDataInputInfo Get(int FixtureItemPK, int NoOfTimes)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Fixture_Item_PK").Type(DbType.Int32).Value(FixtureItemPK);
            paras.Create().Name("No_Of_Times").Type(DbType.Int32).Value(NoOfTimes);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT Fixture_Item_PK,No_Of_Times,Testing_Date,Return_Loss_Value,Insertion_Loss_Value ");
            cmdText.Append("FROM SPC_Fixture_Data_Input  ");
            cmdText.Append("WHERE Fixture_Item_PK=@Fixture_Item_PK ");
            cmdText.Append("AND No_Of_Times=@No_Of_Times ");

            return AdoTemplate.QueryForObjectDelegate<SPCFixtureDataInputInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCFixtureDataInputInfo entity = new SPCFixtureDataInputInfo();
                entity.FixtureItemPK = Convert.ToInt32(reader["Fixture_Item_PK"]);
                entity.NoOfTimes = Convert.ToInt32(reader["No_Of_Times"]);
                entity.TestingDate = Convert.ToDateTime(reader["Testing_Date"]);
                entity.ReturnLossValue = Convert.ToDouble(reader["Return_Loss_Value"]);
                entity.InsertionLossValue = Convert.ToDouble(reader["Insertion_Loss_Value"]);
                return entity;
            }, paras.GetParameters());
        }

        public void UpdateInput(SPCFixtureDataInputInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("UPDATE SPC_Fixture_Data_Input ");
            cmdText.Append("SET ");
            cmdText.Append("Testing_Date=@Testing_Date,Return_Loss_Value=@Return_Loss_Value,Insertion_Loss_Value=@Insertion_Loss_Value,Last_Update_Date=@Last_Update_Date,Last_Updated_By =@Last_Updated_By ");
            cmdText.Append("WHERE ");
            cmdText.Append("Fixture_Item_PK=@Fixture_Item_PK AND No_Of_Times=@No_Of_Times");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Testing_Date").Type(DbType.DateTime).Value(entity.TestingDate);
            paras.Create().Name("Return_Loss_Value").Type(DbType.Double).Value(entity.ReturnLossValue);
            paras.Create().Name("Insertion_Loss_Value").Type(DbType.Double).Value(entity.InsertionLossValue);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("Fixture_Item_PK").Type(DbType.Int32).Value(entity.FixtureItemPK);
            paras.Create().Name("No_Of_Times").Type(DbType.Int32).Value(entity.NoOfTimes);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public int GetMaxNoOfTimes(int FixtureItemPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Fixture_Item_PK").Type(DbType.Int32).Value(FixtureItemPK);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT ISNULL(Max(No_Of_Times),0)  ");
            cmdText.Append("FROM SPC_Fixture_Data_Input  ");
            cmdText.Append("WHERE Fixture_Item_PK=@Fixture_Item_PK ");

            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void DeleteInput(int FixtureItemPK, int MaxTimes)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("DELETE t FROM SPC_Fixture_Data_Input t ");
            cmdText.Append("WHERE t.Fixture_Item_PK=@Fixture_Item_PK ");
            cmdText.Append("AND EXISTS( ");
            cmdText.Append("SELECT 'x' From  SPC_Fixture_Data_Input WHERE Fixture_Item_PK=t.Fixture_Item_PK AND No_Of_Times=" + MaxTimes.ToString());
            cmdText.Append(") ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Fixture_Item_PK").Type(DbType.Int32).Value(FixtureItemPK);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

    }
}

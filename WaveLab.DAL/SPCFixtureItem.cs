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
    public class SPCFixtureItem : AdoDaoSupport, ISPCFixtureItem
    {
        #region Basic Operation
        public IList<SPCFixtureItemInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  Fixture_Item_PK,Fixture,CH,Frequency_Band ");
            cmdText.Append(" FROM    SPC_Fixture_Item");
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
            return AdoTemplate.QueryWithRowMapperDelegate<SPCFixtureItemInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SPCFixtureItemInfo ch = new SPCFixtureItemInfo();
                ch.FixtureItemPK = Convert.ToInt32(reader["Fixture_Item_PK"]);
                ch.Fixture = Convert.ToString(reader["Fixture"]);
                ch.CH = Convert.ToString(reader["CH"]);
                ch.FrequencyBand = Convert.ToString(reader["Frequency_Band"]);
                return ch;
            }, paras.GetParameters());
        }

        public bool CheckExists(string fixture, string frequencyBand, string ch)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SPC_Fixture_Item where upper(Fixture)=upper(@Fixture) and upper(CH)=upper(@CH) and upper(Frequency_Band)=upper(@Frequency_Band)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Fixture").Type(DbType.String).Size(50).Value(fixture);
            paras.Create().Name("CH").Type(DbType.String).Size(50).Value(ch);
            paras.Create().Name("Frequency_Band").Type(DbType.String).Size(50).Value(frequencyBand);

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

        public void Save(SPCFixtureItemInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into SPC_Fixture_Item(Fixture,CH,Frequency_Band,Last_Update_Date,Last_Updated_By)");
            cmdText.Append("values(@Fixture,@CH,@Frequency_Band,@Last_Update_Date,@Last_Updated_By)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Fixture").Type(DbType.String).Size(50).Value(entity.Fixture);
            paras.Create().Name("CH").Type(DbType.String).Size(50).Value(entity.CH);
            paras.Create().Name("Frequency_Band").Type(DbType.String).Size(50).Value(entity.FrequencyBand);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SPCFixtureItemInfo Get(int fixtureItemPK)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select * from SPC_Fixture_Item where Fixture_Item_PK=@Fixture_Item_PK");

            return AdoTemplate.QueryForObjectDelegate<SPCFixtureItemInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SPCFixtureItemInfo entity = new SPCFixtureItemInfo();
                entity.FixtureItemPK = Convert.ToInt32(reader["Fixture_Item_PK"]);
                entity.Fixture = Convert.ToString(reader["Fixture"]);               
                entity.FrequencyBand = Convert.ToString(reader["Frequency_Band"]);
                entity.CH = Convert.ToString(reader["CH"]);
                return entity;
            },
            "Fixture_Item_PK", DbType.Int32, 4, fixtureItemPK);
        }

        public bool CheckExists(string fixture,string frequencyBand,string ch ,int fixtureItemPK)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from SPC_Fixture_Item where upper(Fixture)=upper(@Fixture)  and upper(Frequency_Band)=upper(@Frequency_Band) and upper(CH)=upper(@CH) and Fixture_Item_PK<>@Fixture_Item_PK");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Fixture").Type(DbType.String).Size(50).Value(fixture);          
            paras.Create().Name("Frequency_Band").Type(DbType.String).Size(50).Value(frequencyBand);
            paras.Create().Name("CH").Type(DbType.String).Size(50).Value(ch);
            paras.Create().Name("Fixture_Item_PK").Type(DbType.Int32).Size(4).Value(fixtureItemPK);
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

        public void Update(SPCFixtureItemInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update SPC_Fixture_Item set");
            cmdText.Append(" Fixture=@Fixture,CH=@CH,Frequency_Band=@Frequency_Band,Last_Update_Date=@Last_Update_Date,Last_Updated_By=@Last_Updated_By");
            cmdText.Append(" where Fixture_Item_PK=@Fixture_Item_PK");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Fixture").Type(DbType.String).Size(50).Value(entity.Fixture);
            paras.Create().Name("CH").Type(DbType.String).Size(50).Value(entity.CH);
            paras.Create().Name("Frequency_Band").Type(DbType.String).Size(50).Value(entity.FrequencyBand);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("Fixture_Item_PK").Type(DbType.Int32).Size(4).Value(entity.FixtureItemPK);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(SPCFixtureItemInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from SPC_Fixture_Item where Fixture_Item_PK=@Fixture_Item_PK");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Fixture_Item_PK").Type(DbType.Int32).Size(4).Value(entity.FixtureItemPK);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        #endregion
    }
}

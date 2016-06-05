using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using WaveLab.Model;
using WaveLab.IDAL;

using Spring.Data.Common;
using Spring.Data.Generic;

namespace WaveLab.DAL
{
    public class SPCTxPowerItem : AdoDaoSupport, ISPCTxPowerItem
    {
        public IList<SPCTxPowerItemInfo> Query(Hashtable hashTable, string sortby, string orderby)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct tx_power_item_pk, type,mode,ch,pw ");
            cmdText.Append(" FROM  spc_tx_power_item ");
            cmdText.Append(" WHERE  1=1");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "type":
                        cmdText.Append(" AND upper(type) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            cmdText.Append(" order by ");
            cmdText.Append(sortby);
            cmdText.Append(" ");
            cmdText.Append(orderby);

            return AdoTemplate.QueryWithRowMapperDelegate<SPCTxPowerItemInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCTxPowerItemInfo item = new SPCTxPowerItemInfo();
                item.TxPowerItemPK = Convert.ToInt32(reader["Tx_Power_Item_PK"]);
                item.Type = Convert.ToString(reader["type"]);
                item.Mode = Convert.ToString(reader["mode"]);
                item.CH = Convert.ToString(reader["ch"]);
                item.PW = Convert.ToString(reader["pw"]);
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(SPCTxPowerItemInfo item)
        {
            bool retVal;

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT COUNT(*) FROM spc_tx_power_item ");
            cmdText.Append("WHERE type=@type ");
            cmdText.Append("AND  mode=@mode ");
            cmdText.Append("AND  ch=@ch ");
            cmdText.Append("AND  pw=@pw ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("type").Type(DbType.String).Size(50).Value(item.Type);
            paras.Create().Name("mode").Type(DbType.String).Size(50).Value(item.Mode);
            paras.Create().Name("ch").Type(DbType.String).Size(50).Value(item.CH);
            paras.Create().Name("pw").Type(DbType.String).Size(50).Value(item.PW);

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

        public void Save(SPCTxPowerItemInfo item)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" insert into spc_tx_power_item(type,mode,ch,pw,lsl,usl,Sampling_Lower,Sampling_Upper,LCL_X,UCL_X,LCL_R,UCL_R,enable,last_update_date,last_updated_by) values( ");
            cmdText.Append(" @type,@mode,@ch,@pw,@lsl,@usl,@Sampling_Lower,@Sampling_Upper,@LCL_X,@UCL_X,@LCL_R,@UCL_R,@enable,@last_update_date,@last_updated_by)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("type").Type(DbType.String).Size(50).Value(item.Type);
            paras.Create().Name("mode").Type(DbType.String).Size(50).Value(item.Mode);
            paras.Create().Name("ch").Type(DbType.String).Size(50).Value(item.CH);
            paras.Create().Name("pw").Type(DbType.String).Size(50).Value(item.PW);
            paras.Create().Name("Sampling_Lower").Type(DbType.String).Size(50).Value(item.SamplingLower);
            paras.Create().Name("Sampling_Upper").Type(DbType.String).Size(50).Value(item.SamplingUpper);
            paras.Create().Name("lsl").Type(DbType.Double).Value(item.LSL);
            paras.Create().Name("usl").Type(DbType.Double).Value(item.USL);
            paras.Create().Name("LCL_X").Type(DbType.Double).Value(item.LCL_X);
            paras.Create().Name("UCL_X").Type(DbType.Double).Value(item.UCL_X);
            paras.Create().Name("LCL_R").Type(DbType.Double).Value(item.LCL_R);
            paras.Create().Name("UCL_R").Type(DbType.Double).Value(item.UCL_R);
            paras.Create().Name("enable").Type(DbType.StringFixedLength).Size(1).Value(item.Enable);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(item.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(item.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SPCTxPowerItemInfo Get(int TxPowerItemPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Tx_Power_Item_PK").Type(DbType.Int32).Value(TxPowerItemPK);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT Tx_Power_Item_PK,Type,Mode,CH,PW,Sampling_Lower,Sampling_Upper,LSL,USL,LCL_X,UCL_X,LCL_R,UCL_R,Enable ");
            cmdText.Append("FROM SPC_Tx_Power_Item ");
            cmdText.Append("WHERE 1=1 ");
            cmdText.Append("AND Tx_Power_Item_PK=@Tx_Power_Item_PK ");


            return AdoTemplate.QueryForObjectDelegate<SPCTxPowerItemInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCTxPowerItemInfo entity = new SPCTxPowerItemInfo();
                entity.TxPowerItemPK = Convert.ToInt32(reader["Tx_Power_Item_PK"]);
                entity.Type = Convert.ToString(reader["Type"]);
                entity.Mode = Convert.ToString(reader["Mode"]);
                entity.CH = Convert.ToString(reader["CH"]);
                entity.PW = Convert.ToString(reader["PW"]);
                entity.SamplingLower= Convert.ToDouble(reader["Sampling_Lower"]);
                entity.SamplingUpper = Convert.ToDouble(reader["Sampling_Upper"]);
                entity.LSL = Convert.ToDouble(reader["LSL"]);
                entity.USL = Convert.ToDouble(reader["USL"]);
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
                if (reader["LCL_R"] != DBNull.Value && reader["LCL_R"] != null)
                {
                    entity.LCL_R = Convert.ToDouble(reader["LCL_R"]);
                }
                else
                {
                    entity.LCL_R = null;
                }
                if (reader["UCL_R"] != DBNull.Value && reader["UCL_R"] != null)
                {
                    entity.UCL_R = Convert.ToDouble(reader["UCL_R"]);
                }
                else
                {
                    entity.UCL_R = null;
                }
                entity.Enable = Convert.ToChar(reader["Enable"]);
                return entity;
            }, paras.GetParameters());
        }

        public void Update(SPCTxPowerItemInfo item)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("UPDATE spc_tx_power_item SET ");
            cmdText.Append("Sampling_Lower=@Sampling_Lower,Sampling_Upper=@Sampling_Upper,lsl=@lsl,usl=@usl,LCL_X=@LCL_X,UCL_X=@UCL_X,LCL_R=@LCL_R,UCL_R=@UCL_R,enable=@enable,last_update_date=@last_update_date,last_updated_by=@last_updated_by ");
            cmdText.Append("WHERE Tx_Power_Item_PK=@Tx_Power_Item_PK ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Sampling_Lower").Type(DbType.String).Size(50).Value(item.SamplingLower);
            paras.Create().Name("Sampling_Upper").Type(DbType.String).Size(50).Value(item.SamplingUpper);
            paras.Create().Name("lsl").Type(DbType.Double).Value(item.LSL);
            paras.Create().Name("usl").Type(DbType.Double).Value(item.USL);
            paras.Create().Name("LCL_X").Type(DbType.Double).Value(item.LCL_X);
            paras.Create().Name("UCL_X").Type(DbType.Double).Value(item.UCL_X);
            paras.Create().Name("LCL_R").Type(DbType.Double).Value(item.LCL_R);
            paras.Create().Name("UCL_R").Type(DbType.Double).Value(item.UCL_R);
            paras.Create().Name("enable").Type(DbType.StringFixedLength).Size(1).Value(item.Enable);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(item.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(item.LastUpdatedBy);
            paras.Create().Name("Tx_Power_Item_PK").Type(DbType.Int32).Value(item.TxPowerItemPK);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(SPCTxPowerItemInfo item)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("DELETE spc_tx_power_item WHERE Tx_Power_Item_PK=@Tx_Power_Item_PK ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Tx_Power_Item_PK").Type(DbType.Int32).Value(item.TxPowerItemPK);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SPCTxPowerItemLogInfo> GetLogs(int TxPowerItemPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Tx_Power_Item_PK").Type(DbType.Int32).Value(TxPowerItemPK);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT Log_Id,LSL,USL,LCL_X,UCL_X,LCL_R,UCL_R,Last_Update_Date ");
            cmdText.Append("FROM SPC_Tx_Power_Item_Log ");
            cmdText.Append("WHERE 1=1 ");
            cmdText.Append("AND Tx_Power_Item_PK=@Tx_Power_Item_PK ");
            cmdText.Append("ORDER BY Last_Update_Date Desc ");

            return AdoTemplate.QueryWithRowMapperDelegate<SPCTxPowerItemLogInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCTxPowerItemLogInfo entity = new SPCTxPowerItemLogInfo();
                entity.LogId = Convert.ToInt32(reader["Log_Id"]);             
                entity.LSL = Convert.ToDouble(reader["LSL"]);
                entity.USL = Convert.ToDouble(reader["USL"]);
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
                if (reader["LCL_R"] != DBNull.Value && reader["LCL_R"] != null)
                {
                    entity.LCL_R = Convert.ToDouble(reader["LCL_R"]);
                }
                else
                {
                    entity.LCL_R = null;
                }
                if (reader["UCL_R"] != DBNull.Value && reader["UCL_R"] != null)
                {
                    entity.UCL_R = Convert.ToDouble(reader["UCL_R"]);
                }
                else
                {
                    entity.UCL_R = null;
                }
                entity.LastUpdateDate = Convert.ToDateTime(reader["Last_Update_Date"]);
                //entity.LastUpdatedBy = Convert.ToString(reader["Last_Updated_By"]);
                return entity;
            }, paras.GetParameters());
        }

    }
}

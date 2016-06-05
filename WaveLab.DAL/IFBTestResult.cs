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
    public class IFBTestResult : AdoDaoSupport, IIFBTestResult
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM  ifb_test_result_list ");
            cmdText.Append(" WHERE 1=1");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "type":
                        cmdText.Append(" AND upper(type) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "serial_no":
                        cmdText.Append(" AND upper(" + entry.Key + ") = upper(@" + entry.Key + ")");
                        break;
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),end_time,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),end_time,120)<= @" + entry.Key);
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<IFBTestResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" ifb_test_result_id,type,serial_no,if_frequency,");
            cmdText.Append(" start_time,end_time,app_version,final_flag");
            cmdText.Append(" FROM  ifb_test_result_list ");
            cmdText.Append(" WHERE 1=1");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "type":
                        cmdText.Append(" AND upper(type) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "serial_no":
                        cmdText.Append(" AND upper(" + entry.Key + ") = upper(@" + entry.Key + ")");
                        break;
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),end_time,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),end_time,120)<= @" + entry.Key);
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            int startRowNum = (page - 1) * pageSize + 1;
            int endRowNum = startRowNum + pageSize - 1;

            cmdText.Append(" ) t_pager where rowindex between " + startRowNum.ToString() + " and " + endRowNum.ToString());

            return AdoTemplate.QueryWithRowMapperDelegate<IFBTestResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                IFBTestResultInfo item = new IFBTestResultInfo();
                item.IFBTestResultId = Convert.ToInt32(reader["ifb_test_result_id"]);
                item.Type = Convert.ToString(reader["type"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.IFFrequency = Convert.ToString(reader["if_frequency"]);
                if (reader["end_time"] != null)
                {
                    item.EndTime = Convert.ToDateTime(reader["end_time"]);
                }
                item.AppVersion = Convert.ToString(reader["app_version"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                return item;
            }, paras.GetParameters());
        }

        public IList<IFBTestResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct ifb_test_result_id,type,serial_no,if_frequency,");
            cmdText.Append(" start_time,end_time,app_version,final_flag");
            cmdText.Append(" FROM  ifb_test_result_list ");
            cmdText.Append(" WHERE 1=1");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "type":
                        cmdText.Append(" AND upper(type) = upper(@" + entry.Key + ")");
                        break;
                    case "serial_no":
                        cmdText.Append(" AND upper(" + entry.Key + ") = upper(@" + entry.Key + ")");
                        break;
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),end_time,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),end_time,120)<= @" + entry.Key);
                        break;
                    default:
                        break;
                }
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

            return AdoTemplate.QueryWithRowMapperDelegate<IFBTestResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                IFBTestResultInfo item = new IFBTestResultInfo();
                item.IFBTestResultId = Convert.ToInt32(reader["ifb_test_result_id"]);
                item.Type = Convert.ToString(reader["type"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.IFFrequency = Convert.ToString(reader["if_frequency"]);
                if (reader["end_time"] != null)
                {
                    item.EndTime = Convert.ToDateTime(reader["end_time"]);
                }
                item.AppVersion = Convert.ToString(reader["app_version"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                return item;
            }, paras.GetParameters());
        }

        public IFBTestResultInfo GetDetail(int IFBTestResultId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("ifb_test_result_id").Type(DbType.Int32).Size(4).Value(IFBTestResultId);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT ifb_test_result_id,serial_no,type,start_time,end_time,if_frequency,rev,tx_if,lo_if,rx_if_5,");
	        cmdText.Append(" rx_if_negative65,abs_rx_if_ampl,rssi_volt_5,rssi_volt_negative65,tx_if_range,lo_frequency_offset,");
	        cmdText.Append(" tx_pll,pa_i,rx_pll,tx_pow,negative_5v,tx_if_result,final_flag,app_version,operator ");
            cmdText.Append(" FROM ifb_test_result_list");
            cmdText.Append(" WHERE ifb_test_result_id=@ifb_test_result_id");
            return AdoTemplate.QueryForObjectDelegate<IFBTestResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                IFBTestResultInfo entity = new IFBTestResultInfo();
                entity.Type = Convert.ToString(reader["type"]);
                entity.SerialNo = Convert.ToString(reader["serial_no"]);
                if (reader["end_time"] != null)
                {
                    entity.EndTime = Convert.ToDateTime(reader["end_time"]);
                }
                entity.IFFrequency = Convert.ToString(reader["if_frequency"]);
                entity.REV = Convert.ToString(reader["rev"]);
                entity.TxIF = Convert.ToString(reader["tx_if"]);
                entity.LoIF= Convert.ToString(reader["lo_if"]);
                entity.RxIF5 = Convert.ToString(reader["rx_if_5"]);
                entity.RxIFNegative65 = Convert.ToString(reader["rx_if_negative65"]);
                entity.AbsRxIFAmpl = Convert.ToString(reader["abs_rx_if_ampl"]);
                entity.RSSIVolt5= Convert.ToString(reader["rssi_volt_5"]);
                entity.RSSIVoltNegative65 = Convert.ToString(reader["rssi_volt_negative65"]);
                entity.TxIFRanne = Convert.ToString(reader["tx_if_range"]);

                entity.LoFrequencyOffset = Convert.ToString(reader["lo_frequency_offset"]);
                entity.TxIFRanne = Convert.ToString(reader["tx_if_range"]);
                entity.TxPLL = Convert.ToString(reader["tx_pll"]);
                entity.PAI = Convert.ToString(reader["pa_i"]);
                entity.RxPLL = Convert.ToString(reader["rx_pll"]);
                entity.TxPow = Convert.ToString(reader["tx_pow"]);
                entity.Negative5V= Convert.ToString(reader["negative_5v"]);
                entity.TxIFResult = Convert.ToString(reader["tx_if_result"]);
                
                entity.AppVersion = Convert.ToString(reader["app_version"]);
                entity.FinalFlag = Convert.ToChar(reader["final_flag"]);
                entity.Operator = Convert.ToString(reader["operator"]);

                return entity;
            }, paras.GetParameters());
        }
    }
}

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
    public class MAMTestResult : AdoDaoSupport, IMAMTestResult
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM  mam_test_result_list ");
            cmdText.Append(" WHERE 1=1");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "type":
                        cmdText.Append(" AND upper(type) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "mb_serial_no":
                        cmdText.Append(" AND upper(" + entry.Key + ") = upper(@" + entry.Key + ")");
                        break;
                    case "pll_serial_no":
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

        public IList<MAMTestResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" mam_test_result_id,type,mb_serial_no,pll_serial_no,if_frequency,rev_mainboard,rev_pllboard,station_no,");
            cmdText.Append(" start_time,end_time,app_version,final_flag");
            cmdText.Append(" FROM  mam_test_result_list ");
            cmdText.Append(" WHERE 1=1");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "type":
                        cmdText.Append(" AND upper(type) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "mb_serial_no":
                        cmdText.Append(" AND upper(" + entry.Key + ") = upper(@" + entry.Key + ")");
                        break;
                    case "pll_serial_no":
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

            return AdoTemplate.QueryWithRowMapperDelegate<MAMTestResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                MAMTestResultInfo item = new MAMTestResultInfo();
                item.MAMTestResultId = Convert.ToInt32(reader["mam_test_result_id"]);
                item.Type = Convert.ToString(reader["type"]);
                item.MBSerialNo = Convert.ToString(reader["mb_serial_no"]);
                item.PLLSerialNo = Convert.ToString(reader["pll_serial_no"]);
                item.IFFrequency = Convert.ToString(reader["if_frequency"]);
                item.REVMainBoard = Convert.ToString(reader["rev_mainboard"]);
                item.REVPLLBoard = Convert.ToString(reader["rev_pllboard"]);
                if (reader["end_time"] != null)
                {
                    item.EndTime = Convert.ToDateTime(reader["end_time"]);
                }
                item.StationNo = Convert.ToString(reader["station_no"]);
                item.AppVersion = Convert.ToString(reader["app_version"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                return item;
            }, paras.GetParameters());
        }

        public IList<MAMTestResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct mam_test_result_id,type,mb_serial_no,pll_serial_no,if_frequency,rev_mainboard,rev_pllboard,station_no,");
            cmdText.Append(" start_time,end_time,app_version,final_flag");
            cmdText.Append(" FROM  mam_test_result_list ");
            cmdText.Append(" WHERE 1=1");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "type":
                        cmdText.Append(" AND upper(type) = upper(@" + entry.Key + ")");
                        break;
                    case "mb_serial_no":
                        cmdText.Append(" AND upper(" + entry.Key + ") = upper(@" + entry.Key + ")");
                        break;
                    case "pll_serial_no":
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

            return AdoTemplate.QueryWithRowMapperDelegate<MAMTestResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                MAMTestResultInfo item = new MAMTestResultInfo();
                item.MAMTestResultId= Convert.ToInt32(reader["mam_test_result_id"]);
                item.Type = Convert.ToString(reader["type"]);
                item.MBSerialNo = Convert.ToString(reader["mb_serial_no"]);
                item.PLLSerialNo = Convert.ToString(reader["pll_serial_no"]);
                item.IFFrequency = Convert.ToString(reader["if_frequency"]);
                item.REVMainBoard = Convert.ToString(reader["rev_mainboard"]);
                item.REVPLLBoard = Convert.ToString(reader["rev_pllboard"]);
                if (reader["end_time"] != null)
                {
                    item.EndTime = Convert.ToDateTime(reader["end_time"]);
                }
                item.StationNo = Convert.ToString(reader["station_no"]);
                item.AppVersion = Convert.ToString(reader["app_version"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                return item;
            }, paras.GetParameters());
        }

        public MAMTestResultInfo GetDetail(int MAMTestResultId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("mam_test_result_id").Type(DbType.Int32).Size(4).Value(MAMTestResultId);

            StringBuilder detailCmdText = new StringBuilder();
            detailCmdText.Append(" SELECT tx_if_sweep,tx_lo_sweep, rx_if_sweep");
            detailCmdText.Append(" FROM mam_test_result_detail ");
            detailCmdText.Append(" WHERE mam_test_result_id=@mam_test_result_id");

            IList<MAMTestResultDetail> detailItems = AdoTemplate.QueryWithRowMapperDelegate<MAMTestResultDetail>(CommandType.Text, detailCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                MAMTestResultDetail item = new MAMTestResultDetail();
                if (reader["tx_if_sweep"] != null)
                {
                    item.TxIFSweep = Convert.ToDecimal(reader["tx_if_sweep"]);
                }
                if (reader["tx_lo_sweep"] != null)
                {
                    item.TxLoSweep = Convert.ToDecimal(reader["tx_lo_sweep"]);
                }
                if (reader["rx_if_sweep"] != null)
                {
                    item.RxIFSweep = Convert.ToDecimal(reader["rx_if_sweep"]);
                }
                return item;
            }, paras.GetParameters());

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct type,mb_serial_no,pll_serial_no,start_time,end_time,if_frequency,");
            cmdText.Append(" rev_mainboard,rev_pllboard,station_no,tx_lo_power,rx_lo_power,rx_if_10,rx_if_n67,");
            cmdText.Append(" abs_prx_if,tx_if,tx_if_range,lo_offset,rssi_high_low,ctrl_voltage,heater,");
            cmdText.Append(" aging,flat_tx_if,flat_tx_lo,flat_rx_if,tx_pll,pa_i,rx_pll,tx_pow,negative_5v,");
            cmdText.Append(" tx_if_result,firmware_version,bw_low_high,fsk_freq,lo_leakage,temperature,remodlo,final_flag,app_version,operator ");
            cmdText.Append(" FROM mam_test_result_list");
            cmdText.Append(" WHERE mam_test_result_id=@mam_test_result_id");
            return AdoTemplate.QueryForObjectDelegate<MAMTestResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                MAMTestResultInfo entity = new MAMTestResultInfo();
                entity.Type = Convert.ToString(reader["type"]);
                entity.MBSerialNo= Convert.ToString(reader["mb_serial_no"]);
                entity.PLLSerialNo = Convert.ToString(reader["pll_serial_no"]);
                if (reader["end_time"] != null)
                {
                    entity.EndTime = Convert.ToDateTime(reader["end_time"]);
                }
                entity.IFFrequency = Convert.ToString(reader["if_frequency"]);
                entity.REVMainBoard = Convert.ToString(reader["rev_mainboard"]);
                entity.REVPLLBoard = Convert.ToString(reader["rev_pllboard"]);
                entity.StationNo = Convert.ToString(reader["station_no"]);
                entity.TxLoPower = Convert.ToString(reader["tx_lo_power"]);
                entity.RxLoPower = Convert.ToString(reader["rx_lo_power"]);
                entity.RxIF10 = Convert.ToString(reader["rx_if_10"]);
                entity.RxIFNegative67 = Convert.ToString(reader["rx_if_n67"]);
                entity.AbsPrxIFOffset = Convert.ToString(reader["abs_prx_if"]);

                entity.TxIF= Convert.ToString(reader["tx_if"]);
                entity.TXIFRange = Convert.ToString(reader["tx_if_range"]);
                entity.LoOffset = Convert.ToString(reader["lo_offset"]);
                entity.RSSIHighLow = Convert.ToString(reader["rssi_high_low"]);
                entity.CtrlVoltage= Convert.ToString(reader["ctrl_voltage"]);
                entity.Heater = Convert.ToString(reader["heater"]);
                entity.Aging = Convert.ToString(reader["aging"]);
                entity.FlatTxIF = Convert.ToString(reader["flat_tx_if"]);
                entity.FlatTxLo = Convert.ToString(reader["flat_tx_lo"]);

                entity.FlatRxIF = Convert.ToString(reader["flat_rx_if"]);
                entity.TxPLL = Convert.ToString(reader["tx_pll"]);
                entity.PAI = Convert.ToString(reader["pa_i"]);
                entity.RxPLL = Convert.ToString(reader["rx_pll"]);
                entity.TxPow = Convert.ToString(reader["tx_pow"]);
                entity.Negative5V = Convert.ToString(reader["negative_5v"]);
                entity.TxIFResult = Convert.ToString(reader["tx_if_result"]);
                entity.FirmWareVersion= Convert.ToString(reader["firmware_version"]);
                entity.BwLowHigh= Convert.ToString(reader["bw_low_high"]);

                entity.FSKFreq = Convert.ToString(reader["fsk_freq"]);
                entity.LoLeakage = Convert.ToString(reader["lo_leakage"]);
                entity.Temperature = Convert.ToString(reader["temperature"]);
                entity.Remodlo = Convert.ToString(reader["remodlo"]);

                entity.AppVersion = Convert.ToString(reader["app_version"]);
                entity.FinalFlag = Convert.ToChar(reader["final_flag"]);
                entity.Operator = Convert.ToString(reader["operator"]);

                entity.DetailItems = detailItems;
                return entity;
            }, paras.GetParameters());
        }
    }
}

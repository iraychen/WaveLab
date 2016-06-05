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
    public class MWMTestResult : AdoDaoSupport, IMWMTestResult
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM  mwm_test_result_list ");
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

            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<MWMTestResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" mwm_test_result_id,type,serial_no,station_no,");
            cmdText.Append(" start_time,end_time,app_version,final_flag");
            cmdText.Append(" FROM  mwm_test_result_list ");
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

            int startRowNum = (page - 1) * pageSize + 1;
            int endRowNum = startRowNum + pageSize - 1;

            cmdText.Append(" ) t_pager where rowindex between " + startRowNum.ToString() + " and " + endRowNum.ToString());

            return AdoTemplate.QueryWithRowMapperDelegate<MWMTestResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                MWMTestResultInfo item = new MWMTestResultInfo();
                item.MWMTestResultId = Convert.ToInt32(reader["mwm_test_result_id"]);
                item.Type = Convert.ToString(reader["type"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
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

        public IList<MWMTestResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct mwm_test_result_id,type,serial_no,station_no,");
            cmdText.Append(" start_time,end_time,app_version,final_flag");
            cmdText.Append(" FROM  mwm_test_result_list ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<MWMTestResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                MWMTestResultInfo item = new MWMTestResultInfo();
                item.MWMTestResultId = Convert.ToInt32(reader["mwm_test_result_id"]);
                item.Type = Convert.ToString(reader["type"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
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

        public MWMTestResultInfo GetDetail(int MWMTestResultId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("mwm_test_result_id").Type(DbType.Int32).Size(4).Value(MWMTestResultId);

            StringBuilder detailCmdText = new StringBuilder();
            detailCmdText.Append(" SELECT tx_index,tx_freq,tx_pow,tx_spur_freq,tx_spur_pow,tx_gain,");
            detailCmdText.Append(" rx_if_freq,rx_if_pow,rx_spur_freq,rx_spur_pow,rx_if_gain ");
            detailCmdText.Append(" FROM mwm_test_result_detail ");
            detailCmdText.Append(" WHERE mwm_test_result_id=@mwm_test_result_id");

            IList<MWMTestResultDetail> detailItems = AdoTemplate.QueryWithRowMapperDelegate<MWMTestResultDetail>(CommandType.Text, detailCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                MWMTestResultDetail item = new MWMTestResultDetail();
                item.TxIndex = Convert.ToInt32(reader["tx_index"]);
                item.TxFreq = Convert.ToString(reader["tx_freq"]);
                item.TxPow= Convert.ToString(reader["tx_pow"]);
                item.TxSpurFreq = Convert.ToString(reader["tx_spur_freq"]);
                item.TxSpurPow = Convert.ToString(reader["tx_spur_pow"]);
                if (reader["tx_gain"] != null)
                {
                    item.TxGain = Convert.ToDecimal(reader["tx_gain"]);
                }
                item.RxIFFreq = Convert.ToString(reader["rx_if_freq"]);
                item.RxIFPow = Convert.ToString(reader["rx_if_pow"]);
                item.RxSpurFreq = Convert.ToString(reader["rx_spur_freq"]);
                item.RxSpurPow = Convert.ToString(reader["rx_spur_pow"]);
                if (reader["rx_if_gain"] != null)
                {
                    item.RxIFGain = Convert.ToDecimal(reader["rx_if_gain"]);
                }
               
                return item;
            }, paras.GetParameters());

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct type,serial_no,start_time,end_time,station_no,");
            cmdText.Append(" tx_p1db,tx_gain_flatness,tx_lo_reject_min,tx_lo_reject_max,tx_attn_diff,rx_gain_flatness,");
            cmdText.Append(" current_on_5v_1,current_on_5v_2,current_on_5v_3,current_on_hpa,");
            cmdText.Append(" pwr_d_voltage,pwr_r_ohm,ref_d_voltage,abs_verf_vpwr_d_offset, ");
            cmdText.Append(" final_flag,app_version,operator ");
            cmdText.Append(" FROM mwm_test_result_list");
            cmdText.Append(" WHERE mwm_test_result_id=@mwm_test_result_id");
            return AdoTemplate.QueryForObjectDelegate<MWMTestResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                MWMTestResultInfo entity = new MWMTestResultInfo();
                entity.Type = Convert.ToString(reader["type"]);
                entity.SerialNo = Convert.ToString(reader["serial_no"]);
                if (reader["end_time"] != null)
                {
                    entity.EndTime = Convert.ToDateTime(reader["end_time"]);
                }
                entity.StationNo = Convert.ToString(reader["station_no"]);
                entity.TxP1dB = Convert.ToString(reader["tx_p1db"]);
                entity.TxGainFlatness = Convert.ToString(reader["tx_gain_flatness"]);
                entity.TxLoRejectMin = Convert.ToString(reader["tx_lo_reject_min"]);
                entity.TxLoRejectMax = Convert.ToString(reader["tx_lo_reject_max"]);
                entity.TxAttnDiff= Convert.ToString(reader["tx_attn_diff"]);
                entity.RxGainFlatness = Convert.ToString(reader["rx_gain_flatness"]);
                
                entity.CurrentOn5V1 = Convert.ToString(reader["current_on_5v_1"]);
                entity.CurrentOn5V2 = Convert.ToString(reader["current_on_5v_2"]);
                entity.CurrentOn5V3 = Convert.ToString(reader["current_on_5v_3"]);
                entity.CurrentOnHPA = Convert.ToString(reader["current_on_hpa"]);
                entity.PwrDVoltage = Convert.ToString(reader["pwr_d_voltage"]);
                entity.PwrRVoltage = Convert.ToString(reader["pwr_r_ohm"]);
                entity.RefDVoltage = Convert.ToString(reader["ref_d_voltage"]);
                entity.AbsVerfVpwrDOffset = Convert.ToString(reader["abs_verf_vpwr_d_offset"]);

                entity.AppVersion = Convert.ToString(reader["app_version"]);
                entity.FinalFlag = Convert.ToChar(reader["final_flag"]);
                entity.Operator = Convert.ToString(reader["operator"]);

                entity.DetailItems = detailItems;
                return entity;
            }, paras.GetParameters());
        }
    }
}

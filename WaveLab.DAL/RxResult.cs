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
    public class RxResult : AdoDaoSupport, IRxResult
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM  rx_result_list a left join barcode_list b on a.serial_no=b.serial_no ");
            cmdText.Append(" left join label_code c on b.code=c.code and b.model=c.model");
            cmdText.Append(" WHERE 1=1 ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    
                    case "model":
                          cmdText.Append(" AND upper(c.model) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120)<= @" + entry.Key);
                        break;
                    case "serial_no":
                            cmdText.Append(" AND upper(a.serial_no) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<RxResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" a.rx_result_id,c.model,a.serial_no,a.channel,a.station_no,a.ch_no,a.wg_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.reason");
            cmdText.Append(" FROM  rx_result_list a left join barcode_list b on a.serial_no=b.serial_no ");
            cmdText.Append(" left join label_code c on b.code=c.code and b.model=c.model");
    
            cmdText.Append(" WHERE 1=1 ");


            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                
                    case "model":
                          cmdText.Append(" AND upper(c.model) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120)<= @" + entry.Key);
                        break;
                    case "serial_no":
                            cmdText.Append(" AND upper(a.serial_no) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            int startRowNum = (page - 1) * pageSize + 1;
            int endRowNum = startRowNum + pageSize - 1;

            cmdText.Append(" ) t_pager where rowindex between " + startRowNum.ToString() + " and " + endRowNum.ToString());

            return AdoTemplate.QueryWithRowMapperDelegate<RxResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                RxResultInfo item = new RxResultInfo();
                item.RxResultId = Convert.ToInt32(reader["rx_result_id"]);
            
                item.Model = Convert.ToString(reader["model"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                if (reader["start_time"] != null)
                {
                    item.StartTime = Convert.ToDateTime(reader["start_time"]);
                }
                if (reader["end_time"] != null)
                {
                    item.EndTime = Convert.ToDateTime(reader["end_time"]);
                }
                if (reader["start_time"] != null && reader["end_time"] != null)
                {
                    TimeSpan timeSpan = item.EndTime.Value - item.StartTime.Value;
                    item.RunningTime = Convertor.Format(timeSpan); ;
                }
                item.Channel = Convert.ToString(reader["channel"]);
                item.StationNo = Convert.ToString(reader["station_no"]);
                item.CHNo = Convert.ToString(reader["ch_no"]);
                item.WGNo = Convert.ToString(reader["wg_no"]);
                item.AppVersion = Convert.ToString(reader["app_version"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                item.Reason = Convert.ToString(reader["reason"]);
                return item;
            }, paras.GetParameters());
        }

        public IList<RxResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct a.rx_result_id,c.model,a.serial_no,a.channel,a.station_no,a.ch_no,a.wg_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.reason");
            cmdText.Append(" FROM  rx_result_list a left join barcode_list b on a.serial_no=b.serial_no ");
            cmdText.Append(" left join label_code c on b.code=c.code and b.model=c.model");
          
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                  
                    case "model":
                          cmdText.Append(" AND upper(c.model) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120)<= @" + entry.Key);
                        break;
                    case "serial_no":
                            cmdText.Append(" AND upper(a.serial_no) like upper('%'+@" + entry.Key + "+'%')");
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

            return AdoTemplate.QueryWithRowMapperDelegate<RxResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                RxResultInfo item = new RxResultInfo();
                item.RxResultId = Convert.ToInt32(reader["rx_result_id"]);
             
                item.Model = Convert.ToString(reader["model"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                if (reader["start_time"] != null)
                {
                    item.StartTime= Convert.ToDateTime(reader["start_time"]);
                }
                if (reader["end_time"] != null)
                {
                    item.EndTime= Convert.ToDateTime(reader["end_time"]);
                }
                if (reader["start_time"] != null && reader["end_time"] != null)
                {
                    TimeSpan timeSpan = item.EndTime.Value - item.StartTime.Value;
                    item.RunningTime = Convertor.Format(timeSpan);;
                }
                item.Channel= Convert.ToString(reader["channel"]);
                item.StationNo = Convert.ToString(reader["station_no"]);
                item.CHNo = Convert.ToString(reader["ch_no"]);
                item.WGNo = Convert.ToString(reader["wg_no"]);
                item.AppVersion = Convert.ToString(reader["app_version"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                item.Reason = Convert.ToString(reader["reason"]);
                return item;
            }, paras.GetParameters());
        }

        public RxResultInfo GetDetail(int rxResultId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("rx_result_id").Type(DbType.Int32).Size(4).Value(rxResultId);

            StringBuilder powerLevelCmdText = new StringBuilder();
            powerLevelCmdText.Append(" SELECT pw_lv,case cast(pw_lv as int) when -20 then 4.5 when -90 then 0.1 else null end bnc_voltage");
            powerLevelCmdText.Append(" ,detect_rx_power_high,detect_rx_power_low");
            powerLevelCmdText.Append(",Detect_Rx_Power_7M,Detect_Rx_Power_28M,Detect_Rx_Power_56M,Detect_Rx_Power_14M ");
            powerLevelCmdText.Append(",Detect_Rx_Power_MIN,Detect_Rx_Power_MID ,Detect_Rx_Power_MAX ");
            powerLevelCmdText.Append(",level_140mhz,freq_140mhz  ");
            powerLevelCmdText.Append(" FROM rx_result_power_level ");
            powerLevelCmdText.Append(" WHERE rx_result_id=@rx_result_id");
            powerLevelCmdText.Append(" ORDER BY cast(pw_lv as int) desc");

            IList<RxResultPowerLevelInfo> rxResultPowerLevelItems = AdoTemplate.QueryWithRowMapperDelegate<RxResultPowerLevelInfo>(CommandType.Text, powerLevelCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                RxResultPowerLevelInfo item = new RxResultPowerLevelInfo();
                item.PWLV = Convert.ToString(reader["pw_lv"]);
                item.BNCVoltage = Convert.ToString(reader["bnc_voltage"]);
                item.DetectRxPowerHigh = Convert.ToString(reader["detect_rx_power_high"]);
                item.DetectRxPowerLow = Convert.ToString(reader["detect_rx_power_low"]);
                item.DetectRxPower7M = Convert.ToString(reader["Detect_Rx_Power_7M"]);
                item.DetectRxPower28M = Convert.ToString(reader["Detect_Rx_Power_28M"]);
                item.DetectRxPower56M = Convert.ToString(reader["Detect_Rx_Power_56M"]);
                item.DetectRxPower14M = Convert.ToString(reader["Detect_Rx_Power_14M"]);
                item.DetectRxPowerMIN = Convert.ToString(reader["Detect_Rx_Power_MIN"]);
                item.DetectRxPowerMID = Convert.ToString(reader["Detect_Rx_Power_MID"]);
                item.DetectRxPowerMAX = Convert.ToString(reader["Detect_Rx_Power_MAX"]);
                item.Level140MHZ = Convert.ToString(reader["level_140mhz"]);
                item.Freq140MHZ = Convert.ToString(reader["freq_140mhz"]);
                return item;
            }, paras.GetParameters());

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct c.model,a.serial_no,a.channel,a.station_no, a.ch_no,a.wg_no,");
            cmdText.Append(" a.start_time,a.end_time,a.rx_agc,a.rssi_offset,a.nf,a.bw_low_high,a.freq_140m,a.app_version,a.final_flag,a.reason");
            cmdText.Append(" FROM  rx_result_list a left join barcode_list b on a.serial_no=b.serial_no ");
            cmdText.Append(" left join label_code c on b.code=c.code and b.model=c.model");
            cmdText.Append(" WHERE 1=1 ");
            cmdText.Append(" AND a.rx_result_id=@rx_result_id");
            return AdoTemplate.QueryForObjectDelegate<RxResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                RxResultInfo entity = new RxResultInfo();
         
                entity.Model = Convert.ToString(reader["model"]);
                entity.SerialNo = Convert.ToString(reader["serial_no"]);
                if (reader["start_time"] != null)
                {
                    entity.StartTime = Convert.ToDateTime(reader["start_time"]);
                }
                if (reader["end_time"] != null)
                {
                    entity.EndTime= Convert.ToDateTime(reader["end_time"]);
                }
                if (reader["start_time"] != null && reader["end_time"] != null)
                {
                    TimeSpan timeSpan = entity.EndTime.Value - entity.StartTime.Value;
                    entity.RunningTime = Convertor.Format(timeSpan);;
                }
                entity.Channel= Convert.ToString(reader["channel"]);
                entity.StationNo = Convert.ToString(reader["station_no"]);
                entity.CHNo = Convert.ToString(reader["ch_no"]);
                entity.WGNo = Convert.ToString(reader["wg_no"]);
                entity.RXAGC = Convert.ToString(reader["rx_agc"]);
                entity.RSSIOffSet = Convert.ToString(reader["rssi_offset"]);
                entity.NF = Convert.ToString(reader["nf"]);
                entity.BWLowHIgh = Convert.ToString(reader["bw_low_high"]);
                entity.Freq140M = Convert.ToString(reader["freq_140m"]);
                entity.AppVersion = Convert.ToString(reader["app_version"]);
                entity.FinalFlag = Convert.ToChar(reader["final_flag"]);
                entity.Reason = Convert.ToString(reader["reason"]);
                entity.RxResultPowerLevelItems = rxResultPowerLevelItems;
                return entity;
            }, paras.GetParameters());
        }
    }
}

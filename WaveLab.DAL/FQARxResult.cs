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
    public class FQARxResult : AdoDaoSupport, IFQARxResult
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM fqa_rx_result_list a inner join barcode_list b on a.serial_no=b.serial_no ");
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

        public IList<FQARxResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" a.fqa_rx_result_id,c.model,a.serial_no,a.ch,a.station_no,");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.reason");
            cmdText.Append(" FROM fqa_rx_result_list a inner join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<FQARxResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                FQARxResultInfo item = new FQARxResultInfo();
                item.FQARxResultId = Convert.ToInt32(reader["fqa_rx_result_id"]);
              
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
                item.CH = Convert.ToString(reader["ch"]);
                item.StationNo = Convert.ToString(reader["station_no"]);
                item.AppVersion = Convert.ToString(reader["app_version"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                item.Reason = Convert.ToString(reader["reason"]);
                return item;
            }, paras.GetParameters());
        }

        public IList<FQARxResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct a.fqa_rx_result_id,c.model,a.serial_no,a.ch,a.station_no,");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.reason");
            cmdText.Append(" FROM fqa_rx_result_list a inner join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<FQARxResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                FQARxResultInfo item = new FQARxResultInfo();
                item.FQARxResultId = Convert.ToInt32(reader["fqa_rx_result_id"]);
             
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
                item.CH = Convert.ToString(reader["ch"]);
                item.StationNo = Convert.ToString(reader["station_no"]);
                item.AppVersion = Convert.ToString(reader["app_version"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                item.Reason = Convert.ToString(reader["reason"]);
                return item;
            }, paras.GetParameters());
        }

        public FQARxResultInfo GetDetail(int FQARxResultId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("fqa_rx_result_id").Type(DbType.Int32).Size(4).Value(FQARxResultId);

            StringBuilder powerLevelCmdText = new StringBuilder();
            powerLevelCmdText.Append(" SELECT pw_lv,case cast(pw_lv as int) when -20 then 4.5 when -90 then 0.1 else null end bnc_voltage,detect_rx_power_high,detect_rx_power_low,level_140mhz,freq_140mhz ");
            powerLevelCmdText.Append(" FROM fqa_rx_result_power_level ");
            powerLevelCmdText.Append(" WHERE fqa_rx_result_id=@fqa_rx_result_id");
            powerLevelCmdText.Append(" ORDER BY cast(pw_lv as int) desc");

            IList<FQARxResultPowerLevelInfo> FQARxResultPowerLevelItems = AdoTemplate.QueryWithRowMapperDelegate<FQARxResultPowerLevelInfo>(CommandType.Text, powerLevelCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                FQARxResultPowerLevelInfo item = new FQARxResultPowerLevelInfo();
                item.PWLV = Convert.ToString(reader["pw_lv"]);
                item.BNCVoltage = Convert.ToString(reader["bnc_voltage"]);
                item.DetectRxPowerHigh = Convert.ToString(reader["detect_rx_power_high"]);
                item.DetectRxPowerLow = Convert.ToString(reader["detect_rx_power_low"]);
                item.Level140MHZ = Convert.ToString(reader["level_140mhz"]);
                item.Freq140MHZ = Convert.ToString(reader["freq_140mhz"]);
                return item;
            }, paras.GetParameters());

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct c.model,a.serial_no,a.ch,a.station_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.rx_agc,a.rssi_offset,a.nf,a.bw_low_high,a.freq_140m,a.app_version,a.final_flag,a.reason");
            cmdText.Append(" FROM fqa_rx_result_list a inner join barcode_list b on a.serial_no=b.serial_no ");
             cmdText.Append(" left join label_code c on b.code=c.code and b.model=c.model");
            cmdText.Append(" WHERE 1=1 ");
            cmdText.Append(" AND a.fqa_rx_result_id=@fqa_rx_result_id");
            return AdoTemplate.QueryForObjectDelegate<FQARxResultInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                FQARxResultInfo entity = new FQARxResultInfo();
              
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
                entity.CH = Convert.ToString(reader["ch"]);
                entity.StationNo = Convert.ToString(reader["station_no"]);
                entity.RXAGC = Convert.ToString(reader["rx_agc"]);
                entity.RSSIOffSet = Convert.ToString(reader["rssi_offset"]);
                entity.NF = Convert.ToString(reader["nf"]);
                entity.BWLowHIgh = Convert.ToString(reader["bw_low_high"]);
                entity.Freq140M = Convert.ToString(reader["freq_140m"]);
                entity.AppVersion = Convert.ToString(reader["app_version"]);
                entity.FinalFlag = Convert.ToChar(reader["final_flag"]);
                entity.Reason = Convert.ToString(reader["reason"]);
                entity.FQARxResultPowerLevelItems = FQARxResultPowerLevelItems;
                return entity;
            }, paras.GetParameters());
        }
    }
}

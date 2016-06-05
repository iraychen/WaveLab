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
    public class GeneralInit:AdoDaoSupport, IGeneralInit
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM  general_init_list a left  join barcode_list b on a.serial_no=b.serial_no ");
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

        public IList<GeneralInitInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " "+orderBy+" ) ,");
            cmdText.Append(" a.general_init_id,c.model,a.serial_no,a.station_no,a.start_time, ");
            cmdText.Append(" a.end_time,a.app_version,a.final_flag,a.reason");
            cmdText.Append(" FROM  general_init_list a left  join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<GeneralInitInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                GeneralInitInfo item = new GeneralInitInfo();
                item.GeneralInitId = Convert.ToInt32(reader["general_init_id"]);;
                item.Model = Convert.ToString(reader["model"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.StationNo = Convert.ToString(reader["station_no"]);
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
                item.AppVersion = Convert.ToString(reader["app_version"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                item.Reason = Convert.ToString(reader["reason"]);
                return item;
            }, paras.GetParameters());
        }

        public IList<GeneralInitInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct a.general_init_id,c.code,c.model,a.serial_no,a.station_no,a.start_time, ");
            cmdText.Append(" a.end_time,a.app_version,a.final_flag,a.reason");
            cmdText.Append(" FROM  general_init_list a left  join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<GeneralInitInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                GeneralInitInfo item = new GeneralInitInfo();
                item.GeneralInitId = Convert.ToInt32(reader["general_init_id"]);
                item.Model = Convert.ToString(reader["model"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.StationNo = Convert.ToString(reader["station_no"]);
                if (reader["start_time"] != null)
                {
                    item.StartTime = Convert.ToDateTime(reader["start_time"]);
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
                item.AppVersion= Convert.ToString(reader["app_version"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                item.Reason = Convert.ToString(reader["reason"]);
                return item;
            }, paras.GetParameters());
        }

        public GeneralInitInfo GetDetail(int generalInitId)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct c.code,c.model,a.serial_no,a.station_no,a.start_time,a.end_time, ");
            cmdText.Append(" a.type_low,a.freq_range_low,a.alarm_low,a.type_high,a.freq_range_high,a.alarm_high ,");
            cmdText.Append(" a.power_range,a.mode_max_power,a.rssi_offset,a.power_offset,a.aging,a.filter_switch, ");
            cmdText.Append(" noise_figure,max_suppurted_bandwidth,controled_voltage_ext,tx_temp_offset,clei_no,hard_ver,model_no,");
            cmdText.Append(" a.mcu_version,a.app_version,a.final_flag,a.operator,a.reason");
            cmdText.Append(" FROM  general_init_list a left  join barcode_list b on a.serial_no=b.serial_no ");
            cmdText.Append(" left join label_code c on b.code=c.code and b.model=c.model"); 
            cmdText.Append(" WHERE 1=1 ");
            cmdText.Append(" AND general_init_id=@general_init_id");

            return AdoTemplate.QueryForObjectDelegate<GeneralInitInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                GeneralInitInfo entity = new GeneralInitInfo();
            
                entity.Model = Convert.ToString(reader["model"]);
                entity.SerialNo = Convert.ToString(reader["serial_no"]);
                entity.StationNo = Convert.ToString(reader["station_no"]);
                if (reader["start_time"] != null)
                {
                    entity.StartTime= Convert.ToDateTime(reader["start_time"]);
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
                entity.TypeLow = Convert.ToString(reader["type_low"]);
                entity.FreqRangeLow = Convert.ToString(reader["freq_range_low"]);
                entity.AlarmLow = Convert.ToString(reader["alarm_low"]);
                entity.TypeHigh = Convert.ToString(reader["type_high"]);
                entity.FreqRangeHigh = Convert.ToString(reader["freq_range_high"]);
                entity.AlarmHigh = Convert.ToString(reader["alarm_high"]);
                entity.PowerRange = Convert.ToString(reader["power_range"]);
                entity.ModeMaxPower = Convert.ToString(reader["mode_max_power"]);
                entity.RSSIOffSet = Convert.ToString(reader["rssi_offset"]);
                entity.PowerOffSet = Convert.ToString(reader["power_offset"]);
                entity.Aging = Convert.ToString(reader["aging"]);
                entity.FilterSwitch = Convert.ToString(reader["filter_switch"]);
                entity.NoiseFigure = Convert.ToString(reader["noise_figure"]);
                entity.MaxSupportedBandWidth = Convert.ToString(reader["max_suppurted_bandwidth"]);
                entity.ControledVoltageExt = Convert.ToString(reader["controled_voltage_ext"]);
                entity.TxTempOffSet = Convert.ToString(reader["tx_temp_offset"]);
                entity.CleiNo = Convert.ToString(reader["clei_no"]);
                entity.HardVersion = Convert.ToString(reader["hard_ver"]);
                entity.ModelNo = Convert.ToString(reader["model_no"]);
                entity.MCUVersion = Convert.ToString(reader["mcu_version"]);
                entity.AppVersion = Convert.ToString(reader["app_version"]);
                entity.FinalFlag = Convert.ToChar(reader["final_flag"]);
                entity.Operator = Convert.ToString(reader["operator"]);
                entity.Reason = Convert.ToString(reader["reason"]);
                return entity;
            },
            "general_init_id", DbType.Int32, 4, generalInitId);
        }

        public bool GeneralInitCheck(string serialNo)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select count(*) ");
            cmdText.Append(" from general_init_list ");
            cmdText.Append(" where serial_no=@serial_no ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("serial_no").Type(DbType.String).Size(50).Value(serialNo);

            int recordCoufqa = (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            if (recordCoufqa > 0)
            {
                retVal = true;
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }
    }
}

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
    public class InformationConfirm : AdoDaoSupport,  IInformationConfirm
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM information_confirm_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

        public IList<InformationConfirmInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" a.information_confirm_id,c.model,a.serial_no,a.station_no,a.type_low,a.type_high, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.reason ");
            cmdText.Append(" FROM information_confirm_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<InformationConfirmInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                InformationConfirmInfo item = new InformationConfirmInfo();
                item.InformationConfirmId = Convert.ToInt32(reader["information_confirm_id"]);
                item.Model = Convert.ToString(reader["model"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.StationNo = Convert.ToString(reader["station_no"]);
                item.TypeLow = Convert.ToString(reader["type_low"]);
                item.TypeHigh = Convert.ToString(reader["type_high"]);
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

        public IList<InformationConfirmInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct a.information_confirm_id,c.code,c.model,a.serial_no,a.station_no,a.type_low,a.type_high, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.reason ");
            cmdText.Append(" FROM information_confirm_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<InformationConfirmInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                InformationConfirmInfo item = new InformationConfirmInfo();
                item.InformationConfirmId = Convert.ToInt32(reader["information_confirm_id"]);
                item.Model = Convert.ToString(reader["model"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.StationNo = Convert.ToString(reader["station_no"]);
                item.TypeLow = Convert.ToString(reader["type_low"]);
                item.TypeHigh = Convert.ToString(reader["type_high"]);
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
                    item.RunningTime = Convertor.Format(timeSpan);;
                }
                item.AppVersion = Convert.ToString(reader["app_version"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                item.Reason = Convert.ToString(reader["reason"]);
                return item;
            }, paras.GetParameters());
        }

        public InformationConfirmInfo GetDetail(int confirmId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("information_confirm_id").Type(DbType.Int32).Size(4).Value(confirmId);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT distinct c.model,a.serial_no ,a.station_no,end_time,");
            cmdText.Append("type_low,type_high,power_range,freq_range ,mode_max_power,rssi_offset,rssi_ch_offset,power_offset,aging,filter_switch,controled_voltage,controled_voltage_ext,");
            cmdText.Append("mcu_version,part_num,id_num,tx_pll,rx_pll,pa_i,tx_pow,tx_pow_range,tx_temp_offset,negative_5v,tx_if ,atpc_range,rssi_alarm,remodlo,temperature,model_no,clei_no,");
            cmdText.Append("iqci_volt,iqcq_volt,maufact_date,the_highest_mode,the_highest_capacity,ordering_no,associated_eclipse_version,max_suppurted_bandwidth,bootload_version,noise_figure,");
            cmdText.Append("Hard_Ver,start_time,app_version,a.final_flag,a.reason,a.operator");
            cmdText.Append(" FROM information_confirm_list a left join barcode_list b on a.serial_no=b.serial_no ");
             cmdText.Append(" left join label_code c on b.code=c.code and b.model=c.model"); 
          
            cmdText.Append(" WHERE 1=1 ");
            cmdText.Append(" AND a.information_confirm_id=@information_confirm_id");
            return AdoTemplate.QueryForObjectDelegate<InformationConfirmInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                InformationConfirmInfo entity = new InformationConfirmInfo();
                entity.Model = Convert.ToString(reader["model"]);
                entity.SerialNo = Convert.ToString(reader["serial_no"]);
                entity.StationNo = Convert.ToString(reader["station_no"]);
                entity.TypeLow = Convert.ToString(reader["type_low"]);
                entity.TypeHigh = Convert.ToString(reader["type_high"]);
                if (reader["start_time"] != null)
                {
                    entity.StartTime = Convert.ToDateTime(reader["start_time"]);
                }
                if (reader["end_time"] != null)
                {
                    entity.EndTime = Convert.ToDateTime(reader["end_time"]);
                }
                if (reader["start_time"] != null && reader["end_time"] != null)
                {
                    TimeSpan timeSpan = entity.EndTime.Value - entity.StartTime.Value;
                    entity.RunningTime = Convertor.Format(timeSpan);;
                }
                entity.AppVersion = Convert.ToString(reader["app_version"]);
                entity.FinalFlag = Convert.ToChar(reader["final_flag"]);
                entity.Operator = Convert.ToString(reader["operator"]);

                entity.PowerRange = Convert.ToString(reader["power_range"]);
                entity.FreqRange = Convert.ToString(reader["freq_range"]);
                entity.ModeMaxPower = Convert.ToString(reader["mode_max_power"]);
                entity.RSSIOffSet = Convert.ToString(reader["rssi_offset"]);
                entity.RSSICHOffSet = Convert.ToString(reader["rssi_ch_offset"]);
                entity.PowerOffSet = Convert.ToString(reader["power_offset"]);
                entity.Aging = Convert.ToString(reader["aging"]);
                entity.FilterSwitch = Convert.ToString(reader["filter_switch"]);
                entity.ControledVoltage = Convert.ToString(reader["controled_voltage"]);
                entity.ControledVoltageExt = Convert.ToString(reader["controled_voltage_ext"]);
                entity.MCUVersion = Convert.ToString(reader["mcu_version"]);
                entity.PartNum = Convert.ToString(reader["part_num"]);
                entity.IDNum = Convert.ToString(reader["id_num"]);
                entity.TxPll= Convert.ToString(reader["tx_pll"]);
                entity.RxPll = Convert.ToString(reader["rx_pll"]);
                entity.PaI= Convert.ToString(reader["pa_i"]);
                entity.TxPow= Convert.ToString(reader["tx_pow"]);
                entity.TxPowRange = Convert.ToString(reader["tx_pow_range"]);
                entity.TxTempOffSet = Convert.ToString(reader["tx_temp_offset"]);
                entity.Negative5V = Convert.ToString(reader["negative_5v"]);
                entity.TxIf= Convert.ToString(reader["tx_if"]);
                entity.AtpcRange = Convert.ToString(reader["atpc_range"]);
                entity.RSSIAlarm = Convert.ToString(reader["rssi_alarm"]);

                entity.Remodlo = Convert.ToString(reader["remodlo"]);
                entity.Temperature = Convert.ToString(reader["temperature"]);
                entity.ModelNo = Convert.ToString(reader["model_no"]);
                entity.CleiNo = Convert.ToString(reader["clei_no"]);
                entity.IQCIVolt = Convert.ToString(reader["iqci_volt"]);
                entity.IQCQVolt = Convert.ToString(reader["iqcq_volt"]);
                entity.MaufactDate = Convert.ToString(reader["maufact_date"]);
                entity.TheHighestMode = Convert.ToString(reader["the_highest_mode"]);
                entity.TheHighestCapacity = Convert.ToString(reader["the_highest_capacity"]);
                entity.OrderingNo = Convert.ToString(reader["ordering_no"]);
                entity.AssociatedEclipseVersion = Convert.ToString(reader["associated_eclipse_version"]);
                entity.MaxSuppurtedBandWidth = Convert.ToString(reader["max_suppurted_bandwidth"]);
                entity.BootLoadVersion = Convert.ToString(reader["bootload_version"]);
                entity.NoiseFigure = Convert.ToString(reader["noise_figure"]);
                entity.HardWareVersion = Convert.ToString(reader["Hard_Ver"]);
                entity.Reason = Convert.ToString(reader["reason"]);
                return entity;
            }, paras.GetParameters());
        }
    }
}

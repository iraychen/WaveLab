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
    public class ProtocolInit : AdoDaoSupport, IProtocolInit
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM protocol_init_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

        public IList<ProtocolInitInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" a.protocol_init_id,c.code,c.model,a.serial_no,a.type_low,a.type_high, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag ,a.reason");
            cmdText.Append(" FROM protocol_init_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<ProtocolInitInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                ProtocolInitInfo item = new ProtocolInitInfo();
                item.ProtocolInitId = Convert.ToInt32(reader["protocol_init_id"]);
                item.Model = Convert.ToString(reader["model"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
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

        public IList<ProtocolInitInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct a.protocol_init_id,c.model,a.serial_no,a.type_low,a.type_high, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.reason ");
            cmdText.Append(" FROM protocol_init_list a left join barcode_list b on a.serial_no=b.serial_no ");
             cmdText.Append(" left join label_code c on b.code=c.code and b.model=c.model"); 
            cmdText.Append(" left join ext_sn_list d on b.barcode=d.barcode");
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

            return AdoTemplate.QueryWithRowMapperDelegate<ProtocolInitInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                ProtocolInitInfo item = new ProtocolInitInfo();
                item.ProtocolInitId = Convert.ToInt32(reader["protocol_init_id"]);
                item.Model = Convert.ToString(reader["model"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
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

        public ProtocolInitInfo GetDetail(int protocolInitId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("protocol_init_id").Type(DbType.Int32).Size(4).Value(protocolInitId);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT distinct c.model,a.serial_no ,a.start_time,a.end_time,");
            cmdText.Append("type_low,type_high,power_range,freq_range_low,freq_range_high ,mode_max_power,rssi_offset,power_offset,aging,filter_switch,");
	        cmdText.Append("mcu_version,part_num,id_num,tx_pll_low,rx_pll_low,pa_i_low,tx_pow_low,negative_5v_low,tx_if_low ,tx_pll_high ,");
	        cmdText.Append("rx_pll_high,pa_i_high,tx_pow_high,negative_5v_high,tx_if_high,rssi_alarm,factory_info,app_version,");
            cmdText.Append("final_flag,operator,a.reason");
            cmdText.Append(" FROM protocol_init_list a left join barcode_list b on a.serial_no=b.serial_no ");
             cmdText.Append(" left join label_code c on b.code=c.code and b.model=c.model"); 
            cmdText.Append(" WHERE 1=1 ");
            cmdText.Append(" AND a.protocol_init_id=@protocol_init_id");
            return AdoTemplate.QueryForObjectDelegate<ProtocolInitInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                ProtocolInitInfo entity = new ProtocolInitInfo();
                entity.Model = Convert.ToString(reader["model"]);
                entity.SerialNo = Convert.ToString(reader["serial_no"]);
                entity.TypeLow= Convert.ToString(reader["type_low"]);
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
                entity.FreqRangeLow = Convert.ToString(reader["freq_range_low"]);
                entity.FreqRangeHigh = Convert.ToString(reader["freq_range_high"]);
                entity.ModeMaxPower = Convert.ToString(reader["mode_max_power"]);
                entity.RSSIOffSet = Convert.ToString(reader["rssi_offset"]);
                entity.PowerOffSet = Convert.ToString(reader["power_offset"]);
                entity.Aging = Convert.ToString(reader["aging"]);
                entity.FilterSwitch = Convert.ToString(reader["filter_switch"]);
                entity.MCUVersion = Convert.ToString(reader["mcu_version"]);
                entity.PartNum = Convert.ToString(reader["part_num"]);
                entity.IDNum = Convert.ToString(reader["id_num"]);
                entity.TxPllLow = Convert.ToString(reader["tx_pll_low"]);
                entity.RxPllLow = Convert.ToString(reader["rx_pll_low"]);
                entity.PaILow = Convert.ToString(reader["pa_i_low"]);
                entity.TxPowLow = Convert.ToString(reader["tx_pow_low"]);
                entity.Negative5VLow = Convert.ToString(reader["negative_5v_low"]);
                entity.TxIFLow= Convert.ToString(reader["tx_if_low"]);
                entity.TxPllHigh = Convert.ToString(reader["tx_pll_high"]);
                entity.RxPllHigh = Convert.ToString(reader["rx_pll_high"]);
                entity.PaIHigh = Convert.ToString(reader["pa_i_high"]);
                entity.TxPowHigh = Convert.ToString(reader["tx_pow_high"]);
                entity.Negative5VHigh = Convert.ToString(reader["negative_5v_high"]);

                entity.TxIFHigh = Convert.ToString(reader["tx_if_high"]);
                //entity.AtpcRange = Convert.ToString(reader["atpc_range"]);
                entity.RSSIAlarm= Convert.ToString(reader["rssi_alarm"]);
                entity.FactoryInfo = Convert.ToString(reader["factory_info"]);
                entity.Reason = Convert.ToString(reader["reason"]);
                return entity;
            }, paras.GetParameters());
        }
    }
}

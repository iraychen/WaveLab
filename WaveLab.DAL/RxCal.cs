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
    public class RxCal : AdoDaoSupport, IRxCal
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM  rx_cal_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

        public IList<RxCalInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" a.rx_cal_id,c.model,a.serial_no,a.station_no,a.ch_no,a.wg_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.reason,a.manual_input ");
            cmdText.Append(" FROM  rx_cal_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<RxCalInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                RxCalInfo item = new RxCalInfo();
                item.RxCalId = Convert.ToInt32(reader["rx_cal_id"]);
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
                item.StationNo = Convert.ToString(reader["station_no"]);
                item.CHNo = Convert.ToString(reader["ch_no"]);
                item.WGNo = Convert.ToString(reader["wg_no"]);
                item.AppVersion = Convert.ToString(reader["app_version"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                item.ManualInput = Convert.ToChar(reader["manual_input"]);
                item.Reason = Convert.ToString(reader["reason"]);
                return item;
            }, paras.GetParameters());
        }

        public IList<RxCalInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct a.rx_cal_id,c.model,a.serial_no,a.station_no,a.ch_no,a.wg_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.reason,a.manual_input ");
            cmdText.Append(" FROM  rx_cal_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<RxCalInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                RxCalInfo item = new RxCalInfo();
                item.RxCalId = Convert.ToInt32(reader["rx_cal_id"]);
             
                item.Model = Convert.ToString(reader["model"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
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
                item.StationNo = Convert.ToString(reader["station_no"]);
                item.CHNo = Convert.ToString(reader["ch_no"]);
                item.WGNo = Convert.ToString(reader["wg_no"]);
                item.AppVersion = Convert.ToString(reader["app_version"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                item.ManualInput = Convert.ToChar(reader["manual_input"]);
                item.Reason = Convert.ToString(reader["reason"]);
                return item;
            }, paras.GetParameters());
        }

        public RxCalInfo GetDetail(int rxCalId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("rx_cal_id").Type(DbType.Int32).Size(4).Value(rxCalId);

            StringBuilder rxCalRSSIDetCmdText = new StringBuilder();
            rxCalRSSIDetCmdText.Append(" SELECT rx_cal_id,data,rssi,voltage,address ");
            rxCalRSSIDetCmdText.Append(" FROM rx_cal_rssi_detect ");
            rxCalRSSIDetCmdText.Append(" WHERE rx_cal_id=@rx_cal_id");
            rxCalRSSIDetCmdText.Append(" ORDER BY cast(data as int)");

            IList<RxCalRSSIDetInfo> rxCalRSSIDetItems = AdoTemplate.QueryWithRowMapperDelegate<RxCalRSSIDetInfo>(CommandType.Text, rxCalRSSIDetCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                RxCalRSSIDetInfo item = new RxCalRSSIDetInfo();
                item.RxCalId = Convert.ToInt32(reader["rx_cal_id"]);
			
                if (reader["data"] == null)
                {
                    item.Data = null;
                }
                else
                {
                    item.Data = Convert.ToInt32(reader["data"]);
                }

                if (reader["rssi"] == null)
                {
                    item.RSSI= null;
                }
                else
                {
                    item.RSSI= Convert.ToInt32(reader["rssi"]);
                }
               
                if (reader["voltage"] == null)
                {
                    item.Voltage = null;
                }
                else
                {
                    item.Voltage = Convert.ToDouble(reader["voltage"]);
                }
                item.Address = Convert.ToString(reader["address"]);
                
                return item;
            }, paras.GetParameters());

            // Tx Calibrate
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct  c.model,a.serial_no,a.station_no,a.ch_no,a.wg_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.operator,a.reason,a.manual_input");
            cmdText.Append(" FROM  rx_cal_list a left join barcode_list b on a.serial_no=b.serial_no ");
            cmdText.Append(" left join label_code c on b.code=c.code and b.model=c.model");
          
            cmdText.Append(" WHERE 1=1 ");
            cmdText.Append(" AND a.rx_cal_id=@rx_cal_id");
            return AdoTemplate.QueryForObjectDelegate<RxCalInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                RxCalInfo entity = new RxCalInfo();
     
                entity.Model = Convert.ToString(reader["model"]);
                entity.SerialNo = Convert.ToString(reader["serial_no"]);
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
                entity.StationNo = Convert.ToString(reader["station_no"]);
                entity.CHNo = Convert.ToString(reader["ch_no"]);
                entity.WGNo = Convert.ToString(reader["wg_no"]);
                entity.AppVersion = Convert.ToString(reader["app_version"]);
                entity.FinalFlag = Convert.ToChar(reader["final_flag"]);
                entity.ManualInput = Convert.ToChar(reader["manual_input"]);
                entity.Reason = Convert.ToString(reader["reason"]);
                entity.RxCalRSSIDetItems = rxCalRSSIDetItems;
                return entity;
            }, paras.GetParameters());
        }
    }
}

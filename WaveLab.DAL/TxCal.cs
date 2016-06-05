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
    public class TxCal:AdoDaoSupport,ITxCal
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM  tx_cal_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

        public IList<TxCalInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" a.tx_cal_id,c.model,a.serial_no,a.station_no,a.ch_no,a.wg_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.reason,a.manual_input ");
            cmdText.Append(" FROM  tx_cal_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<TxCalInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                TxCalInfo item = new TxCalInfo();
                item.TxCalId = Convert.ToInt32(reader["tx_cal_id"]);
             
                item.Model = Convert.ToString(reader["model"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.StationNo = Convert.ToString(reader["station_no"]);
                item.CHNo = Convert.ToString(reader["ch_no"]);
                item.WGNo = Convert.ToString(reader["wg_no"]);
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
                item.ManualInput = Convert.ToChar(reader["manual_input"]);
                item.Reason = Convert.ToString(reader["reason"]);
                return item;
            }, paras.GetParameters());
        }

        public IList<TxCalInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct a.tx_cal_id,c.model,a.serial_no,a.station_no,a.ch_no,a.wg_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.reason,a.manual_input ");
            cmdText.Append(" FROM  tx_cal_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<TxCalInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                TxCalInfo item = new TxCalInfo();
                item.TxCalId = Convert.ToInt32(reader["tx_cal_id"]);
             
                item.Model = Convert.ToString(reader["model"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.StationNo = Convert.ToString(reader["station_no"]);
                item.CHNo = Convert.ToString(reader["ch_no"]);
                item.WGNo = Convert.ToString(reader["wg_no"]);
                if (reader["start_time"] != null)
                {
                    item.StartTime= Convert.ToDateTime(reader["start_time"]);
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
                item.ManualInput = Convert.ToChar(reader["manual_input"]);
                item.Reason = Convert.ToString(reader["reason"]);
                return item;
            }, paras.GetParameters());
        }

        public TxCalInfo GetDetail(int txCalId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("tx_cal_id").Type(DbType.Int32).Size(4).Value(txCalId);

            StringBuilder txCalTableCmdText = new StringBuilder();
            txCalTableCmdText.Append(" SELECT tpst_dbm,tpst_tx_pow_set_data,tpst_address,tpst_controled_voltage, ");
            txCalTableCmdText.Append(" tpdt_vref,tpdt_tx_pow,tpdt_voltage,tpst_address, ");
            txCalTableCmdText.Append(" channel_no,channel_out_data,channel_power,channel_address,channel_image_flag ");
            txCalTableCmdText.Append(" FROM tx_cal_table ");
            txCalTableCmdText.Append(" WHERE tx_cal_id=@tx_cal_id");
            txCalTableCmdText.Append(" ORDER BY cast(TPDT_Vref as int)");

            IList<TxCalTableInfo> txCalTableItems = AdoTemplate.QueryWithRowMapperDelegate<TxCalTableInfo>(CommandType.Text, txCalTableCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                TxCalTableInfo item = new TxCalTableInfo();

                //Tx Power Set Table			
                if (reader["tpst_dbm"] == null)
                {
                    item.TPSTDbm = null;
                }
                else
                {
                    item.TPSTDbm = Convert.ToInt32(reader["tpst_dbm"]);
                }

                if (reader["tpst_tx_pow_set_data"] == null)
                {
                    item.TPSTTxPowSetData  = null;
                }
                else
                {
                    item.TPSTTxPowSetData = (int)Convert.ToDouble(reader["tpst_tx_pow_set_data"]);
                }
                item.TPSTAddress = Convert.ToString(reader["tpst_address"]);
                if (reader["tpst_controled_voltage"] == null)
                {
                    item.TPSTControledVoltage = null;
                }
                else
                {
                    item.TPSTControledVoltage = Convert.ToDouble(reader["tpst_controled_voltage"]);
                }

                //Tx Power Detect Table
                if (reader["tpdt_vref"] == null)
                {
                    item.TPDTVref = null;
                }
                else
                {
                    item.TPDTVref = Convert.ToInt32(reader["tpdt_vref"]);
                }
                if (reader["tpdt_tx_pow"] == null)
                {
                    item.TPDTTxPow = null;
                }
                else
                {
                    item.TPDTTxPow = Convert.ToInt32(reader["tpdt_tx_pow"]);
                }
                if (reader["tpdt_voltage"] == null)
                {
                    item.TPDTVoltage = null;
                }
                else
                {
                    item.TPDTVoltage = Convert.ToDouble(reader["tpdt_voltage"]);
                }
                item.TPDTAddress = Convert.ToString(reader["tpst_address"]);

                //Channel 
                if (reader["channel_no"] == null)
                {
                    item.ChannelNo = null;
                }
                else
                {
                    item.ChannelNo = Convert.ToInt32(reader["channel_no"]);
                }
                if (reader["channel_out_data"] == null)
                {
                    item.ChannelOutData  = null;
                }
                else
                {
                    item.ChannelOutData  = Convert.ToInt32(reader["channel_out_data"]);
                }
                item.ChannelPower = Convert.ToString(reader["channel_power"]);
                item.ChannelAddress = Convert.ToString(reader["channel_address"]);
                item.ChannelImageFlag = Convert.ToChar(reader["channel_image_flag"]);
                return item;
            }, paras.GetParameters());

            // Tx Calibrate
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct c.model,a.serial_no,a.tuning_pot,a.station_no,a.ch_no,a.wg_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.operator,a.reason,a.manual_input ");
            cmdText.Append(" FROM  tx_cal_list a left join barcode_list b on a.serial_no=b.serial_no ");
            cmdText.Append(" left join label_code c on b.code=c.code and b.model=c.model");
          
            cmdText.Append(" WHERE 1=1 ");
            cmdText.Append(" AND a.tx_cal_id=@tx_cal_id");
            return AdoTemplate.QueryForObjectDelegate<TxCalInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                TxCalInfo entity = new TxCalInfo();
           
                entity.Model = Convert.ToString(reader["model"]);
                entity.SerialNo = Convert.ToString(reader["serial_no"]);
                entity.TuningPot = Convert.ToString(reader["tuning_pot"]);
                entity.StationNo = Convert.ToString(reader["station_no"]);
                entity.CHNo = Convert.ToString(reader["ch_no"]);
                entity.WGNo = Convert.ToString(reader["wg_no"]);
                if (reader["start_time"] != null)
                {
                    entity.StartTime= Convert.ToDateTime(reader["start_time"]);
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
                entity.ManualInput = Convert.ToChar(reader["manual_input"]);
                entity.Reason = Convert.ToString(reader["reason"]);
                entity.TxCalTableItems = txCalTableItems;
                return entity;
            }, paras.GetParameters());
        }
    }
}

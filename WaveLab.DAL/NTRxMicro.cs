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
    public class NTRxMicro : AdoDaoSupport, INTRxMicro
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM  ATS_NT_Rx_Micro_Vibration a left join barcode_list b on a.serial_no=b.serial_no ");
             cmdText.Append(" left join label_code c on b.code=c.code");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                   
                    case "model":
                         cmdText.Append(" AND upper(c.model) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "serial_no":
                        cmdText.Append(" AND upper(a.serial_no) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120)<= @" + entry.Key);
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<NTRxMicroInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" a.Micro_Vibration_PK,c.model,a.serial_no,a.station_no,a.ch_no,a.wg_no, a.reason,");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,final_flag");
            cmdText.Append(" FROM  ATS_NT_Rx_Micro_Vibration a left join barcode_list b on a.serial_no=b.serial_no ");
             cmdText.Append(" left join label_code c on b.code=c.code"); 

            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                   
                    case "model":
                         cmdText.Append(" AND upper(c.model) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "serial_no":
                        cmdText.Append(" AND upper(a.serial_no) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120)<= @" + entry.Key);
                        break;
                 
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            int startRowNum = (page - 1) * pageSize + 1;
            int endRowNum = startRowNum + pageSize - 1;

            cmdText.Append(" ) t_pager where rowindex between " + startRowNum.ToString() + " and " + endRowNum.ToString());

            return AdoTemplate.QueryWithRowMapperDelegate<NTRxMicroInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                NTRxMicroInfo item = new NTRxMicroInfo();
                item.NTRxMicroPK = Convert.ToInt32(reader["Micro_Vibration_PK"]);
              
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
                item.Reason = Convert.ToString(reader["reason"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                return item;
            }, paras.GetParameters());
        }

        public IList<NTRxMicroInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct a.Micro_Vibration_PK,c.model,a.serial_no,a.station_no,a.ch_no,a.wg_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,final_flag,a.Reason");
            cmdText.Append(" FROM  ATS_NT_Rx_Micro_Vibration a left join barcode_list b on a.serial_no=b.serial_no ");
             cmdText.Append(" left join label_code c on b.code=c.code"); 

            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    
                    case "model":
                         cmdText.Append(" AND upper(c.model) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "serial_no":
                        cmdText.Append(" AND upper(a.serial_no) like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120)<= @" + entry.Key);
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

            return AdoTemplate.QueryWithRowMapperDelegate<NTRxMicroInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                NTRxMicroInfo item = new NTRxMicroInfo();
                item.NTRxMicroPK = Convert.ToInt32(reader["Micro_Vibration_PK"]);
              
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
                    item.RunningTime = Convertor.Format(timeSpan);;
                }
                item.AppVersion = Convert.ToString(reader["app_version"]);
                item.FinalFlag = Convert.ToChar(reader["final_flag"]);
                return item;
            }, paras.GetParameters());
        }

        public NTRxMicroInfo GetDetail(int NTRxMicroPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Micro_Vibration_PK").Type(DbType.Int32).Size(4).Value(NTRxMicroPK);

            StringBuilder detailCmdText = new StringBuilder();
            detailCmdText.Append(" SELECT Micro_Vibration_PK,Mode ,CH,Local_Rx_Power,Local_SNR,Local_Rx_Power_Result ,Local_SNR_Result,Local_ES_Result ");
            detailCmdText.Append("  ,Remote_Rx_Power,Remote_SNR,Remote_Rx_Power_Result,Remote_SNR_Result ,Remote_ES_Result ");
            detailCmdText.Append(" FROM ATS_NT_Rx_Micro_Vibration_Val");
            detailCmdText.Append(" WHERE Micro_Vibration_PK=@Micro_Vibration_PK");
            detailCmdText.Append(" ORDER BY mode");

            IList<NTRxMicroDetailInfo> NTRxMicroDetailItems = AdoTemplate.QueryWithRowMapperDelegate<NTRxMicroDetailInfo>(CommandType.Text, detailCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                NTRxMicroDetailInfo item = new NTRxMicroDetailInfo();
                item.NTRxMicroPK = Convert.ToInt32(reader["Micro_Vibration_PK"]);
                item.Mode = Convert.ToString(reader["mode"]);
                item.CH = Convert.ToString(reader["ch"]);
                item.LocalRxPower = Convert.ToString(reader["Local_Rx_Power"]);
                item.LocalSNR = Convert.ToString(reader["Local_SNR"]);
                item.LocalRxPowerResult = Convert.ToString(reader["Local_Rx_Power_Result"]);
                item.LocalSNRResult = Convert.ToString(reader["Local_SNR_Result"]);
                item.LocalESResult = Convert.ToString(reader["Local_ES_Result"]);
                item.RemoteRxPower = Convert.ToString(reader["Remote_Rx_Power"]);
                item.RemoteSNR = Convert.ToString(reader["Remote_SNR"]);
                item.RemoteRxPowerResult = Convert.ToString(reader["Remote_Rx_Power_Result"]);
                item.RemoteSNRResult = Convert.ToString(reader["Remote_SNR_Result"]);
                item.RemoteESResult = Convert.ToString(reader["Remote_ES_Result"]);
                return item;
            }, paras.GetParameters());

       
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct c.model,a.serial_no,a.station_no,a.ch_no,a.wg_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.operator,a.reason");
            cmdText.Append(" FROM  ATS_NT_Rx_Micro_Vibration a left join barcode_list b on a.serial_no=b.serial_no ");
             cmdText.Append(" left join label_code c on b.code=c.code"); 
          
            cmdText.Append(" WHERE 1=1 ");
            cmdText.Append(" AND a.Micro_Vibration_PK=@Micro_Vibration_PK");
            return AdoTemplate.QueryForObjectDelegate<NTRxMicroInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                NTRxMicroInfo entity = new NTRxMicroInfo();
              
                entity.Model = Convert.ToString(reader["model"]);
                entity.SerialNo = Convert.ToString(reader["serial_no"]);
                entity.StationNo = Convert.ToString(reader["station_no"]);
                entity.CHNo = Convert.ToString(reader["ch_no"]);
                entity.WGNo = Convert.ToString(reader["wg_no"]);
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
                entity.Reason = Convert.ToString(reader["reason"]);
                entity.FinalFlag = Convert.ToChar(reader["final_flag"]);
                entity.Operator = Convert.ToString(reader["operator"]);
                entity.NTRxMicroDetailItems = NTRxMicroDetailItems;
                return entity;
            }, paras.GetParameters());
        }
    }
}

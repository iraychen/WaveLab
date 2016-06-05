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
    public class NTSensitivity:AdoDaoSupport, INTSensitivity
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM nt_sensitivity_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

        public IList<NTSensitivityInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" a.nt_sensitivity_id,c.model,a.serial_no,a.station_no,a.ch_no,a.wg_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,final_flag,a.reason");
            cmdText.Append(" FROM nt_sensitivity_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<NTSensitivityInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                NTSensitivityInfo item = new NTSensitivityInfo();
                item.NTSensitivityId = Convert.ToInt32(reader["nt_sensitivity_id"]);
             
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
                item.Reason = Convert.ToString(reader["reason"]);
                return item;
            }, paras.GetParameters());
        }

        public IList<NTSensitivityInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct a.nt_sensitivity_id,c.model,a.serial_no,a.station_no,a.ch_no,a.wg_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,final_flag,a.reason");
            cmdText.Append(" FROM nt_sensitivity_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<NTSensitivityInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                NTSensitivityInfo item = new NTSensitivityInfo();
                item.NTSensitivityId= Convert.ToInt32(reader["nt_sensitivity_id"]);
             
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
                item.Reason = Convert.ToString(reader["reason"]);
                return item;
            }, paras.GetParameters());
        }

        public NTSensitivityInfo GetDetail(int NTSensitivityId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("nt_sensitivity_id").Type(DbType.Int32).Size(4).Value(NTSensitivityId);

            StringBuilder NTSensitivityResultCmdText = new StringBuilder();
            NTSensitivityResultCmdText.Append(" SELECT mode,ch,upper_limit,upper_result,lower_limit,lower_result ");
            NTSensitivityResultCmdText.Append(" FROM nt_sensitivity_result ");
            NTSensitivityResultCmdText.Append(" WHERE nt_sensitivity_id=@nt_sensitivity_id");
            NTSensitivityResultCmdText.Append(" ORDER BY mode,cast(ch as float)");

            IList<NTSensitivityResultInfo> NTSensitivityResultItems = AdoTemplate.QueryWithRowMapperDelegate<NTSensitivityResultInfo>(CommandType.Text, NTSensitivityResultCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                NTSensitivityResultInfo item = new NTSensitivityResultInfo();
                item.Mode = Convert.ToString(reader["mode"]);
                item.CH = Convert.ToString(reader["ch"]);
                item.UpperLimit= Convert.ToString(reader["upper_limit"]);
                item.UpperResult = Convert.ToString(reader["upper_result"]);
                item.LowerLimit = Convert.ToString(reader["lower_limit"]);
                item.LowerResult = Convert.ToString(reader["lower_result"]);
                return item;
            }, paras.GetParameters());

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct c.model,a.serial_no,a.station_no,a.ch_no,a.wg_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.operator,a.reason");
            cmdText.Append(" FROM nt_sensitivity_list a left join barcode_list b on a.serial_no=b.serial_no ");
             cmdText.Append(" left join label_code c on b.code=c.code and b.model=c.model"); 
          
            cmdText.Append(" WHERE 1=1 ");
            cmdText.Append(" AND a.nt_sensitivity_id=@nt_sensitivity_id");
            return AdoTemplate.QueryForObjectDelegate<NTSensitivityInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                NTSensitivityInfo entity = new NTSensitivityInfo();
        
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
                entity.FinalFlag = Convert.ToChar(reader["final_flag"]);
                entity.Operator = Convert.ToString(reader["operator"]);
                entity.Reason = Convert.ToString(reader["reason"]);
                entity.NTSensitivityResultItems = NTSensitivityResultItems;
                return entity;
            }, paras.GetParameters());
        }
    }
}

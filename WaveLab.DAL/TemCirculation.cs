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
    public class TemCirculation : AdoDaoSupport, ITemCirculation
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM tem_circulation_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

        public IList<TemCirculationInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" a.tem_circulation_id,c.model,a.serial_no,a.station_no,a.ch_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.reason ");
            cmdText.Append(" FROM tem_circulation_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<TemCirculationInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                TemCirculationInfo item = new TemCirculationInfo();
                item.TemCirculationId = Convert.ToInt32(reader["tem_circulation_id"]);
                item.Model = Convert.ToString(reader["model"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.StationNo = Convert.ToString(reader["station_no"]);
                item.CHNo = Convert.ToString(reader["ch_no"]);
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

        public IList<TemCirculationInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct a.tem_circulation_id,d.orderno,c.code,c.model,a.serial_no,a.station_no,a.ch_no, ");
            cmdText.Append(" a.start_time,a.end_time,a.app_version,a.final_flag,a.reason ");
            cmdText.Append(" FROM tem_circulation_list a left join barcode_list b on a.serial_no=b.serial_no ");
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

            return AdoTemplate.QueryWithRowMapperDelegate<TemCirculationInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                TemCirculationInfo item = new TemCirculationInfo();
                item.TemCirculationId = Convert.ToInt32(reader["tem_circulation_id"]);
                item.Model = Convert.ToString(reader["model"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.StationNo = Convert.ToString(reader["station_no"]);
                item.CHNo = Convert.ToString(reader["ch_no"]);
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

        public TemCirculationInfo GetDetail(int temCirculationId)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("tem_circulation_id").Type(DbType.Int32).Size(4).Value(temCirculationId);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT distinct c.model,a.serial_no ,end_time,");
            cmdText.Append("es,ses,ais,fec_cor_byte_cnt,fec_uncor_block_cnt,ms_rdi,r_los,tu_ais,radio_rsl_low,radio_rsl_high,radio_tsl_low,radio_tsl_high,radio_mute,");
            cmdText.Append("power_alm,hard_bad ,temp_alarm ,if_inpwr_abn ,bd_status ,hp_rdi,r_loc,r_oof,r_lof,mw_fec_uncor,mw_lof,");
	        cmdText.Append("curtx_power,maxcurtx_power,mincurtx_power,maxtx_power,mintx_power,qpsk_setpower,qpsk_power,currx_power,maxcurrx_power,");
	        cmdText.Append("mincurrx_power,maxrx_power ,minrx_power ,mode,businese,idu_type ,station_no ,ch_no,start_time,app_version,a.final_flag,a.reason,operator ");
            cmdText.Append(" FROM tem_circulation_list a left join barcode_list b on a.serial_no=b.serial_no ");
             cmdText.Append(" left join label_code c on b.code=c.code and b.model=c.model");
            cmdText.Append(" WHERE 1=1 ");
            cmdText.Append(" AND a.tem_circulation_id=@tem_circulation_id");
            return AdoTemplate.QueryForObjectDelegate<TemCirculationInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                TemCirculationInfo entity = new TemCirculationInfo();
                entity.Model = Convert.ToString(reader["model"]);
                entity.SerialNo = Convert.ToString(reader["serial_no"]);
                entity.StationNo = Convert.ToString(reader["station_no"]);
                entity.CHNo = Convert.ToString(reader["ch_no"]);
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

                entity.FecCorByteCnt = Convert.ToString(reader["fec_cor_byte_cnt"]);
                entity.FecUncorBlockCnt = Convert.ToString(reader["fec_uncor_block_cnt"]);
                entity.MSRDI = Convert.ToString(reader["ms_rdi"]);
                entity.RLOS = Convert.ToString(reader["r_los"]);
                entity.TUAIS = Convert.ToString(reader["tu_ais"]);
                entity.RadioRslLow = Convert.ToString(reader["radio_rsl_low"]);
                entity.RadioRslHigh = Convert.ToString(reader["radio_rsl_high"]);
                entity.RadioTslLow = Convert.ToString(reader["radio_tsl_low"]);
                entity.RadioTslHigh = Convert.ToString(reader["radio_tsl_high"]);
                entity.RADIOMUTE = Convert.ToString(reader["radio_mute"]);
                entity.POWERALM = Convert.ToString(reader["power_alm"]);
                entity.HARDBAD = Convert.ToString(reader["hard_bad"]);
                entity.TEMPALARM = Convert.ToString(reader["temp_alarm"]);
                entity.IFINPWRABN = Convert.ToString(reader["if_inpwr_abn"]);
                entity.BDSTATUS = Convert.ToString(reader["bd_status"]);
                entity.HPRDI = Convert.ToString(reader["hp_rdi"]);
                entity.RLOC = Convert.ToString(reader["r_loc"]);
                entity.ROOF = Convert.ToString(reader["r_oof"]);
                entity.RLOF = Convert.ToString(reader["r_lof"]);
                entity.MWFECUNCOR = Convert.ToString(reader["mw_fec_uncor"]);
                entity.MWLOF = Convert.ToString(reader["mw_lof"]);

                entity.CurTXPower = Convert.ToString(reader["curtx_power"]);
                entity.MaxCurTXPower = Convert.ToString(reader["maxcurtx_power"]);
                entity.MinTXPower = Convert.ToString(reader["mincurtx_power"]);
                entity.MaxTXPower = Convert.ToString(reader["maxtx_power"]);
                entity.MinTXPower = Convert.ToString(reader["mintx_power"]);
                entity.QPSKSetPower = Convert.ToString(reader["qpsk_setpower"]);
                entity.QPSKPower = Convert.ToString(reader["qpsk_power"]);
                entity.CurRXPower = Convert.ToString(reader["currx_power"]);
                entity.MaxCurRXPower = Convert.ToString(reader["maxcurrx_power"]);
                entity.MinRXPower = Convert.ToString(reader["mincurrx_power"]);
                entity.MaxRXPower = Convert.ToString(reader["maxrx_power"]);
                entity.MinRXPower = Convert.ToString(reader["minrx_power"]);

                entity.Mode = Convert.ToString(reader["mode"]);
                entity.Businese = Convert.ToString(reader["businese"]);
                entity.IDUType = Convert.ToString(reader["idu_type"]);

                entity.AppVersion = Convert.ToString(reader["app_version"]);
                entity.FinalFlag = Convert.ToChar(reader["final_flag"]);
                entity.Reason = Convert.ToString(reader["reason"]);
                return entity;
            }, paras.GetParameters());
        }
    }
}

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
    public class MIMeasureData : AdoDaoSupport,IMIMeasureData
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct count(*) ");
            cmdText.Append(" FROM  mi_measure_data_list a,barcode_list b,ext_sn_list c");
            cmdText.Append(" WHERE a.serial_no=b.serial_no ");
            cmdText.Append(" AND b.barcode=c.barcode");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "order_no":
                        cmdText.Append(" AND upper(c.orderno) = upper(@" + entry.Key + ")");
                        break;
                    case "code":
                        cmdText.Append(" AND upper(c.meterialno) = upper(@" + entry.Key + ")");
                        break;
                    case "model":
                        cmdText.Append(" AND upper(c.description) = upper(@" + entry.Key + ")");
                        break;
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120)<= @" + entry.Key);
                        break;
                    case "serial_no":
                        cmdText.Append(" AND upper(a." + entry.Key + ") = upper(@" + entry.Key + ")");
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<MIMeasureDataInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " +sortBy +" "+orderBy+ " ) ,");
            cmdText.Append(" a.mi_measure_data_id,c.orderno,c.meterialno,c.description,a.serial_no,a.last_update_date ");
            cmdText.Append(" FROM  mi_measure_data_list a,barcode_list b,ext_sn_list c");
            cmdText.Append(" WHERE a.serial_no=b.serial_no ");
            cmdText.Append(" AND b.barcode=c.barcode");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "order_no":
                        cmdText.Append(" AND upper(c.orderno) = upper(@" + entry.Key + ")");
                        break;
                    case "code":
                        cmdText.Append(" AND upper(c.meterialno) = upper(@" + entry.Key + ")");
                        break;
                    case "model":
                        cmdText.Append(" AND upper(c.description) = upper(@" + entry.Key + ")");
                        break;
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),a.end_time,120)<= @" + entry.Key);
                        break;
                    case "serial_no":
                        cmdText.Append(" AND upper(a." + entry.Key + ") = upper(@" + entry.Key + ")");
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            int startRowNum = (page - 1) * pageSize + 1;
            int endRowNum = startRowNum + pageSize - 1;

            cmdText.Append(" ) t_pager where rowindex between " + startRowNum.ToString() + " and " + endRowNum.ToString());

            return AdoTemplate.QueryWithRowMapperDelegate<MIMeasureDataInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                MIMeasureDataInfo item = new MIMeasureDataInfo();
                item.MIMeasureDataID= Convert.ToInt32(reader["mi_measure_data_id"]);
                item.OrderNo = Convert.ToString(reader["orderno"]);
                item.Code = Convert.ToString(reader["meterialno"]);
                item.Model = Convert.ToString(reader["description"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                item.LastUpdateDate = Convert.ToDateTime(reader["last_update_date"]);
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string serialNo)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from mi_measure_data_list where upper(serial_no)=upper(@serial_no)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("serial_no").Type(DbType.String).Size(50).Value(serialNo);

            int recordCount = (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            if (recordCount > 0)
            {
                retVal = true;
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        public void Save(MIMeasureDataInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" INSERT INTO MI_MEASURE_DATA_LIST ");
            cmdText.Append(" ( ");
            cmdText.Append(" SERIAL_NO,");

            cmdText.Append(" RSSI_R1_MODE,RSSI_R1_N20_POWER,RSSI_R1_N30_POWER,RSSI_R1_N40_POWER,RSSI_R1_N50_POWER,RSSI_R1_N60_POWER,RSSI_R1_N70_POWER,RSSI_R1_N80_POWER,RSSI_R1_N90_POWER,");
            cmdText.Append(" RSSI_R2_MODE,RSSI_R2_N20_POWER,RSSI_R2_N30_POWER,RSSI_R2_N40_POWER,RSSI_R2_N50_POWER,RSSI_R2_N60_POWER,RSSI_R2_N70_POWER,RSSI_R2_N80_POWER,RSSI_R2_N90_POWER,");
            cmdText.Append(" RSSI_FINAL_FLAG,RSSI_OPERATOR,RSSI_TEST_TIME,");
           
            cmdText.Append(" SNR_MODE,SNR_LOCAL_LEFT,SNR_IF_POINT,SNR_LOCAL_RIGHT,");
            cmdText.Append(" SNR_FINAL_FLAG,SNR_OPERATOR,SNR_TEST_TIME,");

            cmdText.Append(" MICRO_VIBRATION_MODE,MICRO_VIBRATION_ERROR_COUNT,");
            cmdText.Append(" MICRO_VIBRATION_FINAL_FLAG,MICRO_VIBRATION_OPERATOR,MICRO_VIBRATION_TEST_TIME,");

            cmdText.Append(" AGC_M_MODE,AGC_M_R1_CHANNEL,AGC_M_R1_UPPER_LIMIT,AGC_M_R1_UPPER_ATTENUATION,AGC_M_R1_LOWER_LIMIT,AGC_M_R1_LOWER_ATTENUATION,");
            cmdText.Append(" AGC_M_R2_CHANNEL,AGC_M_R2_UPPER_LIMIT,AGC_M_R2_UPPER_ATTENUATION,AGC_M_R2_LOWER_LIMIT,AGC_M_R2_LOWER_ATTENUATION,");
            cmdText.Append(" AGC_M_FINAL_FLAG,AGC_M_OPERATOR,AGC_M_TEST_TIME,");

            cmdText.Append(" AGC_IPR_MODE,AGC_IPR_R1_CHANNEL,AGC_IPR_R1_UPPER_LIMIT,AGC_IPR_R1_LOWER_LIMIT,AGC_IPR_R2_CHANNEL,AGC_IPR_R2_UPPER_LIMIT,AGC_IPR_R2_LOWER_LIMIT,AGC_IPR_R3_CHANNEL,AGC_IPR_R3_UPPER_LIMIT,AGC_IPR_R3_LOWER_LIMIT,");
            cmdText.Append(" AGC_IPR_FINAL_FLAG,AGC_IPR_OPERATOR,AGC_IPR_TEST_TIME,");

            cmdText.Append(" AGC_XCR_R1_MODE,AGC_XCR_R1_CHANNEL,AGC_XCR_R1_UPPER_LIMIT,AGC_XCR_R1_LOWER_LIMIT,AGC_XCR_R2_MODE,AGC_XCR_R2_CHANNEL,AGC_XCR_R2_UPPER_LIMIT,AGC_XCR_R2_LOWER_LIMIT,");
            cmdText.Append(" AGC_XCR_FINAL_FLAG,AGC_XCR_OPERATOR,AGC_XCR_TEST_TIME,");

            cmdText.Append(" AIRTIGHT,AIRTIGHT_FINAL_FLAG,AIRTIGHT_OPERATOR,AIRTIGHT_TEST_TIME,");

            cmdText.Append(" TEM_G3XMC_MODE,TEM_G3XMC_ERROR_NO,TEM_G3XMC_ERROR_SECONDS,TEM_G3XMC_AIS,");
            cmdText.Append(" TEM_G3XMC_FINAL_FLAG,TEM_G3XMC_OPERATOR,TEM_G3XMC_TEST_TIME,");

            cmdText.Append(" TEM_PTN_MODE,TEM_PTN_LOSS_RATE,TEM_PTN_ERROR_SECONDS,");
            cmdText.Append(" TEM_PTN_FINAL_FLAG,TEM_PTN_OPERATOR,TEM_PTN_TEST_TIME,");

            cmdText.Append(" TEM_OML_6101_LOSS_RATE,TEM_OML_6101_FINAL_FLAG,TEM_OML_6101_OPERATOR,TEM_OML_6101_TEST_TIME,");
            cmdText.Append(" TEM_OML_6205_TOTAL_ERROR,TEM_OML_6205_FINAL_FLAG,TEM_OML_6205_OPERATOR,TEM_OML_6205_TEST_TIME,");
            cmdText.Append(" TEM_OML_6202_TOTAL_ERROR,TEM_OML_6202_FINAL_FLAG,TEM_OML_6202_OPERATOR,TEM_OML_6202_TEST_TIME,");

            cmdText.Append(" FTC_MODE,FTC_ERROR_COUNT,FTC_ERROR_SECONDS,FTC_AIS,");
            cmdText.Append(" FTC_FINAL_FLAG,FTC_OPERATOR,FTC_TEST_TIME,");

            cmdText.Append(" LAST_UPDATE_DATE,LAST_UPDATED_BY");
            cmdText.Append(" ) ");
            cmdText.Append(" VALUES");
            cmdText.Append(" ( ");
            cmdText.Append(" @SERIAL_NO,");
            cmdText.Append(" @RSSI_R1_MODE,@RSSI_R1_N20_POWER,@RSSI_R1_N30_POWER,@RSSI_R1_N40_POWER,@RSSI_R1_N50_POWER,@RSSI_R1_N60_POWER,@RSSI_R1_N70_POWER,@RSSI_R1_N80_POWER,@RSSI_R1_N90_POWER,");
            cmdText.Append(" @RSSI_R2_MODE,@RSSI_R2_N20_POWER,@RSSI_R2_N30_POWER,@RSSI_R2_N40_POWER,@RSSI_R2_N50_POWER,@RSSI_R2_N60_POWER,@RSSI_R2_N70_POWER,@RSSI_R2_N80_POWER,@RSSI_R2_N90_POWER,");
            cmdText.Append(" @RSSI_FINAL_FLAG,@RSSI_OPERATOR,@RSSI_TEST_TIME,");

            cmdText.Append(" @SNR_MODE,@SNR_LOCAL_LEFT,@SNR_IF_POINT,@SNR_LOCAL_RIGHT,");
            cmdText.Append(" @SNR_FINAL_FLAG,@SNR_OPERATOR,@SNR_TEST_TIME,");

            cmdText.Append(" @MICRO_VIBRATION_MODE,@MICRO_VIBRATION_ERROR_COUNT,");
            cmdText.Append(" @MICRO_VIBRATION_FINAL_FLAG,@MICRO_VIBRATION_OPERATOR,@MICRO_VIBRATION_TEST_TIME,");

            cmdText.Append(" @AGC_M_MODE,@AGC_M_R1_CHANNEL,@AGC_M_R1_UPPER_LIMIT,@AGC_M_R1_UPPER_ATTENUATION,@AGC_M_R1_LOWER_LIMIT,@AGC_M_R1_LOWER_ATTENUATION,");
            cmdText.Append(" @AGC_M_R2_CHANNEL,@AGC_M_R2_UPPER_LIMIT,@AGC_M_R2_UPPER_ATTENUATION,@AGC_M_R2_LOWER_LIMIT,@AGC_M_R2_LOWER_ATTENUATION,");
            cmdText.Append(" @AGC_M_FINAL_FLAG,@AGC_M_OPERATOR,@AGC_M_TEST_TIME,");

            cmdText.Append(" @AGC_IPR_MODE,@AGC_IPR_R1_CHANNEL,@AGC_IPR_R1_UPPER_LIMIT,@AGC_IPR_R1_LOWER_LIMIT,@AGC_IPR_R2_CHANNEL,@AGC_IPR_R2_UPPER_LIMIT,@AGC_IPR_R2_LOWER_LIMIT,@AGC_IPR_R3_CHANNEL,@AGC_IPR_R3_UPPER_LIMIT,@AGC_IPR_R3_LOWER_LIMIT,");
            cmdText.Append(" @AGC_IPR_FINAL_FLAG,@AGC_IPR_OPERATOR,@AGC_IPR_TEST_TIME,");

            cmdText.Append(" @AGC_XCR_R1_MODE,@AGC_XCR_R1_CHANNEL,@AGC_XCR_R1_UPPER_LIMIT,@AGC_XCR_R1_LOWER_LIMIT,@AGC_XCR_R2_MODE,@AGC_XCR_R2_CHANNEL,@AGC_XCR_R2_UPPER_LIMIT,@AGC_XCR_R2_LOWER_LIMIT,");
            cmdText.Append(" @AGC_XCR_FINAL_FLAG,@AGC_XCR_OPERATOR,@AGC_XCR_TEST_TIME,");

            cmdText.Append(" @AIRTIGHT,@AIRTIGHT_FINAL_FLAG,@AIRTIGHT_OPERATOR,@AIRTIGHT_TEST_TIME,");

            cmdText.Append(" @TEM_G3XMC_MODE,@TEM_G3XMC_ERROR_NO,@TEM_G3XMC_ERROR_SECONDS,@TEM_G3XMC_AIS,");
            cmdText.Append(" @TEM_G3XMC_FINAL_FLAG,@TEM_G3XMC_OPERATOR,@TEM_G3XMC_TEST_TIME,");

            cmdText.Append(" @TEM_PTN_MODE,@TEM_PTN_LOSS_RATE,@TEM_PTN_ERROR_SECONDS,");
            cmdText.Append(" @TEM_PTN_FINAL_FLAG,@TEM_PTN_OPERATOR,@TEM_PTN_TEST_TIME,");

            cmdText.Append(" @TEM_OML_6101_LOSS_RATE,@TEM_OML_6101_FINAL_FLAG,@TEM_OML_6101_OPERATOR,@TEM_OML_6101_TEST_TIME,");
            cmdText.Append(" @TEM_OML_6205_TOTAL_ERROR,@TEM_OML_6205_FINAL_FLAG,@TEM_OML_6205_OPERATOR,@TEM_OML_6205_TEST_TIME,");
            cmdText.Append(" @TEM_OML_6202_TOTAL_ERROR,@TEM_OML_6202_FINAL_FLAG,@TEM_OML_6202_OPERATOR,@TEM_OML_6202_TEST_TIME,");

            cmdText.Append(" @FTC_MODE,@FTC_ERROR_COUNT,@FTC_ERROR_SECONDS,@FTC_AIS,");
            cmdText.Append(" @FTC_FINAL_FLAG,@FTC_OPERATOR,@FTC_TEST_TIME,");

            cmdText.Append(" @LAST_UPDATE_DATE,@LAST_UPDATED_BY");
            cmdText.Append(" ) ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("SERIAL_NO").Type(DbType.String).Size(50).Value(entity.SerialNo);

            paras.Create().Name("RSSI_R1_MODE").Type(DbType.String).Size(50).Value(entity.RSSIR1Mode);
            paras.Create().Name("RSSI_R1_N20_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N20Power);
            paras.Create().Name("RSSI_R1_N30_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N30Power);
            paras.Create().Name("RSSI_R1_N40_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N40Power);
            paras.Create().Name("RSSI_R1_N50_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N50Power);
            paras.Create().Name("RSSI_R1_N60_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N60Power);
            paras.Create().Name("RSSI_R1_N70_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N70Power);
            paras.Create().Name("RSSI_R1_N80_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N80Power);
            paras.Create().Name("RSSI_R1_N90_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N90Power);
            paras.Create().Name("RSSI_R2_MODE").Type(DbType.String).Size(50).Value(entity.RSSIR2Mode);
            paras.Create().Name("RSSI_R2_N20_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N20Power);
            paras.Create().Name("RSSI_R2_N30_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N30Power);
            paras.Create().Name("RSSI_R2_N40_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N40Power);
            paras.Create().Name("RSSI_R2_N50_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N50Power);
            paras.Create().Name("RSSI_R2_N60_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N60Power);
            paras.Create().Name("RSSI_R2_N70_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N70Power);
            paras.Create().Name("RSSI_R2_N80_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N80Power);
            paras.Create().Name("RSSI_R2_N90_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N90Power);
            paras.Create().Name("RSSI_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.RSSIFinalFlag);
            paras.Create().Name("RSSI_OPERATOR").Type(DbType.String).Size(50).Value(entity.RSSIOperator);
            paras.Create().Name("RSSI_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.RSSITestTime);

            paras.Create().Name("SNR_MODE").Type(DbType.String).Size(50).Value(entity.SNRMode);
            paras.Create().Name("SNR_LOCAL_LEFT").Type(DbType.String).Size(50).Value(entity.SNRLocalLeft);
            paras.Create().Name("SNR_IF_POINT").Type(DbType.String).Size(50).Value(entity.SNRIFPoint);
            paras.Create().Name("SNR_LOCAL_RIGHT").Type(DbType.String).Size(50).Value(entity.SNRLocalRight);
            paras.Create().Name("SNR_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.SNRFinalFlag);
            paras.Create().Name("SNR_OPERATOR").Type(DbType.String).Size(50).Value(entity.SNROperator);
            paras.Create().Name("SNR_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.SNRTestTime);

            paras.Create().Name("MICRO_VIBRATION_MODE").Type(DbType.String).Size(50).Value(entity.MicroVibrationMode);
            paras.Create().Name("MICRO_VIBRATION_ERROR_COUNT").Type(DbType.String).Size(50).Value(entity.MicroVibrationErrorCount);
            paras.Create().Name("MICRO_VIBRATION_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.MicroVibrationFinalFlag);
            paras.Create().Name("MICRO_VIBRATION_OPERATOR").Type(DbType.String).Size(50).Value(entity.MicroVibrationOperator);
            paras.Create().Name("MICRO_VIBRATION_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.MicroVibrationTestTime);

            paras.Create().Name("AGC_M_MODE").Type(DbType.String).Size(50).Value(entity.AGCMMode);
            paras.Create().Name("AGC_M_R1_CHANNEL").Type(DbType.String).Size(50).Value(entity.AGCMR1Channel);
            paras.Create().Name("AGC_M_R1_UPPER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCMR1UpperLimit);
            paras.Create().Name("AGC_M_R1_UPPER_ATTENUATION").Type(DbType.String).Size(50).Value(entity.AGCMR1UpperAttenuation);
            paras.Create().Name("AGC_M_R1_LOWER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCMR1LowerLimit);
            paras.Create().Name("AGC_M_R1_LOWER_ATTENUATION").Type(DbType.String).Size(50).Value(entity.AGCMR1LowerAttenuation);
            paras.Create().Name("AGC_M_R2_CHANNEL").Type(DbType.String).Size(50).Value(entity.AGCMR2Channel);
            paras.Create().Name("AGC_M_R2_UPPER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCMR2UpperLimit);
            paras.Create().Name("AGC_M_R2_UPPER_ATTENUATION").Type(DbType.String).Size(50).Value(entity.AGCMR2UpperAttenuation);
            paras.Create().Name("AGC_M_R2_LOWER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCMR2LowerLimit);
            paras.Create().Name("AGC_M_R2_LOWER_ATTENUATION").Type(DbType.String).Size(50).Value(entity.AGCMR2LowerAttenuation);
            paras.Create().Name("AGC_M_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.AGCMFinalFlag);
            paras.Create().Name("AGC_M_OPERATOR").Type(DbType.String).Size(50).Value(entity.AGCMOperator);
            paras.Create().Name("AGC_M_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.AGCMTestTime);

            paras.Create().Name("AGC_IPR_MODE").Type(DbType.String).Size(50).Value(entity.AGCIPRMode);
            paras.Create().Name("AGC_IPR_R1_CHANNEL").Type(DbType.String).Size(50).Value(entity.AGCIPRR1Channel);
            paras.Create().Name("AGC_IPR_R1_UPPER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCIPRR1UpperLimit);
            paras.Create().Name("AGC_IPR_R1_LOWER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCIPRR1LowerLimit);
            paras.Create().Name("AGC_IPR_R2_CHANNEL").Type(DbType.String).Size(50).Value(entity.AGCIPRR2Channel);
            paras.Create().Name("AGC_IPR_R2_UPPER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCIPRR2UpperLimit);
            paras.Create().Name("AGC_IPR_R2_LOWER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCIPRR2LowerLimit);
            paras.Create().Name("AGC_IPR_R3_CHANNEL").Type(DbType.String).Size(50).Value(entity.AGCIPRR3Channel);
            paras.Create().Name("AGC_IPR_R3_UPPER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCIPRR3UpperLimit);
            paras.Create().Name("AGC_IPR_R3_LOWER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCIPRR3LowerLimit);
            paras.Create().Name("AGC_IPR_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.AGCIPRFinalFlag);
            paras.Create().Name("AGC_IPR_OPERATOR").Type(DbType.String).Size(50).Value(entity.AGCIPROperator);
            paras.Create().Name("AGC_IPR_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.AGCIPRTestTime);

            paras.Create().Name("AGC_XCR_R1_MODE").Type(DbType.String).Size(50).Value(entity.AGCXCRR1Mode);
            paras.Create().Name("AGC_XCR_R1_CHANNEL").Type(DbType.String).Size(50).Value(entity.AGCXCRR1Channel);
            paras.Create().Name("AGC_XCR_R1_UPPER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCXCRR1UpperLimit);
            paras.Create().Name("AGC_XCR_R1_LOWER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCXCRR1LowerLimit);
            paras.Create().Name("AGC_XCR_R2_MODE").Type(DbType.String).Size(50).Value(entity.AGCXCRR2Mode);
            paras.Create().Name("AGC_XCR_R2_CHANNEL").Type(DbType.String).Size(50).Value(entity.AGCXCRR2Channel);
            paras.Create().Name("AGC_XCR_R2_UPPER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCXCRR2UpperLimit);
            paras.Create().Name("AGC_XCR_R2_LOWER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCXCRR2LowerLimit);
            paras.Create().Name("AGC_XCR_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.AGCXCRFinalFlag);
            paras.Create().Name("AGC_XCR_OPERATOR").Type(DbType.String).Size(50).Value(entity.AGCXCROperator);
            paras.Create().Name("AGC_XCR_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.AGCXCRTestTime);

            paras.Create().Name("AIRTIGHT").Type(DbType.String).Size(50).Value(entity.Airtight);
            paras.Create().Name("AIRTIGHT_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.AirtightFinalFlag);
            paras.Create().Name("AIRTIGHT_OPERATOR").Type(DbType.String).Size(50).Value(entity.AirtightOperator);
            paras.Create().Name("AIRTIGHT_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.AirtightTestTime);

            paras.Create().Name("TEM_G3XMC_MODE").Type(DbType.String).Size(50).Value(entity.TemG3XMCMode);
            paras.Create().Name("TEM_G3XMC_ERROR_NO").Type(DbType.String).Size(50).Value(entity.TemG3XMCErrorNo);
            paras.Create().Name("TEM_G3XMC_ERROR_SECONDS").Type(DbType.String).Size(50).Value(entity.TemG3XMCErrorSeconds);
            paras.Create().Name("TEM_G3XMC_AIS").Type(DbType.String).Size(50).Value(entity.TemG3XMCAIS);
            paras.Create().Name("TEM_G3XMC_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.TemG3XMCFinalFlag);
            paras.Create().Name("TEM_G3XMC_OPERATOR").Type(DbType.String).Size(50).Value(entity.TemG3XMCOperator);
            paras.Create().Name("TEM_G3XMC_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.TemG3XMCTestTime);

            paras.Create().Name("TEM_PTN_MODE").Type(DbType.String).Size(50).Value(entity.TemPTNMode);
            paras.Create().Name("TEM_PTN_LOSS_RATE").Type(DbType.String).Size(50).Value(entity.TemPTNLossRate);
            paras.Create().Name("TEM_PTN_ERROR_SECONDS").Type(DbType.String).Size(50).Value(entity.TemPTNErrorSeconds);
            paras.Create().Name("TEM_PTN_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.TemPTNFinalFlag);
            paras.Create().Name("TEM_PTN_OPERATOR").Type(DbType.String).Size(50).Value(entity.TemPTNOperator);
            paras.Create().Name("TEM_PTN_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.TemPTNTestTime);

            paras.Create().Name("TEM_OML_6101_LOSS_RATE").Type(DbType.String).Size(50).Value(entity.TemOML6101LossRate);
            paras.Create().Name("TEM_OML_6101_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.TemOML6101FinalFlag);
            paras.Create().Name("TEM_OML_6101_OPERATOR").Type(DbType.String).Size(50).Value(entity.TemOML6101Operator);
            paras.Create().Name("TEM_OML_6101_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.TemOML6101TestTime);

            paras.Create().Name("TEM_OML_6205_TOTAL_ERROR").Type(DbType.String).Size(50).Value(entity.TemOML6205TotalError);
            paras.Create().Name("TEM_OML_6205_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.TemOML6205FinalFlag);
            paras.Create().Name("TEM_OML_6205_OPERATOR").Type(DbType.String).Size(50).Value(entity.TemOML6205Operator);
            paras.Create().Name("TEM_OML_6205_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.TemOML6205TestTime);

            paras.Create().Name("TEM_OML_6202_TOTAL_ERROR").Type(DbType.String).Size(50).Value(entity.TemOML6202TotalError);
            paras.Create().Name("TEM_OML_6202_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.TemOML6202FinalFlag);
            paras.Create().Name("TEM_OML_6202_OPERATOR").Type(DbType.String).Size(50).Value(entity.TemOML6202Operator);
            paras.Create().Name("TEM_OML_6202_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.TemOML6202TestTime);


            paras.Create().Name("FTC_MODE").Type(DbType.String).Size(50).Value(entity.FTCMode);
            paras.Create().Name("FTC_ERROR_COUNT").Type(DbType.String).Size(50).Value(entity.FTCErrorCount);
            paras.Create().Name("FTC_ERROR_SECONDS").Type(DbType.String).Size(50).Value(entity.FTCErrorSeconds);
            paras.Create().Name("FTC_AIS").Type(DbType.String).Size(50).Value(entity.FTCAIS);
            paras.Create().Name("FTC_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.FTCFinalFlag);
            paras.Create().Name("FTC_OPERATOR").Type(DbType.String).Size(50).Value(entity.FTCOperator);
            paras.Create().Name("FTC_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.FTCTestTime);

            paras.Create().Name("LAST_UPDATE_DATE").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("LAST_UPDATED_BY").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public MIMeasureDataInfo GetDetail(int MIMeasureDataId)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT MI_MEASURE_DATA_ID,SERIAL_NO,");

            cmdText.Append(" RSSI_R1_MODE,RSSI_R1_N20_POWER,RSSI_R1_N30_POWER,RSSI_R1_N40_POWER,RSSI_R1_N50_POWER,RSSI_R1_N60_POWER,RSSI_R1_N70_POWER,RSSI_R1_N80_POWER,RSSI_R1_N90_POWER,");
            cmdText.Append(" RSSI_R2_MODE,RSSI_R2_N20_POWER,RSSI_R2_N30_POWER,RSSI_R2_N40_POWER,RSSI_R2_N50_POWER,RSSI_R2_N60_POWER,RSSI_R2_N70_POWER,RSSI_R2_N80_POWER,RSSI_R2_N90_POWER,");
            cmdText.Append(" RSSI_FINAL_FLAG,RSSI_OPERATOR,RSSI_TEST_TIME,");
           
            cmdText.Append(" SNR_MODE,SNR_LOCAL_LEFT,SNR_IF_POINT,SNR_LOCAL_RIGHT,");
            cmdText.Append(" SNR_FINAL_FLAG,SNR_OPERATOR,SNR_TEST_TIME,");

            cmdText.Append(" MICRO_VIBRATION_MODE,MICRO_VIBRATION_ERROR_COUNT,");
            cmdText.Append(" MICRO_VIBRATION_FINAL_FLAG,MICRO_VIBRATION_OPERATOR,MICRO_VIBRATION_TEST_TIME,");

            cmdText.Append(" AGC_M_MODE,AGC_M_R1_CHANNEL,AGC_M_R1_UPPER_LIMIT,AGC_M_R1_UPPER_ATTENUATION,AGC_M_R1_LOWER_LIMIT,AGC_M_R1_LOWER_ATTENUATION,");
            cmdText.Append(" AGC_M_R2_CHANNEL,AGC_M_R2_UPPER_LIMIT,AGC_M_R2_UPPER_ATTENUATION,AGC_M_R2_LOWER_LIMIT,AGC_M_R2_LOWER_ATTENUATION,");
            cmdText.Append(" AGC_M_FINAL_FLAG,AGC_M_OPERATOR,AGC_M_TEST_TIME,");

            cmdText.Append(" AGC_IPR_MODE,AGC_IPR_R1_CHANNEL,AGC_IPR_R1_UPPER_LIMIT,AGC_IPR_R1_LOWER_LIMIT,AGC_IPR_R2_CHANNEL,AGC_IPR_R2_UPPER_LIMIT,AGC_IPR_R2_LOWER_LIMIT,AGC_IPR_R3_CHANNEL,AGC_IPR_R3_UPPER_LIMIT,AGC_IPR_R3_LOWER_LIMIT,");
            cmdText.Append(" AGC_IPR_FINAL_FLAG,AGC_IPR_OPERATOR,AGC_IPR_TEST_TIME,");

            cmdText.Append(" AGC_XCR_R1_MODE,AGC_XCR_R1_CHANNEL,AGC_XCR_R1_UPPER_LIMIT,AGC_XCR_R1_LOWER_LIMIT,AGC_XCR_R2_MODE,AGC_XCR_R2_CHANNEL,AGC_XCR_R2_UPPER_LIMIT,AGC_XCR_R2_LOWER_LIMIT,");
            cmdText.Append(" AGC_XCR_FINAL_FLAG,AGC_XCR_OPERATOR,AGC_XCR_TEST_TIME,");

            cmdText.Append(" AIRTIGHT,AIRTIGHT_FINAL_FLAG,AIRTIGHT_OPERATOR,AIRTIGHT_TEST_TIME,");

            cmdText.Append(" TEM_G3XMC_MODE,TEM_G3XMC_ERROR_NO,TEM_G3XMC_ERROR_SECONDS,TEM_G3XMC_AIS,");
            cmdText.Append(" TEM_G3XMC_FINAL_FLAG,TEM_G3XMC_OPERATOR,TEM_G3XMC_TEST_TIME,");

            cmdText.Append(" TEM_PTN_MODE,TEM_PTN_LOSS_RATE,TEM_PTN_ERROR_SECONDS,");
            cmdText.Append(" TEM_PTN_FINAL_FLAG,TEM_PTN_OPERATOR,TEM_PTN_TEST_TIME,");

            cmdText.Append(" TEM_OML_6101_LOSS_RATE,TEM_OML_6101_FINAL_FLAG,TEM_OML_6101_OPERATOR,TEM_OML_6101_TEST_TIME,");
            cmdText.Append(" TEM_OML_6205_TOTAL_ERROR,TEM_OML_6205_FINAL_FLAG,TEM_OML_6205_OPERATOR,TEM_OML_6205_TEST_TIME,");
            cmdText.Append(" TEM_OML_6202_TOTAL_ERROR,TEM_OML_6202_FINAL_FLAG,TEM_OML_6202_OPERATOR,TEM_OML_6202_TEST_TIME,");

            cmdText.Append(" FTC_MODE,FTC_ERROR_COUNT,FTC_ERROR_SECONDS,FTC_AIS,");
            cmdText.Append(" FTC_FINAL_FLAG,FTC_OPERATOR,FTC_TEST_TIME ");

            cmdText.Append(" FROM MI_MEASURE_DATA_LIST");
            cmdText.Append(" WHERE MI_MEASURE_DATA_ID=@MI_MEASURE_DATA_ID");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("MI_MEASURE_DATA_ID").Type(DbType.Int32).Size(4).Value(MIMeasureDataId);

            return AdoTemplate.QueryForObjectDelegate<MIMeasureDataInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                MIMeasureDataInfo entity = new MIMeasureDataInfo();
                entity.MIMeasureDataID = Convert.ToInt32(reader["MI_MEASURE_DATA_ID"]);
                entity.SerialNo = Convert.ToString(reader["SERIAL_NO"]);

                entity.RSSIR1Mode = Convert.ToString(reader["RSSI_R1_MODE"]);
                entity.RSSIR1N20Power = Convert.ToString(reader["RSSI_R1_N20_POWER"]);
                entity.RSSIR1N30Power = Convert.ToString(reader["RSSI_R1_N30_POWER"]);
                entity.RSSIR1N40Power = Convert.ToString(reader["RSSI_R1_N40_POWER"]);
                entity.RSSIR1N50Power = Convert.ToString(reader["RSSI_R1_N50_POWER"]);
                entity.RSSIR1N60Power = Convert.ToString(reader["RSSI_R1_N60_POWER"]);
                entity.RSSIR1N70Power = Convert.ToString(reader["RSSI_R1_N70_POWER"]);
                entity.RSSIR1N80Power = Convert.ToString(reader["RSSI_R1_N80_POWER"]);
                entity.RSSIR1N90Power = Convert.ToString(reader["RSSI_R1_N90_POWER"]);
                entity.RSSIR2Mode = Convert.ToString(reader["RSSI_R2_MODE"]);
                entity.RSSIR2N20Power = Convert.ToString(reader["RSSI_R2_N20_POWER"]);
                entity.RSSIR2N30Power = Convert.ToString(reader["RSSI_R2_N30_POWER"]);
                entity.RSSIR2N40Power = Convert.ToString(reader["RSSI_R2_N40_POWER"]);
                entity.RSSIR2N50Power = Convert.ToString(reader["RSSI_R2_N50_POWER"]);
                entity.RSSIR2N60Power = Convert.ToString(reader["RSSI_R2_N60_POWER"]);
                entity.RSSIR2N70Power = Convert.ToString(reader["RSSI_R2_N70_POWER"]);
                entity.RSSIR2N80Power = Convert.ToString(reader["RSSI_R2_N80_POWER"]);
                entity.RSSIR2N90Power = Convert.ToString(reader["RSSI_R2_N90_POWER"]);
                entity.RSSIFinalFlag = Convert.ToChar(reader["RSSI_FINAL_FLAG"]);
                entity.RSSIOperator = Convert.ToString(reader["RSSI_OPERATOR"]);
                if (reader["RSSI_TEST_TIME"] == null)
                {
                    entity.RSSITestTime = null; 
                }
                else
                {
                    entity.RSSITestTime = Convert.ToDateTime(reader["RSSI_TEST_TIME"]);
                }

                entity.SNRMode = Convert.ToString(reader["SNR_MODE"]);
                entity.SNRLocalLeft = Convert.ToString(reader["SNR_LOCAL_LEFT"]);
                entity.SNRIFPoint = Convert.ToString(reader["SNR_IF_POINT"]);
                entity.SNRLocalRight = Convert.ToString(reader["SNR_LOCAL_RIGHT"]);
                entity.SNRFinalFlag = Convert.ToChar(reader["SNR_FINAL_FLAG"]);
                entity.SNROperator = Convert.ToString(reader["SNR_OPERATOR"]);
                if (reader["SNR_TEST_TIME"] == null)
                {
                    entity.SNRTestTime = null; 
                }
                else
                {
                    entity.SNRTestTime = Convert.ToDateTime(reader["SNR_TEST_TIME"]);
                }

                entity.MicroVibrationMode = Convert.ToString(reader["MICRO_VIBRATION_MODE"]);
                entity.MicroVibrationErrorCount = Convert.ToString(reader["MICRO_VIBRATION_ERROR_COUNT"]);
                entity.MicroVibrationFinalFlag = Convert.ToChar(reader["MICRO_VIBRATION_FINAL_FLAG"]);
                entity.MicroVibrationOperator = Convert.ToString(reader["MICRO_VIBRATION_OPERATOR"]);
                if (reader["MICRO_VIBRATION_TEST_TIME"] == null)
                {
                    entity.MicroVibrationTestTime = null; 
                }
                else
                {
                    entity.MicroVibrationTestTime = Convert.ToDateTime(reader["MICRO_VIBRATION_TEST_TIME"]);
                }

                entity.AGCMMode = Convert.ToString(reader["AGC_M_MODE"]);
                entity.AGCMR1Channel = Convert.ToString(reader["AGC_M_R1_CHANNEL"]);
                entity.AGCMR1UpperLimit = Convert.ToString(reader["AGC_M_R1_UPPER_LIMIT"]);
                entity.AGCMR1UpperAttenuation = Convert.ToString(reader["AGC_M_R1_UPPER_ATTENUATION"]);
                entity.AGCMR1LowerLimit = Convert.ToString(reader["AGC_M_R1_LOWER_LIMIT"]);
                entity.AGCMR1LowerAttenuation = Convert.ToString(reader["AGC_M_R1_LOWER_ATTENUATION"]);
                entity.AGCMR2Channel = Convert.ToString(reader["AGC_M_R2_CHANNEL"]);
                entity.AGCMR2UpperLimit = Convert.ToString(reader["AGC_M_R2_UPPER_LIMIT"]);
                entity.AGCMR2UpperAttenuation = Convert.ToString(reader["AGC_M_R2_UPPER_ATTENUATION"]);
                entity.AGCMR2LowerLimit = Convert.ToString(reader["AGC_M_R2_LOWER_LIMIT"]);
                entity.AGCMR2LowerAttenuation = Convert.ToString(reader["AGC_M_R2_LOWER_ATTENUATION"]);
                entity.AGCMFinalFlag = Convert.ToChar(reader["AGC_M_FINAL_FLAG"]);
                entity.AGCMOperator = Convert.ToString(reader["AGC_M_OPERATOR"]);
                if (reader["AGC_M_TEST_TIME"] == null)
                {
                    entity.AGCMTestTime = null; 
                }
                else
                {
                    entity.AGCMTestTime = Convert.ToDateTime(reader["AGC_M_TEST_TIME"]);
                }

                entity.AGCIPRMode = Convert.ToString(reader["AGC_IPR_MODE"]);
                entity.AGCIPRR1Channel = Convert.ToString(reader["AGC_IPR_R1_CHANNEL"]);
                entity.AGCIPRR1UpperLimit = Convert.ToString(reader["AGC_IPR_R1_UPPER_LIMIT"]);
                entity.AGCIPRR1LowerLimit = Convert.ToString(reader["AGC_IPR_R1_LOWER_LIMIT"]);
                entity.AGCIPRR2Channel = Convert.ToString(reader["AGC_IPR_R2_CHANNEL"]);
                entity.AGCIPRR2UpperLimit = Convert.ToString(reader["AGC_IPR_R2_UPPER_LIMIT"]);
                entity.AGCIPRR2LowerLimit = Convert.ToString(reader["AGC_IPR_R2_LOWER_LIMIT"]);
                entity.AGCIPRR3Channel = Convert.ToString(reader["AGC_IPR_R3_CHANNEL"]);
                entity.AGCIPRR3UpperLimit = Convert.ToString(reader["AGC_IPR_R3_UPPER_LIMIT"]);
                entity.AGCIPRR3LowerLimit = Convert.ToString(reader["AGC_IPR_R3_LOWER_LIMIT"]);
                entity.AGCIPRFinalFlag = Convert.ToChar(reader["AGC_IPR_FINAL_FLAG"]);
                entity.AGCIPROperator = Convert.ToString(reader["AGC_IPR_OPERATOR"]);
                if (reader["AGC_IPR_TEST_TIME"] == null)
                {
                    entity.AGCIPRTestTime = null; 
                }
                else
                {
                    entity.AGCIPRTestTime = Convert.ToDateTime(reader["AGC_IPR_TEST_TIME"]);
                }

                entity.AGCXCRR1Mode = Convert.ToString(reader["AGC_XCR_R1_MODE"]);
                entity.AGCXCRR1Channel = Convert.ToString(reader["AGC_XCR_R1_CHANNEL"]);
                entity.AGCXCRR1UpperLimit = Convert.ToString(reader["AGC_XCR_R1_UPPER_LIMIT"]);
                entity.AGCXCRR1LowerLimit = Convert.ToString(reader["AGC_XCR_R1_LOWER_LIMIT"]);
                entity.AGCXCRR2Mode = Convert.ToString(reader["AGC_XCR_R2_MODE"]);
                entity.AGCXCRR2Channel = Convert.ToString(reader["AGC_XCR_R2_CHANNEL"]);
                entity.AGCXCRR2UpperLimit = Convert.ToString(reader["AGC_XCR_R2_UPPER_LIMIT"]);
                entity.AGCXCRR2LowerLimit = Convert.ToString(reader["AGC_XCR_R2_LOWER_LIMIT"]);
                entity.AGCXCRFinalFlag = Convert.ToChar(reader["AGC_XCR_FINAL_FLAG"]);
                entity.AGCXCROperator = Convert.ToString(reader["AGC_XCR_OPERATOR"]);
                if (reader["AGC_XCR_TEST_TIME"] == null)
                {
                    entity.AGCXCRTestTime = null;
                }
                else
                {
                    entity.AGCXCRTestTime = Convert.ToDateTime(reader["AGC_XCR_TEST_TIME"]);
                }

                entity.Airtight = Convert.ToString(reader["AIRTIGHT"]);
                entity.AirtightFinalFlag = Convert.ToChar(reader["AIRTIGHT_FINAL_FLAG"]);
                entity.AirtightOperator = Convert.ToString(reader["AIRTIGHT_OPERATOR"]);
                if (reader["AIRTIGHT_TEST_TIME"] == null)
                {
                    entity.AirtightTestTime = null; 
                }
                else
                {
                    entity.AirtightTestTime = Convert.ToDateTime(reader["AIRTIGHT_TEST_TIME"]);
                }

                entity.TemG3XMCMode = Convert.ToString(reader["TEM_G3XMC_MODE"]);
                entity.TemG3XMCErrorNo = Convert.ToString(reader["TEM_G3XMC_ERROR_NO"]);
                entity.TemG3XMCErrorSeconds = Convert.ToString(reader["TEM_G3XMC_ERROR_SECONDS"]);
                entity.TemG3XMCAIS = Convert.ToString(reader["TEM_G3XMC_AIS"]);
                entity.TemG3XMCFinalFlag = Convert.ToChar(reader["TEM_G3XMC_FINAL_FLAG"]);
                entity.TemG3XMCOperator = Convert.ToString(reader["TEM_G3XMC_OPERATOR"]);
                if (reader["TEM_G3XMC_TEST_TIME"] == null)
                {
                    entity.TemG3XMCTestTime = null; 
                }
                else
                {
                    entity.TemG3XMCTestTime = Convert.ToDateTime(reader["TEM_G3XMC_TEST_TIME"]);
                }

                entity.TemPTNMode = Convert.ToString(reader["TEM_PTN_MODE"]);
                entity.TemPTNLossRate = Convert.ToString(reader["TEM_PTN_LOSS_RATE"]);
                entity.TemPTNErrorSeconds = Convert.ToString(reader["TEM_PTN_ERROR_SECONDS"]);
                entity.TemPTNFinalFlag = Convert.ToChar(reader["TEM_PTN_FINAL_FLAG"]);
                entity.TemPTNOperator = Convert.ToString(reader["TEM_PTN_OPERATOR"]);
                if (reader["TEM_PTN_TEST_TIME"] == null)
                {
                    entity.TemPTNTestTime = null; 
                }
                else
                {
                    entity.TemPTNTestTime = Convert.ToDateTime(reader["TEM_PTN_TEST_TIME"]);
                }

                entity.TemOML6101LossRate = Convert.ToString(reader["TEM_OML_6101_LOSS_RATE"]);
                entity.TemOML6101FinalFlag = Convert.ToChar(reader["TEM_OML_6101_FINAL_FLAG"]);
                entity.TemOML6101Operator = Convert.ToString(reader["TEM_OML_6101_OPERATOR"]);
                if (reader["TEM_OML_6101_TEST_TIME"] == null)
                {
                    entity.TemOML6101TestTime = null; 
                }
                else
                {
                    entity.TemOML6101TestTime = Convert.ToDateTime(reader["TEM_OML_6101_TEST_TIME"]);
                }

                entity.TemOML6205TotalError = Convert.ToString(reader["TEM_OML_6205_TOTAL_ERROR"]);
                entity.TemOML6205FinalFlag = Convert.ToChar(reader["TEM_OML_6205_FINAL_FLAG"]);
                entity.TemOML6205Operator = Convert.ToString(reader["TEM_OML_6205_OPERATOR"]);
                if (reader["TEM_OML_6205_TEST_TIME"] == null)
                {
                    entity.TemOML6205TestTime = null; 
                }
                else
                {
                    entity.TemOML6205TestTime = Convert.ToDateTime(reader["TEM_OML_6205_TEST_TIME"]);
                }

                entity.TemOML6202TotalError = Convert.ToString(reader["TEM_OML_6202_TOTAL_ERROR"]);
                entity.TemOML6202FinalFlag = Convert.ToChar(reader["TEM_OML_6202_FINAL_FLAG"]);
                entity.TemOML6202Operator = Convert.ToString(reader["TEM_OML_6202_OPERATOR"]);
                entity.TemOML6202TestTime = Convert.ToDateTime(reader["TEM_OML_6202_TEST_TIME"]);
                if (reader["TEM_OML_6202_TEST_TIME"] == null)
                {
                    entity.TemOML6202TestTime = null; 
                }
                else
                {
                    entity.TemOML6202TestTime = Convert.ToDateTime(reader["TEM_OML_6202_TEST_TIME"]);
                }

                entity.FTCMode = Convert.ToString(reader["FTC_MODE"]);
                entity.FTCErrorCount = Convert.ToString(reader["FTC_ERROR_COUNT"]);
                entity.FTCErrorSeconds = Convert.ToString(reader["FTC_ERROR_SECONDS"]);
                entity.FTCAIS = Convert.ToString(reader["FTC_AIS"]);
                entity.FTCFinalFlag = Convert.ToChar(reader["FTC_FINAL_FLAG"]);
                entity.FTCOperator = Convert.ToString(reader["FTC_OPERATOR"]);
                if (reader["FTC_TEST_TIME"] == null)
                {
                    entity.FTCTestTime = null;
                }
                else
                {
                    entity.FTCTestTime = Convert.ToDateTime(reader["FTC_TEST_TIME"]);
                }
                return entity;
            }, paras.GetParameters());
        }

        public void Update(MIMeasureDataInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" UPDATE MI_MEASURE_DATA_LIST SET");

            cmdText.Append(" RSSI_R1_MODE=@RSSI_R1_MODE,RSSI_R1_N20_POWER=@RSSI_R1_N20_POWER,RSSI_R1_N30_POWER=@RSSI_R1_N30_POWER,RSSI_R1_N40_POWER=@RSSI_R1_N40_POWER,RSSI_R1_N50_POWER=@RSSI_R1_N50_POWER,RSSI_R1_N60_POWER=@RSSI_R1_N60_POWER,RSSI_R1_N70_POWER=@RSSI_R1_N70_POWER,RSSI_R1_N80_POWER=@RSSI_R1_N80_POWER,RSSI_R1_N90_POWER=@RSSI_R1_N90_POWER,");
            cmdText.Append(" RSSI_R2_MODE=@RSSI_R2_MODE,RSSI_R2_N20_POWER=@RSSI_R2_N20_POWER,RSSI_R2_N30_POWER=@RSSI_R2_N30_POWER,RSSI_R2_N40_POWER=@RSSI_R2_N40_POWER,RSSI_R2_N50_POWER=@RSSI_R2_N50_POWER,RSSI_R2_N60_POWER=@RSSI_R2_N60_POWER,RSSI_R2_N70_POWER=@RSSI_R2_N70_POWER,RSSI_R2_N80_POWER=@RSSI_R2_N80_POWER,RSSI_R2_N90_POWER=@RSSI_R2_N90_POWER,");
            cmdText.Append(" RSSI_FINAL_FLAG=@RSSI_FINAL_FLAG,RSSI_OPERATOR=@RSSI_OPERATOR,RSSI_TEST_TIME=@RSSI_TEST_TIME,");

            cmdText.Append(" SNR_MODE=@SNR_MODE,SNR_LOCAL_LEFT=@SNR_LOCAL_LEFT,SNR_IF_POINT=@SNR_IF_POINT,SNR_LOCAL_RIGHT=@SNR_LOCAL_RIGHT,");
            cmdText.Append(" SNR_FINAL_FLAG=@SNR_FINAL_FLAG,SNR_OPERATOR=@SNR_OPERATOR,SNR_TEST_TIME=@SNR_TEST_TIME,");

            cmdText.Append(" MICRO_VIBRATION_MODE=@MICRO_VIBRATION_MODE,MICRO_VIBRATION_ERROR_COUNT=@MICRO_VIBRATION_ERROR_COUNT,");
            cmdText.Append(" MICRO_VIBRATION_FINAL_FLAG=@MICRO_VIBRATION_FINAL_FLAG,MICRO_VIBRATION_OPERATOR=@MICRO_VIBRATION_OPERATOR,MICRO_VIBRATION_TEST_TIME=@MICRO_VIBRATION_TEST_TIME,");

            cmdText.Append(" AGC_M_MODE=@AGC_M_MODE,AGC_M_R1_CHANNEL=@AGC_M_R1_CHANNEL,AGC_M_R1_UPPER_LIMIT=@AGC_M_R1_UPPER_LIMIT,AGC_M_R1_UPPER_ATTENUATION=@AGC_M_R1_UPPER_ATTENUATION,AGC_M_R1_LOWER_LIMIT=@AGC_M_R1_LOWER_LIMIT,AGC_M_R1_LOWER_ATTENUATION=@AGC_M_R1_LOWER_ATTENUATION,");
            cmdText.Append(" AGC_M_R2_CHANNEL=@AGC_M_R2_CHANNEL,AGC_M_R2_UPPER_LIMIT=@AGC_M_R2_UPPER_LIMIT,AGC_M_R2_UPPER_ATTENUATION=@AGC_M_R2_UPPER_ATTENUATION,AGC_M_R2_LOWER_LIMIT=@AGC_M_R2_LOWER_LIMIT,AGC_M_R2_LOWER_ATTENUATION=@AGC_M_R2_LOWER_ATTENUATION,");
            cmdText.Append(" AGC_M_FINAL_FLAG=@AGC_M_FINAL_FLAG,AGC_M_OPERATOR=@AGC_M_OPERATOR,AGC_M_TEST_TIME=@AGC_M_TEST_TIME,");

            cmdText.Append(" AGC_IPR_MODE=@AGC_IPR_MODE,AGC_IPR_R1_CHANNEL=@AGC_IPR_R1_CHANNEL,AGC_IPR_R1_UPPER_LIMIT=@AGC_IPR_R1_UPPER_LIMIT,AGC_IPR_R1_LOWER_LIMIT=@AGC_IPR_R1_LOWER_LIMIT,AGC_IPR_R2_CHANNEL=@AGC_IPR_R2_CHANNEL,AGC_IPR_R2_UPPER_LIMIT=@AGC_IPR_R2_UPPER_LIMIT,AGC_IPR_R2_LOWER_LIMIT=@AGC_IPR_R2_LOWER_LIMIT,AGC_IPR_R3_CHANNEL=@AGC_IPR_R3_CHANNEL,AGC_IPR_R3_UPPER_LIMIT=@AGC_IPR_R3_UPPER_LIMIT,AGC_IPR_R3_LOWER_LIMIT=@AGC_IPR_R3_LOWER_LIMIT,");
            cmdText.Append(" AGC_IPR_FINAL_FLAG=@AGC_IPR_FINAL_FLAG,AGC_IPR_OPERATOR=@AGC_IPR_OPERATOR,AGC_IPR_TEST_TIME=@AGC_IPR_TEST_TIME,");

            cmdText.Append(" AGC_XCR_R1_MODE=@AGC_XCR_R1_MODE,AGC_XCR_R1_CHANNEL=@AGC_XCR_R1_CHANNEL,AGC_XCR_R1_UPPER_LIMIT=@AGC_XCR_R1_UPPER_LIMIT,AGC_XCR_R1_LOWER_LIMIT=@AGC_XCR_R1_LOWER_LIMIT,AGC_XCR_R2_MODE=@AGC_XCR_R2_MODE,AGC_XCR_R2_CHANNEL=@AGC_XCR_R2_CHANNEL,AGC_XCR_R2_UPPER_LIMIT=@AGC_XCR_R2_UPPER_LIMIT,AGC_XCR_R2_LOWER_LIMIT=@AGC_XCR_R2_LOWER_LIMIT,");
            cmdText.Append(" AGC_XCR_FINAL_FLAG=@AGC_XCR_FINAL_FLAG,AGC_XCR_OPERATOR=@AGC_XCR_OPERATOR,AGC_XCR_TEST_TIME=@AGC_XCR_TEST_TIME,");

            cmdText.Append(" AIRTIGHT=@AIRTIGHT,AIRTIGHT_FINAL_FLAG=@AIRTIGHT_FINAL_FLAG,AIRTIGHT_OPERATOR=@AIRTIGHT_OPERATOR,AIRTIGHT_TEST_TIME=@AIRTIGHT_TEST_TIME,");

            cmdText.Append(" TEM_G3XMC_MODE=@TEM_G3XMC_MODE,TEM_G3XMC_ERROR_NO=@TEM_G3XMC_ERROR_NO,TEM_G3XMC_ERROR_SECONDS=@TEM_G3XMC_ERROR_SECONDS,TEM_G3XMC_AIS=@TEM_G3XMC_AIS,");
            cmdText.Append(" TEM_G3XMC_FINAL_FLAG=@TEM_G3XMC_FINAL_FLAG,TEM_G3XMC_OPERATOR=@TEM_G3XMC_OPERATOR,TEM_G3XMC_TEST_TIME=@TEM_G3XMC_TEST_TIME,");

            cmdText.Append(" TEM_PTN_MODE=@TEM_PTN_MODE,TEM_PTN_LOSS_RATE=@TEM_PTN_LOSS_RATE,TEM_PTN_ERROR_SECONDS=@TEM_PTN_ERROR_SECONDS,");
            cmdText.Append(" TEM_PTN_FINAL_FLAG=@TEM_PTN_FINAL_FLAG,TEM_PTN_OPERATOR=@TEM_PTN_OPERATOR,TEM_PTN_TEST_TIME=@TEM_PTN_TEST_TIME,");

            cmdText.Append(" TEM_OML_6101_LOSS_RATE=@TEM_OML_6101_LOSS_RATE,TEM_OML_6101_FINAL_FLAG=@TEM_OML_6101_FINAL_FLAG,TEM_OML_6101_OPERATOR=@TEM_OML_6101_OPERATOR,TEM_OML_6101_TEST_TIME=@TEM_OML_6101_TEST_TIME,");
            cmdText.Append(" TEM_OML_6205_TOTAL_ERROR=@TEM_OML_6205_TOTAL_ERROR,TEM_OML_6205_FINAL_FLAG=@TEM_OML_6205_FINAL_FLAG,TEM_OML_6205_OPERATOR=@TEM_OML_6205_OPERATOR,TEM_OML_6205_TEST_TIME=@TEM_OML_6205_TEST_TIME,");
            cmdText.Append(" TEM_OML_6202_TOTAL_ERROR=@TEM_OML_6202_TOTAL_ERROR,TEM_OML_6202_FINAL_FLAG=@TEM_OML_6202_FINAL_FLAG,TEM_OML_6202_OPERATOR=@TEM_OML_6202_OPERATOR,TEM_OML_6202_TEST_TIME=@TEM_OML_6202_TEST_TIME,");

            cmdText.Append(" FTC_MODE=@FTC_MODE,FTC_ERROR_COUNT=@FTC_ERROR_COUNT,FTC_ERROR_SECONDS=@FTC_ERROR_SECONDS,FTC_AIS=@FTC_AIS,");
            cmdText.Append(" FTC_FINAL_FLAG=@FTC_FINAL_FLAG,FTC_OPERATOR=@FTC_OPERATOR,FTC_TEST_TIME=@FTC_TEST_TIME, ");

            cmdText.Append(" LAST_UPDATE_DATE=@LAST_UPDATE_DATE,LAST_UPDATED_BY=@LAST_UPDATED_BY");
            cmdText.Append(" WHERE MI_MEASURE_DATA_ID=@MI_MEASURE_DATA_ID");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("RSSI_R1_MODE").Type(DbType.String).Size(50).Value(entity.RSSIR1Mode);
            paras.Create().Name("RSSI_R1_N20_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N20Power);
            paras.Create().Name("RSSI_R1_N30_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N30Power);
            paras.Create().Name("RSSI_R1_N40_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N40Power);
            paras.Create().Name("RSSI_R1_N50_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N50Power);
            paras.Create().Name("RSSI_R1_N60_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N60Power);
            paras.Create().Name("RSSI_R1_N70_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N70Power);
            paras.Create().Name("RSSI_R1_N80_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N80Power);
            paras.Create().Name("RSSI_R1_N90_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR1N90Power);
            paras.Create().Name("RSSI_R2_MODE").Type(DbType.String).Size(50).Value(entity.RSSIR2Mode);
            paras.Create().Name("RSSI_R2_N20_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N20Power);
            paras.Create().Name("RSSI_R2_N30_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N30Power);
            paras.Create().Name("RSSI_R2_N40_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N40Power);
            paras.Create().Name("RSSI_R2_N50_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N50Power);
            paras.Create().Name("RSSI_R2_N60_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N60Power);
            paras.Create().Name("RSSI_R2_N70_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N70Power);
            paras.Create().Name("RSSI_R2_N80_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N80Power);
            paras.Create().Name("RSSI_R2_N90_POWER").Type(DbType.String).Size(50).Value(entity.RSSIR2N90Power);
            paras.Create().Name("RSSI_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.RSSIFinalFlag);
            paras.Create().Name("RSSI_OPERATOR").Type(DbType.String).Size(50).Value(entity.RSSIOperator);
            paras.Create().Name("RSSI_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.RSSITestTime);

            paras.Create().Name("SNR_MODE").Type(DbType.String).Size(50).Value(entity.SNRMode);
            paras.Create().Name("SNR_LOCAL_LEFT").Type(DbType.String).Size(50).Value(entity.SNRLocalLeft);
            paras.Create().Name("SNR_IF_POINT").Type(DbType.String).Size(50).Value(entity.SNRIFPoint);
            paras.Create().Name("SNR_LOCAL_RIGHT").Type(DbType.String).Size(50).Value(entity.SNRLocalRight);
            paras.Create().Name("SNR_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.SNRFinalFlag);
            paras.Create().Name("SNR_OPERATOR").Type(DbType.String).Size(50).Value(entity.SNROperator);
            paras.Create().Name("SNR_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.SNRTestTime);

            paras.Create().Name("MICRO_VIBRATION_MODE").Type(DbType.String).Size(50).Value(entity.MicroVibrationMode);
            paras.Create().Name("MICRO_VIBRATION_ERROR_COUNT").Type(DbType.String).Size(50).Value(entity.MicroVibrationErrorCount);
            paras.Create().Name("MICRO_VIBRATION_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.MicroVibrationFinalFlag);
            paras.Create().Name("MICRO_VIBRATION_OPERATOR").Type(DbType.String).Size(50).Value(entity.MicroVibrationOperator);
            paras.Create().Name("MICRO_VIBRATION_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.MicroVibrationTestTime);

            paras.Create().Name("AGC_M_MODE").Type(DbType.String).Size(50).Value(entity.AGCMMode);
            paras.Create().Name("AGC_M_R1_CHANNEL").Type(DbType.String).Size(50).Value(entity.AGCMR1Channel);
            paras.Create().Name("AGC_M_R1_UPPER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCMR1UpperLimit);
            paras.Create().Name("AGC_M_R1_UPPER_ATTENUATION").Type(DbType.String).Size(50).Value(entity.AGCMR1UpperAttenuation);
            paras.Create().Name("AGC_M_R1_LOWER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCMR1LowerLimit);
            paras.Create().Name("AGC_M_R1_LOWER_ATTENUATION").Type(DbType.String).Size(50).Value(entity.AGCMR1LowerAttenuation);
            paras.Create().Name("AGC_M_R2_CHANNEL").Type(DbType.String).Size(50).Value(entity.AGCMR2Channel);
            paras.Create().Name("AGC_M_R2_UPPER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCMR2UpperLimit);
            paras.Create().Name("AGC_M_R2_UPPER_ATTENUATION").Type(DbType.String).Size(50).Value(entity.AGCMR2UpperAttenuation);
            paras.Create().Name("AGC_M_R2_LOWER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCMR2LowerLimit);
            paras.Create().Name("AGC_M_R2_LOWER_ATTENUATION").Type(DbType.String).Size(50).Value(entity.AGCMR2LowerAttenuation);
            paras.Create().Name("AGC_M_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.AGCMFinalFlag);
            paras.Create().Name("AGC_M_OPERATOR").Type(DbType.String).Size(50).Value(entity.AGCMOperator);
            paras.Create().Name("AGC_M_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.AGCMTestTime);

            paras.Create().Name("AGC_IPR_MODE").Type(DbType.String).Size(50).Value(entity.AGCIPRMode);
            paras.Create().Name("AGC_IPR_R1_CHANNEL").Type(DbType.String).Size(50).Value(entity.AGCIPRR1Channel);
            paras.Create().Name("AGC_IPR_R1_UPPER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCIPRR1UpperLimit);
            paras.Create().Name("AGC_IPR_R1_LOWER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCIPRR1LowerLimit);
            paras.Create().Name("AGC_IPR_R2_CHANNEL").Type(DbType.String).Size(50).Value(entity.AGCIPRR2Channel);
            paras.Create().Name("AGC_IPR_R2_UPPER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCIPRR2UpperLimit);
            paras.Create().Name("AGC_IPR_R2_LOWER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCIPRR2LowerLimit);
            paras.Create().Name("AGC_IPR_R3_CHANNEL").Type(DbType.String).Size(50).Value(entity.AGCIPRR3Channel);
            paras.Create().Name("AGC_IPR_R3_UPPER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCIPRR3UpperLimit);
            paras.Create().Name("AGC_IPR_R3_LOWER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCIPRR3LowerLimit);
            paras.Create().Name("AGC_IPR_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.AGCIPRFinalFlag);
            paras.Create().Name("AGC_IPR_OPERATOR").Type(DbType.String).Size(50).Value(entity.AGCIPROperator);
            paras.Create().Name("AGC_IPR_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.AGCIPRTestTime);

            paras.Create().Name("AGC_XCR_R1_MODE").Type(DbType.String).Size(50).Value(entity.AGCXCRR1Mode);
            paras.Create().Name("AGC_XCR_R1_CHANNEL").Type(DbType.String).Size(50).Value(entity.AGCXCRR1Channel);
            paras.Create().Name("AGC_XCR_R1_UPPER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCXCRR1UpperLimit);
            paras.Create().Name("AGC_XCR_R1_LOWER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCXCRR1LowerLimit);
            paras.Create().Name("AGC_XCR_R2_MODE").Type(DbType.String).Size(50).Value(entity.AGCXCRR2Mode);
            paras.Create().Name("AGC_XCR_R2_CHANNEL").Type(DbType.String).Size(50).Value(entity.AGCXCRR2Channel);
            paras.Create().Name("AGC_XCR_R2_UPPER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCXCRR2UpperLimit);
            paras.Create().Name("AGC_XCR_R2_LOWER_LIMIT").Type(DbType.String).Size(50).Value(entity.AGCXCRR2LowerLimit);
            paras.Create().Name("AGC_XCR_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.AGCXCRFinalFlag);
            paras.Create().Name("AGC_XCR_OPERATOR").Type(DbType.String).Size(50).Value(entity.AGCXCROperator);
            paras.Create().Name("AGC_XCR_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.AGCXCRTestTime);

            paras.Create().Name("AIRTIGHT").Type(DbType.String).Size(50).Value(entity.Airtight);
            paras.Create().Name("AIRTIGHT_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.AirtightFinalFlag);
            paras.Create().Name("AIRTIGHT_OPERATOR").Type(DbType.String).Size(50).Value(entity.AirtightOperator);
            paras.Create().Name("AIRTIGHT_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.AirtightTestTime);

            paras.Create().Name("TEM_G3XMC_MODE").Type(DbType.String).Size(50).Value(entity.TemG3XMCMode);
            paras.Create().Name("TEM_G3XMC_ERROR_NO").Type(DbType.String).Size(50).Value(entity.TemG3XMCErrorNo);
            paras.Create().Name("TEM_G3XMC_ERROR_SECONDS").Type(DbType.String).Size(50).Value(entity.TemG3XMCErrorSeconds);
            paras.Create().Name("TEM_G3XMC_AIS").Type(DbType.String).Size(50).Value(entity.TemG3XMCAIS);
            paras.Create().Name("TEM_G3XMC_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.TemG3XMCFinalFlag);
            paras.Create().Name("TEM_G3XMC_OPERATOR").Type(DbType.String).Size(50).Value(entity.TemG3XMCOperator);
            paras.Create().Name("TEM_G3XMC_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.TemG3XMCTestTime);

            paras.Create().Name("TEM_PTN_MODE").Type(DbType.String).Size(50).Value(entity.TemPTNMode);
            paras.Create().Name("TEM_PTN_LOSS_RATE").Type(DbType.String).Size(50).Value(entity.TemPTNLossRate);
            paras.Create().Name("TEM_PTN_ERROR_SECONDS").Type(DbType.String).Size(50).Value(entity.TemPTNErrorSeconds);
            paras.Create().Name("TEM_PTN_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.TemPTNFinalFlag);
            paras.Create().Name("TEM_PTN_OPERATOR").Type(DbType.String).Size(50).Value(entity.TemPTNOperator);
            paras.Create().Name("TEM_PTN_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.TemPTNTestTime);

            paras.Create().Name("TEM_OML_6101_LOSS_RATE").Type(DbType.String).Size(50).Value(entity.TemOML6101LossRate);
            paras.Create().Name("TEM_OML_6101_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.TemOML6101FinalFlag);
            paras.Create().Name("TEM_OML_6101_OPERATOR").Type(DbType.String).Size(50).Value(entity.TemOML6101Operator);
            paras.Create().Name("TEM_OML_6101_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.TemOML6101TestTime);

            paras.Create().Name("TEM_OML_6205_TOTAL_ERROR").Type(DbType.String).Size(50).Value(entity.TemOML6205TotalError);
            paras.Create().Name("TEM_OML_6205_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.TemOML6205FinalFlag);
            paras.Create().Name("TEM_OML_6205_OPERATOR").Type(DbType.String).Size(50).Value(entity.TemOML6205Operator);
            paras.Create().Name("TEM_OML_6205_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.TemOML6205TestTime);

            paras.Create().Name("TEM_OML_6202_TOTAL_ERROR").Type(DbType.String).Size(50).Value(entity.TemOML6202TotalError);
            paras.Create().Name("TEM_OML_6202_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.TemOML6202FinalFlag);
            paras.Create().Name("TEM_OML_6202_OPERATOR").Type(DbType.String).Size(50).Value(entity.TemOML6202Operator);
            paras.Create().Name("TEM_OML_6202_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.TemOML6202TestTime);


            paras.Create().Name("FTC_MODE").Type(DbType.String).Size(50).Value(entity.FTCMode);
            paras.Create().Name("FTC_ERROR_COUNT").Type(DbType.String).Size(50).Value(entity.FTCErrorCount);
            paras.Create().Name("FTC_ERROR_SECONDS").Type(DbType.String).Size(50).Value(entity.FTCErrorSeconds);
            paras.Create().Name("FTC_AIS").Type(DbType.String).Size(50).Value(entity.FTCAIS);
            paras.Create().Name("FTC_FINAL_FLAG").Type(DbType.StringFixedLength).Size(1).Value(entity.FTCFinalFlag);
            paras.Create().Name("FTC_OPERATOR").Type(DbType.String).Size(50).Value(entity.FTCOperator);
            paras.Create().Name("FTC_TEST_TIME").Type(DbType.DateTime).Size(4).Value(entity.FTCTestTime);

            paras.Create().Name("LAST_UPDATE_DATE").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("LAST_UPDATED_BY").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            paras.Create().Name("MI_MEASURE_DATA_ID").Type(DbType.Int32).Size(4).Value(entity.MIMeasureDataID);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(MIMeasureDataInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" DELETE FROM MI_MEASURE_DATA_LIST WHERE MI_MEASURE_DATA_ID=@MI_MEASURE_DATA_ID");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("MI_MEASURE_DATA_ID").Type(DbType.Int32).Size(4).Value(entity.MIMeasureDataID);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }
    }
}

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
    public class SPCPullingForceMonthly : AdoDaoSupport, ISPCPullingForceMonthly
    {
        public IList<SPCPullingForceMonthlyInfo> GetYearMonth()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT DISTINCT YearMonth" );
            cmdText.Append(" FROM SPC_Pulling_Force_Monthly");
            cmdText.Append(" WHERE 1=1 ");
            return AdoTemplate.QueryWithRowMapperDelegate<SPCPullingForceMonthlyInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCPullingForceMonthlyInfo item = new SPCPullingForceMonthlyInfo();
                item.YearMonth = Convert.ToString(reader["yearmonth"]);
                return item;
            });
        }

        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT DISTINCT COUNT(*) ");
            cmdText.Append(" FROM SPC_Pulling_Force_Monthly");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "machine_no":
                        cmdText.Append(" AND upper(machine_no) = upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "yearmonth":
                        cmdText.Append(" AND yearmonth= @" + entry.Key);
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SPCPullingForceMonthlyInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");
            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" Pulling_Force_Monthly_PK,Machine_No,YearMonth,last_update_date");
            cmdText.Append(" FROM SPC_Pulling_Force_Monthly");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "machine_no":
                        cmdText.Append(" AND upper(machine_no) = upper('%'+@" + entry.Key + "+'%')");
                        break;
                    case "yearmonth":
                        cmdText.Append(" AND yearmonth= @" + entry.Key);
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            int startRowNum = (page - 1) * pageSize + 1;
            int endRowNum = startRowNum + pageSize - 1;

            cmdText.Append(" ) t_pager where rowindex between " + startRowNum.ToString() + " and " + endRowNum.ToString());

            return AdoTemplate.QueryWithRowMapperDelegate<SPCPullingForceMonthlyInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCPullingForceMonthlyInfo item = new SPCPullingForceMonthlyInfo();
                item.PullingForceMonthlyPK = Convert.ToInt32(reader["Pulling_Force_Monthly_PK"]);
                item.MachineNo = Convert.ToString(reader["machine_no"]);
                item.YearMonth = Convert.ToString(reader["yearmonth"]);
              
                item.LastUpdateDate = Convert.ToDateTime(reader["last_update_date"]);
                return item;
            }, paras.GetParameters());
        }

        public SPCPullingForceMonthlyInfo GetDetail(int PullingForceMonthlyPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Pulling_Force_Monthly_PK").Type(DbType.Int32).Size(4).Value(PullingForceMonthlyPK);

            StringBuilder DetailCmdText = new StringBuilder();
            DetailCmdText.Append(" SELECT  Group_No,Working_Date ,X1,X2 ,X3,X4 ,X5,X6,");
            DetailCmdText.Append(" X7,X8,X9,X10,X,R ,CPK,Last_Update_Date,Last_Updated_By");
            DetailCmdText.Append(" FROM SPC_Pulling_Force_Monthly_Detail ");
            DetailCmdText.Append(" WHERE Pulling_Force_Monthly_PK=@Pulling_Force_Monthly_PK");
            DetailCmdText.Append(" ORDER BY Working_Date ASC");

            IList<SPCPullingForceMonthlyDetail> DetailItems = AdoTemplate.QueryWithRowMapperDelegate<SPCPullingForceMonthlyDetail>(CommandType.Text, DetailCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCPullingForceMonthlyDetail item = new SPCPullingForceMonthlyDetail();
                item.GroupNo = Convert.ToInt32(reader["Group_No"]);
                item.WorkingDate = Convert.ToDateTime(reader["Working_Date"]);
                item.X1 = Convert.ToDouble(reader["X1"]);
                item.X2 = Convert.ToDouble(reader["X2"]);
                item.X3 = Convert.ToDouble(reader["X3"]);
                item.X4 = Convert.ToDouble(reader["X4"]);
                item.X5 = Convert.ToDouble(reader["X5"]);
                item.X6 = Convert.ToDouble(reader["X6"]);
                item.X7 = Convert.ToDouble(reader["X7"]);
                item.X8 = Convert.ToDouble(reader["X8"]);
                item.X9 = Convert.ToDouble(reader["X9"]);
                item.X10 = Convert.ToDouble(reader["X10"]);
                item.X = Convert.ToDouble(reader["X"]);
                item.R = Convert.ToDouble(reader["R"]);
                item.CPK = Convert.ToDouble(reader["CPK"]);
                return item;
            }, paras.GetParameters());

            StringBuilder ExceptionCmdText = new StringBuilder();
            ExceptionCmdText.Append(" SELECT Group_No, Working_Date,chart_type,comment ");
            ExceptionCmdText.Append(" FROM SPC_Pulling_Force_Monthly_exception ");
            ExceptionCmdText.Append(" WHERE Pulling_Force_Monthly_PK=@Pulling_Force_Monthly_PK");
            ExceptionCmdText.Append(" ORDER BY  Working_Date ASC");

            IList<SPCPullingForceMonthlyException> ExceptionItems = AdoTemplate.QueryWithRowMapperDelegate<SPCPullingForceMonthlyException>(CommandType.Text, ExceptionCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCPullingForceMonthlyException item = new SPCPullingForceMonthlyException();
                item.GroupNo = Convert.ToInt32(reader["Group_No"]);
                item.WorkingDate = Convert.ToDateTime(reader["working_date"]);
                item.ChartType = Convert.ToChar(reader["chart_type"]);
                item.Comment = Convert.ToString(reader["comment"]);
                return item;
            }, paras.GetParameters());

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT Pulling_Force_Monthly_PK,Machine_No,YearMonth,Grouping_No,X,");
            cmdText.Append(" R,S,LSL,USL,CPK,CL_X,UCL_X,LCL_X,CL_R,UCL_R,LCL_R,Last_Update_Date,Last_Updated_By");
            cmdText.Append(" FROM SPC_Pulling_Force_Monthly ");
            cmdText.Append(" WHERE Pulling_Force_Monthly_PK=@Pulling_Force_Monthly_PK");

            return AdoTemplate.QueryForObjectDelegate<SPCPullingForceMonthlyInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCPullingForceMonthlyInfo entity = new SPCPullingForceMonthlyInfo();
                entity.PullingForceMonthlyPK = Convert.ToInt32(reader["Pulling_Force_Monthly_PK"]);
                entity.MachineNo = Convert.ToString(reader["machine_no"]);
                entity.YearMonth = Convert.ToString(reader["YearMonth"]);
                entity.GroupingNo = Convert.ToInt32(reader["grouping_no"]);
                entity.X = Convert.ToDouble(reader["x"]);
                entity.R = Convert.ToDouble(reader["r"]);
                entity.S = Convert.ToDouble(reader["s"]);
                if (reader["lsl"] != null) { entity.LSL = Convert.ToDouble(reader["lsl"]); }
                if (reader["usl"] != null) { entity.USL = Convert.ToDouble(reader["usl"]); }
                entity.CPK = Convert.ToDouble(reader["cpk"]);
                entity.LCL_X = Convert.ToDouble(reader["lcl_x"]);
                entity.CL_X = Convert.ToDouble(reader["cl_x"]);
                entity.UCL_X = Convert.ToDouble(reader["ucl_x"]);
                entity.LCL_R = Convert.ToDouble(reader["lcl_r"]);
                entity.CL_R = Convert.ToDouble(reader["cl_r"]);
                entity.UCL_R = Convert.ToDouble(reader["ucl_r"]);
                entity.LastUpdateDate = Convert.ToDateTime(reader["last_update_date"]);
                entity.LastUpdatedBy = Convert.ToString(reader["last_updated_by"]);

                entity.DetailItems = DetailItems;
                entity.ExceptionItems = ExceptionItems;
                return entity;
            }, paras.GetParameters());
        }

        public void Save(int PullingForceMonthlyPK, IList<SPCPullingForceMonthlyException> ExceptionItems)
        {
            StringBuilder cmdText = new StringBuilder();
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            cmdText.Append(" DELETE FROM SPC_Pulling_Force_Monthly_Exception WHERE Pulling_Force_Monthly_PK=@Pulling_Force_Monthly_PK;");

            paras.Create().Name("Pulling_Force_Monthly_PK").Type(DbType.Int32).Size(4).Value(PullingForceMonthlyPK);

            for (int i = 0; i < ExceptionItems.Count; i++)
            {
                cmdText.Append(" INSERT INTO SPC_Pulling_Force_Monthly_Exception");
                cmdText.Append(" (Pulling_Force_Monthly_PK,Group_No,Working_Date,Chart_Type,Comment,Last_Update_Date,Last_Updated_By)");
                cmdText.Append(" VALUES");
                cmdText.Append(" (@Pulling_Force_Monthly_PK,,@Group_No_" + i.ToString() + ",@Working_Date_" + i.ToString() + ",@Chart_Type_" + i.ToString() + ",@Comment_" + i.ToString() + ",@Last_Update_Date,@Last_Updated_By)");
                paras.Create().Name("Group_No_" + i.ToString()).Type(DbType.Int32).Size(4).Value(ExceptionItems[i].GroupNo);
                paras.Create().Name("Working_Date_" + i.ToString()).Type(DbType.DateTime).Size(4).Value(ExceptionItems[i].WorkingDate);
                paras.Create().Name("Chart_Type_" + i.ToString()).Type(DbType.StringFixedLength).Size(1).Value(ExceptionItems[i].ChartType);
                paras.Create().Name("Comment_" + i.ToString()).Type(DbType.String).Size(100).Value(ExceptionItems[i].Comment);
            }

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }
    }
}

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
    public class SPCPullingForce : AdoDaoSupport, ISPCPullingForce
    {
        public int Query(Hashtable hashTable)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT DISTINCT COUNT(*) ");
            cmdText.Append(" FROM SPC_Pulling_Force");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "machine_no":
                        cmdText.Append(" AND upper(Machine_No) = upper(@" + entry.Key + ")");
                        break;
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),Working_Date,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),Working_Date,120)<= @" + entry.Key);
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            return (int)AdoTemplate.ExecuteScalar(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<SPCPullingForceInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT * FROM (");

            cmdText.Append(" SELECT rowindex = row_number() over (order by " + sortBy + " " + orderBy + " ) ,");
            cmdText.Append(" Pulling_Force_PK,Machine_No ,Working_Date ,MWM_Type,Machine_Pressure,Power_First_Point ,Power_Second_Point,Operator");
            cmdText.Append(" ,X1 ,X2,X3,X4,X5 ,X6,X7,X8,X9 ,X10");
            cmdText.Append(" FROM SPC_Pulling_Force");
            cmdText.Append(" WHERE 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "machine_no":
                        cmdText.Append(" AND upper(Machine_No) = upper(@" + entry.Key + ")");
                        break;
                    case "date_from":
                        cmdText.Append(" AND convert(varchar(10),Working_Date,120) >= @" + entry.Key);
                        break;
                    case "date_to":
                        cmdText.Append(" AND convert(varchar(10),Working_Date,120)<= @" + entry.Key);
                        break;
                    default:
                        break;
                }
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            int startRowNum = (page - 1) * pageSize + 1;
            int endRowNum = startRowNum + pageSize - 1;

            cmdText.Append(" ) t_pager where rowindex between " + startRowNum.ToString() + " and " + endRowNum.ToString());

            return AdoTemplate.QueryWithRowMapperDelegate<SPCPullingForceInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCPullingForceInfo item = new SPCPullingForceInfo();
                item.PullingForcePK = Convert.ToInt32(reader["Pulling_Force_PK"]);
                item.MachineNo = Convert.ToString(reader["Machine_No"]);
                item.WorkingDate = Convert.ToDateTime(reader["Working_Date"]);
                item.MWMType = Convert.ToString(reader["MWM_Type"]);
                item.MachinePressure = Convert.ToInt32(reader["Machine_Pressure"]);
                item.PowerFirstPoint = Convert.ToInt32(reader["Power_First_Point"]);
                item.PowerSecondPoint = Convert.ToInt32(reader["Power_Second_Point"]);
                item.Operator = Convert.ToString(reader["Operator"]);
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
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string machineNo, string testingDate)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT count(*) ");
            cmdText.Append(" FROM SPC_Pulling_Force");
            cmdText.Append(" WHERE   1=1");
            cmdText.Append(" AND  upper(Machine_No)=upper(@Machine_No)");
            cmdText.Append(" AND  CONVERT(VARCHAR(10),Working_Date,120)=@Working_Date");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Machine_No").Type(DbType.String).Size(50).Value(machineNo);
            paras.Create().Name("Working_Date").Type(DbType.String).Size(50).Value(testingDate);

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

        public void Save(SPCPullingForceInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("INSERT INTO SPC_Pulling_Force");
            cmdText.Append("(");
            cmdText.Append("Machine_No,Working_Date,MWM_Type,Machine_Pressure,Power_First_Point,Power_Second_Point,Operator,");
            cmdText.Append("X1,X2,X3,X4,X5,X6,X7,X8,X9,X10,Last_Update_Date,Last_Updated_By");
            cmdText.Append(")");
            cmdText.Append("VALUES");
            cmdText.Append("(");
            cmdText.Append("@Machine_No,@Working_Date,@MWM_Type,@Machine_Pressure,@Power_First_Point,@Power_Second_Point,@Operator,");
            cmdText.Append("@X1,@X2,@X3,@X4,@X5,@X6,@X7,@X8,@X9,@X10,@Last_Update_Date,@Last_Updated_By");
            cmdText.Append(")");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Machine_No").Type(DbType.String).Size(50).Value(entity.MachineNo);
            paras.Create().Name("Working_Date").Type(DbType.DateTime).Size(4).Value(entity.WorkingDate);
            paras.Create().Name("MWM_Type").Type(DbType.String).Size(50).Value(entity.MWMType);
            paras.Create().Name("Machine_Pressure").Type(DbType.Int32).Size(4).Value(entity.MachinePressure);
            paras.Create().Name("Power_First_Point").Type(DbType.Int32).Size(4).Value(entity.PowerFirstPoint);
            paras.Create().Name("Power_Second_Point").Type(DbType.Int32).Size(4).Value(entity.PowerSecondPoint);
            paras.Create().Name("Operator").Type(DbType.String).Size(50).Value(entity.Operator);
            paras.Create().Name("X1").Type(DbType.Double).Size(8).Value(entity.X1);
            paras.Create().Name("X2").Type(DbType.Double).Size(8).Value(entity.X2);
            paras.Create().Name("X3").Type(DbType.Double).Size(8).Value(entity.X3);
            paras.Create().Name("X4").Type(DbType.Double).Size(8).Value(entity.X4);
            paras.Create().Name("X5").Type(DbType.Double).Size(8).Value(entity.X5);
            paras.Create().Name("X6").Type(DbType.Double).Size(8).Value(entity.X6);
            paras.Create().Name("X7").Type(DbType.Double).Size(8).Value(entity.X7);
            paras.Create().Name("X8").Type(DbType.Double).Size(8).Value(entity.X8);
            paras.Create().Name("X9").Type(DbType.Double).Size(8).Value(entity.X9);
            paras.Create().Name("X10").Type(DbType.Double).Size(8).Value(entity.X10);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SPCPullingForceInfo GetDetail(int PullingForcePK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Pulling_Force_PK").Type(DbType.Int32).Size(4).Value(PullingForcePK);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT Pulling_Force_PK,Machine_No ,Working_Date ,MWM_Type,Machine_Pressure,Power_First_Point ,Power_Second_Point,Operator ");
            cmdText.Append(" ,X1 ,X2,X3,X4,X5 ,X6,X7,X8,X9 ,X10");
            cmdText.Append(" FROM SPC_Pulling_Force");
            cmdText.Append(" WHERE Pulling_Force_PK=@Pulling_Force_PK");

            return AdoTemplate.QueryForObjectDelegate<SPCPullingForceInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SPCPullingForceInfo entity = new SPCPullingForceInfo();
                entity.PullingForcePK = Convert.ToInt32(reader["Pulling_Force_PK"]);
                entity.MachineNo = Convert.ToString(reader["Machine_No"]);
                entity.WorkingDate = Convert.ToDateTime(reader["Working_Date"]);
                entity.MWMType = Convert.ToString(reader["MWM_Type"]);
                entity.MachinePressure = Convert.ToInt32(reader["Machine_Pressure"]);
                entity.PowerFirstPoint = Convert.ToInt32(reader["Power_First_Point"]);
                entity.PowerSecondPoint = Convert.ToInt32(reader["Power_Second_Point"]);
                entity.Operator = Convert.ToString(reader["Operator"]);
                entity.X1 = Convert.ToDouble(reader["X1"]);
                entity.X2 = Convert.ToDouble(reader["X2"]);
                entity.X3 = Convert.ToDouble(reader["X3"]);
                entity.X4 = Convert.ToDouble(reader["X4"]);
                entity.X5 = Convert.ToDouble(reader["X5"]);
                entity.X6 = Convert.ToDouble(reader["X6"]);
                entity.X7 = Convert.ToDouble(reader["X7"]);
                entity.X8 = Convert.ToDouble(reader["X8"]);
                entity.X9 = Convert.ToDouble(reader["X9"]);
                entity.X10 = Convert.ToDouble(reader["X10"]);
                return entity;
            }, paras.GetParameters());
        }

        public void Update(SPCPullingForceInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" UPDATE SPC_Pulling_Force");
            cmdText.Append(" SET Machine_No = @Machine_No,");
            cmdText.Append(" Working_Date = @Working_Date,");
            cmdText.Append(" MWM_Type=@MWM_Type,");
            cmdText.Append(" Machine_Pressure=@Machine_Pressure,");
            cmdText.Append(" Power_First_Point=@Power_First_Point,");
            cmdText.Append(" Power_Second_Point=@Power_Second_Point,");
            cmdText.Append(" Operator=@Operator,");
            cmdText.Append(" X1=@X1,");
            cmdText.Append(" X2=@X2,");
            cmdText.Append(" X3=@X3,");
            cmdText.Append(" X4=@X4,");
            cmdText.Append(" X5=@X4,");
            cmdText.Append(" X6=@X6,");
            cmdText.Append(" X7=@X7,");
            cmdText.Append(" X8=@X8,");
            cmdText.Append(" X9=@X9,");
            cmdText.Append(" X10=@X10");
            cmdText.Append(" WHERE Pulling_Force_PK=@Pulling_Force_PK");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Machine_No").Type(DbType.String).Size(50).Value(entity.MachineNo);
            paras.Create().Name("Working_Date").Type(DbType.DateTime).Size(4).Value(entity.WorkingDate);
            paras.Create().Name("MWM_Type").Type(DbType.String).Size(50).Value(entity.MWMType);
            paras.Create().Name("Machine_Pressure").Type(DbType.Int32).Size(4).Value(entity.MachinePressure);
            paras.Create().Name("Power_First_Point").Type(DbType.Int32).Size(4).Value(entity.PowerFirstPoint);
            paras.Create().Name("Power_Second_Point").Type(DbType.Int32).Size(4).Value(entity.PowerSecondPoint);
            paras.Create().Name("Operator").Type(DbType.String).Size(50).Value(entity.Operator);
            paras.Create().Name("X1").Type(DbType.Double).Size(8).Value(entity.X1);
            paras.Create().Name("X2").Type(DbType.Double).Size(8).Value(entity.X2);
            paras.Create().Name("X3").Type(DbType.Double).Size(8).Value(entity.X3);
            paras.Create().Name("X4").Type(DbType.Double).Size(8).Value(entity.X4);
            paras.Create().Name("X5").Type(DbType.Double).Size(8).Value(entity.X5);
            paras.Create().Name("X6").Type(DbType.Double).Size(8).Value(entity.X6);
            paras.Create().Name("X7").Type(DbType.Double).Size(8).Value(entity.X7);
            paras.Create().Name("X8").Type(DbType.Double).Size(8).Value(entity.X8);
            paras.Create().Name("X9").Type(DbType.Double).Size(8).Value(entity.X9);
            paras.Create().Name("X10").Type(DbType.Double).Size(8).Value(entity.X10);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("Pulling_Force_PK").Type(DbType.Int32).Size(4).Value(entity.PullingForcePK);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(Int32 PullingForcePK)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" DELETE FROM SPC_Pulling_Force");
            cmdText.Append(" WHERE Pulling_Force_PK=@Pulling_Force_PK");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Pulling_Force_PK").Type(DbType.Int32).Size(4).Value(PullingForcePK);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }
    }
}

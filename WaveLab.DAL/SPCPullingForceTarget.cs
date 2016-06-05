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
    public class SPCPullingForceTarget : AdoDaoSupport, ISPCPullingForceTarget
    {
        public IList<SPCPullingForceTargetInfo> Query(string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT Pulling_Force_Target_PK,Machine_No,Effective_Date,UCL_X,LCL_X,CL_X,UCL_R,LCL_R ,CL_R ");
            cmdText.Append(" FROM SPC_Pulling_Force_Target");
            cmdText.Append(" WHERE 1=1 ");
            cmdText.Append(" order by ");
            cmdText.Append(sortBy);
            cmdText.Append(" ");
            cmdText.Append(orderBy);

            return AdoTemplate.QueryWithRowMapperDelegate<SPCPullingForceTargetInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SPCPullingForceTargetInfo item = new SPCPullingForceTargetInfo();
                item.PullingForceTargetPK = Convert.ToInt32(reader["Pulling_Force_Target_PK"]);
                item.MachineNo = Convert.ToString(reader["Machine_No"]);
                item.EffectiveDate = Convert.ToDateTime(reader["Effective_Date"]);
                item.UCL_X = Convert.ToDouble(reader["UCL_X"]);
                item.LCL_X = Convert.ToDouble(reader["LCL_X"]);
                item.CL_X = Convert.ToDouble(reader["CL_X"]);
                item.UCL_R = Convert.ToDouble(reader["UCL_R"]);
                item.LCL_R = Convert.ToDouble(reader["LCL_R"]);
                item.CL_R = Convert.ToDouble(reader["CL_R"]);
                return item;
            });
        }

        public bool CheckExists(string machineNo, string effectiveDate)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT count(*) ");
            cmdText.Append(" FROM SPC_Pulling_Force_Target");
            cmdText.Append(" WHERE   1=1");
            cmdText.Append(" AND  upper(Machine_No)=upper(@Machine_No)");
            cmdText.Append(" AND  CONVERT(VARCHAR(10),Effective_Date,120)=upper(@Effective_Date)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Machine_No").Type(DbType.String).Size(50).Value(machineNo);
            paras.Create().Name("Effective_Date").Type(DbType.String).Size(50).Value(effectiveDate);

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

        public void Save(SPCPullingForceTargetInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("INSERT INTO SPC_Pulling_Force_Target");
            cmdText.Append("(");
            cmdText.Append("Machine_No ,Effective_Date,UCL_X,LCL_X,CL_X ,UCL_R,LCL_R,CL_R,Last_Update_Date ,Last_Updated_By");
            cmdText.Append(")");
            cmdText.Append("VALUES");
            cmdText.Append("(");
            cmdText.Append("@Machine_No ,@Effective_Date,@UCL_X,@LCL_X,@CL_X ,@UCL_R,@LCL_R,@CL_R,@Last_Update_Date ,@Last_Updated_By");
            cmdText.Append(")");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Machine_No").Type(DbType.String).Size(50).Value(entity.MachineNo);
            paras.Create().Name("Effective_Date").Type(DbType.DateTime).Size(4).Value(entity.EffectiveDate);
            paras.Create().Name("UCL_X").Type(DbType.Double).Size(8).Value(entity.UCL_X);
            paras.Create().Name("LCL_X").Type(DbType.Double).Size(8).Value(entity.LCL_X);
            paras.Create().Name("CL_X").Type(DbType.Double).Size(8).Value(entity.CL_X);
            paras.Create().Name("UCL_R").Type(DbType.Double).Size(8).Value(entity.UCL_R);
            paras.Create().Name("LCL_R").Type(DbType.Double).Size(8).Value(entity.LCL_R);
            paras.Create().Name("CL_R").Type(DbType.Double).Size(8).Value(entity.CL_R);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SPCPullingForceTargetInfo GetDetail(int PullingForceTargetPK)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Pulling_Force_Target_PK").Type(DbType.Int32).Size(4).Value(PullingForceTargetPK);

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT Pulling_Force_Target_PK,Machine_No,Effective_Date,UCL_X,LCL_X,CL_X,UCL_R,LCL_R ,CL_R ");
            cmdText.Append(" FROM SPC_Pulling_Force_Target");
            cmdText.Append(" WHERE Pulling_Force_Target_PK=@Pulling_Force_Target_PK");

            return AdoTemplate.QueryForObjectDelegate<SPCPullingForceTargetInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SPCPullingForceTargetInfo entity = new SPCPullingForceTargetInfo();
                entity.PullingForceTargetPK = Convert.ToInt32(reader["Pulling_Force_Target_PK"]);
                entity.MachineNo = Convert.ToString(reader["Machine_No"]);
                entity.EffectiveDate = Convert.ToDateTime(reader["Effective_Date"]);
                entity.UCL_X = Convert.ToDouble(reader["UCL_X"]);
                entity.LCL_X = Convert.ToDouble(reader["LCL_X"]);
                entity.CL_X = Convert.ToDouble(reader["CL_X"]);
                entity.UCL_R = Convert.ToDouble(reader["UCL_R"]);
                entity.LCL_R = Convert.ToDouble(reader["LCL_R"]);
                entity.CL_R = Convert.ToDouble(reader["CL_R"]);
                return entity;
            }, paras.GetParameters());
        }

        public void Update(SPCPullingForceTargetInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" UPDATE SPC_Pulling_Force_Target ");
            cmdText.Append(" SET Machine_No = @Machine_No,");
            cmdText.Append(" Effective_Date = @Effective_Date,");
            cmdText.Append(" UCL_X=@UCL_X,");
            cmdText.Append(" LCL_X=@LCL_X,");
            cmdText.Append(" CL_X=@CL_X,");
            cmdText.Append(" UCL_R=@UCL_R,");
            cmdText.Append(" LCL_R=@LCL_R,");
            cmdText.Append(" CL_R=@CL_R");
            cmdText.Append(" WHERE Pulling_Force_Target_PK=@Pulling_Force_Target_PK");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Machine_No").Type(DbType.String).Size(50).Value(entity.MachineNo);
            paras.Create().Name("Effective_Date").Type(DbType.DateTime).Size(4).Value(entity.EffectiveDate);
            paras.Create().Name("UCL_X").Type(DbType.Double).Size(8).Value(entity.UCL_X);
            paras.Create().Name("LCL_X").Type(DbType.Double).Size(8).Value(entity.LCL_X);
            paras.Create().Name("CL_X").Type(DbType.Double).Size(8).Value(entity.CL_X);
            paras.Create().Name("UCL_R").Type(DbType.Double).Size(8).Value(entity.UCL_R);
            paras.Create().Name("LCL_R").Type(DbType.Double).Size(8).Value(entity.LCL_R);
            paras.Create().Name("CL_R").Type(DbType.Double).Size(8).Value(entity.CL_R);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("Pulling_Force_Target_PK").Type(DbType.Int32).Size(4).Value(entity.PullingForceTargetPK);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(Int32 PullingForceTargetPK)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" DELETE FROM SPC_Pulling_Force_Target");
            cmdText.Append(" WHERE Pulling_Force_Target_PK=@Pulling_Force_Target_PK");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Pulling_Force_Target_PK").Type(DbType.Int32).Size(4).Value(PullingForceTargetPK);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

using WaveLab.Model;
using WaveLab.IDAL;

using Spring.Data.Common;
using Spring.Data.Generic;

namespace WaveLab.DAL
{
    public class SPCProject : AdoDaoSupport, ISPCProject
    {        
        public IList<SPCProjectInfo> Query( string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  Project_Code,Project_Desc,Min_Times,Max_Times,Grouping_No,Receiver,CC ");
            cmdText.Append(" FROM    SPC_Project");
            cmdText.Append(" WHERE   1=1 ");

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
            return AdoTemplate.QueryWithRowMapperDelegate<SPCProjectInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SPCProjectInfo item = new SPCProjectInfo();
                item.ProjectCode = Convert.ToString(reader["Project_Code"]);
                item.ProjectDesc = Convert.ToString(reader["Project_Desc"]);
                item.MinTimes = Convert.ToInt32(reader["Min_Times"]);
                item.MaxTimes = Convert.ToInt32(reader["Max_Times"]);
                if (reader["Grouping_No"] != null)
                {
                    item.GroupingNo = Convert.ToInt32(reader["Grouping_No"]);
                }
                item.Receiver = Convert.ToString(reader["Receiver"]);
                item.CC = Convert.ToString(reader["CC"]);
                return item;
            });
        }

        public SPCProjectInfo Get(string ProjectCode)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select * from SPC_Project where Project_Code=@Project_Code");

            return AdoTemplate.QueryForObjectDelegate<SPCProjectInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SPCProjectInfo entity = new SPCProjectInfo();
                entity.ProjectCode = Convert.ToString(reader["Project_Code"]);
                entity.ProjectDesc = Convert.ToString(reader["Project_Desc"]);
                entity.MinTimes = Convert.ToInt32(reader["Min_Times"]);
                entity.MaxTimes = Convert.ToInt32(reader["Max_Times"]);
                if (reader["Grouping_No"] != null)
                {
                    entity.GroupingNo = Convert.ToInt32(reader["Grouping_No"]);
                }
                entity.Receiver = Convert.ToString(reader["Receiver"]);
                entity.CC = Convert.ToString(reader["CC"]);
                return entity;
            },
            "Project_Code", DbType.String, 50, ProjectCode);
        }
    
        public void Update(SPCProjectInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update SPC_Project set");
            cmdText.Append(" Min_Times=@Min_Times,Max_Times=@Max_Times,Grouping_No=@Grouping_No,Receiver=@Receiver,CC=@CC,Last_Update_Date=@Last_Update_Date,Last_Updated_By=@Last_Updated_By");
            cmdText.Append(" where Project_Code=@Project_Code");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Min_Times").Type(DbType.Int32).Value(entity.MinTimes);
            paras.Create().Name("Max_Times").Type(DbType.Int32).Value(entity.MaxTimes);
            paras.Create().Name("Grouping_No").Type(DbType.Int32).Value(entity.GroupingNo);
            paras.Create().Name("Receiver").Type(DbType.String).Size(500).Value(entity.Receiver);
            paras.Create().Name("CC").Type(DbType.String).Value(entity.CC);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("Project_Code").Type(DbType.String).Size(50).Value(entity.ProjectCode);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }
    }
}

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
    public class SPCEmailContainer : AdoDaoSupport, ISPCEmailContainer
    {
        public void Save(SPCEmailContainerInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into SPC_Email_Container(Project_Code,Error_PK,Subject,Body,Last_Update_Date,Last_Updated_By)");
            cmdText.Append("values(@Project_Code,@Error_PK,@Subject,@Body,@Last_Update_Date,@Last_Updated_By)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Project_Code").Type(DbType.String).Size(50).Value(entity.ProjectCode);
            paras.Create().Name("Error_PK").Type(DbType.Int32).Value(entity.ErrorPK);
            paras.Create().Name("Subject").Type(DbType.String).Value(entity.Subject);
            paras.Create().Name("Body").Type(DbType.String).Value(entity.Body);
            paras.Create().Name("Last_Update_Date").Type(DbType.DateTime).Value(entity.LastUpdateDate);
            paras.Create().Name("Last_Updated_By").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }
    }
}

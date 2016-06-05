using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;

using WaveLab.Model;
using WaveLab.IDAL;

using Spring.Data.Common;
using Spring.Data.Generic;

namespace WaveLab.DAL
{
    public class SYSFunctionControl : AdoDaoSupport, ISYSFunctionControl
    {
        #region Basic Operation

        public  bool CheckExists(string functionId)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count('x') from SYS_function_control where upper(function_id)=upper(@function_id)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("function_id").Type(DbType.String).Size(10).Value(functionId);

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

        public void Save(SYSFunctionControlInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into SYS_function_control(function_id,last_update_date,last_updated_by,creationdate,created_by,enable) ");
            cmdText.Append("values(@function_id,@last_update_date,@last_updated_by,@creationdate,@created_by,@enable)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("function_id").Type(DbType.StringFixedLength).Size(10).Value(entity.FunctionId.ToUpper());
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("enable").Type(DbType.String).Size(1).Value(entity.Enable);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Update(SYSFunctionControlInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update SYS_function_control set last_update_date=@last_update_date,");
            cmdText.Append(" last_updated_by=@last_updated_by,");
            cmdText.Append(" enable=upper(@enable)");
            cmdText.Append(" where upper(function_id)=upper(@function_id)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("enable").Type(DbType.String).Size(1).Value(entity.Enable);
            paras.Create().Name("function_id").Type(DbType.StringFixedLength).Size(10).Value(entity.FunctionId.ToUpper());

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public SYSFunctionControlInfo GetDetail(string functionId)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("SELECT function_id, enable ");
            cmdText.Append("FROM    SYS_function_control  where upper(function_id)=upper(@function_id)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("function_id").Type(DbType.StringFixedLength).Size(10).Value(functionId);

            return AdoTemplate.QueryForObjectDelegate<SYSFunctionControlInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SYSFunctionControlInfo entity = new SYSFunctionControlInfo();
                entity.FunctionId = Convert.ToString(reader["function_id"]);
                entity.Enable = Convert.ToChar(reader["enable"]);
                return entity;
            }, paras.GetParameters());
        }

        #endregion
    }
}

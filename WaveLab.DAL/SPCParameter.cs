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
    public class SPCParameter : AdoDaoSupport, ISPCParameter
    {
        public IList<SPCParameterInfo> Query()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  n,a2,d2,d3,d4,a3,c4,b3,b4");
            cmdText.Append(" FROM    spc_parameters  ");
            cmdText.Append(" WHERE   1=1 ");
            cmdText.Append(" order by n ");

            return AdoTemplate.QueryWithRowMapperDelegate<SPCParameterInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SPCParameterInfo item = new SPCParameterInfo();
                item.N = Convert.ToInt32(reader["n"]);
                if (reader["a2"] == null)
                {
                    item.A2 = null;
                }
                else
                {
                    item.A2 = Convert.ToDouble(reader["a2"]);
                }

                if (reader["d2"] == null)
                {
                    item.D2 = null;
                }
                else
                {
                    item.D2 = Convert.ToDouble(reader["d2"]);
                }
                if (reader["d3"] == null)
                {
                    item.D3 = null;
                }
                else
                {
                    item.D3 = Convert.ToDouble(reader["d3"]);
                }
                if (reader["d4"] == null)
                {
                    item.D4 = null;
                }
                else
                {
                    item.D4 = Convert.ToDouble(reader["d4"]);
                }
                if (reader["a3"] == null)
                {
                    item.A3 = null;
                }
                else
                {
                    item.A3 = Convert.ToDouble(reader["a3"]);
                }
                if (reader["c4"] == null)
                {
                    item.C4 = null;
                }
                else
                {
                    item.C4 = Convert.ToDouble(reader["c4"]);
                }
                if (reader["b3"] == null)
                {
                    item.B3 = null;
                }
                else
                {
                    item.B3 = Convert.ToDouble(reader["b3"]);
                }
                if (reader["b4"] == null)
                {
                    item.B4 = null;
                }
                else
                {
                    item.B4 = Convert.ToDouble(reader["b4"]);
                }
                return item;
            });
        }

        public void Import(IList<SPCParameterInfo> items)
        {
            string Sql;
            Sql = "delete from spc_parameters;";
            AdoTemplate.ExecuteNonQuery(CommandType.Text, Sql);

            foreach (SPCParameterInfo item in items)
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(" insert into spc_parameters ");
                cmdText.Append("(n,a2,d2,d3,d4,a3,c4,b3,b4,last_update_date,last_updated_by)");
                cmdText.Append(" values");
                cmdText.Append("(@n,@a2,@d2,@d3,@d4,@a3,@c4,@b3,@b4,@last_update_date,@last_updated_by)");

                IDbParametersBuilder paras = base.CreateDbParametersBuilder();
                paras.Create().Name("n").Type(DbType.Int32).Size(4).Value(item.N);
                paras.Create().Name("a2").Type(DbType.Double).Size(8).Value(item.A2);
                paras.Create().Name("d2").Type(DbType.Double).Size(8).Value(item.D2);
                paras.Create().Name("d3").Type(DbType.Double).Size(8).Value(item.D3);
                paras.Create().Name("d4").Type(DbType.Double).Size(8).Value(item.D4);
                paras.Create().Name("a3").Type(DbType.Double).Size(8).Value(item.A3);
                paras.Create().Name("c4").Type(DbType.Double).Size(8).Value(item.C4);
                paras.Create().Name("b3").Type(DbType.Double).Size(8).Value(item.B3);
                paras.Create().Name("b4").Type(DbType.Double).Size(8).Value(item.B4);
                paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(item.LastUpdateDate);
                paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(item.LastUpdatedBy);
                
                AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
            }
        }

        public SPCParameterInfo GetDetail(int n)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT a2,d2,d3,d4,a3,c4,b3,b4");
            cmdText.Append(" FROM   spc_parameters");
            cmdText.Append(" WHERE  1=1");
            cmdText.Append(" AND  upper(n)=upper(@n)");
    

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("n").Type(DbType.Int32).Size(4).Value(n);

            return AdoTemplate.QueryForObjectDelegate<SPCParameterInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SPCParameterInfo entity = new SPCParameterInfo();

                if (reader["a2"] == null)
                {
                    entity.A2 = null;
                }
                else
                {
                    entity.A2 = Convert.ToDouble(reader["a2"]);
                }

                if (reader["d2"] == null)
                {
                    entity.D2 = null;
                }
                else
                {
                    entity.D2 = Convert.ToDouble(reader["d2"]);
                }
                if (reader["d3"] == null)
                {
                    entity.D3 = null;
                }
                else
                {
                    entity.D3 = Convert.ToDouble(reader["d3"]);
                }
                if (reader["d4"] == null)
                {
                    entity.D4 = null;
                }
                else
                {
                    entity.D4 = Convert.ToDouble(reader["d4"]);
                }
                if (reader["a3"] == null)
                {
                    entity.A3 = null;
                }
                else
                {
                    entity.A3 = Convert.ToDouble(reader["a3"]);
                }
                if (reader["c4"] == null)
                {
                    entity.C4 = null;
                }
                else
                {
                    entity.C4 = Convert.ToDouble(reader["c4"]);
                }
                if (reader["b3"] == null)
                {
                    entity.B3 = null;
                }
                else
                {
                    entity.B3 = Convert.ToDouble(reader["b3"]);
                }
                if (reader["b4"] == null)
                {
                    entity.B4 = null;
                }
                else
                {
                    entity.B4 = Convert.ToDouble(reader["b4"]);
                }
                return entity;
            }, paras.GetParameters());
        }
    }
}

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
    public class Report : AdoDaoSupport, IReport
    {
        public IList<ReportInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  a.Report_PK,a.Title,a.Url,a.Group_Code ,b.Descript ");
            cmdText.Append(" FROM    Reports a left join Report_Group b on a.Group_Code=b.Group_Code ");
            cmdText.Append(" WHERE   1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                cmdText.Append(" AND upper(" + entry.Key + ") = upper(@" + entry.Key + ")");
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
            return AdoTemplate.QueryWithRowMapperDelegate<ReportInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                ReportInfo item = new ReportInfo();
                item.ReportPK = Convert.ToInt32(reader["Report_PK"]);
                item.Title = Convert.ToString(reader["Title"]);
                item.Url= Convert.ToString(reader["Url"]);
                item.GroupCode = Convert.ToString(reader["Group_Code"]);
                item.ReportGroup = new ReportGroupInfo() { Descript = Convert.ToString(reader["Descript"]) };
                return item;
            }, paras.GetParameters());
        }

        public bool CheckExists(string groupCode,string title)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from reports where upper(group_code)=upper(@group_code) and upper(title)=upper(@title)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("group_code").Type(DbType.String).Size(50).Value(groupCode);
            paras.Create().Name("title").Type(DbType.String).Size(50).Value(groupCode);
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

        public void Save(ReportInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into Reports(Group_Code,Title,Url,last_update_date,last_updated_by)");
            cmdText.Append("values(@Group_Code,@Title,@Url,@last_update_date,@last_updated_by)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Group_Code").Type(DbType.String).Size(50).Value(entity.GroupCode);
            paras.Create().Name("Title").Type(DbType.String).Size(50).Value(entity.Title);
            paras.Create().Name("Url").Type(DbType.String).Size(200).Value(entity.Url);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public ReportInfo GetDetail(int reportPK)
        {
            StringBuilder cmdText = new StringBuilder();

            cmdText.Append("select * from Reports where Report_PK=@Report_PK");

            return AdoTemplate.QueryForObjectDelegate<ReportInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                ReportInfo entity = new ReportInfo();
                entity.ReportPK = Convert.ToInt32(reader["Report_PK"]);
                entity.Title = Convert.ToString(reader["Title"]);
                entity.Url = Convert.ToString(reader["Url"]);
                entity.GroupCode = Convert.ToString(reader["Group_Code"]);
                return entity;
            },
            "Report_PK", DbType.Int32, 4, reportPK);
        }

        public void Update(ReportInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update Reports set");
            cmdText.Append(" Group_Code=@Group_Code,Title=@Title,Url=@Url,last_update_date=@last_update_date,last_updated_by=@last_updated_by");
            cmdText.Append(" where Report_PK=@Report_PK");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Group_Code").Type(DbType.String).Size(50).Value(entity.GroupCode);
            paras.Create().Name("Title").Type(DbType.String).Size(50).Value(entity.Title);
            paras.Create().Name("Url").Type(DbType.String).Size(200).Value(entity.Url);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("Report_PK").Type(DbType.Int32).Size(4).Value(entity.ReportPK);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(ReportInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from Report where Report_PK=@Report_PK");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Report_PK").Type(DbType.Int32).Size(4).Value(entity.ReportPK);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }
    }
}

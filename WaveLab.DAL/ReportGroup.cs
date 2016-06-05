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
    public class ReportGroup : AdoDaoSupport, IReportGroup
    {
        public ReportGroupInfo GetDetail(string groupCode)
        {
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("Group_Code").Type(DbType.String).Size(50).Value(groupCode);

            StringBuilder reportCmdText = new StringBuilder();
            reportCmdText.Append(" SELECT * ");
            reportCmdText.Append(" FROM Reports ");
            reportCmdText.Append(" WHERE Group_Code=@Group_Code");

            IList<ReportInfo> reportItems = AdoTemplate.QueryWithRowMapperDelegate<ReportInfo>(CommandType.Text, reportCmdText.ToString(), delegate(IDataReader reader, int row)
            {
                ReportInfo item = new ReportInfo();
                item.ReportPK = Convert.ToInt32(reader["Report_PK"]);
                item.Title = Convert.ToString(reader["Title"]);
                item.Url = Convert.ToString(reader["Url"]);
                item.GroupCode = Convert.ToString(reader["Group_Code"]);
                return item;
            }, paras.GetParameters());



            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select * from Report_Group where Group_Code=@Group_Code");

            return AdoTemplate.QueryForObjectDelegate<ReportGroupInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                ReportGroupInfo entity = new ReportGroupInfo();
                entity.GroupCode = Convert.ToString(reader["Group_Code"]);
                entity.Descript = Convert.ToString(reader["Descript"]);
                entity.ReportItems = reportItems;
                return entity;
            }, paras.GetParameters());
        }

        public IList<ReportGroupInfo> GetItems()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  Group_Code,Descript ");
            cmdText.Append(" FROM    Report_Group");
            cmdText.Append(" ORDER BY Group_Code");
            return AdoTemplate.QueryWithRowMapperDelegate<ReportGroupInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                ReportGroupInfo item = new ReportGroupInfo();
                item.GroupCode = Convert.ToString(reader["Group_Code"]);
                item.Descript = Convert.ToString(reader["Descript"]);
                return item;
            });
        }
    }
}

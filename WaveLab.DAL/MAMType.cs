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
    public class MAMType : AdoDaoSupport, IMAMType
    {
        public IList<MAMTypeInfo> GetItems()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  mam_type,mam_type_desc");
            cmdText.Append(" FROM    mam_type_list");
            cmdText.Append(" ORDER BY mam_type asc");
            return AdoTemplate.QueryWithRowMapperDelegate<MAMTypeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                MAMTypeInfo item = new MAMTypeInfo();
                item.MAMType = Convert.ToString(reader["mam_type"]);
                item.MAMTypeDesc = Convert.ToString(reader["mam_type_desc"]);
                return item;
            });
        }

        public MAMTypeInfo GetDetail(string MAMType)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  MAM_type,MAM_type_desc");
            cmdText.Append(" FROM    MAM_type_list");
            cmdText.Append(" where upper(MAM_type)=upper(@MAM_type)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("MAM_type").Type(DbType.String).Size(50).Value(MAMType);

            return AdoTemplate.QueryForObjectDelegate<MAMTypeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                MAMTypeInfo entity = new MAMTypeInfo();
                entity.MAMType = Convert.ToString(reader["MAM_type"]);
                entity.MAMTypeDesc = Convert.ToString(reader["MAM_type_desc"]);
                return entity;
            }, paras.GetParameters());
        }
    }
}

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
    public class Frequency : AdoDaoSupport, IFrequency
    {
        public IList<FrequencyInfo> GetItems()
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  frequency");
            cmdText.Append(" FROM    frequency_list");
            cmdText.Append(" ORDER BY frequency asc");
            return AdoTemplate.QueryWithRowMapperDelegate<FrequencyInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                FrequencyInfo item = new FrequencyInfo();
                item.Frequency = Convert.ToString(reader["frequency"]);
                return item;
            });
        }
    }
}

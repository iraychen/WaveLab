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
    public class LabelCode : AdoDaoSupport, ILabelCode
    {
        public IList<LabelCodeInfo> GetItems(string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select distinct a.* FROM  label_code a inner join barcode_list b on a.code=b.Code and a.model=b.model");
            
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

            return AdoTemplate.QueryWithRowMapperDelegate<LabelCodeInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                LabelCodeInfo item = new LabelCodeInfo();
                item.Code = Convert.ToString(reader["code"]);
                item.Antenna = Convert.ToString(reader["Antenna"]);
                item.BoxType = Convert.ToString(reader["boxtype"]);
                item.BW = Convert.ToString(reader["bw"]);
                item.Customer = Convert.ToString(reader["customer"]);
                item.Description = Convert.ToString(reader["description"]);
                item.Freq = Convert.ToString(reader["freq"]);
                item.HiLow = Convert.ToString(reader["hilow"]);
                item.HWLabelFreq = Convert.ToString(reader["hw_label_freq"]);
                item.HWLabelModel = Convert.ToString(reader["hw_label_model"]);
                item.MaxFreq = Convert.ToDouble(reader["maxfreq"]);
                item.MinFreq = Convert.ToDouble(reader["minfreq"]);
                item.Model = Convert.ToString(reader["model"]);
                item.TR = Convert.ToString(reader["tr"]);
                item.TRM = Convert.ToString(reader["trm"]);
                item.Type = Convert.ToString(reader["type"]);
                return item;
            });
        }
    }
}

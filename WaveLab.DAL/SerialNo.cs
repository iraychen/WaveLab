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
    public class SerialNo : AdoDaoSupport, ISerialNo
    {
        public IList<SerialNoInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT distinct a.orderno,a.meterialno,a.description,a.barcode,b.serial_no");
            cmdText.Append(" FROM  ext_sn_list a,barcode_list b");
            cmdText.Append(" WHERE a.barcode=b.barcode");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "order_no":
                        cmdText.Append(" AND upper(a.orderno) = upper(@" + entry.Key + ")");
                        break;
                    case "code":
                        cmdText.Append(" AND upper(a.meterialno) = upper(@" + entry.Key + ")");
                        break;
                    case "model":
                        cmdText.Append(" AND upper(a.description) = upper(@" + entry.Key + ")");
                        break;
                    case "serial_no":
                        cmdText.Append(" AND upper(b." + entry.Key + ") like upper('%'+@" + entry.Key + "+'%')");
                        break;
                    default:
                        break;
                }
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

            return AdoTemplate.QueryWithRowMapperDelegate<SerialNoInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int row)
            {
                SerialNoInfo item = new SerialNoInfo();
                item.OrderNo = Convert.ToString(reader["orderno"]);
                item.MeterialCode = Convert.ToString(reader["meterialno"]);
                item.MeterialDesc = Convert.ToString(reader["description"]);
                item.BarCode = Convert.ToString(reader["barcode"]);
                item.SerialNo = Convert.ToString(reader["serial_no"]);
                return item;
            }, paras.GetParameters());
        }
    }
}

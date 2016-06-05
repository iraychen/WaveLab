using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace WaveLab.DAL
{
    public sealed class HTToSqlParameters
    {
        public static SqlParameter[] Convert(Hashtable ht)
        {
            List<SqlParameter> collection = new List<SqlParameter>();
            foreach (DictionaryEntry htItem in ht)
            {
                collection.Add(new SqlParameter("@" + htItem.Key, htItem.Value));
            }
            SqlParameter[] paras = new SqlParameter[collection.Count];
            for (int i = 0; i < collection.Count; i++)
            {
                paras[i] = (SqlParameter)((ICloneable)collection[i]).Clone();
            }
            return paras;
        }
    }
}

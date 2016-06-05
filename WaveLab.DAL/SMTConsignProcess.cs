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
    public class SMTConsignProcess : AdoDaoSupport, ISMTConsignProcess
    {
        public IList<SMTConsignProcessInfo> Export(Hashtable hashTable,string sortBy,string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select distinct ");
            cmdText.Append(" a.material_code, ");
            cmdText.Append(" a.material_desc, ");
            cmdText.Append(" a.pcb, ");
            cmdText.Append(" a.genboard, ");
            cmdText.Append(" a.genboarddn, ");
            cmdText.Append(" a.genboarddvs, ");
            cmdText.Append(" a.speboard,");
            cmdText.Append(" a.speboarddn,");
            cmdText.Append(" a.speboarddvs, ");
            cmdText.Append(" a.smtfabricationdn,");
            cmdText.Append(" a.smtfabricationdvs, ");
            cmdText.Append(" ( ");
            cmdText.Append(" select steelmesh ");
            cmdText.Append(" from SMT_pcb_steelmesh_list ");
            cmdText.Append(" where pcb=a.pcb ");
            cmdText.Append(") ");
            cmdText.Append("steelmesh,");
            cmdText.Append("( ");
            cmdText.Append(" select coorpattern ");
            cmdText.Append(" from SMT_bom_coorpattern_list ");
            cmdText.Append(" where module=a.genboard ");
            cmdText.Append(" and bomdn=a.genboarddn ");
            cmdText.Append(" and bomdvs=a.genboarddvs ");
            cmdText.Append(")");
            cmdText.Append("coorpattern ,a.comments ");
            cmdText.Append("from SMT_file_induce_list a ");
            cmdText.Append("where 1=1");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                if (string.Equals(entry.Key, "module_type_id") == true)
                {
                    cmdText.Append(" AND upper(" + entry.Key + ") = upper(@" + entry.Key + ")");
                }
                else
                {
                    cmdText.Append(" AND upper(" + entry.Key + ") like upper('%'+@" + entry.Key + "+'%')");
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

            return AdoTemplate.QueryWithRowMapperDelegate<SMTConsignProcessInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                SMTConsignProcessInfo item = new SMTConsignProcessInfo();
                item.MaterialCode = Convert.ToString(reader["material_code"]);
                item.MaterialDesc = Convert.ToString(reader["material_desc"]);
                item.PCB = Convert.ToString(reader["pcb"]);

                item.GenBoard = Convert.ToString(reader["genboard"]);
                item.GenBoardDN = Convert.ToString(reader["genboarddn"]);
                item.GenBoardDVS = Convert.ToString(reader["genboarddvs"]);

                item.SpeBoard = Convert.ToString(reader["speboard"]);
                item.SpeBoardDN = Convert.ToString(reader["speboarddn"]);
                item.SpeBoardDVS = Convert.ToString(reader["speboarddvs"]);

                item.SMTFabricationDN = Convert.ToString(reader["smtfabricationdn"]);
                item.SMTFabricationDVS = Convert.ToString(reader["smtfabricationdvs"]);
                item.SteelMesh = Convert.ToString(reader["steelmesh"]);
                item.CoorPattern = Convert.ToString(reader["coorpattern"]);
                item.Comments = Convert.ToString(reader["comments"]);
                return item;
            }, paras.GetParameters());
        }
    }
}

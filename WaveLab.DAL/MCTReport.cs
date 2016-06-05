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
    public class MCTReport:AdoDaoSupport, IMCTReport 
    {
        public IList<RptMCTMTAnalysisInfo> QueryMCTMTAnalysis(Hashtable hashTable, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select m.product_desc, m.material_type_desc, m.component_desc, ");
            cmdText.Append("m.homo_material_name, n.substance_name, n.cas_no, round(n.substance_mass,5) substance_mass, ");
            cmdText.Append("round(case m.total_mass when 0 then 0 else n.substance_mass/m.total_mass*100 end,3) content_rate from ");
            cmdText.Append("(  ");
            cmdText.Append("	select   c.product_id,   d.product_desc, c.material_type_id,  e.material_type_desc, b.component_desc,  b.homo_material_name, ");
            cmdText.Append("    sum(case e.cal_by_quantity ");
            cmdText.Append("            when 'Y' then b.substance_mass*c.amount  else c.amount*b.content_rate/100  end)  total_mass  ");
            cmdText.Append("	from material_composition_table a  ,material_composition_dtl b, ");
            cmdText.Append("        product_bom_list c left join material_type_list e  on  c.material_type_id=e.material_type_id , ");
            cmdText.Append("	product_list d ");
            cmdText.Append("        where a.mct_id=b.mct_id  ");
            cmdText.Append("	and upper(a.supplier_name)=upper(c.supplier_name) ");
            cmdText.Append("        and upper(b.part_no)=upper(c.material_code)  ");
            cmdText.Append("	and upper(b.model)=upper(c.material_desc)  ");
            cmdText.Append("	and c.product_id=d.product_id  ");
            cmdText.Append("	and d.audited='Y' ");
            cmdText.Append("	group by c.product_id,   d.product_desc, c.material_type_id,  e.material_type_desc,  b.component_desc,  b.homo_material_name "); 
            cmdText.Append(")  m, ");
            cmdText.Append(" (  ");
            cmdText.Append("	select   c.product_id,   d.product_desc, c.material_type_id,  e.material_type_desc, b.component_desc,  b.homo_material_name, ");
            cmdText.Append("	b.substance_name,  b.cas_no,  ");
            cmdText.Append("	sum(  ");
            cmdText.Append("	case e.cal_by_quantity   when 'Y' then b.substance_mass*c.amount  else c.amount*b.content_rate/100 end ");
            cmdText.Append("        )  ");
            cmdText.Append("	substance_mass  ");
            cmdText.Append("	from material_composition_table a  ,material_composition_dtl b, ");
            cmdText.Append("	product_bom_list c left join material_type_list e  on  c.material_type_id=e.material_type_id , ");
            cmdText.Append("	product_list d ");
            cmdText.Append("        where a.mct_id=b.mct_id  ");
            cmdText.Append("	and upper(a.supplier_name)=upper(c.supplier_name)  ");
            cmdText.Append("	and upper(b.part_no)=upper(c.material_code)  ");
            cmdText.Append("	and upper(b.model)=upper(c.material_desc)  ");
            cmdText.Append("	and c.product_id=d.product_id  ");
            cmdText.Append("        and d.audited='Y'  ");
            cmdText.Append("	group by c.product_id,   d.product_desc, c.material_type_id,  e.material_type_desc, b.component_desc,  b.homo_material_name, ");
            cmdText.Append("	b.substance_name,  b.cas_no");
            cmdText.Append(") n ");
            cmdText.Append("where m.product_id=n.product_id ");
            cmdText.Append("and m.material_type_id=n.material_type_id ");
            cmdText.Append("and m.component_desc=n.component_desc  ");
            cmdText.Append("and m.homo_material_name=n.homo_material_name  ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "product_id":
                        cmdText.Append(" AND m." + entry.Key + "=@" + entry.Key + "");
                        paras.Create().Name(entry.Key.ToString()).Type(DbType.Int32).Size(4).Value(Convert.ToInt32(entry.Value));
                        break;
                    case "material_type_id":
                        cmdText.Append(" AND m." + entry.Key + "=@" + entry.Key + "");
                        paras.Create().Name(entry.Key.ToString()).Type(DbType.Int32).Size(4).Value(Convert.ToInt32(entry.Value));
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(sortBy))
            {
                cmdText.Append(" order by  ");
                cmdText.Append(sortBy);
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                cmdText.Append("  ");
                cmdText.Append(orderBy);
            }

            return AdoTemplate.QueryWithRowMapperDelegate<RptMCTMTAnalysisInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                RptMCTMTAnalysisInfo item = new RptMCTMTAnalysisInfo();
                item.ProductDesc = Convert.ToString(reader["product_desc"]);
                item.MaterialTypeDesc = Convert.ToString(reader["material_type_desc"]);
                item.ComponentDesc = Convert.ToString(reader["component_desc"]);
                item.HomoMaterialName = Convert.ToString(reader["homo_material_name"]);
                item.SubstanceName = Convert.ToString(reader["substance_name"]);
                item.CasNo = Convert.ToString(reader["cas_no"]);
                item.SubstanceMass = Convert.ToDouble(reader["substance_mass"]);
                item.ContentRate = Convert.ToDouble(reader["content_rate"]);
                return item;
            }, paras.GetParameters());
        }

        public IList<RptMCTOriginalInfo> QueryMCTOriginal(Hashtable hashTable ,string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select m.product_desc, ");
            cmdText.Append("m.material_type_desc, ");
            cmdText.Append("m.material_code, ");
            cmdText.Append("m.material_desc, ");
            cmdText.Append("m.supplier_name, ");
            cmdText.Append("m.component_desc, "); 
            cmdText.Append("m.homo_material_name, "); 
            cmdText.Append("n.substance_name, "); 
            cmdText.Append("n.cas_no, "); 
            cmdText.Append("round(n.substance_mass,5) substance_mass, ");
            cmdText.Append("round(case m.total_mass when 0 then 0 else n.substance_mass/m.total_mass*100 end,3) content_rate "); 
            cmdText.Append("from  ");
            cmdText.Append("(  ");
            cmdText.Append("select   ");
            cmdText.Append("c.product_id,   ");
            cmdText.Append("d.product_desc, ");
            cmdText.Append("c.material_code, ");
            cmdText.Append("c.material_type_id,  ");
            cmdText.Append("e.material_type_desc, ");
            cmdText.Append("c.material_desc, ");
            cmdText.Append("a.supplier_name,  ");
            cmdText.Append("b.component_desc,  ");
            cmdText.Append("b.homo_material_name,  ");
            cmdText.Append("sum(case e.cal_by_quantity   ");
            cmdText.Append("when 'Y' then b.substance_mass*c.amount  ");
            cmdText.Append("else c.amount*b.content_rate/100  ");
            cmdText.Append("end)  ");
            cmdText.Append("total_mass  ");
            cmdText.Append("from material_composition_table a  ");
            cmdText.Append(",material_composition_dtl b,  ");
            cmdText.Append("product_bom_list c left join material_type_list e  on  c.material_type_id=e.material_type_id , ");
            cmdText.Append("product_list d ");
            cmdText.Append("where a.mct_id=b.mct_id  ");
            cmdText.Append("and upper(a.supplier_name)=upper(c.supplier_name)  ");
            cmdText.Append("and upper(b.part_no)=upper(c.material_code)  ");
            cmdText.Append("and upper(b.model)=upper(c.material_desc)  ");
            cmdText.Append("and c.product_id=d.product_id  ");
            cmdText.Append("and d.audited='Y'  ");
            cmdText.Append("group by ");
            cmdText.Append("c.product_id,   ");
            cmdText.Append("d.product_desc, ");
            cmdText.Append("c.material_type_id,  ");
            cmdText.Append("e.material_type_desc, ");
            cmdText.Append("c.material_code, ");
            cmdText.Append("c.material_desc,  ");
            cmdText.Append("a.supplier_name,  ");
            cmdText.Append("b.component_desc,  ");
            cmdText.Append("b.homo_material_name  ");
            cmdText.Append(")  ");
            cmdText.Append("m,  ");
            cmdText.Append("(  ");
            cmdText.Append("select   ");
            cmdText.Append("c.product_id,   ");
            cmdText.Append("d.product_desc, ");
            cmdText.Append("c.material_type_id,  ");
            cmdText.Append("e.material_type_desc, ");
            cmdText.Append("c.material_code, ");
            cmdText.Append("c.material_desc, ");
            cmdText.Append("a.supplier_name,  ");
            cmdText.Append("b.component_desc,  ");
            cmdText.Append("b.homo_material_name,  ");
            cmdText.Append("b.substance_name,  ");
            cmdText.Append("b.cas_no,  ");
            cmdText.Append("(  ");
            cmdText.Append("case e.cal_by_quantity   ");
            cmdText.Append("when 'Y' then b.substance_mass*c.amount  ");
            cmdText.Append("else c.amount*b.content_rate/100 ");
            cmdText.Append("end  ");
            cmdText.Append(")  ");
            cmdText.Append("substance_mass  ");
            cmdText.Append("from material_composition_table a  ");
            cmdText.Append(",material_composition_dtl b,  ");
            cmdText.Append("product_bom_list c left join material_type_list e  on  c.material_type_id=e.material_type_id , ");
            cmdText.Append("product_list d ");
            cmdText.Append("where a.mct_id=b.mct_id  ");
            cmdText.Append("and upper(a.supplier_name)=upper(c.supplier_name)  ");
            cmdText.Append("and upper(b.part_no)=upper(c.material_code)  ");
            cmdText.Append("and upper(b.model)=upper(c.material_desc)  ");
            cmdText.Append("and c.product_id=d.product_id  ");
            cmdText.Append("and d.audited='Y'  ");
            cmdText.Append(") n ");
            cmdText.Append("where m.product_id=n.product_id ");
            cmdText.Append("and m.material_type_id=n.material_type_id ");
            cmdText.Append("and m.material_code=n.material_code ");
            cmdText.Append("and m.material_desc=n.material_desc ");
            cmdText.Append("and  m.supplier_name=n.supplier_name  ");
            cmdText.Append("and m.component_desc=n.component_desc  ");
            cmdText.Append("and m.homo_material_name=n.homo_material_name  ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "product_id":
                        cmdText.Append(" AND m." + entry.Key + "=@" + entry.Key + "");
                        paras.Create().Name(entry.Key.ToString()).Type(DbType.Int32).Size(4).Value(Convert.ToInt32(entry.Value));
                        break;
                    case "material_type_id":
                        cmdText.Append(" AND m." + entry.Key + "=@" + entry.Key + "");
                        paras.Create().Name(entry.Key.ToString()).Type(DbType.Int32).Size(4).Value(Convert.ToInt32(entry.Value));
                        break;
                    case "material_code":
                        cmdText.Append(" AND upper(m." + entry.Key + ") =upper(@" + entry.Key + ")");
                        paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
                        break;
                    case "material_desc":
                        cmdText.Append(" AND upper(m." + entry.Key + ") =upper(@" + entry.Key + ")");
                        paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(sortBy))
            {
                cmdText.Append(" order by  ");
                cmdText.Append(sortBy);
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                cmdText.Append("  ");
                cmdText.Append(orderBy);
            }

            return AdoTemplate.QueryWithRowMapperDelegate<RptMCTOriginalInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                RptMCTOriginalInfo item = new RptMCTOriginalInfo();
                item.ProductDesc = Convert.ToString(reader["product_desc"]);
                item.MaterialTypeDesc = Convert.ToString(reader["material_type_desc"]);
                item.MaterialCode = Convert.ToString(reader["material_code"]);
                item.MaterialDesc = Convert.ToString(reader["material_desc"]);
                item.SupplierName = Convert.ToString(reader["supplier_name"]);
                item.ComponentDesc = Convert.ToString(reader["component_desc"]);
                item.HomoMaterialName = Convert.ToString(reader["homo_material_name"]);
                item.SubstanceName = Convert.ToString(reader["substance_name"]);
                item.CasNo = Convert.ToString(reader["cas_no"]);
                item.SubstanceMass = Convert.ToDouble(reader["substance_mass"]);
                item.ContentRate = Convert.ToDouble(reader["content_rate"]);
                return item;
            }, paras.GetParameters());

        }

        public IList<RptMCTCountInfo> QueryMCTCount( Hashtable hashTable, string sortBy, string orderBy)
        {

            StringBuilder cmdText = new StringBuilder();

            cmdText.Append("select ");
            cmdText.Append("distinct ");
            cmdText.Append("a.product_id, ");
            cmdText.Append("b.product_desc, ");
            cmdText.Append("a.material_type_id, ");
            cmdText.Append("( ");
            cmdText.Append("select material_type_desc ");
            cmdText.Append("from material_type_list ");
            cmdText.Append("where  material_type_id=a.material_type_id ");
            cmdText.Append(") material_type_desc, ");
            cmdText.Append("a.material_code, ");
            cmdText.Append("a.material_desc, ");
            cmdText.Append("a.supplier_name, ");
            cmdText.Append("case  ");
            cmdText.Append("( ");
            cmdText.Append("select distinct 'x' ");
            cmdText.Append("from material_composition_table m,material_composition_dtl n ");
            cmdText.Append("where m.mct_id=n.mct_id ");
            cmdText.Append("and upper(n.part_no)=upper(a.material_code) ");
            cmdText.Append("and upper(n.model)=upper(a.material_desc) ");
            cmdText.Append("and upper(m.supplier_name)=upper(a.supplier_name) ");
            cmdText.Append(")  ");
            cmdText.Append("when 'x' then 'Y' ");
            cmdText.Append("else 'N' end supplied ");
            cmdText.Append("from product_bom_list a , ");
            cmdText.Append("product_list b ");
            cmdText.Append("where a.product_id=b.product_id ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            foreach (DictionaryEntry entry in hashTable)
            {
                switch (entry.Key.ToString())
                {
                    case "product_id":
                        cmdText.Append(" AND a." + entry.Key + "=@" + entry.Key + "");
                        paras.Create().Name(entry.Key.ToString()).Type(DbType.Int32).Size(4).Value(Convert.ToInt32(entry.Value));
                        break;
                    case "material_type_id":
                        cmdText.Append(" AND a." + entry.Key + "=@" + entry.Key + "");
                        paras.Create().Name(entry.Key.ToString()).Type(DbType.Int32).Size(4).Value(Convert.ToInt32(entry.Value));
                        break;
                    case "material_code":
                        cmdText.Append(" AND upper(a." + entry.Key + ") =upper(@" + entry.Key + ")");
                        paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
                        break;
                    case "material_desc":
                        cmdText.Append(" AND upper(a." + entry.Key + ") =upper(@" + entry.Key + ")");
                        paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
                        break;
                    case "supplier_name":
                        cmdText.Append(" AND upper(a." + entry.Key + ") =upper(@" + entry.Key + ")");
                        paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
                        break;
                    default:
                        break;
                }
            }
            //if(string.IsNullOrEmpty(productId)==false)
            //{
            //    cmdText.Append("and a.product_id=@product_id ");
            //    paras.Create().Name("product_id").Type(DbType.String).Size(50).Value(productId);
            //}
            //if (string.IsNullOrEmpty(materialTypeId) == false)
            //{
            //    cmdText.Append("and a.material_type_id=@material_type_id ");
            //    paras.Create().Name("material_type_id").Type(DbType.String).Size(50).Value(materialTypeId);
            //}

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
            return AdoTemplate.QueryWithRowMapperDelegate<RptMCTCountInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                RptMCTCountInfo item = new RptMCTCountInfo();
                item.ProductItem = new ProductInfo
                {
                     ProductId =Convert.ToInt32(reader["product_id"]),
                     ProductDesc =Convert.ToString(reader["product_desc"])
                };
                if (reader["material_type_id"] != null)
                {
                    item.MaterialTypeItem = new MaterialTypeInfo
                    {
                        MaterialTypeId = Convert.ToInt32(reader["material_type_id"]),
                        MaterialTypeDesc = Convert.ToString(reader["material_type_desc"])
                    };
                }
                item.MaterialCode = Convert.ToString(reader["material_code"]);
                item.MaterialDesc = Convert.ToString(reader["material_desc"]);
                item.SupplierName = Convert.ToString(reader["supplier_name"]);
                item.Supplied = Convert.ToChar(reader["supplied"]);
                return item;
            }, paras.GetParameters());
        }

        public IList<MCTDtlInfo> GetMaterialSubstances(string materialCode, string materialDesc, string supplierName, string sortBy, string orderBy)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select ");
            cmdText.Append("distinct ");
            cmdText.Append("a.component_desc,");
            cmdText.Append("a.homo_material_name, ");
            cmdText.Append("a.substance_name,");
            cmdText.Append("a.cas_no, ");
            cmdText.Append("a.substance_mass, ");
            cmdText.Append("a.content_rate ");
            cmdText.Append("from material_composition_dtl a,material_composition_table b ");
            cmdText.Append("where a.mct_id=b.mct_id ");
            cmdText.Append("and upper(b.supplier_name)=upper(@supplier_name) ");
            cmdText.Append("and upper(a.part_no)=upper(@material_code) ");
            cmdText.Append("and upper(a.model)=upper(@material_desc) ");
            cmdText.Append("order by " + sortBy + " " + orderBy);
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("material_code").Type(DbType.String).Size(50).Value(materialCode);
            paras.Create().Name("material_desc").Type(DbType.String).Size(50).Value(materialDesc);
            paras.Create().Name("supplier_name").Type(DbType.String).Size(50).Value(supplierName);
            return AdoTemplate.QueryWithRowMapperDelegate<MCTDtlInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader DR, int row)
            {
                MCTDtlInfo item = new MCTDtlInfo();
                item.ComponentDesc = Convert.ToString(DR["component_desc"]);
                item.HomoMaterialName = Convert.ToString(DR["homo_material_name"]);
                item.SubstanceName = Convert.ToString(DR["substance_name"]);
                item.CASNo = Convert.ToString(DR["cas_no"]);
                item.SubstanceMass = Convert.ToDouble(DR["substance_mass"]);
                item.ContentRate = Convert.ToDouble(DR["content_rate"]);
                return item;
            }, paras.GetParameters());
        }
   
        
    }
}

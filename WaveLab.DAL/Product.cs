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
    public class Product : AdoDaoSupport, IProduct
    {
        public IList<ProductInfo> GetItems(Hashtable equalHashTable, string sortBy, string orderBy)
        {
           
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" SELECT  product_id,product_desc,audited ");
            cmdText.Append(" FROM    product_list Where 1=1 ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in equalHashTable)
            {
                cmdText.Append(" AND " + entry.Key + " = @" + entry.Key + " ");
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(1).Value(entry.Value);
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
            return AdoTemplate.QueryWithRowMapperDelegate<ProductInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                ProductInfo item = new ProductInfo();
                item.ProductId = Convert.ToInt32(reader["product_id"]);
                item.ProductDesc =Convert.ToString( reader["product_desc"]);
                item.Audited = Convert.ToChar(reader["audited"]);
                return item;
            },paras.GetParameters());

        }

        public bool CheckExists(string productDesc)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from product_list where upper(product_desc)=upper(@product_desc)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("product_desc").Type(DbType.String).Size(50).Value(productDesc);
           
            int recordCount=(int)AdoTemplate.ExecuteScalar(CommandType.Text,cmdText.ToString(),paras.GetParameters());
            if(recordCount>0)
            {
                retVal=true;
            }
            else
            {
                retVal =false ;
            }
            return retVal;
        }

        public void Save(ProductInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into product_list(product_desc,last_update_date,last_updated_by,creation_date,created_by,audited)");
            cmdText.Append("values(@product_desc,@last_update_date,@last_updated_by,@creation_date,@created_by,@audited)");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("product_desc").Type(DbType.String).Size(50).Value(entity.ProductDesc);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("audited").Type(DbType.StringFixedLength).Size(1).Value(entity.Audited);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());

           

        }

        public ProductInfo GetDetail(int productId)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select * from product_list where upper(product_id)=upper(@product_id)");

            return AdoTemplate.QueryForObjectDelegate<ProductInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                ProductInfo entity = new ProductInfo();
                entity.ProductId = Convert.ToInt32(reader["product_id"]);
                entity.ProductDesc = Convert.ToString(reader["product_desc"]);
                entity.Audited = Convert.ToChar(reader["audited"]);
                return entity;
            },
            "product_id", DbType.String, 50, productId);
        }

        public bool CheckExists(ProductInfo entity, string productDesc)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from product_list where upper(product_desc)=upper(@product_desc) and product_id<>@product_id ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("product_desc").Type(DbType.String).Size(50).Value(productDesc);
            paras.Create().Name("product_id").Type(DbType.Int32).Size(4).Value(entity.ProductId);

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

        public void Update(ProductInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" update product_list set");
            cmdText.Append(" product_desc=@product_desc,last_update_date=@last_update_date,last_updated_by=@last_updated_by,audited=@audited");
            cmdText.Append(" where product_id=@product_id");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("product_desc").Type(DbType.String).Size(50).Value(entity.ProductDesc);
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("audited").Type(DbType.StringFixedLength).Size(1).Value(entity.Audited);
            paras.Create().Name("product_id").Type(DbType.Int32).Size(4).Value(entity.ProductId);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(ProductInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from product_list ");
            cmdText.Append(" where product_id=@product_id");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("product_id").Type(DbType.Int32).Size(4).Value(entity.ProductId);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public IList<ProductAuditInfo> GetSuppliedMCTItems(int productId, string status, string sortBy, string orderBy)
        {

            StringBuilder cmdText = new StringBuilder();

            cmdText.Append("select distinct ");
            cmdText.Append("k.material_code,k.material_desc,k.supplier_name,k.supplied, ");
            cmdText.Append("case  k.supplied  ");
            cmdText.Append("when 'Y' then ( ");
            cmdText.Append("select distinct m.mct_id ");
            cmdText.Append("from material_composition_table m,material_composition_dtl n ");
            cmdText.Append("where upper(n.part_no)=upper(k.material_code) ");
            cmdText.Append("and m.mct_id=n.mct_id ");
            cmdText.Append("and upper(n.model)=upper(k.material_desc) ");
            cmdText.Append("and upper(m.supplier_name)=upper(k.supplier_name) ) ");
            cmdText.Append("else null end  mct_id ");
            cmdText.Append("from ");
            cmdText.Append("( ");
            if (status == "Y" || status == "A")
            {
                cmdText.Append("select distinct ");
                cmdText.Append("t.material_code,t.material_desc,t.supplier_name,'Y' supplied ");
                cmdText.Append("from product_bom_list t ");
                cmdText.Append("where exists ");
                cmdText.Append("( ");
                cmdText.Append("select 'x' ");
                cmdText.Append("from material_composition_table a,material_composition_dtl b ");
                cmdText.Append("where a.mct_id=b.mct_id ");
                cmdText.Append("and upper(b.part_no)=upper(t.material_code) ");
                cmdText.Append("and upper(b.model)=upper(t.material_desc) ");
                cmdText.Append("and upper(a.supplier_name)=upper(t.supplier_name) ");
                cmdText.Append(")  ");
                cmdText.Append("and t.product_id=@product_id ");
            }

            if (status == "A")
            {
                cmdText.Append("union ");
            }


            if (status == "A" || status == "N")
            {
                cmdText.Append("select distinct ");
                cmdText.Append("t.material_code,t.material_desc,t.supplier_name,'N' supplied ");
                cmdText.Append("from product_bom_list t ");
                cmdText.Append("where not exists ");
                cmdText.Append("( ");
                cmdText.Append("select 'x' ");
                cmdText.Append("from material_composition_table a,material_composition_dtl b ");
                cmdText.Append("where a.mct_id=b.mct_id ");
                cmdText.Append("and upper(b.part_no)=upper(t.material_code) ");
                cmdText.Append("and upper(b.model)=upper(t.material_desc) ");
                cmdText.Append("and upper(a.supplier_name)=upper(t.supplier_name) ");
                cmdText.Append(")  ");
                cmdText.Append("and t.product_id=@product_id ");
            }
            cmdText.Append(") k ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("product_id").Type(DbType.Int32).Size(4).Value(productId);

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
            return AdoTemplate.QueryWithRowMapperDelegate<ProductAuditInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                ProductAuditInfo item = new ProductAuditInfo();
                item.MaterialCode = Convert.ToString(reader["material_code"]);
                item.MaterialDesc = Convert.ToString(reader["material_desc"]);
                item.SupplierName = Convert.ToString(reader["supplier_name"]);
                item.Supplied = Convert.ToChar(reader["supplied"]);
                if (reader["mct_id"] == DBNull.Value)
                {
                    item.MCTId = Int32.MinValue;
                }
                else
                {
                    item.MCTId = Convert.ToInt32(reader["mct_id"]);
                }
                return item;
            }, paras.GetParameters());
        }
    }
}

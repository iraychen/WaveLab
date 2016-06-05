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
    public class ProductBom :AdoDaoSupport, IProductBom
    {
        public IList<ProductBomInfo> GetItems(Hashtable equalHashTable, Hashtable hashTable, string sortBy, string orderBy)
        {

            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select ");
            cmdText.Append("a.product_bom_id, ");
            cmdText.Append("a.product_id, ");
            cmdText.Append("b.product_desc,");
            cmdText.Append("a.material_code,");
            cmdText.Append("a.material_type_id,");
            cmdText.Append("( ");
            cmdText.Append("select material_type_desc ");
            cmdText.Append("from material_type_list ");
            cmdText.Append("where material_type_id=a.material_type_id ");
            cmdText.Append(") material_type_desc,");
            cmdText.Append("a.material_desc,");
            cmdText.Append("a.supplier_name,");
            cmdText.Append("a.amount, ");
            cmdText.Append("a.module_type_id,  ");
            cmdText.Append("( ");
            cmdText.Append("select module_type_desc ");
            cmdText.Append("from SYS_module_type_list ");
            cmdText.Append("where module_type_id=a.module_type_id ");
            cmdText.Append(") module_type_desc, ");
            cmdText.Append("a.comment ");
            cmdText.Append(" from product_bom_list a ,product_list b ");
            cmdText.Append("where a.product_id=b.product_id ");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();

            foreach (DictionaryEntry entry in equalHashTable)
            {
                cmdText.Append(" AND upper(a." + entry.Key + ")=upper(@" + entry.Key + ")");
                paras.Create().Name(entry.Key.ToString()).Type(DbType.String).Size(50).Value(entry.Value);
            }

            foreach (DictionaryEntry entry in hashTable)
            {
                cmdText.Append(" AND upper(a." + entry.Key + ") like upper('%'+@" + entry.Key + "+'%')");
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
            return AdoTemplate.QueryWithRowMapperDelegate<ProductBomInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                ProductInfo productItem = new ProductInfo
                {
                    ProductId=Convert.ToInt32(reader["product_id"]),
                    ProductDesc=Convert.ToString(reader["product_desc"])
                };
                MaterialTypeInfo materialTypeItem = new MaterialTypeInfo
                {
                    MaterialTypeId=Convert.ToInt32(reader["material_type_id"]),
                    MaterialTypeDesc=Convert.ToString(reader["material_type_desc"])
                };
                SYSModuleTypeInfo moduleTypeItem= new SYSModuleTypeInfo
                {
                     ModuleTypeId=Convert.ToString(reader["module_type_id"]),
                     ModuleTypeDesc = Convert.ToString(reader["module_type_desc"])
                };
                ProductBomInfo item = new ProductBomInfo
                {
                    ProductBomId =Convert.ToInt32(reader["product_bom_id"]),
                    ProductItem=productItem,
                    MaterialCode=Convert.ToString(reader["material_code"]),
                    MaterialTypeItem=materialTypeItem,
                    MaterialDesc = Convert.ToString(reader["material_desc"]),
                    SupplierName=Convert.ToString(reader["supplier_name"]),
                    Amount=Convert.ToDouble(reader["amount"]),
                    ModuleTypeItem = moduleTypeItem,
                    Comment=Convert.ToString(reader["comment"]),
                };
                return item;
            }, paras.GetParameters());

        }

        public bool CheckExists(int productId, string materialCode,string materialDesc)
        {
            bool retVal;
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("select count(*) from  product_bom_list ");
            cmdText.Append("where product_id=@product_id ");
            cmdText.Append("and upper(material_code)=upper(@material_code) ");
            cmdText.Append("and upper(material_desc)=upper(@material_desc) ");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("product_id").Type(DbType.Int32).Size(4).Value(productId);
            paras.Create().Name("material_code").Type(DbType.String).Size(50).Value(materialCode);
            paras.Create().Name("material_desc").Type(DbType.String).Size(50).Value(materialDesc);

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

        public void Save(ProductBomInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into product_bom_list ");
            cmdText.Append("(");
            cmdText.Append("last_update_date,last_updated_by,creation_date,created_by,");
            cmdText.Append("product_id,");
            cmdText.Append("material_code,");
            cmdText.Append("material_type_id,");
            cmdText.Append("material_desc,");
            cmdText.Append("supplier_name,");
            cmdText.Append("amount,");
            cmdText.Append("module_type_id,");
            cmdText.Append("comment ");
            cmdText.Append(")");
            cmdText.Append("values");
            cmdText.Append("(");
            cmdText.Append ("@last_update_date,@last_updated_by,@creation_date,@created_by,");
            cmdText.Append("@product_id,");
            cmdText.Append("@material_code,");
            cmdText.Append("@material_type_id,");
            cmdText.Append("@material_desc,");
            cmdText.Append("@supplier_name,");
            cmdText.Append("@amount,");
            cmdText.Append("@module_type_id,");
            cmdText.Append("@comment");
            cmdText.Append(")");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("product_id").Type(DbType.Int32).Size(4).Value(entity.ProductItem.ProductId);
            paras.Create().Name("material_code").Type(DbType.String).Size(50).Value(entity.MaterialCode);
            paras.Create().Name("material_type_id").Type(DbType.Int32).Size(4).Value(entity.MaterialTypeItem.MaterialTypeId);
            paras.Create().Name("material_desc").Type(DbType.String).Size(50).Value(entity.MaterialDesc);
            paras.Create().Name("supplier_name").Type(DbType.String).Size(50).Value(entity.SupplierName);
            paras.Create().Name("amount").Type(DbType.Double).Size(8).Value(entity.Amount);
            paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(entity.ModuleTypeItem.ModuleTypeId);
            paras.Create().Name("comment").Type(DbType.String).Size(100).Value(entity.Comment);
          
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());

        }

        public ProductBomInfo GetDetail(int productBomId)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" select ");
            cmdText.Append("a.product_bom_id, ");
            cmdText.Append("a.product_id, ");
            cmdText.Append("b.product_desc,");
            cmdText.Append("a.material_code,");
            cmdText.Append("a.material_type_id,");
            cmdText.Append("( ");
            cmdText.Append("select material_type_desc ");
            cmdText.Append("from material_type_list ");
            cmdText.Append("where material_type_id=a.material_type_id ");
            cmdText.Append(") material_type_desc,");
            cmdText.Append("a.material_desc,");
            cmdText.Append("a.supplier_name,");
            cmdText.Append("a.amount, ");
            cmdText.Append("a.module_type_id,  ");
            cmdText.Append("( ");
            cmdText.Append("select module_type_desc ");
            cmdText.Append("from SYS_module_type_list ");
            cmdText.Append("where module_type_id=a.module_type_id ");
            cmdText.Append(") module_type_desc, ");
            cmdText.Append("a.comment ");
            cmdText.Append(" from product_bom_list a ,product_list b ");
            cmdText.Append("where a.product_id=b.product_id ");
            cmdText.Append("and product_bom_id=@product_bom_id");

            return AdoTemplate.QueryForObjectDelegate<ProductBomInfo>(CommandType.Text, cmdText.ToString(), delegate(IDataReader reader, int rowNum)
            {
                ProductInfo productItem = new ProductInfo
                {
                    ProductId = Convert.ToInt32(reader["product_id"]),
                    ProductDesc = Convert.ToString(reader["product_desc"])
                };
                MaterialTypeInfo materialTypeItem = new MaterialTypeInfo
                {
                    MaterialTypeId = Convert.ToInt32(reader["material_type_id"]),
                    MaterialTypeDesc = Convert.ToString(reader["material_type_desc"])
                };
                SYSModuleTypeInfo moduleTypeItem = new SYSModuleTypeInfo
                {
                    ModuleTypeId = Convert.ToString(reader["module_type_id"]),
                    ModuleTypeDesc = Convert.ToString(reader["module_type_desc"])
                };
                ProductBomInfo entity = new ProductBomInfo
                {
                    ProductBomId = Convert.ToInt32(reader["product_bom_id"]),
                    ProductItem = productItem,
                    MaterialCode = Convert.ToString(reader["material_code"]),
                    MaterialTypeItem = materialTypeItem,
                    MaterialDesc = Convert.ToString(reader["material_desc"]),
                   
                    SupplierName = Convert.ToString(reader["supplier_name"]),
                   
                    Amount = Convert.ToDouble(reader["amount"]),
                    ModuleTypeItem = moduleTypeItem,
                    Comment = Convert.ToString(reader["comment"]),
                   
                };
                return entity;
            },
            "product_bom_id", DbType.String, 50, productBomId);
        }

        public void Update(ProductBomInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("update product_bom_list set ");
            cmdText.Append("last_update_date=@last_update_date,last_updated_by=@last_updated_by,");
            cmdText.Append("material_type_id=@material_type_id,");
            cmdText.Append("supplier_name=@supplier_name,");
            cmdText.Append("amount=@amount,");
            cmdText.Append("module_type_id=@module_type_id,");
            cmdText.Append("comment=@comment ");
            cmdText.Append("where product_bom_id=@product_bom_id");

            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("material_type_id").Type(DbType.Int32).Size(4).Value(entity.MaterialTypeItem.MaterialTypeId);
            paras.Create().Name("supplier_name").Type(DbType.String).Size(50).Value(entity.SupplierName);
            paras.Create().Name("amount").Type(DbType.Double).Size(8).Value(entity.Amount);
            paras.Create().Name("module_type_id").Type(DbType.String).Size(50).Value(entity.ModuleTypeItem.ModuleTypeId);
            paras.Create().Name("comment").Type(DbType.String).Size(100).Value(entity.Comment);
            paras.Create().Name("product_bom_id").Type(DbType.Int32).Size(4).Value(entity.ProductBomId);

            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(ProductBomInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from product_bom_list ");
            cmdText.Append(" where product_bom_id=@product_bom_id");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("product_bom_id").Type(DbType.Int32).Size(4).Value(entity.ProductBomId);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Delete(int productId)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(" delete from product_bom_list ");
            cmdText.Append(" where product_id=@product_id");
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("product_id").Type(DbType.Int32).Size(4).Value(productId);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }

        public void Import(ProductBomInfo entity)
        {
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append("insert into product_bom_list ");
            cmdText.Append("select ");
            cmdText.Append("@last_update_date,@last_updated_by,@creation_date,@created_by,");
            cmdText.Append("@product_id,");
            cmdText.Append("@material_code,");
            cmdText.Append("(select material_type_id from material_type_list where upper(material_type_desc)=upper(@material_type_desc)),");
            cmdText.Append("@material_desc,");
            cmdText.Append("@supplier_name,");
            cmdText.Append("@amount,");
            cmdText.Append("(select module_type_id from SYS_module_type_list where upper(module_type_desc)=upper(@module_type_desc)),");
            cmdText.Append("@comment");
           
            IDbParametersBuilder paras = base.CreateDbParametersBuilder();
            paras.Create().Name("last_update_date").Type(DbType.DateTime).Size(4).Value(entity.LastUpdateDate);
            paras.Create().Name("last_updated_by").Type(DbType.String).Size(50).Value(entity.LastUpdatedBy);
            paras.Create().Name("creation_date").Type(DbType.DateTime).Size(4).Value(entity.CreationDate);
            paras.Create().Name("created_by").Type(DbType.String).Size(50).Value(entity.CreatedBy);
            paras.Create().Name("product_id").Type(DbType.Int32).Size(4).Value(entity.ProductItem.ProductId);
            paras.Create().Name("material_code").Type(DbType.String).Size(50).Value(entity.MaterialCode);
            paras.Create().Name("material_type_desc").Type(DbType.String).Size(50).Value(entity.MaterialTypeItem.MaterialTypeDesc);
            paras.Create().Name("material_desc").Type(DbType.String).Size(50).Value(entity.MaterialDesc);
            paras.Create().Name("supplier_name").Type(DbType.String).Size(50).Value(entity.SupplierName);
            paras.Create().Name("amount").Type(DbType.Double).Size(8).Value(entity.Amount);
            paras.Create().Name("module_type_desc").Type(DbType.String).Size(50).Value(entity.ModuleTypeItem.ModuleTypeDesc);
            paras.Create().Name("comment").Type(DbType.String).Size(100).Value(entity.Comment);
            AdoTemplate.ExecuteNonQuery(CommandType.Text, cmdText.ToString(), paras.GetParameters());
        }
    }
}

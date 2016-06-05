using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;
using WaveLab.IService;
using WaveLab.IDAL;

namespace WaveLab.Service
{
    public class ProductService:IProductService
    {
        public IProduct dal;

        public IList<ProductInfo> GetItems(Hashtable equalHashTable, string sortBy, string orderBy)
        {
            return dal.GetItems(equalHashTable,sortBy, orderBy);
        }

        public bool CheckExists(string productDesc)
        {
            return dal.CheckExists(productDesc);
        }

        public void Save(ProductInfo entity)
        {
            dal.Save(entity);
        }

        public ProductInfo GetDetail(int productId)
        {
            return dal.GetDetail(productId);
        }

        public void Update(ProductInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(ProductInfo entity)
        {
            dal.Delete(entity);
        }

        public bool CheckExists(ProductInfo entity, string productDesc)
        {
            return dal.CheckExists(entity,productDesc);
        }

        public IList<ProductAuditInfo> GetSuppliedMCTItems(int productId, string status, string sortBy, string orderBy)
        {
            return dal.GetSuppliedMCTItems(productId, status, sortBy, orderBy);
        }
    }
}

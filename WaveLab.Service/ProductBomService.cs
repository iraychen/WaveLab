using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

namespace WaveLab.Service
{
    public class ProductBomService: IProductBomService
    {
        public IProductBom dal;

        public IList<ProductBomInfo> GetItems(Hashtable equalHashTable, Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.GetItems(equalHashTable,hashTable,sortBy,orderBy);
        }

        public bool CheckExists(int productId, string materialCode,string materialDesc)
        {
            return dal.CheckExists(productId, materialCode,materialDesc);
        }

        public void Save(ProductBomInfo entity)
        {
            dal.Save(entity);
        }

        public ProductBomInfo GetDetail(int productBomId)
        {
            return dal.GetDetail(productBomId);
        }

        public void Update(ProductBomInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(ProductBomInfo entity)
        {
            dal.Delete(entity);
        }

        public void Import(int productId,IList<ProductBomInfo> items)
        {

            dal.Delete(productId);

            foreach (ProductBomInfo item in items)
            {
                dal.Import(item);
            }
        }
    }
}

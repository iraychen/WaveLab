using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IProduct
    {
        IList<ProductInfo> GetItems(Hashtable equalHashTable, string sortBy, string orderBy);

        bool CheckExists(string productDesc);

        void  Save(ProductInfo entity);

        ProductInfo GetDetail(int productId);

        bool CheckExists(ProductInfo entity,string productDesc);

        void Update(ProductInfo entity);

        void Delete(ProductInfo entity);

        IList<ProductAuditInfo> GetSuppliedMCTItems(int productId, string status, string sortBy, string orderBy); 
    }
}

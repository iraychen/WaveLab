using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IProductBom
    {
        IList<ProductBomInfo> GetItems(Hashtable equalHashTable ,Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(int productId, string materialCode, string materialDesc);

        void Save(ProductBomInfo entity);

        ProductBomInfo GetDetail(int productBomId);

        void Update(ProductBomInfo entity);

        void Delete(ProductBomInfo entity);

        void Delete(int productId);

        void Import(ProductBomInfo entity);

    }
}

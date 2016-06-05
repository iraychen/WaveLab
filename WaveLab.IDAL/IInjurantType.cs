using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IInjurantType
    {
        IList<InjurantTypeInfo> GetItems(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string injurantTypeDesc);

        void Save(InjurantTypeInfo entity);

        InjurantTypeInfo GetDetail(int injurantTypeId);

        bool CheckExists(InjurantTypeInfo entity, string injurantTypeDesc);

        void Update(InjurantTypeInfo entity);

        void Delete(InjurantTypeInfo entity);
    }
}

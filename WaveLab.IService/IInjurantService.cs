using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IService
{
    public interface IInjurantService
    {
        IList<InjurantInfo> GetItems(Hashtable equalHashTable, Hashtable hashTable, string sortBy, string orderBy);


        bool CheckExists(string injurantDescCn, string injurantDescEn, string casNo);

        bool CheckInjuct(string substanceName, string casNo);

        void Save(InjurantInfo entity);

        InjurantInfo GetDetail(int injurantId);

        bool CheckExists(InjurantInfo entity, string injurantDescCn, string injurantDescEn, string casNo);

        void Update(InjurantInfo entity);

        void Delete(InjurantInfo entity);
    }
}

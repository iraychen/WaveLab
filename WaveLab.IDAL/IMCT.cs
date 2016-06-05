using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IMCT
    {

        IList<MCTInfo> GetItems(Hashtable equalHashTable, Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string supplierName, string portNo, string model);

        void Save(MCTInfo entity);

        MCTInfo GetDetail(int mctId);

        void Update(string supplierName, string partNo, string model, MCTInfo entity);

        void Delete(MCTInfo entity);

        IList<MCTQueryInfo> Query(Hashtable hashTable, string sortBy, string orderBy);
    }
}

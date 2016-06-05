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
    public class MCTService :IMCTService
    {
        public IMCT dal;

        public IList<MCTInfo> GetItems(Hashtable equalHashTable, Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.GetItems(equalHashTable,hashTable, sortBy, orderBy);
        }

        public bool CheckExists(string supplierName, string portNo, string model)
        {
            return dal.CheckExists(supplierName, portNo, model);
        }

        public void Save(MCTInfo entity)
        {
            dal.Save(entity);
        }

        public MCTInfo GetDetail(int mctId)
        {
            return dal.GetDetail(mctId);
        }

        public void Update(string supplierName, string partNo, string model, MCTInfo entity)
        {
            dal.Update(supplierName, partNo, model, entity);
        }

        public void Delete(MCTInfo entity)
        {
            dal.Delete(entity);
        }

        public IList<MCTQueryInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }
    }
}

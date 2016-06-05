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
    public class SMTConsignProcessService : ISMTConsignProcessService
    {
        public ISMTConsignProcess dal;

        public IList<SMTConsignProcessInfo> Export(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Export(hashTable, sortBy, orderBy);
        }
    }
}

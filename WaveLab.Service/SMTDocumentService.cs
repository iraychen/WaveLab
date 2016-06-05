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
    public sealed class SMTDocumentService : ISMTDocumentService
    {
        public ISMTDocument dal;

        public IList<SMTDocumentInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

        public void Import(IList<SMTDocumentInfo> items)
        {
            dal.Import(items);
        }
    }
}

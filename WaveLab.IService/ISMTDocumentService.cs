using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;
using System.Collections;

namespace WaveLab.IService
{
    public interface ISMTDocumentService
    {
        IList<SMTDocumentInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        void Import(IList<SMTDocumentInfo> items);
    }
}

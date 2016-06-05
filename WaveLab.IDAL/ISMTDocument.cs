using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISMTDocument
    {
        IList<SMTDocumentInfo> Query(Hashtable hashTable, string sortBy, string orderBy);
       
        void Import(IList<SMTDocumentInfo> items);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ISMTConsignProcessService
    {
        IList<SMTConsignProcessInfo> Export(Hashtable hashTable, string sortBy, string orderBy);
    }
}

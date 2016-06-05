using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISerialNo
    {
        IList<SerialNoInfo> Query(Hashtable hashTable, string sortBy, string orderBy);
    }
}

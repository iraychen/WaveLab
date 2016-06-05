using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IFQATxMaskFlat
    {
        int Query(Hashtable hashTable);

        IList<FQATxMaskFlatInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<FQATxMaskFlatInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        FQATxMaskFlatInfo GetDetail(int FQATxMaskFlatId);
    }
}

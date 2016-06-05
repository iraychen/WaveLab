using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IFQATxMask
    {
        int Query(Hashtable hashTable);

        IList<FQATxMaskInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<FQATxMaskInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        FQATxMaskInfo GetDetail(int FQATxMaskId);
    }
}

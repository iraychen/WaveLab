using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface IFQATxSpurService
    {
        int Query(Hashtable hashTable);

        IList<FQATxSpurInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<FQATxSpurInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        FQATxSpurInfo GetDetail(int FQATxSpurId);
    }
}

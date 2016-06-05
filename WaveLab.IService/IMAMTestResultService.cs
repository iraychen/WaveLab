using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface IMAMTestResultService
    {
        int Query(Hashtable hashTable);

        IList<MAMTestResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        IList<MAMTestResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        MAMTestResultInfo GetDetail(int MAMTestResultId);
    }
}

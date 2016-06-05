using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Caching;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

namespace WaveLab.Service
{
    public class GeneralInitService:  IGeneralInitService
    {
        public IGeneralInit dal;

        public int Query(Hashtable hashTable)
        {
            return dal.Query(hashTable);
        }

        public IList<GeneralInitInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.Query(hashTable, sortBy,orderBy, page, pageSize);
        }

        public IList<GeneralInitInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query( hashTable, sortBy, orderBy);
        }

        public GeneralInitInfo GetDetail(int generalInitId)
        {
            return dal.GetDetail(generalInitId);
        }

        public bool GeneralInitCheck(string serialNo)
        {
            return dal.GeneralInitCheck(serialNo);
        }

    }
}

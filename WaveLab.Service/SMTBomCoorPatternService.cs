using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.HSSF.UserModel.Contrib;
using NPOI.SS.Util;
using NPOI.SS.UserModel;

namespace WaveLab.Service
{
    public  class SMTBomCoorPatternService:ISMTBomCoorPatternService
    {
        public ISMTBomCoorPattern dal;

        public IList<SMTBomCoorPatternInfo> Query(Hashtable hashTable, string sortBy, string oderBy)
        {
            return dal.Query(hashTable, sortBy, oderBy);
        }

        public  bool CheckExists(string module, string bomdn, string bomdvs)
        {
            return dal.CheckExists(module,bomdn,bomdvs);
        }

        public void Import(IList<SMTBomCoorPatternInfo> newItems, IList<SMTBomCoorPatternInfo> editItems)
        {
            foreach (SMTBomCoorPatternInfo newItem in newItems)
            {
                dal.Save(newItem);
            }
            foreach (SMTBomCoorPatternInfo editItem in editItems)
            {
                dal.Update(editItem);
            }
        }

        public void Save(SMTBomCoorPatternInfo entity)
        {
            dal.Save(entity);
        }

        public SMTBomCoorPatternInfo GetDetail(string module, string bomdn, string bomdvs)
        {
            return dal.GetDetail(module, bomdn, bomdvs);
        }

        public void Update(SMTBomCoorPatternInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SMTBomCoorPatternInfo entity)
        {
            dal.Delete(entity);
        }

    }
}

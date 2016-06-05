using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.Service
{
    public class SYSSectionService : WaveLab.IService.ISYSSectionService
    {
        public WaveLab.IDAL.ISYSSection dal;

        public IList<SYSSectionInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

        public  bool CheckExists(string sectionId)
        {
            return dal.CheckExists(sectionId);
        }

        public void Save(SYSSectionInfo entity)
        {
            dal.Save(entity);
        }

        public SYSSectionInfo GetDetail(string sectionId)
        {
            return dal.GetDetail(sectionId);
        }

        public void Update(SYSSectionInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SYSSectionInfo entity)
        {
            dal.Delete(entity);
        }

        public IList<SYSSectionInfo> GetItems()
        {
            return dal.GetItems();
        }
    }
}

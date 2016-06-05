using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

namespace WaveLab.Service
{
    public class SMTPCBSteelMeshService :ISMTPCBSteelMeshService
    {
        public ISMTPCBSteelMesh dal;

        public IList<SMTPCBSteelMeshInfo> Query(Hashtable hashTable, string sortBy, string oderBy)
        {
            return dal.Query(hashTable, sortBy, oderBy);
        }

        public  bool CheckExists(string pcb)
        {
            return dal.CheckExists(pcb);
        }

        public void Save(SMTPCBSteelMeshInfo entity)
        {
            dal.Save(entity);
        }

        public SMTPCBSteelMeshInfo GetDetail(string pcb)
        {
            return dal.GetDetail(pcb);
        }

        public void Update(SMTPCBSteelMeshInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SMTPCBSteelMeshInfo entity)
        {
            dal.Delete(entity);
        }

        public IList<SMTPCBSteelMeshInfo> Export(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Export(hashTable, sortBy, orderBy);
        }
    }
}

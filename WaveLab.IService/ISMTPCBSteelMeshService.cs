using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;
using System.Collections;

namespace WaveLab.IService
{
    public interface ISMTPCBSteelMeshService
    {
        IList<SMTPCBSteelMeshInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string pcb);

        void Save(SMTPCBSteelMeshInfo entity);

        SMTPCBSteelMeshInfo GetDetail(string pcb);

        void Update(SMTPCBSteelMeshInfo entity);

        void Delete(SMTPCBSteelMeshInfo entity);

        IList<SMTPCBSteelMeshInfo> Export(Hashtable hashTable, string sortBy, string orderBy);
    }
}

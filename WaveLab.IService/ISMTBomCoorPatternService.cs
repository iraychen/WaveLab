using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using WaveLab.Model;

namespace WaveLab.IService
{
   public interface ISMTBomCoorPatternService
    {
        IList<SMTBomCoorPatternInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string module, string bomdn, string bomdvs);

        void Import(IList<SMTBomCoorPatternInfo> newItems, IList<SMTBomCoorPatternInfo> editItems);

        void Save(SMTBomCoorPatternInfo entity);

        SMTBomCoorPatternInfo GetDetail(string module, string bomdn, string bomdvs);

        void Update(SMTBomCoorPatternInfo entity);

        void Delete(SMTBomCoorPatternInfo entity);      
    }
}

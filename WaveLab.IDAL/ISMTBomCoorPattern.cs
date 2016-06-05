using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
   public interface ISMTBomCoorPattern
    {
       IList<SMTBomCoorPatternInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string module, string bomdn, string bomdvs);

        void Save(SMTBomCoorPatternInfo entity);

        SMTBomCoorPatternInfo GetDetail(string module, string bomdn, string bomdvs);

        void Update(SMTBomCoorPatternInfo entity);

        void Delete(SMTBomCoorPatternInfo entity);

    }
}

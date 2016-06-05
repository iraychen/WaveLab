using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISMTCPTemplate
    {
        IList<SMTCPTemplateInfo> Query(string sortBy, string orderBy);
      
        bool CheckExists(string EffectiveDate);

        void Save(SMTCPTemplateInfo entity);

        void Delete(SMTCPTemplateInfo entity);

        SMTCPTemplateInfo GetExportTemplate();
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;
using System.Collections;

namespace WaveLab.IService
{
    public interface ISMTCPTemplateService
    {

        IList<SMTCPTemplateInfo> Query(string sortBy, string orderBy);
      
        bool CheckExists(string EffectiveDate);

        void Save(SMTCPTemplateInfo entity);

        void Delete(SMTCPTemplateInfo entity);

        SMTCPTemplateInfo GetExportTemplate();
      
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

namespace WaveLab.Service
{
    public  class SMTCPTemplateService: ISMTCPTemplateService
    {
       public ISMTCPTemplate dal;

       public bool CheckExists(string EffectiveDate)
       {
           return dal.CheckExists(EffectiveDate);
       }

       public void Save(SMTCPTemplateInfo entity)
       {
           dal.Save(entity);
       }

       public  IList<SMTCPTemplateInfo> Query(string sortBy, string orderBy)
       {
           return dal.Query(sortBy, orderBy);
       }

       public  SMTCPTemplateInfo GetExportTemplate()
       {
           return dal.GetExportTemplate();
       }

       public  void Delete(SMTCPTemplateInfo entity)
       {
           dal.Delete(entity);
       }
    }
}

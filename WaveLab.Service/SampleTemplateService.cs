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
    public  class SampleTemplateService: ISampleTemplateService
    {
       public ISampleTemplate dal;

       public IList<SampleTemplateInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
       {
           return dal.Query(hashTable,sortBy, orderBy);
       }

       public bool CheckExists(string sampleTemplateId,string EffectiveDate)
       {
           return dal.CheckExists(sampleTemplateId,EffectiveDate);
       }

       public void Save(SampleTemplateInfo entity)
       {
           dal.Save(entity);
       }

       public void Delete(SampleTemplateInfo entity)
       {
           dal.Delete(entity);
       }

       public SampleTemplateInfo GetDetail(string sampleTemplateId, string effectiveDate)
       {
           return dal.GetDetail(sampleTemplateId, effectiveDate);
       }

       public SampleTemplateInfo GetSampleTemplate(string sampleTemplateId)
       {
           return dal. GetSampleTemplate(sampleTemplateId);
       }
    }
}

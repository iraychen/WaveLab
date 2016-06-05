using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;
using System.Collections;

namespace WaveLab.IService
{
    public interface ISampleTemplateService
    {
        IList<SampleTemplateInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string sampleTemplateId, string effectiveDate);

        void Save(SampleTemplateInfo entity);

        void Delete(SampleTemplateInfo entity);

        SampleTemplateInfo GetDetail(string sampleTemplateId, string effectiveDate);

        SampleTemplateInfo GetSampleTemplate(string sampleTemplateId);
    }
}

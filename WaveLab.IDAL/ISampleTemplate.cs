using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISampleTemplate
    {
        IList<SampleTemplateInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string sampleTemplateId, string effectiveDate);

        void Save(SampleTemplateInfo entity);

        void Delete(SampleTemplateInfo entity);

        SampleTemplateInfo GetDetail(string sampleTemplateId, string effectiveDate);

        SampleTemplateInfo GetSampleTemplate(string sampleTemplateId);
    }
}

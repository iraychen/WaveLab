using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IService
{
    public interface IReportService
    {
        IList<ReportInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string groupCode, string title);

        void Save(ReportInfo entity);

        ReportInfo GetDetail(int reportPK);

        void Update(ReportInfo entity);

        void Delete(ReportInfo entity);

    }
}

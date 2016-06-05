using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IReport
    {
        IList<ReportInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string groupCode, string title );

        void Save(ReportInfo entity);

        ReportInfo GetDetail(int reportPK);

        void Update(ReportInfo entity);

        void Delete(ReportInfo entity);
     

    }
}

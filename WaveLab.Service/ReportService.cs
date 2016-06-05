using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

namespace WaveLab.Service
{
    public class ReportService : IReportService
    {
        public IReport dal;

        public IList<ReportInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query(hashTable,sortBy, orderBy);
        }

        public bool CheckExists(string groupCode, string title)
        {
            return dal.CheckExists(groupCode,title);
        }

        public void Save(ReportInfo entity)
        {
            dal.Save(entity);
        }

        public ReportInfo GetDetail(int reportPK)
        {
            return dal.GetDetail(reportPK);
        }

        public void Update(ReportInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(ReportInfo entity)
        {
            dal.Delete(entity);
        }     
    }
}

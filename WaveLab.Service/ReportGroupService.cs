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
    public class ReportGroupService: IReportGroupService
    {
        public IReportGroup dal;

        public ReportGroupInfo GetDetail(string groupCode)
        {
            return dal.GetDetail(groupCode);
        }

        public IList<ReportGroupInfo> GetItems()
        {
            return dal.GetItems();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;


namespace WaveLab.IDAL
{
    public interface IReportGroup
    {
        ReportGroupInfo GetDetail(string groupCode);

        IList<ReportGroupInfo> GetItems();

    }
}

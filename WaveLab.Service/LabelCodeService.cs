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
    public class LabelCodeService : ILabelCodeService
    {
        public ILabelCode dal;

        public IList<LabelCodeInfo> GetItems(string sortBy, string orderBy)
        {
            return dal.GetItems(sortBy, orderBy);
        }
    }
}

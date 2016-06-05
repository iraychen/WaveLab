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
    public class FrequencyService : IFrequencyService
    {
        public IFrequency dal;

        public IList<FrequencyInfo> GetItems()
        {
            return dal.GetItems();
        }
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface IFrequencyService
    {
        IList<FrequencyInfo> GetItems();
    }
}

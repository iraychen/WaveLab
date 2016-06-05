using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ILabelCodeService
    {
        IList<LabelCodeInfo> GetItems(string sortBy, string orderBy);
    }
}

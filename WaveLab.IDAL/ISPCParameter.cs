using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCParameter
    {
        IList<SPCParameterInfo> Query();

        void Import(IList<SPCParameterInfo> items);

        SPCParameterInfo GetDetail(int n);
    }
}

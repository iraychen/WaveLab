using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface IMAMType
    {
        IList<MAMTypeInfo> GetItems();

        MAMTypeInfo GetDetail(string MAMType);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.IDAL
{
    public interface ISYSSerialNoGenerator
    {
        string GenerateSerialNo(string code);

    }
}

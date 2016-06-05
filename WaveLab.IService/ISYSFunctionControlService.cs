using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface ISYSFunctionControlService
    {
        bool CheckExists(string functionId);
      
        void Save(SYSFunctionControlInfo info);

        void Update(SYSFunctionControlInfo info);

        SYSFunctionControlInfo GetDetail(string functionId);
       
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;

namespace WaveLab.IDAL
{
    public interface ISPCProject
    {
        IList<SPCProjectInfo> Query(string sortBy, string orderBy);

        SPCProjectInfo Get(string ProjectCode);

        void Update(SPCProjectInfo entity);

    }
}

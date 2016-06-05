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
    public class SPCProjectService : ISPCProjectService
    {
        public ISPCProject dal;

        public IList<SPCProjectInfo> Query(string sortBy, string orderBy)
        {
            return dal.Query(sortBy, orderBy);
        }

        public SPCProjectInfo Get(string ProjectCode)
        {
            return dal.Get(ProjectCode);
        }

        public void Update(SPCProjectInfo entity)
        {
            dal.Update(entity);
        }
    }
}

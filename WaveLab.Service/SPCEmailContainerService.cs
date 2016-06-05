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
    public class SPCEmailContainerService : ISPCEmailContainerService
    {
        public ISPCEmailContainer dal;

      
        public void Save(SPCEmailContainerInfo entity)
        {
            dal.Save(entity);
        }
    }
}

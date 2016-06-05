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
    public sealed  class SYSFunctionControlService:ISYSFunctionControlService
    {

        public ISYSFunctionControl dal;

        public SYSFunctionControlInfo GetDetail(string functionId)
        {
            return dal.GetDetail(functionId);
        }

        public  bool CheckExists(string functionId)
        {
            return dal.CheckExists(functionId);
        }

        public void Save(SYSFunctionControlInfo entity)
        {
            dal.Save(entity);
        }

        public void Update(SYSFunctionControlInfo entity)
        {
            dal.Update(entity);
        }
    }
}

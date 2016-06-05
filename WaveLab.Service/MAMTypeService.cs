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
    public class MAMTypeService : IMAMTypeService
    {
        public IMAMType dal;

        public IList<MAMTypeInfo> GetItems()
        {
            return dal.GetItems();
        }

        public MAMTypeInfo GetDetail(string MAMType)
        {
            return dal.GetDetail(MAMType);
        }
    }
}

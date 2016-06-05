using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WaveLab.Model;

namespace WaveLab.IService
{
    public interface IItemService
    {
       List<ItemInfo> GetItems();
    }
}

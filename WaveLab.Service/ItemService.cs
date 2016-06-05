using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;
using System.Web;

namespace WaveLab.Service
{
    public  class ItemService:WaveLab.IService.IItemService
    {
        public  List<ItemInfo> GetItems()
        {
            List<ItemInfo> items = new List<ItemInfo>();

            ItemInfo itemY = new ItemInfo();
            itemY.ItemValue = "Y";
            itemY.ItemText = HttpContext.GetGlobalResourceObject("globalItems", "Ykey").ToString();
            items.Add(itemY);

            ItemInfo itemN = new ItemInfo();
            itemN.ItemValue = "N";
            itemN.ItemText = HttpContext.GetGlobalResourceObject("globalItems", "Nkey").ToString();
            items.Add(itemN);
            return items;
        }
    }
}

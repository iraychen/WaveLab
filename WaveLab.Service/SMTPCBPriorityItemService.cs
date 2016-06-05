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
   public class SMTPCBPriorityItemService:ISMTPCBPriorityItemService
    {
        public ISMTPCBPriorityItem dal;

        public IList<SMTPCBPriorityItemInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

        public SMTPCBPriorityItemInfo GetDetail(string pcb)
        {
            return dal.GetDetail(pcb);
        }

        public bool CheckExists(string pcb)
        {
            return dal.CheckExists(pcb);
        }

        public void SavePriorityItem(IList<SMTPCBPriorityItemInfo> newItems, IList<SMTPCBPriorityItemInfo> editItems)
        {
            dal.SavePriorityItem(newItems, editItems);
        }
    }
}

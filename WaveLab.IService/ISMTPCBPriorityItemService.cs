using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;
using System.Collections;

namespace WaveLab.IService
{
    public interface ISMTPCBPriorityItemService
    {
        IList<SMTPCBPriorityItemInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        SMTPCBPriorityItemInfo GetDetail(string pcb);

        bool CheckExists(string pcb);

        void SavePriorityItem(IList<SMTPCBPriorityItemInfo> newItems, IList<SMTPCBPriorityItemInfo> editItems);
    }
}

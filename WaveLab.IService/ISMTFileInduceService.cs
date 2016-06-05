using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;
using System.Collections;

namespace WaveLab.IService
{
    public interface ISMTFileInduceService
    {

        IList<SMTFileInduceInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        bool CheckExists(string materialCode, string materialDesc, string pcb);

        void Save(SMTFileInduceInfo entity);

        SMTFileInduceInfo GetDetail(string materialCode, string materialDesc, string pcb);

        void Update(SMTFileInduceInfo entity);

        void Delete(SMTFileInduceInfo entity);

        void Import(IList<SMTFileInduceInfo> newItems, IList<SMTFileInduceInfo> editItems);   

        IList<SMTFileInduceNewDVSInfo> GetNewDVSItems(string sortBy, string orderBy);

        void UpdateNewDVS(IList<SMTFileInduceInfo> items);       

        IList<SMTFileInduceInfo> GetNewPCBItems(string moduleTypeId, string pcb, string newPCB, string sortBy, string orderBy);

        void SaveNewPCB(SMTPCBPriorityItemInfo pcb, SMTPCBPriorityItemInfo newPCB, IList<SMTFileInduceInfo> items);

        IList<SMTFileInduceInfo> Query(string moduleTypeId, string pcb, string sortBy, string orderBy);

        //void UpdateComentsBatch(string moduleTypeId, string pcb, string comments);
        void UpdateComentsBatch(IList<SMTFileInduceInfo> items, string comments);

        bool CheckExists(string moduleTypeId, string materialCode, string materialDesc, string pcb);

        SMTFileInduceInfo QueryReport(string moduleTypeId, string materialCode, string materialDesc, string pcb);
    }
}

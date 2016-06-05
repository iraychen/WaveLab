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
    public class SMTFileInduceService : ISMTFileInduceService
    {
        public ISMTFileInduce dal;

        #region Basic Function

        public IList<SMTFileInduceInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

        public bool CheckExists(string materialCode, string materialDesc, string pcb)
        {
            return dal.CheckExists(materialCode, materialDesc, pcb);
        }

        public void Save(SMTFileInduceInfo entity)
        {
            dal.Save(entity);
        }

        public SMTFileInduceInfo GetDetail(string materialCode, string materialDesc, string pcb)
        {
            return dal.GetDetail(materialCode, materialDesc,  pcb);
        }

        public void Update(SMTFileInduceInfo entity)
        {
            dal.Update(entity);
        }

        public void Delete(SMTFileInduceInfo entity)
        {
            dal.Delete(entity);
        }

        #endregion

        #region Import,Update DV,New PCB

        public void Import(IList<SMTFileInduceInfo> newItems, IList<SMTFileInduceInfo> editItems)
        {
            foreach (SMTFileInduceInfo newItem in newItems)
            {
                dal.Save(newItem);
            }
            foreach (SMTFileInduceInfo editItem in editItems)
            {
                dal.Update(editItem);
            }
        }

        public IList<SMTFileInduceNewDVSInfo> GetNewDVSItems(string sortBy, string oderBy)
        {
            return dal.GetNewDVSItems(sortBy, oderBy);
        }

        public void UpdateNewDVS(IList<SMTFileInduceInfo> items)
        {
           dal.UpdateNewDVS(items);
        }

        public IList<SMTFileInduceInfo> GetNewPCBItems(string moduleTypeId, string pcb, string newPCB, string sortBy, string orderBy)
        {
            return dal.GetNewPCBItems(moduleTypeId, pcb, newPCB, sortBy, orderBy);
        }

        public void SaveNewPCB(SMTPCBPriorityItemInfo pcb, SMTPCBPriorityItemInfo newPCB, IList<SMTFileInduceInfo> items)
        {
            dal.SaveNewPCB(pcb, newPCB, items);
        }

        public IList<SMTFileInduceInfo> Query(string moduleTypeId, string pcb, string sortBy, string orderBy)
        {
            return dal.Query(moduleTypeId, pcb, sortBy, orderBy);
        }

        //public void UpdateComentsBatch(string moduleTypeId, string pcb, string comments)
        //{
            //dal.UpdateComentsBatch(moduleTypeId, pcb, comments);
        //}
        public void UpdateComentsBatch(IList<SMTFileInduceInfo> items, string comments)
        {
            dal.UpdateComentsBatch(items, comments);
        }
        #endregion

        #region Query Report
        public bool CheckExists(string moduleTypeId, string materialCode, string materialDesc, string pcb)
        {
            return dal.CheckExists(moduleTypeId, materialCode, materialDesc, pcb);
        }

        public SMTFileInduceInfo QueryReport(string moduleTypeId, string materialCode, string materialDesc, string pcb)
        {
            return dal.QueryReport(moduleTypeId, materialCode, materialDesc, pcb);
        }
        #endregion
    }
}

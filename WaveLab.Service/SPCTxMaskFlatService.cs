using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Caching;

using WaveLab.Model;
using WaveLab.IDAL;
using WaveLab.IService;

namespace WaveLab.Service
{
    public class SPCTxMaskFlatService: ISPCTxMaskFlatService 
    {
        public ISPCTxMaskFlat dal;

        public IList<SPCTxMaskFlatItemInfo> Query(Hashtable hashTable, string sortby, string orderby)
        {
            return dal.Query(hashTable, sortby, orderby);
        }
     
        public IList<SPCTxMaskFlatDetail> GetGroupData_Manual(Hashtable hashTable, string sortby, string orderby)
        {
            return dal.GetGroupData_Manual(hashTable, sortby, orderby);
        }

        public IList<SPCTxMaskFlatDetail> GetGroupData_Auto(Hashtable hashTable, string sortby, string orderby)
        {
            return dal.GetGroupData_Auto(hashTable, sortby, orderby);
        }

        public int Save( SPCTxMaskFlatInfo entity)
        {
           return  dal.Save(entity);
        }

        public int Query(Hashtable hashTable)
        {
            return dal.Query(hashTable);
        }

        public IList<SPCTxMaskFlatInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.Query(hashTable, sortBy, orderBy, page, pageSize);
        }

        public SPCTxMaskFlatInfo GetDetail(int TxMaskFlatPK)
        {
            return dal.GetDetail(TxMaskFlatPK);
        }

        public void Delete(SPCTxMaskFlatInfo entity)
        {
            dal.Delete(entity);
        }

        public IList<SPCTxMaskFlatDetail> GetOrignalData(int TxMaskFlatPK, int GroupNo)
        {
            return dal.GetOrignalData(TxMaskFlatPK, GroupNo);
        }

        public SPCTxMaskFlatInfo GetLatestTarget(string type, string mode, string ch)
        {
            return dal.GetLatestTarget(type, mode, ch);
        }

        public int GetAutoLatest(string type, string mode, string ch)
        {
            return dal.GetAutoLatest(type, mode, ch);
        }

        public int LastestTargetCount(string type, string mode, string ch)
        {
            return dal.LastestTargetCount(type, mode, ch);
        }

        public void SaveException(int TxMaskFlatPK, IList<SPCTxMaskFlatException> ExceptionItems)
        {
            dal.SaveException(TxMaskFlatPK, ExceptionItems);
        }
    }
}

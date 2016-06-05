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
    public class SPCTxPowerService: ISPCTxPowerService 
    {
        public ISPCTxPower dal;

        public IList<SPCTxPowerItemInfo> Query(Hashtable hashTable, string sortby, string orderby)
        {
            return dal.Query(hashTable, sortby, orderby);
        }

        public IList<SPCTxPowerDetail> GetGroupData_Manual(Hashtable hashTable, string sortby, string orderby)
        {
            return dal.GetGroupData_Manual(hashTable, sortby, orderby);
        }

        public IList<SPCTxPowerDetail> GetGroupData_Auto(Hashtable hashTable, string sortby, string orderby)
        {
            return dal.GetGroupData_Auto(hashTable, sortby, orderby);
        }

        public  int Save( SPCTxPowerInfo entity)
        {
            return dal.Save(entity);
        }

        public int Query(Hashtable hashTable)
        {
            return dal.Query(hashTable);
        }

        public IList<SPCTxPowerInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.Query(hashTable, sortBy, orderBy, page, pageSize);
        }

        public SPCTxPowerInfo GetDetail(int TxPowerPK)
        {
            return dal.GetDetail(TxPowerPK);
        }

        public void Delete(SPCTxPowerInfo entity)
        {
            dal.Delete(entity);
        }

        public IList<SPCTxPowerDetail> GetOrignalData(int TxPowerPK, int GroupNo)
        {
            return dal.GetOrignalData(TxPowerPK, GroupNo);
        }

        public SPCTxPowerInfo GetLatestTarget(string type, string mode, string ch, string pw)
        {
            return dal.GetLatestTarget(type, mode, ch,  pw);
        }

        public int GetAutoLatest(string type, string mode, string ch, string pw)
        {
            return dal.GetAutoLatest(type, mode, ch, pw);
        }

        public int LastestTargetCount(string type, string mode, string ch, string pw)
        {
            return dal.LastestTargetCount(type, mode, ch, pw);
        }

        public void SaveException(int TxPowerPK, IList<SPCTxPowerException> ExceptionItems)
        {
            dal.SaveException(TxPowerPK, ExceptionItems);
        }
    }
}

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
    public class SPCRxPowerService: ISPCRxPowerService 
    {
        public ISPCRxPower dal;

        public IList<SPCRxPowerItemInfo> Query(Hashtable hashTable, string sortby, string orderby)
        {
            return dal.Query(hashTable, sortby, orderby);
        }      

        public IList<SPCRxPowerDetail> GetGroupData_Manual(Hashtable hashTable, string sortby, string orderby)
        {
            return dal.GetGroupData_Manual(hashTable, sortby, orderby);
        }

        public IList<SPCRxPowerDetail> GetGroupData_Auto(Hashtable hashTable, string sortby, string orderby)
        {
            return dal.GetGroupData_Auto(hashTable, sortby, orderby);
        }

        public  int Save( SPCRxPowerInfo entity)
        {
            return dal.Save(entity);
        }

        public int Query(Hashtable hashTable)
        {
            return dal.Query(hashTable);
        }

        public IList<SPCRxPowerInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.Query(hashTable, sortBy, orderBy, page, pageSize);
        }

        public SPCRxPowerInfo GetDetail(int RxPowerPK)
        {
            return dal.GetDetail(RxPowerPK);
        }

        public void Delete(SPCRxPowerInfo entity)
        {
            dal.Delete(entity);
        }

        public IList<SPCRxPowerDetail> GetOrignalData(int RxPowerPK, int GroupNo)
        {
            return dal.GetOrignalData(RxPowerPK, GroupNo);
        }

        public int GetAutoLatest(string type, string mode, string ch, string pw)
        {
            return dal.GetAutoLatest(type, mode, ch, pw);
        }

        public SPCRxPowerInfo GetLatestTarget(string type, string mode, string ch, string pw)
        {
            return dal.GetLatestTarget(type, mode, ch,  pw);
        }
        public int LastestTargetCount(string type, string mode, string ch, string pw)
        {
            return dal.LastestTargetCount(type, mode, ch, pw);
        }

        public void SaveException(int RxPowerPK, IList<SPCRxPowerException> ExceptionItems)
        {
            dal.SaveException(RxPowerPK, ExceptionItems);
        }
    }
}

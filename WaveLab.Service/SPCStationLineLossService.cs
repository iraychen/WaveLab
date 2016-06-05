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
    public class SPCStationLineLossService: ISPCStationLineLossService
    {
        public ISPCStationLineLoss dal;

        public IList<SPCStationLineLossInput> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

        public void SaveInput(SPCStationLineLossInput entity)
        {
            dal.SaveInput(entity);
        }

        public SPCStationLineLossInput Get(int StationPK, int NoOfTimes)
        {
            return dal.Get(StationPK, NoOfTimes);
        }

        public void UpdateInput(SPCStationLineLossInput entity)
        {
            dal.UpdateInput(entity);
        }

        public int GetMaxNoOfTimes(int StationPK)
        {
            return dal.GetMaxNoOfTimes(StationPK);
        }

        public void SaveSPC(SPCStationLineLossInfo entity)
        {
            dal.SaveSPC(entity);
        }

        public SPCStationLineLossInfo Get(int LineLossPK)
        {
            return dal.Get(LineLossPK);
        }

        public void SaveException(int LineLossPK, IList<SPCStationLineLossException> ExceptionItems)
        {
            dal.SaveException(LineLossPK, ExceptionItems);
        }

        public SPCStationLineLossInfo GetLastestLineLoss(int StationPK)
        {
            return dal.GetLastestLineLoss(StationPK);
        }

        public bool CheckExists(int StationPK, string TestingDate)
        {
            return dal.CheckExists(StationPK, TestingDate);
        }

        public void DeleteInput(int StationPK, int MaxTimes)
        {
            dal.DeleteInput(StationPK,MaxTimes);
        }

        public void DeleteSPC(int StationPK)
        {
            dal.DeleteSPC(StationPK);
        }

        public int QueryHistory(Hashtable hashTable)
        {
            return dal.QueryHistory(hashTable);
        }

        public IList<SPCStationLineLossInfo> QueryHistory(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.QueryHistory(hashTable, sortBy, orderBy, page, pageSize);
        }

       
    }
}

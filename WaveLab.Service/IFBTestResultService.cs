﻿using System;
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
    public class IFBTestResultService:  IIFBTestResultService
    {
        public IIFBTestResult dal;

        public int Query(Hashtable hashTable)
        {
            return dal.Query(hashTable);
        }

        public IList<IFBTestResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize)
        {
            return dal.Query(hashTable, sortBy, orderBy, page, pageSize);
        }

        public IList<IFBTestResultInfo> Query(Hashtable hashTable, string sortBy, string orderBy)
        {
            return dal.Query(hashTable, sortBy, orderBy);
        }

        public IFBTestResultInfo GetDetail(int IFBTestResultId)
        {
            return dal.GetDetail(IFBTestResultId);
        }
    }
}

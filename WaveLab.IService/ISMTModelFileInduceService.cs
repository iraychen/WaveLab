using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveLab.Model;
using System.Collections;
using System.IO;
using System.Data;

namespace WaveLab.IService
{
    public interface ISMTModelFileInduceService
    {

        int Query(Hashtable hashTable);

        IList<SMTModelFileInduceInfo> Query(Hashtable hashTable, string sortBy, string orderBy, int page, int pageSize);

        bool CheckExists(SMTModelFileInduceInfo entity);

        void Save(SMTModelFileInduceInfo entity);

        SMTModelFileInduceInfo GetDetail(int FileInducePK);

        void Update(SMTModelFileInduceInfo entity);

        void Delete(SMTModelFileInduceInfo entity);

        DataTable Upload(SYSModuleTypeInfo moduleTypeItem, Stream excelFileStream, string SheetName);

        void Import(IList<SMTModelFileInduceInfo> newItems, IList<SMTModelFileInduceInfo> editItems);


        IList<SMTModelFileInduceInfo> Query(Hashtable hashTable, string sortBy, string orderBy);

        MemoryStream Export(string templateFileName, SMTModelFileInduceInfo entity);

        //int GetCount(string modelOrder);

        //SMTModelFileInduceInfo Get(string modelOrder);
    }
}

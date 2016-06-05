using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using WaveLab.Model;
using WaveLab.IDAL;

using Spring.Data.Common;
using Spring.Data.Generic;
using Spring.Data.Objects.Generic;

namespace WaveLab.DAL
{
    public class SYSSerialNoGenerator : StoredProcedure, ISYSSerialNoGenerator
    {
        private static string procedureName = "wl_generate_serial_no";

        public SYSSerialNoGenerator(IDbProvider dbProvider): base(dbProvider, procedureName)
        {           
            DeriveParameters();
            Compile();
        }
        
        public string GenerateSerialNo(string code)
        {
            IDictionary outParams = base.ExecuteScalar(code);
            return outParams["scalar"] as string;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class MCTImportInfo
    {
        private System.Collections.Hashtable _BasicInfo;
        private System.Data.DataTable _ProductSubstanceInfo;

        public MCTImportInfo()
		{
			
		}


        public System.Collections.Hashtable BasicInfo
		{
			get
			{
                return this._BasicInfo;
			}
			set
			{
                this._BasicInfo = value;
			}
		}

        public System.Data.DataTable ProductSubstanceInfo
		{
			get
			{
                return this._ProductSubstanceInfo;
			}
			set
			{
                this._ProductSubstanceInfo = value;
			}
		}

    }
}

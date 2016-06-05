using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class NTSensitivityResultInfo
    {
        private System.Nullable<int> _NTSensitivityId;
		
		private string _Mode;
		
		private string _CH;
		
		private string _UpperLimit;

        private string _UpperResult;
		
		private string _LowerLimit;

        private string _LowerResult;
		
		public System.Nullable<int> NTSensitivityId
		{
			get
			{
                return this._NTSensitivityId;
			}
			set
			{
                this._NTSensitivityId = value;
			}
		}
		
		public string Mode
		{
			get
			{
				return this._Mode;
			}
			set
			{
                this._Mode = value;
			}
		}
		
		public string CH
		{
			get
			{
                return this._CH;
			}
			set
			{
                this._CH = value;
			}
		}
		
		public string UpperLimit
		{
			get
			{
				return this._UpperLimit;
			}
			set
			{
                this._UpperLimit = value;
			}
		}

        public string UpperResult
		{
			get
			{
                return this._UpperResult;
			}
			set
			{
                this._UpperResult = value;
			}
		}
		
		public string LowerLimit
		{
			get
			{
				return this._LowerLimit;
			}
			set
			{
                this._LowerLimit = value;
			}
		}

        public string LowerResult
		{
			get
			{
                return this._LowerResult;
			}
			set
			{
                this._LowerResult = value;
			}
		}
    }
}

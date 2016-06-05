using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class MWMTestResultInfo
    {
        
		private int _MWMTestResultId;
		
		private string _SerialNo;
		
		private string _Type;
		
		private System.Nullable<System.DateTime> _StartTime;
		
		private System.Nullable<System.DateTime> _EndTime;
		
		private string _StationNo;
		
		private string _TxP1dB;
		
		private string _TxGainFlatness;

        private string _TxLoRejectMin;

        private string _TxLoRejectMax;
		
		private string _TxAttnDiff;
		
		private string _RxGainFlatness;
		
		private string _CurrentOn5V1;
		
		private string _CurrentOn5V2;

        private string _CurrentOn5V3;
		
		private string _CurrentOnHPA;
		
		private string _PwrDVoltage;

        private string _PwrRVoltage;
		
		private string _RefDVoltage;
		
		private string _AbsVerfVpwrDOffset;

        private char _FinalFlag;
		
		private string _AppVersion;
		
		private string _Operator;

        private IList<MWMTestResultDetail> _DetailItems;

		public int MWMTestResultId
		{
			get
			{
				return this._MWMTestResultId;
			}
			set
			{
                this._MWMTestResultId = value;
			}
		}
		
		public string SerialNo
		{
			get
			{
				return this._SerialNo;
			}
			set
			{
                this._SerialNo = value;
			}
		}
		
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
                this._Type = value;
			}
		}
		
		public System.Nullable<System.DateTime> StartTime
		{
			get
			{
				return this._StartTime;
			}
			set
			{
                this._StartTime = value;
			}
		}
		
		public System.Nullable<System.DateTime> EndTime
		{
			get
			{
				return this._EndTime;
			}
			set
			{
                this._EndTime = value;
			}
		}
		
		public string StationNo
		{
			get
			{
				return this._StationNo;
			}
			set
			{
                this._StationNo = value;
			}
		}
		
		public string TxP1dB
		{
			get
			{
				return this._TxP1dB;
			}
			set
			{
                this._TxP1dB = value;
			}
		}
		
		public string TxGainFlatness
		{
			get
			{
				return this._TxGainFlatness;
			}
			set
			{
                this._TxGainFlatness = value;
			}
		}

        public string TxLoRejectMin
        {
            get
            {
                return this._TxLoRejectMin;
            }
            set
            {
                this._TxLoRejectMin = value;
            }
        }

        public string TxLoRejectMax
        {
            get
            {
                return this._TxLoRejectMax;
            }
            set
            {
                this._TxLoRejectMax = value;
            }
        }
		
		public string TxAttnDiff
		{
			get
			{
				return this._TxAttnDiff;
			}
			set
			{
                this._TxAttnDiff = value;
			}
		}
		
		public string RxGainFlatness
		{
			get
			{
				return this._RxGainFlatness;
			}
			set
			{
                this._RxGainFlatness = value;
			}
		}
		
		public string CurrentOn5V1
		{
			get
			{
				return this._CurrentOn5V1;
			}
			set
			{
                this._CurrentOn5V1 = value;
			}
		}

        public string CurrentOn5V2
		{
			get
			{
                return this._CurrentOn5V2;
			}
			set
			{
                this._CurrentOn5V2 = value;
			}
		}

        public string CurrentOn5V3
		{
			get
			{
                return this._CurrentOn5V3;
			}
			set
			{
                this._CurrentOn5V3 = value;
			}
		}

        public string CurrentOnHPA
		{
			get
			{
                return this._CurrentOnHPA;
			}
			set
			{
                this._CurrentOnHPA = value;
			}
		}
		
		public string PwrDVoltage
		{
			get
			{
				return this._PwrDVoltage;
			}
			set
			{
                this._PwrDVoltage = value;
			}
		}

        public string PwrRVoltage
        {
            get
            {
                return this._PwrRVoltage;
            }
            set
            {
                this._PwrRVoltage = value;
            }
        }
		
		public string RefDVoltage
		{
			get
			{
				return this._RefDVoltage;
			}
			set
			{
                this._RefDVoltage = value;
			}
		}
		
		public string AbsVerfVpwrDOffset
		{
			get
			{
				return this._AbsVerfVpwrDOffset;
			}
			set
			{
                this._AbsVerfVpwrDOffset = value;
			}
		}

        public char FinalFlag
        {
            get
            {
                return this._FinalFlag;
            }
            set
            {
                this._FinalFlag = value;
            }
        }
		
		public string AppVersion
		{
			get
			{
				return this._AppVersion;
			}
			set
			{
                this._AppVersion = value;
			}
		}
		
		public string Operator
		{
			get
			{
				return this._Operator;
			}
			set
			{
                this._Operator = value;
			}
		}

        public IList<MWMTestResultDetail> DetailItems
        {
            get
            {
                return this._DetailItems;
            }
            set
            {
                this._DetailItems = value;
            }
        }
		
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class MIMeasureDataInfo
    {
        private string _OrderNo;

        private string _Code;

        private string _Model;

		private int _MIMeasureDataID;
		
		private string _SerialNo;
		
		private string _RSSIR1Mode;

        private string _RSSIR1N20Power;

        private string _RSSIR1N30Power;

        private string _RSSIR1N40Power;

        private string _RSSIR1N50Power;

        private string _RSSIR1N60Power;

        private string _RSSIR1N70Power;

        private string _RSSIR1N80Power;

        private string _RSSIR1N90Power;
		
		private string _RSSIR2Mode;
		
		private string _RSSIR2N20Power;

        private string _RSSIR2N30Power;

        private string _RSSIR2N40Power;

        private string _RSSIR2N50Power;

        private string _RSSIR2N60Power;

        private string _RSSIR2N70Power;

        private string _RSSIR2N80Power;

        private string _RSSIR2N90Power;

        private System.Nullable<char> _RSSIFinalFlag;

        private string _RSSIOperator;

        private System.Nullable<DateTime> _RSSITestTime;
		
		private string _SNRMode;
		
		private string _SNRLocalLeft;
		
		private string _SNRIFPoint;
		
		private string _SNRLocalRight;

        private System.Nullable<char> _SNRFinalFlag;

        private string _SNROperator;

        private System.Nullable<DateTime> _SNRTestTime;
		
		private string _MicroVibrationMode;
		
		private string _MicroVibrationErrorCount;

        private System.Nullable<char> _MicroVibrationFinalFlag;

        private string _MicroVibrationOperator;

        private System.Nullable<DateTime> _MicroVibrationTestTime;
		
		private string _AGCMMode;

        private string _AGCMR1Channel;

        private string _AGCMR1UpperLimit;

        private string _AGCMR1UpperAttenuation;

        private string _AGCMR1LowerLimit;

        private string _AGCMR1LowerAttenuation;

        private string _AGCMR2Channel;

        private string _AGCMR2UpperLimit;

        private string _AGCMR2UpperAttenuation;

        private string _AGCMR2LowerLimit;

        private string _AGCMR2LowerAttenuation;

        private System.Nullable<char> _AGCMFinalFlag;

        private string _AGCMOperator;

        private System.Nullable<DateTime> _AGCMTestTime;
		
		private string _AGCIPRMode;

        private string _AGCIPRR1Channel;

        private string _AGCIPRR1UpperLimit;

        private string _AGCIPRR1LowerLimit;

        private string _AGCIPRR2Channel;

        private string _AGCIPRR2UpperLimit;

        private string _AGCIPRR2LowerLimit;

        private string _AGCIPRR3Channel;

        private string _AGCIPRR3UpperLimit;

        private string _AGCIPRR3LowerLimit;

        private System.Nullable<char> _AGCIPRFinalFlag;

        private string _AGCIPROperator;

        private System.Nullable<DateTime> _AGCIPRTestTime;
		
		private string _AGCXCRR1Mode;

        private string _AGCXCRR1Channel;
		
		private string _AGCXCRR1UpperLimit;
		
		private string _AGCXCRR1LowerLimit;
		
		private string _AGCXCRR2Mode;

        private string _AGCXCRR2Channel;
		
		private string _AGCXCRR2UpperLimit;
		
		private string _AGCXCRR2LowerLimit;

        private System.Nullable<char> _AGCXCRFinalFlag;

        private string _AGCXCROperator;

        private System.Nullable<DateTime> _AGCXCRTestTime;
		
		private string _Airtight;

        private System.Nullable<char> _AirtightFinalFlag;

        private string _AirtightOperator;

        private System.Nullable<DateTime> _AirtightTestTime;
		
		private string _TemG3XMCMode;
		
		private string _TemG3XMCErrorNo;
		
		private string _TemG3XMCErrorSeconds;
		
		private string _TemG3XMCAIS;

        private System.Nullable<char> _TemG3XMCFinalFlag;

        private string _TemG3XMCOperator;

        private System.Nullable<DateTime> _TemG3XMCTestTime;
		
		private string _TemPTNMode;
		
		private string _TemPTNLossRate;
		
		private string _TemPTNErrorSeconds;

        private System.Nullable<char> _TemPTNFinalFlag;

        private string _TemPTNOperator;

        private System.Nullable<DateTime> _TemPTNTestTime;
		
		private string _TemOML6101LossRate;

        private System.Nullable<char> _TemOML6101FinalFlag;

        private string _TemOML6101Operator;

        private System.Nullable<DateTime> _TemOML6101TestTime;
		
		private string _TemOML6205TotalError;

        private System.Nullable<char> _TemOML6205FinalFlag;

        private string _TemOML6205Operator;

        private System.Nullable<DateTime> _TemOML6205TestTime;

		private string _TemOML6202TotalError;

        private System.Nullable<char> _TemOML6202FinalFlag;

        private string _TemOML6202Operator;

        private System.Nullable<DateTime> _TemOML6202TestTime;
		
		private string _FTCMode;
		
		private string _FTCErrorCount;
		
		private string _FTCErrorSeconds;
		
		private string _FTCAIS;

        private System.Nullable<char> _FTCFinalFlag;

        private string _FTCOperator;

        private System.Nullable<DateTime> _FTCTestTime;

		private System.Nullable<System.DateTime> _LastUpdateDate;
		
		private string _LastUpdatedBy;

        public string OrderNo
        {
            get
            {
                return this._OrderNo;
            }
            set
            {
                this._OrderNo = value;
            }
        }

        public string Model
        {
            get
            {
                return this._Model;
            }
            set
            {
                this._Model = value;
            }
        }

        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this._Code = value;
            }
        }

		public int MIMeasureDataID
		{
			get
			{
                return this._MIMeasureDataID;
			}
			set
			{
                this._MIMeasureDataID = value;
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
		
		public string RSSIR1Mode
		{
			get
			{
				return this._RSSIR1Mode;
			}
			set
			{
                this._RSSIR1Mode= value;
			}
		}
		
		public string RSSIR1N20Power
		{
			get
			{
                return this._RSSIR1N20Power;
			}
			set
			{
                this._RSSIR1N20Power = value;
			}
		}
		
		public string RSSIR1N30Power
		{
			get
			{
                return this._RSSIR1N30Power;
			}
			set
			{
                this._RSSIR1N30Power = value;
			}
		}
		
		public string RSSIR1N40Power
		{
			get
			{
                return this._RSSIR1N40Power;
			}
			set
			{
                this._RSSIR1N40Power = value;
			}
		}
		
		public string RSSIR1N50Power
		{
			get
			{
				return this._RSSIR1N50Power;
			}
			set
			{
                this._RSSIR1N50Power = value;
			}
		}
		
		public string RSSIR1N60Power
		{
            get
            {
                return this._RSSIR1N60Power;
            }
			set
			{
                this._RSSIR1N60Power = value;
			}
		}

		public string RSSIR1N70Power
		{
			get
			{
                return this._RSSIR1N70Power;
			}
			set
			{
                this._RSSIR1N70Power = value;
			}
		}
		
		public string RSSIR1N80Power
		{
			get
			{
				return this._RSSIR1N80Power;
			}
			set
			{
                this._RSSIR1N80Power = value;
			}
		}
		
		public string RSSIR1N90Power
		{
			get
			{
                return this._RSSIR1N90Power;
			}
			set
			{
                this._RSSIR1N90Power = value;
			}
		}
		
		public string RSSIR2Mode
		{
			get
			{
                return this._RSSIR2Mode;
			}
			set
			{
                this._RSSIR2Mode = value;
			}
		}

        public string RSSIR2N20Power
		{
			get
			{
                return this._RSSIR2N20Power;
			}
			set
			{
                this._RSSIR2N20Power = value;
			}
		}
		
		public string RSSIR2N30Power
		{
			get
			{
                return this._RSSIR2N30Power;
			}
			set
			{
                this._RSSIR2N30Power = value;
			}
		}

        public string RSSIR2N40Power
		{
			get
			{
                return this._RSSIR2N40Power;
			}
			set
			{
                this._RSSIR2N40Power = value;
			}
		}

        public string RSSIR2N50Power
		{
			get
			{
                return this._RSSIR2N50Power;
			}
			set
			{
                this._RSSIR2N50Power = value;
			}
		}

        public string RSSIR2N60Power
		{
			get
			{
                return this._RSSIR2N60Power;
			}
			set
			{
                this._RSSIR2N60Power = value;
			}
		}

        public string RSSIR2N70Power
		{
			get
			{
                return this._RSSIR2N70Power;
			}
			set
			{
                this._RSSIR2N70Power = value;
			}
		}

        public string RSSIR2N80Power
		{
			get
			{
                return this._RSSIR2N80Power;
			}
			set
			{
                this._RSSIR2N80Power = value;
			}
		}

        public string RSSIR2N90Power
		{
			get
			{
                return this._RSSIR2N90Power;
			}
			set
			{
                this._RSSIR2N90Power = value;
			}
		}

        public System.Nullable<char> RSSIFinalFlag
        {
            get
            {
                return this._RSSIFinalFlag;
            }
            set
            {
                this._RSSIFinalFlag = value;
            }
        }

        public string RSSIOperator
        {
            get
            {
                return this._RSSIOperator;
            }
            set
            {
                this._RSSIOperator = value;
            }
        }

        public System.Nullable<DateTime> RSSITestTime
        {
            get
            {
                return this._RSSITestTime;
            }
            set
            {
                this._RSSITestTime = value;
            }
        }
		
		public string SNRMode
		{
			get
			{
				return this._SNRMode;
			}
			set
			{
                this._SNRMode = value;
			}
		}
		
		public string SNRLocalLeft
		{
			get
			{
				return this._SNRLocalLeft;
			}
			set
			{
                this._SNRLocalLeft = value;
			}
		}
		
		public string SNRIFPoint
		{
			get
			{
				return this._SNRIFPoint;
			}
			set
			{
                this._SNRIFPoint = value;
			}
		}
		
		public string SNRLocalRight
		{
			get
			{
				return this._SNRLocalRight;
			}
			set
			{
                this._SNRLocalRight = value;
			}
		}

        public System.Nullable<char> SNRFinalFlag
        {
            get
            {
                return this._SNRFinalFlag;
            }
            set
            {
                this._SNRFinalFlag = value;
            }
        }

        public string SNROperator
        {
            get
            {
                return this._SNROperator;
            }
            set
            {
                this._SNROperator = value;
            }
        }

        public System.Nullable<DateTime> SNRTestTime
        {
            get
            {
                return this._SNRTestTime;
            }
            set
            {
                this._SNRTestTime = value;
            }
        }
		
		public string MicroVibrationMode
		{
			get
			{
				return this._MicroVibrationMode;
			}
			set
			{
                this._MicroVibrationMode = value;
			}
		}
		
		public string MicroVibrationErrorCount
		{
			get
			{
				return this._MicroVibrationErrorCount;
			}
			set
			{
                this._MicroVibrationErrorCount = value;
			}
		}

        public System.Nullable<char> MicroVibrationFinalFlag
        {
            get
            {
                return this._MicroVibrationFinalFlag;
            }
            set
            {
                this._MicroVibrationFinalFlag = value;
            }
        }

        public string MicroVibrationOperator
        {
            get
            {
                return this._MicroVibrationOperator;
            }
            set
            {
                this._MicroVibrationOperator = value;
            }
        }

        public System.Nullable<DateTime> MicroVibrationTestTime
        {
            get
            {
                return this._MicroVibrationTestTime;
            }
            set
            {
                this._MicroVibrationTestTime = value;
            }
        }
		
		public string AGCMMode
		{
			get
			{
				return this._AGCMMode;
			}
			set
			{
                this._AGCMMode = value;
			}
		}

        public string AGCMR1Channel
        {
            get
            {
                return this._AGCMR1Channel;
            }
            set
            {
                this._AGCMR1Channel = value;
            }
        }
		
		public string AGCMR1UpperLimit
		{
			get
			{
				return this._AGCMR1UpperLimit;
			}
			set
			{
                this._AGCMR1UpperLimit = value;
			}
		}
		
		public string AGCMR1UpperAttenuation
		{
			get
			{
				return this._AGCMR1UpperAttenuation;
			}
			set
			{
                this._AGCMR1UpperAttenuation = value;
			}
		}
		
		public string AGCMR1LowerLimit
		{
			get
			{
				return this._AGCMR1LowerLimit;
			}
			set
			{
                this._AGCMR1LowerLimit = value;
			}
		}
		
		public string AGCMR1LowerAttenuation
		{
			get
			{
                return this._AGCMR1LowerAttenuation;
			}
			set
			{
                this._AGCMR1LowerAttenuation = value;
			}
		}

        public string AGCMR2Channel
        {
            get
            {
                return this._AGCMR2Channel;
            }
            set
            {
                this._AGCMR2Channel = value;
            }
        }
		
		public string AGCMR2UpperLimit
		{
			get
			{
                return this._AGCMR2UpperLimit;
			}
			set
			{
                this._AGCMR2UpperLimit = value;
			}
		}
		
		public string AGCMR2UpperAttenuation
		{
			get
			{
                return this._AGCMR2UpperAttenuation;
			}
			set
			{
                this._AGCMR2UpperAttenuation = value;
			}
		}

        public string AGCMR2LowerLimit
		{
			get
			{
                return this._AGCMR2LowerLimit;
			}
			set
			{
                this._AGCMR2LowerLimit = value;
			}
		}

        public string AGCMR2LowerAttenuation
		{
			get
			{
                return this._AGCMR2LowerAttenuation;
			}
			set
			{
                this._AGCMR2LowerAttenuation = value;
			}
		}

        public System.Nullable<char> AGCMFinalFlag
        {
            get
            {
                return this._AGCMFinalFlag;
            }
            set
            {
                this._AGCMFinalFlag = value;
            }
        }

        public string AGCMOperator
        {
            get
            {
                return this._AGCMOperator;
            }
            set
            {
                this._AGCMOperator = value;
            }
        }

        public System.Nullable<DateTime> AGCMTestTime
        {
            get
            {
                return this._AGCMTestTime;
            }
            set
            {
                this._AGCMTestTime = value;
            }
        }

		public string AGCIPRMode
		{
			get
			{
				return this._AGCIPRMode;
			}
			set
			{
                this._AGCIPRMode = value;
			}
		}

        public string AGCIPRR1Channel
        {
            get
            {
                return this._AGCIPRR1Channel;
            }
            set
            {
                this._AGCIPRR1Channel = value;
            }
        }

        public string AGCIPRR1UpperLimit
		{
			get
			{
                return this._AGCIPRR1UpperLimit;
			}
			set
			{
                this._AGCIPRR1UpperLimit = value;
			}
		}

        public string AGCIPRR1LowerLimit
		{
			get
			{
                return this._AGCIPRR1LowerLimit;
			}
			set
			{
                this._AGCIPRR1LowerLimit = value;
			}
		}

        public string AGCIPRR2Channel
        {
            get
            {
                return this._AGCIPRR2Channel;
            }
            set
            {
                this._AGCIPRR2Channel = value;
            }
        }

        public string AGCIPRR2UpperLimit
		{
			get
			{
                return this._AGCIPRR2UpperLimit;
			}
			set
			{
                this._AGCIPRR2UpperLimit = value;
			}
		}

        public string AGCIPRR2LowerLimit
		{
			get
			{
                return this._AGCIPRR2LowerLimit;
			}
			set
			{
                this._AGCIPRR2LowerLimit = value;
			}
		}

        public string AGCIPRR3Channel
        {
            get
            {
                return this._AGCIPRR3Channel;
            }
            set
            {
                this._AGCIPRR3Channel = value;
            }
        }

        public string AGCIPRR3UpperLimit
		{
			get
			{
                return this._AGCIPRR3UpperLimit;
			}
			set
			{
                this._AGCIPRR3UpperLimit = value;
			}
		}

        public string AGCIPRR3LowerLimit
		{
			get
			{
                return this._AGCIPRR3LowerLimit;
			}
			set
			{
                this._AGCIPRR3LowerLimit = value;
			}
		}

        public System.Nullable<char> AGCIPRFinalFlag
        {
            get
            {
                return this._AGCIPRFinalFlag;
            }
            set
            {
                this._AGCIPRFinalFlag = value;
            }
        }

        public string AGCIPROperator
        {
            get
            {
                return this._AGCIPROperator;
            }
            set
            {
                this._AGCIPROperator = value;
            }
        }

        public System.Nullable<DateTime> AGCIPRTestTime
        {
            get
            {
                return this._AGCIPRTestTime;
            }
            set
            {
                this._AGCIPRTestTime = value;
            }
        }

        public string AGCXCRR1Mode
		{
			get
			{
                return this._AGCXCRR1Mode;
			}
			set
			{
                this._AGCXCRR1Mode = value;
			}
		}

        public string AGCXCRR1Channel
        {
            get
            {
                return this._AGCXCRR1Channel;
            }
            set
            {
                this._AGCXCRR1Channel = value;
            }
        }

        public string AGCXCRR1UpperLimit
		{
			get
			{
                return this._AGCXCRR1UpperLimit;
			}
			set
			{
                this._AGCXCRR1UpperLimit = value;
			}
		}

        public string AGCXCRR1LowerLimit
		{
			get
			{
                return this._AGCXCRR1LowerLimit;
			}
			set
			{
                this._AGCXCRR1LowerLimit = value;
			}
		}

        public string AGCXCRR2Mode
		{
			get
			{
                return this._AGCXCRR2Mode;
			}
			set
			{
                this._AGCXCRR2Mode = value;
			}
		}

        public string AGCXCRR2Channel
        {
            get
            {
                return this._AGCXCRR2Channel;
            }
            set
            {
                this._AGCXCRR2Channel = value;
            }
        }

        public string AGCXCRR2UpperLimit
		{
			get
			{
                return this._AGCXCRR2UpperLimit;
			}
			set
			{
                this._AGCXCRR2UpperLimit = value;
			}
		}

        public string AGCXCRR2LowerLimit
		{
			get
			{
                return this._AGCXCRR2LowerLimit;
			}
			set
			{
                this._AGCXCRR2LowerLimit = value;
			}
		}

        public System.Nullable<char> AGCXCRFinalFlag
        {
            get
            {
                return this._AGCXCRFinalFlag;
            }
            set
            {
                this._AGCXCRFinalFlag = value;
            }
        }

        public string AGCXCROperator
        {
            get
            {
                return this._AGCXCROperator;
            }
            set
            {
                this._AGCXCROperator = value;
            }
        }

        public System.Nullable<DateTime> AGCXCRTestTime
        {
            get
            {
                return this._AGCXCRTestTime;
            }
            set
            {
                this._AGCXCRTestTime = value;
            }
        }

		public string Airtight
		{
			get
			{
				return this._Airtight;
			}
			set
			{
                this._Airtight = value;
			}
		}

        public System.Nullable<char> AirtightFinalFlag
        {
            get
            {
                return _AirtightFinalFlag;
            }
            set
            {
                _AirtightFinalFlag = value;
            }
        }

        public string AirtightOperator
        {
            get
            {
                return this._AirtightOperator;
            }
            set
            {
                this._AirtightOperator = value;
            }
        }

        public System.Nullable<DateTime> AirtightTestTime
        {
            get
            {
                return this._AirtightTestTime;
            }
            set
            {
                this._AirtightTestTime = value;
            }
        }

		public string TemG3XMCMode
		{
			get
			{
				return this._TemG3XMCMode;
			}
			set
			{
                this._TemG3XMCMode = value;
			}
		}
		
		public string TemG3XMCErrorNo
		{
			get
			{
				return this._TemG3XMCErrorNo;
			}
			set
			{
                this._TemG3XMCErrorNo = value;
			}
		}
		
		public string TemG3XMCErrorSeconds
		{
			get
			{
                return this._TemG3XMCErrorSeconds;
			}
			set
			{
                this._TemG3XMCErrorSeconds = value;
			}
		}
		
		public string TemG3XMCAIS
		{
			get
			{
                return this._TemG3XMCAIS;
			}
			set
			{
                this._TemG3XMCAIS = value;
			}
		}

        public System.Nullable<char> TemG3XMCFinalFlag
        {
            get
            {
                return this._TemG3XMCFinalFlag;
            }
            set
            {
                this._TemG3XMCFinalFlag = value;
            }
        }

        public string TemG3XMCOperator
        {
            get
            {
                return this._TemG3XMCOperator;
            }
            set
            {
                this._TemG3XMCOperator = value;
            }
        }

        public System.Nullable<DateTime> TemG3XMCTestTime
        {
            get
            {
                return this._TemG3XMCTestTime;
            }
            set
            {
                this._TemG3XMCTestTime = value;
            }
        }

		public string TemPTNMode
		{
			get
			{
				return this._TemPTNMode;
			}
			set
			{
                this._TemPTNMode = value;
			}
		}
		
		public string TemPTNLossRate
		{
			get
			{
                return this._TemPTNLossRate;
			}
			set
			{
                this._TemPTNLossRate = value;
			}
		}
		
		public string TemPTNErrorSeconds
		{
			get
			{
                return this._TemPTNErrorSeconds;
			}
			set
			{
                this._TemPTNErrorSeconds = value;
			}
		}

        public System.Nullable<char> TemPTNFinalFlag
        {
            get
            {
                return this._TemPTNFinalFlag;
            }
            set
            {
                this._TemPTNFinalFlag = value;
            }
        }

        public string TemPTNOperator
        {
            get
            {
                return _TemPTNOperator;
            }
            set
            {
                _TemPTNOperator = value;
            }
        }

        public System.Nullable<DateTime> TemPTNTestTime
        {
            get
            {
                return this._TemPTNTestTime;
            }
            set
            {
                this._TemPTNTestTime = value;
            }
        }
		
		public string TemOML6101LossRate
		{
			get
			{
				return this._TemOML6101LossRate;
			}
			set
			{
                this._TemOML6101LossRate = value;
			}
		}

        public System.Nullable<char> TemOML6101FinalFlag
        {
            get
            {
                return this._TemOML6101FinalFlag;
            }
            set
            {
                this._TemOML6101FinalFlag = value;
            }
        }

        public string TemOML6101Operator
        {
            get
            {
                return this._TemOML6101Operator;
            }
            set
            {
                this._TemOML6101Operator = value;
            }
        }

        public System.Nullable<DateTime> TemOML6101TestTime
        {
            get
            {
                return this._TemOML6101TestTime;
            }
            set
            {
                this._TemOML6101TestTime = value;
            }
        }
		
		public string TemOML6205TotalError
		{
			get
			{
                return this._TemOML6205TotalError;
			}
			set
			{
                this._TemOML6205TotalError = value;
			}
		}

        public System.Nullable<char> TemOML6205FinalFlag
        {
            get
            {
                return this._TemOML6205FinalFlag;
            }
            set
            {
                this._TemOML6205FinalFlag = value;
            }
        }

        public string TemOML6205Operator
        {
            get
            {
                return this._TemOML6205Operator;
            }
            set
            {
                this._TemOML6205Operator = value;
            }
        }

        public System.Nullable<DateTime> TemOML6205TestTime
        {
            get
            {
                return this._TemOML6205TestTime;
            }
            set
            {
                this._TemOML6205TestTime = value;
            }
        }
		
		public string TemOML6202TotalError
		{
			get
			{
                return this._TemOML6202TotalError;
			}
			set
			{
                this._TemOML6202TotalError = value;
			}
		}

        public System.Nullable<char> TemOML6202FinalFlag
        {
            get
            {
                return this._TemOML6202FinalFlag;
            }
            set
            {
                this._TemOML6202FinalFlag = value;
            }
        }

        public string TemOML6202Operator
        {
            get
            {
                return this._TemOML6202Operator;
            }
            set
            {
                this._TemOML6202Operator = value;
            }
        }

        public System.Nullable<DateTime> TemOML6202TestTime
        {
            get
            {
                return this._TemOML6202TestTime;
            }
            set
            {
                this._TemOML6202TestTime = value;
            }
        }
		
		public string FTCMode
		{
			get
			{
				return this._FTCMode;
			}
			set
			{
                this._FTCMode = value;
			}
		}
		
		public string FTCErrorCount
		{
			get
			{
                return this._FTCErrorCount;
			}
			set
			{
                this._FTCErrorCount = value;
			}
		}
		
		public string FTCErrorSeconds
		{
			get
			{
				return this._FTCErrorSeconds;
			}
			set
			{
                this._FTCErrorSeconds = value;
			}
		}

		public string FTCAIS
		{
			get
			{
				return this._FTCAIS;
			}
			set
			{
                this._FTCAIS = value;
			}
		}

        public System.Nullable<char> FTCFinalFlag
        {
            get
            {
                return this._FTCFinalFlag;
            }
            set
            {
                this._FTCFinalFlag = value;
            }
        }

        public string FTCOperator
        {
            get
            {
                return this._FTCOperator;
            }
            set
            {
                this._FTCOperator = value;
            }
        }

        public System.Nullable<DateTime> FTCTestTime
        {
            get
            {
                return this._FTCTestTime;
            }
            set
            {
                this._FTCTestTime = value;
            }
        }
		
		public System.Nullable<System.DateTime> LastUpdateDate
		{
			get
			{
				return this._LastUpdateDate;
			}
			set
			{
                this._LastUpdateDate = value;
			}
		}
		
		public string LastUpdatedBy
		{
			get
			{
				return this._LastUpdatedBy;
			}
			set
			{
                this._LastUpdatedBy = value;
			}
		}
    }
}

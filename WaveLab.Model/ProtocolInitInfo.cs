using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class ProtocolInitInfo
	{

        private string _Model;

        private int _ProtocolInitId;

        private string _SerialNo;

        private System.Nullable<System.DateTime> _StartTime;

        private System.Nullable<System.DateTime> _EndTime;

        private string _TypeLow;

        private string _TypeHigh;

        private string _PowerRange;

        private string _FreqRangeLow;

        private string _FreqRangeHigh;

        private string _ModeMaxPower;

        private string _RSSIOffSet;

        private string _PowerOffSet;

        private string _Aging;

        private string _FilterSwitch;

        private string _MCUVersion;

        private string _PartNum;

        private string _IDNum;

        private string _TxPllLow;

        private string _RxPllLow;

        private string _PaILow;

        private string _TxPowLow;

        private string _Negative5VLow;

        private string _TxIFLow;

        private string _TxPllHigh;

        private string _RxPllHigh;

        private string _PaIHigh;

        private string _TxPowHigh;

        private string _Negative5VHigh;

        private string _TxIFHigh;

        private string _AtpcRange;

        private string _RSSIAlarm;

        private string _FactoryInfo;

        private string _RunningTime;

        private string _AppVersion;

        private System.Nullable<char> _FinalFlag;

        private string _Operator;

        private string _Reason;

        public string Reason
        {
            get
            {
                return this._Reason;
            }
            set
            {
                this._Reason = value;
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

        public int ProtocolInitId
        {
            get
            {
                return this._ProtocolInitId;
            }
            set
            {
                this._ProtocolInitId = value;
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

        public string TypeLow
        {
            get
            {
                return this._TypeLow;
            }
            set
            {
                this._TypeLow = value;
            }
        }

        public string TypeHigh
        {
            get
            {
                return this._TypeHigh;
            }
            set
            {
                this._TypeHigh = value;
            }
        }

        public string PowerRange
        {
            get
            {
                return this._PowerRange;
            }
            set
            {
                this._PowerRange = value;
            }
        }

        public string FreqRangeLow
        {
            get
            {
                return this._FreqRangeLow;
            }
            set
            {
                this._FreqRangeLow = value;
            }
        }

        public string FreqRangeHigh
        {
            get
            {
                return this._FreqRangeHigh;
            }
            set
            {
                this._FreqRangeHigh = value;
            }
        }

        public string ModeMaxPower
        {
            get
            {
                return this._ModeMaxPower;
            }
            set
            {
                this._ModeMaxPower = value;
            }
        }

        public string RSSIOffSet
        {
            get
            {
                return this._RSSIOffSet;
            }
            set
            {
                this._RSSIOffSet = value;
            }
        }

        public string PowerOffSet
        {
            get
            {
                return this._PowerOffSet;
            }
            set
            {
                this._PowerOffSet = value;
            }
        }

        public string Aging
        {
            get
            {
                return this._Aging;
            }
            set
            {
                this._Aging = value;
            }
        }


        public string FilterSwitch
        {
            get
            {
                return this._FilterSwitch;
            }
            set
            {
                this._FilterSwitch = value;
            }
        }

        public string MCUVersion
        {
            get
            {
                return this._MCUVersion;
            }
            set
            {
                this._MCUVersion = value;
            }
        }


        public string PartNum
        {
            get
            {
                return this._PartNum;
            }
            set
            {
                this._PartNum = value;
            }
        }

        public string IDNum
        {
            get
            {
                return this._IDNum;
            }
            set
            {
                this._IDNum = value;
            }
        }

        public string TxPllLow
        {
            get
            {
                return this._TxPllLow;
            }
            set
            {
                this._TxPllLow = value;
            }
        }

        public string RxPllLow
        {
            get
            {
                return this._RxPllLow;
            }
            set
            {
                this._RxPllLow = value;
            }
        }


        public string PaILow
        {
            get
            {
                return this._PaILow;
            }
            set
            {
                this._PaILow = value;
            }
        }

        public string TxPowLow
        {
            get
            {
                return this._TxPowLow;
            }
            set
            {
                this._TxPowLow = value;
            }
        }

        public string Negative5VLow
        {
            get
            {
                return this._Negative5VLow;
            }
            set
            {
                this._Negative5VLow = value;
            }
        }

        public string TxIFLow
        {
            get
            {
                return this._TxIFLow;
            }
            set
            {
                this._TxIFLow = value;
            }
        }

        public string TxPllHigh
        {
            get
            {
                return this._TxPllHigh;
            }
            set
            {
                this._TxPllHigh = value;
            }
        }

        public string RxPllHigh
        {
            get
            {
                return this._RxPllHigh;
            }
            set
            {
                this._RxPllHigh = value;
            }
        }

        public string PaIHigh
        {
            get
            {
                return this._PaIHigh;
            }
            set
            {
                this._PaIHigh = value;
            }
        }

        public string TxPowHigh
        {
            get
            {
                return this._TxPowHigh;
            }
            set
            {
                this._TxPowHigh = value;
            }
        }

        public string Negative5VHigh
        {
            get
            {
                return this._Negative5VHigh;
            }
            set
            {
                this._Negative5VHigh = value;
            }
        }

        public string TxIFHigh
        {
            get
            {
                return this._TxIFHigh;
            }
            set
            {
                this._TxIFHigh = value;
            }
        }

        public string RSSIAlarm
        {
            get
            {
                return this._RSSIAlarm;
            }
            set
            {
                this._RSSIAlarm = value;
            }
        }

        public string FactoryInfo
        {
            get
            {
                return this._FactoryInfo;
            }
            set
            {
                this._FactoryInfo = value;
            }
        }

        public string RunningTime
        {
            get
            {
                return this._RunningTime;
            }
            set
            {
                this._RunningTime = value;
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

        public System.Nullable<char> FinalFlag
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
	}
}

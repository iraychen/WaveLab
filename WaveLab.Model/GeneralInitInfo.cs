using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class GeneralInitInfo
    {
       
        private string _Model;

        private int _GeneralInitId;

        private string _SerialNo;

        private System.Nullable<System.DateTime> _StartTime;

        private System.Nullable<System.DateTime> _EndTime;

        private string _TypeLow;

        private string _FreqRangeLow;

        private string _AlarmLow;

        private string _TypeHigh;

        private string _FreqRangeHigh;

        private string _AlarmHigh;

        private string _PowerRange;

        private string _ModeMaxPower;

        private string _RSSIOffSet;

        private string _PowerOffSet;

        private string _Aging;

        private string _FilterSwitch;

        private string _NoiseFigure;

        private string _MaxSupportedBandWidth;

        private string _ControledVoltageExt;

        private string _TxTempOffSet;

        private string _CleiNo;

        private string _HardVersion;

        private string _ModelNo;

        private string _StationNo;

        private System.Nullable<char> _FinalFlag;

        private string _MCUVersion;

        private string _RunningTime;

        private string _AppVersion;

        private string _Operator;

        private string _Reason;

        public int GeneralInitId
        {
            get
            {
                return this._GeneralInitId;
            }
            set
            {
                this._GeneralInitId = value;
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

        public string AlarmLow
        {
            get
            {
                return this._AlarmLow;
            }
            set
            {
                this._AlarmLow = value;
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

        public string AlarmHigh
        {
            get
            {
                return this._AlarmHigh;
            }
            set
            {
                this._AlarmHigh = value;
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

        public string NoiseFigure
        {
            get
            {
                return this._NoiseFigure;
            }
            set
            {
                this._NoiseFigure = value;
            }
        }

        public string MaxSupportedBandWidth
        {
            get
            {
                return this._MaxSupportedBandWidth;
            }
            set
            {
                this._MaxSupportedBandWidth = value;
            }
        }

        public string ControledVoltageExt
        {
            get
            {
                return this._ControledVoltageExt;
            }
            set
            {
                this._ControledVoltageExt = value;
            }
        }

        public string TxTempOffSet
        {
            get
            {
                return this._TxTempOffSet;
            }
            set
            {
                this._TxTempOffSet = value;
            }
        }

        public string CleiNo
        {
            get
            {
                return this._CleiNo;
            }
            set
            {
                this._CleiNo = value;
            }
        }

        public string HardVersion
        {
            get
            {
                return this._HardVersion;
            }
            set
            {
                this._HardVersion = value;
            }
        }

        public string ModelNo
        {
            get
            {
                return this._ModelNo;
            }
            set
            {
                this._ModelNo = value;
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
                this._RunningTime= value;
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
    }
}

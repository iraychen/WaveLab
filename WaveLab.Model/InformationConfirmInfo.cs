using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class InformationConfirmInfo
    {
        private string _Model;

        private int _InformationConfirmId;

        private string _SerialNo;

        private System.Nullable<System.DateTime> _StartTime;

        private System.Nullable<System.DateTime> _EndTime;

        private string _TypeLow;

        private string _TypeHigh;

        private string _PowerRange;

        private string _FreqRange;

        private string _ModeMaxPower;

        private string _RSSIOffSet;

        private string _RSSICHOffSet;

        private string _PowerOffSet;

        private string _Aging;

        private string _FilterSwitch;

        private string _ControledVoltage;

        private string _ControledVoltageExt;

        private string _MCUVersion;

        private string _PartNum;

        private string _IDNum;

        private string _TxPll;

        private string _RxPll;

        private string _PaI;

        private string _TxPow;

        private string _TxPowRange;

        private string _TxTempOffSet;

        private string _Negative5V;

        private string _TxIf;

        private string _AtpcRange;

        private string _RSSIAlarm;

        private string _Remodlo;

        private string _Temperature;

        private string _ModelNo;
	
        private string _CleiNo;

        private string _IQCIVolt;

        private string _IQCQVolt;

        private string _MaufactDate;

        private string _TheHighestMode;

        private string _TheHighestCapacity;

        private string _OrderingNo;

        private string _AssociatedEclipseVersion;

        private string _MaxSuppurtedBandWidth;
	
	    private string _BootLoadVersion;

        private string _NoiseFigure;

        private string _HardWare_Version;

        private string _RunningTime;

        private string _AppVersion;

        private System.Nullable<char> _FinalFlag;

        private string _Operator;

        private string _StationNo;

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

        public int InformationConfirmId
        {
            get
            {
                return this._InformationConfirmId;
            }
            set
            {
                this._InformationConfirmId = value;
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

        public string FreqRange
        {
            get
            {
                return this._FreqRange;
            }
            set
            {
                this._FreqRange = value;
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

        public string RSSICHOffSet
        {
            get
            {
                return this._RSSICHOffSet;
            }
            set
            {
                this._RSSICHOffSet = value;
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

        public string ControledVoltage
        {
            get
            {
                return this._ControledVoltage;
            }
            set
            {
                this._ControledVoltage = value;
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

        public string TxPll
        {
            get
            {
                return this._TxPll;
            }
            set
            {
                this._TxPll = value;
            }
        }

        public string RxPll
        {
            get
            {
                return this._RxPll;
            }
            set
            {
                this._RxPll = value;
            }
        }

        public string PaI
        {
            get
            {
                return this._PaI;
            }
            set
            {
                this._PaI = value;
            }
        }

        public string TxPow
        {
            get
            {
                return this._TxPow;
            }
            set
            {
                this._TxPow = value;
            }
        }

        public string TxPowRange
        {
            get
            {
                return this._TxPowRange;
            }
            set
            {
                this._TxPowRange = value;
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

        public string Negative5V
        {
            get
            {
                return this._Negative5V;
            }
            set
            {
                this._Negative5V = value;
            }
        }

        public string TxIf
        {
            get
            {
                return this._TxIf;
            }
            set
            {
                this._TxIf = value;
            }
        }

        public string AtpcRange
        {
            get
            {
                return this._AtpcRange;
            }
            set
            {
                this._AtpcRange = value;
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

        public string Remodlo
        {
            get
            {
                return this._Remodlo;
            }
            set
            {
                this._Remodlo = value;
            }
        }

        public string Temperature
        {
            get
            {
                return this._Temperature;
            }
            set
            {
                this._Temperature = value;
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

        public string IQCIVolt
        {
            get
            {
                return this._IQCIVolt;
            }
            set
            {
                this._IQCIVolt = value;
            }
        }

        public string IQCQVolt
        {
            get
            {
                return this._IQCQVolt;
            }
            set
            {
                this._IQCQVolt = value;
            }
        }

        public string MaufactDate
        {
            get
            {
                return this._MaufactDate;
            }
            set
            {
                this._MaufactDate = value;
            }
        }

        public string TheHighestMode
        {
            get
            {
                return this._TheHighestMode;
            }
            set
            {
                this._TheHighestMode = value;
            }
        }

        public string TheHighestCapacity
        {
            get
            {
                return this._TheHighestCapacity;
            }
            set
            {
                this._TheHighestCapacity = value;
            }
        }

        public string OrderingNo
        {
            get
            {
                return this._OrderingNo;
            }
            set
            {
                this._OrderingNo = value;
            }
        }

        public string AssociatedEclipseVersion
        {
            get
            {
                return this._AssociatedEclipseVersion;
            }
            set
            {
                this._AssociatedEclipseVersion = value;
            }
        }

        public string MaxSuppurtedBandWidth
        {
            get
            {
                return this._MaxSuppurtedBandWidth;
            }
            set
            {
                this._MaxSuppurtedBandWidth = value;
            }
        }

        public string BootLoadVersion
        {
            get
            {
                return this._BootLoadVersion;
            }
            set
            {
                this._BootLoadVersion = value;
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
        public string HardWareVersion
        {
            get
            {
                return this._HardWare_Version;
            }
            set
            {
                this._HardWare_Version = value;
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

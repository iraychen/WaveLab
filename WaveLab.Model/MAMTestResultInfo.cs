using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class MAMTestResultInfo
    {
        private int _MAMTestResultId;

        private string _MBSerialNo;

        private string _PLLSerialNo;

        private string _Type;

        private System.Nullable<System.DateTime> _StartTime;

        private System.Nullable<System.DateTime> _EndTime;

        private string _IFFrequency;

        private string _REVMainBoard;

        private string _REVPLLBoard;

        private string _StationNo;

        private string _TxLoPower;

        private string _RxLoPower;

        private string _RxIF10;

        private string _RxIFNegative67;

        private string _AbsPrxIFOffset;

        private string _TxIF;

        private string _TXIFRange;

        private string _LoOffset;

        private string _RSSIHighLow;

        private string _CtrlVoltage;

        private string _Heater;

        private string _Aging;

        private string _FlatTxIF;

        private string _FlatTxLo;

        private string _FlatRxIF;

        private string _TxPLL;

        private string _PAI;

        private string _RxPLL;

        private string _TxPow;

        private string _Negative5V;

        private string _TxIFResult;

        private string _FirmWareVersion;

        private string _BwLowHigh;

        private string _FSKFreq;

        private string _LoLeakage;

        private string _Temperature;

        private string _Remodlo;

        private char _FinalFlag;

        private string _AppVersion;

        private string _Operator;

        private IList<MAMTestResultDetail> _DetailItems;

        public int MAMTestResultId
        {
            get
            {
                return this._MAMTestResultId;
            }
            set
            {
                this._MAMTestResultId = value;
            }
        }

        public string MBSerialNo
        {
            get
            {
                return this._MBSerialNo;
            }
            set
            {
                this._MBSerialNo = value;
            }
        }

        public string PLLSerialNo
        {
            get
            {
                return this._PLLSerialNo;
            }
            set
            {
                this._PLLSerialNo = value;
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

        public string IFFrequency
        {
            get
            {
                return this._IFFrequency;
            }
            set
            {
                this._IFFrequency = value;
            }
        }

        public string REVMainBoard
        {
            get
            {
                return this._REVMainBoard;
            }
            set
            {
                this._REVMainBoard = value;
            }
        }

        public string REVPLLBoard
        {
            get
            {
                return this._REVPLLBoard;
            }
            set
            {
                this._REVPLLBoard = value;
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

        public string TxLoPower
        {
            get
            {
                return this._TxLoPower;
            }
            set
            {
                this._TxLoPower = value;
            }
        }

        public string RxLoPower
        {
            get
            {
                return this._RxLoPower;
            }
            set
            {
                this._RxLoPower = value;
            }
        }

        public string RxIF10
        {
            get
            {
                return this._RxIF10;
            }
            set
            {
                this._RxIF10 = value;
            }
        }

        public string RxIFNegative67
        {
            get
            {
                return this._RxIFNegative67;
            }
            set
            {
                this._RxIFNegative67 = value;
            }
        }

        public string AbsPrxIFOffset
        {
            get
            {
                return this._AbsPrxIFOffset;
            }
            set
            {
                this._AbsPrxIFOffset = value;
            }
        }

        public string TxIF
        {
            get
            {
                return this._TxIF;
            }
            set
            {
                this._TxIF = value;
            }
        }

        public string TXIFRange
        {
            get
            {
                return this._TXIFRange;
            }
            set
            {
                this._TXIFRange = value;
            }
        }

        public string LoOffset
        {
            get
            {
                return this._LoOffset;
            }
            set
            {
                this._LoOffset = value;
            }
        }

        public string RSSIHighLow
        {
            get
            {
                return this._RSSIHighLow;
            }
            set
            {
                this._RSSIHighLow = value;
            }
        }

        public string CtrlVoltage
        {
            get
            {
                return this._CtrlVoltage;
            }
            set
            {
                this._CtrlVoltage = value;
            }
        }

        public string Heater
        {
            get
            {
                return this._Heater;
            }
            set
            {
                this._Heater = value;
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

        public string FlatTxIF
        {
            get
            {
                return this._FlatTxIF;
            }
            set
            {
                this._FlatTxIF = value;
            }
        }

        public string FlatTxLo
        {
            get
            {
                return this._FlatTxLo;
            }
            set
            {
                this._FlatTxLo = value;
            }
        }

        public string FlatRxIF
        {
            get
            {
                return this._FlatRxIF;
            }
            set
            {
                this._FlatRxIF = value;
            }
        }

        public string TxPLL
        {
            get
            {
                return this._TxPLL;
            }
            set
            {
                this._TxPLL = value;
            }
        }

        public string PAI
        {
            get
            {
                return this._PAI;
            }
            set
            {
                this._PAI = value;
            }
        }

        public string RxPLL
        {
            get
            {
                return this._RxPLL;
            }
            set
            {
                this._RxPLL = value;
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

        public string TxIFResult
        {
            get
            {
                return this._TxIFResult;
            }
            set
            {
                this._TxIFResult = value;
            }
        }

        public string FirmWareVersion
        {
            get
            {
                return this._FirmWareVersion;
            }
            set
            {
                this._FirmWareVersion = value;
            }
        }

        public string BwLowHigh
        {
            get
            {
                return this._BwLowHigh;
            }
            set
            {
                this._BwLowHigh = value;
            }
        }

        public string FSKFreq
        {
            get
            {
                return this._FSKFreq;
            }
            set
            {
                this._FSKFreq = value;
            }
        }

        public string LoLeakage
        {
            get
            {
                return this._LoLeakage;
            }
            set
            {
                this._LoLeakage = value;
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

        public IList<MAMTestResultDetail> DetailItems
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

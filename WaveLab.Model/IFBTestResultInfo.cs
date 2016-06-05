using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class IFBTestResultInfo
    {

        private int _IFBTestResultId;

        private string _SerialNo;

        private string _Type;

        private System.Nullable<System.DateTime> _StartTime;

        private System.Nullable<System.DateTime> _EndTime;

        private string _IFFrequency;

        private string _REV;

        private string _TxIF;

        private string _LoIF;

        private string _RxIF5;

        private string _RxIFNegative65;

        private string _AbsRxIFAmpl;

        private string _RSSIVolt5;

        private string _RSSIVoltNegative65;

        private string _TxIFRanne;

        private string _LoFrequencyOffset;

        private string _TxPLL;

        private string _PAI;

        private string _RxPLL;

        private string _TxPow;

        private string _Negative5V;

        private string _TxIFResult;

        private char _FinalFlag;

        private string _AppVersion;

        private string _Operator;

        public int IFBTestResultId
        {
            get
            {
                return this._IFBTestResultId;
            }
            set
            {
                this._IFBTestResultId = value;
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

        public string REV
        {
            get
            {
                return this._REV;
            }
            set
            {
                this._REV = value;
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

        public string LoIF
        {
            get
            {
                return this._LoIF;
            }
            set
            {
                this._LoIF = value;
            }
        }

        public string RxIF5
        {
            get
            {
                return this._RxIF5;
            }
            set
            {
                this._RxIF5 = value;
            }
        }

        public string RxIFNegative65
        {
            get
            {
                return this._RxIFNegative65;
            }
            set
            {
                this._RxIFNegative65 = value;
            }
        }

        public string AbsRxIFAmpl
        {
            get
            {
                return this._AbsRxIFAmpl;
            }
            set
            {
                this._AbsRxIFAmpl = value;
            }
        }

        public string RSSIVolt5
        {
            get
            {
                return this._RSSIVolt5;
            }
            set
            {
                this._RSSIVolt5 = value;
            }
        }

        public string RSSIVoltNegative65
        {
            get
            {
                return this._RSSIVoltNegative65;
            }
            set
            {
                this._RSSIVoltNegative65 = value;
            }
        }

        public string TxIFRanne
        {
            get
            {
                return this._TxIFRanne;
            }
            set
            {
                this._TxIFRanne = value;
            }
        }

        public string LoFrequencyOffset
        {
            get
            {
                return this._LoFrequencyOffset;
            }
            set
            {
                this._LoFrequencyOffset = value;
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
    }
}

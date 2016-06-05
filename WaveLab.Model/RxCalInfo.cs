using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class RxCalInfo
    {
        private int _RxCalId;

      
        private string _Model;


        private string _SerialNo;

        private System.Nullable<System.DateTime> _StartTime;

        private System.Nullable<System.DateTime> _EndTime;

        private string _Type;

        private string _StationNo;

        private string _CHNo;

        private string _WGNo;

        private string _RunningTime;

        private System.Nullable<char> _FinalFlag;

        private string _AppVersion;

        private string _Operator;

        private string _Reason;

        private System.Nullable<char> _ManualInput;

        private IList<RxCalRSSIDetInfo> _RxCalRSSIDetItems;

        public int RxCalId
        {
            get
            {
                return this._RxCalId;
            }
            set
            {
                this._RxCalId = value;
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

        public string CHNo
        {
            get
            {
                return this._CHNo;
            }
            set
            {
                this._CHNo = value;
            }
        }

        public string WGNo
        {
            get
            {
                return this._WGNo;
            }
            set
            {
                this._WGNo = value;
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

        public System.Nullable<char> ManualInput
        {
            get
            {
                return this._ManualInput;
            }
            set
            {
                this._ManualInput = value;
            }
        }

        public IList<RxCalRSSIDetInfo> RxCalRSSIDetItems
        {
            get
            {
                return this._RxCalRSSIDetItems;
            }
            set
            {
                this._RxCalRSSIDetItems = value;
            }
        }
    }
}

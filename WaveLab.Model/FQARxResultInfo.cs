using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class FQARxResultInfo
    {
       
        private string _Model;


        private int _FQARxResultId;

        private string _SerialNo;

        private System.Nullable<System.DateTime> _StartTime;

        private System.Nullable<System.DateTime> _EndTime;

        private string _Type;

        private string _CH;

        private string _StationNo;

        private string _RunningTime;

        private string _RXAGC;

        private string _RSSIOffSet;

        private string _NF;

        private string _BWLowHIgh;

        private string _Freq140M;

        private System.Nullable<char> _FinalFlag;

        private string _AppVersion;

        private string _Operator;

        private IList<FQARxResultPowerLevelInfo> _FQARxResultPowerLevelItems;


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

        

        public int FQARxResultId
        {
            get
            {
                return this._FQARxResultId;
            }
            set
            {
                this._FQARxResultId = value;
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

        public string RXAGC
        {
            get
            {
                return this._RXAGC;
            }
            set
            {
                this._RXAGC = value;
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

        public string NF
        {
            get
            {
                return this._NF;
            }
            set
            {
                this._NF = value;
            }
        }

        public string BWLowHIgh
        {
            get
            {
                return this._BWLowHIgh;
            }
            set
            {
                this._BWLowHIgh = value;
            }
        }

        public string Freq140M
        {
            get
            {
                return this._Freq140M;
            }
            set
            {
                this._Freq140M = value;
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

        public IList<FQARxResultPowerLevelInfo> FQARxResultPowerLevelItems
        {
            get
            {
                return this._FQARxResultPowerLevelItems;
            }
            set
            {
                this._FQARxResultPowerLevelItems = value;
            }
        }
    }
}

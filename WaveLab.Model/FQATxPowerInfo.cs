using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class FQATxPowerInfo
    {
      
        private string _Model;

    

        private int _FQATxPowerId;

        private string _SerialNo;

        private System.Nullable<System.DateTime> _StartTime;

        private System.Nullable<System.DateTime> _EndTime;

        private string _Type;

        private string _StationNo;

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


        private IList<FQATxPowerTableInfo> _FQATxPowerTableItems;

      

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

       

        public int FQATxPowerId
        {
            get
            {
                return this._FQATxPowerId;
            }
            set
            {
                this._FQATxPowerId = value;
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

        public IList<FQATxPowerTableInfo> FQATxPowerTableItems
        {
            get
            {
                return this._FQATxPowerTableItems;
            }
            set
            {
                this._FQATxPowerTableItems = value;
            }
        }
    }
}

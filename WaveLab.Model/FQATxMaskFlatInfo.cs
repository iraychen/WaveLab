﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class FQATxMaskFlatInfo
    {

      

        private string _Model;

        private int _FQATxMaskFlatId;

        private string _SerialNo;

        private System.Nullable<System.DateTime> _StartTime;

        private System.Nullable<System.DateTime> _EndTime;

        private string _Type;

        private string _StationNo;

        private string _RunningTime;

        private string _AppVersion;

        private System.Nullable<char> _FinalFlag;

        private string _Operator;

        private IList<FQATxMaskFlatDetailInfo> _FQATxMaskFlatDetailItems;


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

       

        public int FQATxMaskFlatId
        {
            get
            {
                return this._FQATxMaskFlatId;
            }
            set
            {
                this._FQATxMaskFlatId = value;
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

        public IList<FQATxMaskFlatDetailInfo> FQATxMaskFlatDetailItems
        {
            get
            {
                return this._FQATxMaskFlatDetailItems;
            }
            set
            {
                this._FQATxMaskFlatDetailItems = value;
            }
        }
    }
}

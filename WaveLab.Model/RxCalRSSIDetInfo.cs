using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class RxCalRSSIDetInfo
    {
        private System.Nullable<int> _RxCalId;

        private System.Nullable<int> _Data;

        private System.Nullable<int> _RSSI;

        private System.Nullable<double> _Voltage;

        private string _Address;

        public System.Nullable<int> RxCalId
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

        public System.Nullable<int> Data
        {
            get
            {
                return this._Data;
            }
            set
            {
                this._Data = value;
            }
        }

        public System.Nullable<int> RSSI
        {
            get
            {
                return this._RSSI;
            }
            set
            {
                this._RSSI = value;
            }
        }

        public System.Nullable<double> Voltage
        {
            get
            {
                return this._Voltage;
            }
            set
            {
                this._Voltage = value;
            }
        }

        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this._Address = value;
            }
        }
    }
}

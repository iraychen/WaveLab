using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class TxCableTableInfo
    {
        private System.Nullable<int> _TxCableId;

        private System.Nullable<int> _CBLData;

        private System.Nullable<int> _CBL;

        private System.Nullable<double> _CBLVoltage;

        private string _CBLAddress;

        public System.Nullable<int> TxCableId
        {
            get
            {
                return this._TxCableId;
            }
            set
            {
                this._TxCableId = value;
            }
        }

        public System.Nullable<int> CBLData
        {
            get
            {
                return this._CBLData;
            }
            set
            {
                this._CBLData = value;
            }
        }

        public System.Nullable<int> CBL
        {
            get
            {
                return this._CBL;
            }
            set
            {
                this._CBL = value;
            }
        }

        public System.Nullable<double> CBLVoltage
        {
            get
            {
                return this._CBLVoltage;
            }
            set
            {
                this._CBLVoltage = value;
            }
        }

        public string CBLAddress
        {
            get
            {
                return this._CBLAddress;
            }
            set
            {
                this._CBLAddress = value;
            }
        }
    }
}

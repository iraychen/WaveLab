using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCSDPartMAMInfo
    {
        private int _SDPartPK;

        private string _StationNo;

        private string _SerialNo;

        private System.Nullable<double> _LSL_TxLoPower;

        private System.Nullable<double> _USL_TxLoPower;

        private System.Nullable<double> _LSL_RxAGC;

        private System.Nullable<double> _USL_RxAGC;

        private char _Enable;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int SDPartPK
        {
            get
            {
                return this._SDPartPK;
            }
            set
            {
                this._SDPartPK = value;
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

        public System.Nullable<double> LSL_TxLoPower
        {
            get
            {
                return this._LSL_TxLoPower;
            }
            set
            {
                this._LSL_TxLoPower = value;
            }
        }

        public System.Nullable<double> USL_TxLoPower
        {
            get
            {
                return this._USL_TxLoPower;
            }
            set
            {
                this._USL_TxLoPower = value;
            }
        }

        public System.Nullable<double> LSL_RxAGC
        {
            get
            {
                return this._LSL_RxAGC;
            }
            set
            {
                this._LSL_RxAGC = value;
            }
        }

        public System.Nullable<double> USL_RxAGC
        {
            get
            {
                return this._USL_RxAGC;
            }
            set
            {
                this._USL_RxAGC = value;
            }
        }

        public char Enable
        {
            get
            {
                return this._Enable;
            }
            set
            {
                this._Enable = value;
            }
        }

        public System.DateTime LastUpdateDate
        {
            get
            {
                return this._LastUpdateDate;
            }
            set
            {
                this._LastUpdateDate = value;
            }
        }

        public string LastUpdatedBy
        {
            get
            {
                return this._LastUpdatedBy;
            }
            set
            {
                this._LastUpdatedBy = value;
            }
        }
    }
}

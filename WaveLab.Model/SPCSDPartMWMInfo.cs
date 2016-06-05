using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCSDPartMWMInfo
    {
        private int _SDPartPK;

        private string _StationNo;

        private string _TxIndex;

        private string _SerialNo;

        private System.Nullable<double> _LSL_TxGain;

        private System.Nullable<double> _USL_TxGain;

        private System.Nullable<double> _LSL_RxIFGain;

        private System.Nullable<double> _USL_RxIFGain;

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

        public string TxIndex
        {
            get
            {
                return this._TxIndex;
            }
            set
            {
                this._TxIndex = value;
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

        public System.Nullable<double> LSL_TxGain
        {
            get
            {
                return this._LSL_TxGain;
            }
            set
            {
                this._LSL_TxGain = value;
            }
        }

        public System.Nullable<double> USL_TxGain
        {
            get
            {
                return this._USL_TxGain;
            }
            set
            {
                this._USL_TxGain = value;
            }
        }

        public System.Nullable<double> LSL_RxIFGain
        {
            get
            {
                return this._LSL_RxIFGain;
            }
            set
            {
                this._LSL_RxIFGain = value;
            }
        }

        public System.Nullable<double> USL_RxIFGain
        {
            get
            {
                return this._USL_RxIFGain;
            }
            set
            {
                this._USL_RxIFGain = value;
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

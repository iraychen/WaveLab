using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCSDPartRxPowerInfo
    {
        private int _SDPartPK;

        private string _StationNo;

        private char _Divide;

        private string _CHNo;

        private string _Mode;

        private string _CH;

        private string _PW;

        private string _SerialNo;

        private System.Nullable<double> _LSL;

        private System.Nullable<double> _USL;

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

        public char Divide
        {
            get
            {
                return this._Divide;
            }
            set
            {
                this._Divide = value;
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

        public string Mode
        {
            get
            {
                return this._Mode;
            }
            set
            {
                this._Mode = value;
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

        public string PW
        {
            get
            {
                return this._PW;
            }
            set
            {
                this._PW = value;
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

        public System.Nullable<double> LSL
        {
            get
            {
                return this._LSL;
            }
            set
            {
                this._LSL = value;
            }
        }

        public System.Nullable<double> USL
        {
            get
            {
                return this._USL;
            }
            set
            {
                this._USL = value;
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

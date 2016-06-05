using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCRxPowerItemInfo
    {
        private int _RxPowerItemPK;

        private string _Type;

        private string _Mode;

        private string _CH;

        private string _PW;

        private double _SamplingLower;

        private double _SamplingUpper;

        private double _LSL;

        private double _USL;

        private System.Nullable<double> _LCL_X;

        private System.Nullable<double> _UCL_X;

        private System.Nullable<double> _LCL_R;

        private System.Nullable<double> _UCL_R;

        private char _TakePartIn;

        private char _Enable;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int RxPowerItemPK
        {
            get
            {
                return this._RxPowerItemPK;
            }
            set
            {
                this._RxPowerItemPK = value;
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

        public double SamplingLower
        {
            get
            {
                return this._SamplingLower;
            }
            set
            {
                this._SamplingLower = value;
            }
        }

        public double SamplingUpper
        {
            get
            {
                return this._SamplingUpper;
            }
            set
            {
                this._SamplingUpper = value;
            }
        }

        public double LSL
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

        public double USL
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

        public System.Nullable<double> LCL_X
        {
            get
            {
                return this._LCL_X;
            }
            set
            {
                this._LCL_X = value;
            }
        }

        public System.Nullable<double> UCL_X
        {
            get
            {
                return this._UCL_X;
            }
            set
            {
                this._UCL_X = value;
            }
        }

        public System.Nullable<double> LCL_R
        {
            get
            {
                return this._LCL_R;
            }
            set
            {
                this._LCL_R = value;
            }
        }

        public System.Nullable<double> UCL_R
        {
            get
            {
                return this._UCL_R;
            }
            set
            {
                this._UCL_R = value;
            }
        }

        public char TakePartIn
        {
            get
            {
                return this._TakePartIn;
            }
            set
            {
                this._TakePartIn = value;
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

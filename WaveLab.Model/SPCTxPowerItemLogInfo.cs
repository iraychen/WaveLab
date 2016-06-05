using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCTxPowerItemLogInfo
    {
        private int _LogId;

        private double _LSL;

        private double _USL;

        private System.Nullable<double> _LCL_X;

        private System.Nullable<double> _UCL_X;

        private System.Nullable<double> _LCL_R;

        private System.Nullable<double> _UCL_R;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int LogId
        {
            get
            {
                return this._LogId;
            }
            set
            {
                this._LogId = value;
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

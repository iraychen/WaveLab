using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCSDPartRxAGCDetail
    {
        private int _XMRDetailPK;

        private int _XMRPK;

        private int _NoOfTimes;

        private System.DateTime _TestingDate;

        private double _TestingValue;

        private System.Nullable<double> _MR;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int XMRDetailPK
        {
            get
            {
                return this._XMRDetailPK;
            }
            set
            {
                this._XMRDetailPK = value;
            }
        }

        public int XMRPK
        {
            get
            {
                return this._XMRPK;
            }
            set
            {
                this._XMRPK = value;
            }
        }

        public int NoOfTimes
        {
            get
            {
                return this._NoOfTimes;
            }
            set
            {
                this._NoOfTimes = value;
            }
        }

        public DateTime TestingDate
        {
            get
            {
                return this._TestingDate;
            }
            set
            {
                this._TestingDate = value;
            }
        }

        public double TestingValue
        {
            get
            {
                return this._TestingValue;
            }
            set
            {
                this._TestingValue = value;
            }
        }

        public System.Nullable<double> MR
        {
            get
            {
                return this._MR;
            }
            set
            {
                this._MR = value;
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

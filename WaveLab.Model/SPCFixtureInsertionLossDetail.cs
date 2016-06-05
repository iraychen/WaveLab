using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCFixtureInsertionLossDetail
    {
        private int _LineLossDetailPK;

        private int _LineLossPK;

        private int _NoOfTimes;

        private DateTime _TestingDate;

        private double _TestingValue;

        private System.Nullable<double> _MR;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int LineLossDetailPK
        {
            get
            {
                return this._LineLossDetailPK;
            }
            set
            {
                this._LineLossDetailPK = value;
            }
        }

        public int LineLossPK
        {
            get
            {
                return this._LineLossPK;
            }
            set
            {
                this._LineLossPK = value;
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

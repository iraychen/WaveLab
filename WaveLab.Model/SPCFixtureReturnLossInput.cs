using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCFixtureReturnLossInput
    {      
        private int _FixtureItemPK;

        private int _NoOfTimes;

        private System.DateTime _TestingDate;

        private double _TestingValue;

        private System.Nullable<char> _IsHistory;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;
       

        public int FixtureItemPK
        {
            get
            {
                return this._FixtureItemPK;
            }
            set
            {
                this._FixtureItemPK = value;
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

        public System.DateTime TestingDate
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

        public System.Nullable<char> IsHistory
        {
            get
            {
                return this._IsHistory;
            }
            set
            {
                this._IsHistory = value;
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

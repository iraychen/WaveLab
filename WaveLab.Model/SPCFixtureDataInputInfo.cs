using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCFixtureDataInputInfo
    {      
        private int _FixtureItemPK;

        private int _NoOfTimes;

        private System.DateTime _TestingDate;

        private double _ReturnLossValue;

        private double _InsertionLossValue;

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

        public double ReturnLossValue
        {
            get
            {
                return this._ReturnLossValue;
            }
            set
            {
                this._ReturnLossValue = value;
            }
        }

        public double InsertionLossValue
        {
            get
            {
                return this._InsertionLossValue;
            }
            set
            {
                this._InsertionLossValue = value;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCFixtureInsertionLossException
    {
        private int _LineLossExceptionPK;

        private int _LineLossPK;

        private int _NoOfTimes;

        private DateTime _TestingDate;

        private char _ChartType;

        private string _Comment;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int LineLossExceptionPK
        {
            get
            {
                return this._LineLossExceptionPK;
            }
            set
            {
                this._LineLossExceptionPK = value;
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

        public char ChartType
        {
            get
            {
                return this._ChartType;
            }
            set
            {
                this._ChartType = value;
            }
        }

        public string Comment
        {
            get
            {
                return this._Comment;
            }
            set
            {
                this._Comment = value;
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

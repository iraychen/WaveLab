using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCPullingForceWeeklyException
    {
        private int _PullingForceWeeklyExceptionPK;

        private int _PullingForceWeeklyPK;

        private int _GroupNo;

        private DateTime _WorkingDate;

        private char _ChartType;

        private string _Comment;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int PullingForceWeeklyExceptionPK
        {
            get
            {
                return this._PullingForceWeeklyExceptionPK;
            }
            set
            {
                this._PullingForceWeeklyExceptionPK = value;
            }
        }

        public int PullingForceWeeklyPK
        {
            get
            {
                return this._PullingForceWeeklyPK;
            }
            set
            {
                this._PullingForceWeeklyPK = value;
            }
        }

        public int GroupNo
        {
            get
            {
                return this._GroupNo;
            }
            set
            {
                this._GroupNo = value;
            }
        }

        public DateTime WorkingDate
        {
            get
            {
                return this._WorkingDate;
            }
            set
            {
                this._WorkingDate = value;
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

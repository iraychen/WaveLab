using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCPullingForceMonthlyException
    {
        private int _PullingForceMonthlyExceptionPK;

        private int _PullingForceMonthlyPK;

        private int _GroupNo;

        private DateTime _WorkingDate;

        private char _ChartType;

        private string _Comment;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int PullingForceMonthlyExceptionPK
        {
            get
            {
                return this._PullingForceMonthlyExceptionPK;
            }
            set
            {
                this._PullingForceMonthlyExceptionPK = value;
            }
        }

        public int PullingForceMonthlyPK
        {
            get
            {
                return this._PullingForceMonthlyPK;
            }
            set
            {
                this._PullingForceMonthlyPK = value;
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

        public  DateTime WorkingDate
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

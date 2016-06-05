using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCStationLineLossItemLogInfo
    {
        private int _LogId;

        private System.Nullable<double> _LCL_X;

        private System.Nullable<double> _UCL_X;

        private System.Nullable<double> _LCL_MR;

        private System.Nullable<double> _UCL_MR;

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

        public System.Nullable<double> LCL_MR
        {
            get
            {
                return this._LCL_MR;
            }
            set
            {
                this._LCL_MR = value;
            }
        }

        public System.Nullable<double> UCL_MR
        {
            get
            {
                return this._UCL_MR;
            }
            set
            {
                this._UCL_MR = value;
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

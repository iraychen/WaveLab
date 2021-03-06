﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCPullingForceWeeklyInfo
    {
        private int _PullingForceWeeklyPK;

        private string _MachineNo;

        private DateTime _DateFrom;

        private DateTime _DateTo;

        private int _GroupingNo;

        private double _X;

        private double _R;

        private double _S;

        private System.Nullable<double> _LSL;

        private System.Nullable<double> _USL;

        private double _CPK;

        private double _LCL_X;

        private double _CL_X;

        private double _UCL_X;

        private double _LCL_R;

        private double _CL_R;

        private double _UCL_R;

        private IList<SPCPullingForceWeeklyDetail> _DetailItems;

        private IList<SPCPullingForceWeeklyException> _ExceptionItems;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

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

        public string MachineNo
        {
            get
            {
                return this._MachineNo;
            }
            set
            {
                this._MachineNo = value;
            }
        }
       
        public DateTime DateFrom
        {
            get
            {
                return this._DateFrom;
            }
            set
            {
                this._DateFrom = value;
            }
        }

        public DateTime DateTo
        {
            get
            {
                return this._DateTo;
            }
            set
            {
                this._DateTo = value;
            }
        }

        public int GroupingNo
        {
            get
            {
                return this._GroupingNo;
            }
            set
            {
                this._GroupingNo = value;
            }
        }

        public double X
        {
            get
            {
                return this._X;
            }
            set
            {
                this._X = value;
            }
        }

        public double R
        {
            get
            {
                return this._R;
            }
            set
            {
                this._R = value;
            }
        }

        public double S
        {
            get
            {
                return this._S;
            }
            set
            {
                this._S = value;
            }
        }

        public System.Nullable<double> LSL
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

        public System.Nullable<double> USL
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

        public double CPK
        {
            get
            {
                return this._CPK;
            }
            set
            {
                this._CPK = value;
            }
        }

        public double LCL_X
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

        public double CL_X
        {
            get
            {
                return this._CL_X;
            }
            set
            {
                this._CL_X = value;
            }
        }

        public double UCL_X
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

        public double LCL_R
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

        public double CL_R
        {
            get
            {
                return this._CL_R;
            }
            set
            {
                this._CL_R = value;
            }
        }

        public double UCL_R
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

        public IList<SPCPullingForceWeeklyDetail> DetailItems
        {
            get
            {
                return this._DetailItems;
            }
            set
            {
                this._DetailItems = value;
            }
        }

        public IList<SPCPullingForceWeeklyException> ExceptionItems
        {
            get
            {
                return this._ExceptionItems;
            }
            set
            {
                this._ExceptionItems = value;
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

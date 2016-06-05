using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCPullingForceTargetInfo
    {
        private int _PullingForceTargetPK;

        private string _MachineNo;

        private DateTime _EffectiveDate;

        private double _UCL_X;

        private double _LCL_X;

        private double _CL_X;

        private double _UCL_R;

        private double _LCL_R;

        private double _CL_R;

        private DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int PullingForceTargetPK
        {
            get
            {
                return this._PullingForceTargetPK;
            }
            set
            {
                this._PullingForceTargetPK = value;
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

        public DateTime EffectiveDate
        {
            get
            {
                return this._EffectiveDate;
            }
            set
            {
                this._EffectiveDate = value;
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

        public DateTime LastUpdateDate
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCPullingForceInfo
    {
         private int _PullingForcePK;

        private string _MachineNo;

        private DateTime _WorkingDate;

        private string _MWMType;

        private int _MachinePressure;

        private int _PowerFirstPoint;

        private int _PowerSecondPoint;

        private string _Operator;

        private double _X1;

        private double _X2;

        private double _X3;

        private double _X4;

        private double _X5;

        private double _X6;

        private double _X7;

        private double _X8;

        private double _X9;

        private double _X10;

        private DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int  PullingForcePK
        {
            get
            {
                return this._PullingForcePK;
            }
            set
            {
                this._PullingForcePK = value;
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

        public string MWMType
        {
            get
            {
                return this._MWMType;
            }
            set
            {
                this._MWMType = value;
            }
        }

        public int MachinePressure
        {
            get
            {
                return this._MachinePressure;
            }
            set
            {
                this._MachinePressure = value;
            }
        }

        public int PowerFirstPoint
        {
            get
            {
                return this._PowerFirstPoint;
            }
            set
            {
                this._PowerFirstPoint = value;
            }
        }

        public int PowerSecondPoint
        {
            get
            {
                return this._PowerSecondPoint;
            }
            set
            {
                this._PowerSecondPoint = value;
            }
        }

        public string Operator
        {
            get
            {
                return this._Operator;
            }
            set
            {
                this._Operator = value;
            }
        }

        public double X1
        {
            get
            {
                return this._X1;
            }
            set
            {
                this._X1 = value;
            }
        }

        public double X2
        {
            get
            {
                return this._X2;
            }
            set
            {
                this._X2 = value;
            }
        }

        public double X3
        {
            get
            {
                return this._X3;
            }
            set
            {
                this._X3 = value;
            }
        }

        public double X4
        {
            get
            {
                return this._X4;
            }
            set
            {
                this._X4 = value;
            }
        }

        public double X5
        {
            get
            {
                return this._X5;
            }
            set
            {
                this._X5 = value;
            }
        }

        public double X6
        {
            get
            {
                return this._X6;
            }
            set
            {
                this._X6 = value;
            }
        }

        public double X7
        {
            get
            {
                return this._X7;
            }
            set
            {
                this._X7 = value;
            }
        }

        public double X8
        {
            get
            {
                return this._X8;
            }
            set
            {
                this._X8 = value;
            }
        }

        public double X9
        {
            get
            {
                return this._X9;
            }
            set
            {
                this._X9 = value;
            }
        }

        public double X10
        {
            get
            {
                return this._X10;
            }
            set
            {
                this._X10 = value;
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

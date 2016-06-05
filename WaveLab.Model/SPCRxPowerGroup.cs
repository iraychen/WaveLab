using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCRxPowerGroup
    {
        private int _RxPowerGroupPK;

        private int _RxPowerPK;

        private int _GroupNo;

        private double _X;

        private double _R;

        private char _TakePartIn;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int RxPowerGroupPK
        {
            get
            {
                return this._RxPowerGroupPK;
            }
            set
            {
                this._RxPowerGroupPK = value;
            }
        }

        public int RxPowerPK
        {
            get
            {
                return this._RxPowerPK;
            }
            set
            {
                this._RxPowerPK = value;
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

        public char TakePartIn
        {
            get
            {
                return this._TakePartIn;
            }
            set
            {
                this._TakePartIn = value;
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

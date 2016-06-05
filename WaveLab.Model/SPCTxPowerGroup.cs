using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCTxPowerGroup
    {
        private int _TxPowerGroupPK;

        private int _TxPowerPK;

        private int _GroupNo;

        private double _X;

        private double _R;

        private char _TakePartIn;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int TxPowerGroupPK
        {
            get
            {
                return this._TxPowerGroupPK;
            }
            set
            {
                this._TxPowerGroupPK = value;
            }
        }

        public int TxPowerPK
        {
            get
            {
                return this._TxPowerPK;
            }
            set
            {
                this._TxPowerPK = value;
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

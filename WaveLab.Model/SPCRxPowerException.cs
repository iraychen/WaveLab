using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCRxPowerException
    {
        private int _TxPowerExceptionPK;

        private int _TxPowerPK;

        private int _GroupNo;

        private char _ChartType;

        private string _Comment;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int TxPowerExceptionPK
        {
            get
            {
                return this._TxPowerExceptionPK;
            }
            set
            {
                this._TxPowerExceptionPK = value;
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

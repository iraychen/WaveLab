using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCTxMaskFlatException
    {
        private int _TxMaskFlatExceptionPK;

        private int _TxMaskFlatPK;

        private int _GroupNo;

        private char _ChartType;

        private string _Comment;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int TxMaskFlatExceptionPK
        {
            get
            {
                return this._TxMaskFlatExceptionPK;
            }
            set
            {
                this._TxMaskFlatExceptionPK = value;
            }
        }

        public int TxMaskFlatPK
        {
            get
            {
                return this._TxMaskFlatPK;
            }
            set
            {
                this._TxMaskFlatPK = value;
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

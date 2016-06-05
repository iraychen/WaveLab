using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCTxMaskFlatDetail
    {
        private int _TxMaskFlatDetailPK;

        private int _TxMaskFlatPK;

        private string _SerialNo;

        private DateTime _EndTime;

        private string _Val;

        private int _GroupNo;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int TxMaskFlatDetailPK
        {
            get
            {
                return this._TxMaskFlatDetailPK;
            }
            set
            {
                this._TxMaskFlatDetailPK = value;
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

        public string SerialNo
        {
            get
            {
                return this._SerialNo;
            }
            set
            {
                this._SerialNo = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return this._EndTime;
            }
            set
            {
                this._EndTime = value;
            }
        }

        public string Val
        {
            get
            {
                return this._Val;
            }
            set
            {
                this._Val = value;
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

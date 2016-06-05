using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCTxPowerDetail
    {
        private int _TxPowerDetailPK;

        private int _TxPowerPK;

        private string _SerialNo;

        private DateTime _EndTime;

        private string _OutPutPower;

        private int _GroupNo;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int TxPowerDetailPK
        {
            get
            {
                return this._TxPowerDetailPK;
            }
            set
            {
                this._TxPowerDetailPK = value;
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

        public string OutPutPower
        {
            get
            {
                return this._OutPutPower;
            }
            set
            {
                this._OutPutPower = value;
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

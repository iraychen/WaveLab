using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class NTRxPowerDetailIInfo
    {
        private System.Nullable<int> _NTRxPowerId;

        private string _Mode;

        private string _CH;

        private string _RxPower;

        private string _ReceiveResult;

        public System.Nullable<int> NTRxPowerId
        {
            get
            {
                return this._NTRxPowerId;
            }
            set
            {
                this._NTRxPowerId = value;
            }
        }

        public string Mode
        {
            get
            {
                return this._Mode;
            }
            set
            {
                this._Mode = value;
            }
        }

        public string CH
        {
            get
            {
                return this._CH;
            }
            set
            {
                this._CH = value;
            }
        }

        public string RxPower
        {
            get
            {
                return this._RxPower;
            }
            set
            {
                this._RxPower = value;
            }
        }

        public string ReceiveResult
        {
            get
            {
                return this._ReceiveResult;
            }
            set
            {
                this._ReceiveResult = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public  class NTRxMicroDetailInfo
    {
        private System.Nullable<int> _NTRxMicroPK;

        private string _Mode;

        private string _CH;

        private string _LocalRxPower;

        private string _LocalSNR;

        private string _LocalRxPowerResult;

        private string _LocalSNRResult;

        private string _LocalESResult;

        private string _RemoteRxPower;

        private string _RemoteSNR;

        private string _RemoteRxPowerResult;

        private string _RemoteSNRResult;

        private string _RemoteESResult;

        public System.Nullable<int> NTRxMicroPK
        {
            get
            {
                return this._NTRxMicroPK;
            }
            set
            {
                this._NTRxMicroPK = value;
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

        public string LocalRxPower
        {
            get
            {
                return this._LocalRxPower;
            }
            set
            {
                this._LocalRxPower = value;
            }
        }

        public string LocalSNR
        {
            get
            {
                return this._LocalSNR;
            }
            set
            {
                this._LocalSNR = value;
            }
        }

        public string LocalRxPowerResult
        {
            get
            {
                return this._LocalRxPowerResult;
            }
            set
            {
                this._LocalRxPowerResult = value;
            }
        }

        public string LocalSNRResult
        {
            get
            {
                return this._LocalSNRResult;
            }
            set
            {
                this._LocalSNRResult = value;
            }
        }

        public string LocalESResult
        {
            get
            {
                return this._LocalESResult;
            }
            set
            {
                this._LocalESResult = value;
            }
        }

        public string RemoteRxPower
        {
            get
            {
                return this._RemoteRxPower;
            }
            set
            {
                this._RemoteRxPower = value;
            }
        }

        public string RemoteSNR
        {
            get
            {
                return this._RemoteSNR;
            }
            set
            {
                this._RemoteSNR = value;
            }
        }

        public string RemoteRxPowerResult
        {
            get
            {
                return this._RemoteRxPowerResult;
            }
            set
            {
                this._RemoteRxPowerResult = value;
            }
        }

        public string RemoteSNRResult
        {
            get
            {
                return this._RemoteSNRResult;
            }
            set
            {
                this._RemoteSNRResult = value;
            }
        }

        public string RemoteESResult
        {
            get
            {
                return this._RemoteESResult;
            }
            set
            {
                this._RemoteESResult = value;
            }
        }

    }
}

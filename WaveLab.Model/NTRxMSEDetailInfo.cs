using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class NTRxMSEDetailInfo
    {
        private System.Nullable<int> _BatchNTRxId;

        private string _Mode;

        private string _CH;

        private string _LocalRxPower;

        private string _LocalMSE;

        private string _LocalRxPowerResult;

        private string _LocalMSEResult;

        private string _RemoteRxPower;

        private string _RemoteMSE;

        private string _RemoteRxPowerResult;

        private string _RemoteMSEResult;

        public System.Nullable<int> BatchNTRxId
        {
            get
            {
                return this._BatchNTRxId;
            }
            set
            {
                this._BatchNTRxId = value;
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

        public string LocalMSE
        {
            get
            {
                return this._LocalMSE;
            }
            set
            {
                this._LocalMSE = value;
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

        public string LocalMSEResult
        {
            get
            {
                return this._LocalMSEResult;
            }
            set
            {
                this._LocalMSEResult = value;
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

        public string RemoteMSE
        {
            get
            {
                return this._RemoteMSE;
            }
            set
            {
                this._RemoteMSE = value;
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

        public string RemoteMSEResult
        {
            get
            {
                return this._RemoteMSEResult;
            }
            set
            {
                this._RemoteMSEResult = value;
            }
        }
    }
}

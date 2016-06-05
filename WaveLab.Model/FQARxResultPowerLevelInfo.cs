using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class FQARxResultPowerLevelInfo
    {
        private System.Nullable<int> _FQARxResultId;

        private string _PWLV;

        private string _BNCVoltage;

        private string _DetectRxPowerHigh;

        private string _DetectRxPowerLow;

        private string _Level140MHZ;

        private string _Freq140MHZ;

        public System.Nullable<int> FQARxResultId
        {
            get
            {
                return this._FQARxResultId;
            }
            set
            {
                this._FQARxResultId = value;
            }
        }

        public string PWLV
        {
            get
            {
                return this._PWLV;
            }
            set
            {
                this._PWLV = value;
            }
        }

        public string BNCVoltage
        {
            get
            {
                return this._BNCVoltage;
            }
            set
            {
                this._BNCVoltage = value;
            }
        }

        public string DetectRxPowerHigh
        {
            get
            {
                return this._DetectRxPowerHigh;
            }
            set
            {
                this._DetectRxPowerHigh = value;
            }
        }

        public string DetectRxPowerLow
        {
            get
            {
                return this._DetectRxPowerLow;
            }
            set
            {
                this._DetectRxPowerLow = value;
            }
        }

        public string Level140MHZ
        {
            get
            {
                return this._Level140MHZ;
            }
            set
            {
                this._Level140MHZ = value;
            }
        }

        public string Freq140MHZ
        {
            get
            {
                return this._Freq140MHZ;
            }
            set
            {
                this._Freq140MHZ = value;
            }
        }
    }
}

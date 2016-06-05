using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class FQATxPowerTableInfo
    {
        private System.Nullable<int> _FQATxPowerId;

        private string _Mode;

        private string _CH;

        private string _PW;

        private string _OutputPower;

        private string _TxDetPower;

        private string _TxRSSIPower;

        public System.Nullable<int> FQATxPowerId
        {
            get
            {
                return this._FQATxPowerId;
            }
            set
            {
                this._FQATxPowerId = value;
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

        public string PW
        {
            get
            {
                return this._PW;
            }
            set
            {
                this._PW = value;
            }
        }

        public string OutputPower
        {
            get
            {
                return this._OutputPower;
            }
            set
            {
                this._OutputPower = value;
            }
        }

        public string TxDetPower
        {
            get
            {
                return this._TxDetPower;
            }
            set
            {
                this._TxDetPower = value;
            }
        }

        public string TxRSSIPower
        {
            get
            {
                return this._TxRSSIPower;
            }
            set
            {
                this._TxRSSIPower = value;
            }
        }
    }
}

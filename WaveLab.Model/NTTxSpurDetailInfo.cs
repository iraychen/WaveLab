using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class NTTxSpurDetailInfo
    {
        private System.Nullable<int> _TxSpurId;

        private string _Mode;

        private string _CH;

        private string _FreqRange;

        private string _FreqPoint;

        private string _SpurCheck;

        public System.Nullable<int> TxSpurId
        {
            get
            {
                return this._TxSpurId;
            }
            set
            {
                this._TxSpurId = value;
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

        public string FreqRange
        {
            get
            {
                return this._FreqRange;
            }
            set
            {
                this._FreqRange = value;
            }
        }

        public string FreqPoint
        {
            get
            {
                return this._FreqPoint;
            }
            set
            {
                this._FreqPoint = value;
            }
        }

        public string SpurCheck
        {
            get
            {
                return this._SpurCheck;
            }
            set
            {
                this._SpurCheck = value;
            }
        }
    }
}

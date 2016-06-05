using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class NTTxMaskFlatDetailInfo
    {
        private System.Nullable<int> _NTTxMaskFlatId;

        private string _Mode;

        private string _CH;

        private string _MaskFlat;

        public System.Nullable<int> NTTxMaskFlatId
        {
            get
            {
                return this._NTTxMaskFlatId;
            }
            set
            {
                this._NTTxMaskFlatId = value;
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

        public string MaskFlat
        {
            get
            {
                return this._MaskFlat;
            }
            set
            {
                this._MaskFlat = value;
            }
        }
    }
}

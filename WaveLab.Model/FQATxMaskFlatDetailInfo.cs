using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class FQATxMaskFlatDetailInfo
    {
        private System.Nullable<int> _FQATxMaskFlatId;

        private string _Mode;

        private string _CH;

        private string _MaskFlat;

        public System.Nullable<int> FQATxMaskFlatId
        {
            get
            {
                return this._FQATxMaskFlatId;
            }
            set
            {
                this._FQATxMaskFlatId = value;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public  class FQATxMaskDetailInfo
    {
        private System.Nullable<int> _FQATxMaskId;

        private string _Mode;

        private string _CH;

        private string _MaskCheck;

        private System.Byte[] _MaskImage;

        public System.Nullable<int> FQATxMaskId
        {
            get
            {
                return this._FQATxMaskId;
            }
            set
            {
                this._FQATxMaskId = value;
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

        public string MaskCheck
        {
            get
            {
                return this._MaskCheck;
            }
            set
            {
                this._MaskCheck = value;
            }
        }

        public System.Byte[] MaskImage
        {
            get
            {
                return this._MaskImage;
            }
            set
            {
                this._MaskImage = value;
            }
        }
    }
}

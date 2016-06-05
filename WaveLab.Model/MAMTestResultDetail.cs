using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class MAMTestResultDetail
    {
        private System.Nullable<int> _MAMTestResultId;

        private System.Nullable<decimal> _TxIFSweep;

        private System.Nullable<decimal> _TxLoSweep;

        private System.Nullable<decimal> _RxIFSweep;

        public System.Nullable<int> MAMTestResultId
        {
            get
            {
                return this._MAMTestResultId;
            }
            set
            {
                this._MAMTestResultId = value;
            }
        }

        public System.Nullable<decimal> TxIFSweep
        {
            get
            {
                return this._TxIFSweep;
            }
            set
            {
                this._TxIFSweep = value;
            }
        }

        public System.Nullable<decimal> TxLoSweep
        {
            get
            {
                return this._TxLoSweep;
            }
            set
            {
                 this._TxLoSweep = value;
            }
        }

        public System.Nullable<decimal> RxIFSweep
        {
            get
            {
                return this._RxIFSweep;
            }
            set
            {
                this._RxIFSweep = value;
            }
        }
    }
}

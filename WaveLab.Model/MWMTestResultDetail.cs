using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class MWMTestResultDetail
    {
		private System.Nullable<int> _MWMTestResultId;

        private int _TxIndex;
		
		private string _TxFreq;
		
		private string _TxPow;
		
		private string _TxSpurFreq;
		
		private string _TxSpurPow;
		
		private System.Nullable<decimal> _TxGain;
		
		private string _RxIFFreq;
		
		private string _RxIFPow;
		
		private string _RxSpurFreq;
		
		private string _RxSpurPow;

        private System.Nullable<decimal> _RxIFGain;

        private System.Nullable<decimal> _NoiseFigure;
		
		public System.Nullable<int> MWMTestResultId
		{
			get
			{
				return this._MWMTestResultId;
			}
			set
			{
				this._MWMTestResultId = value;
			}
		}

        public int TxIndex
        {
            get
            {
                return this._TxIndex;
            }
            set
            {
                this._TxIndex = value;
            }
        }
		
		public string TxFreq
		{
			get
			{
				return this._TxFreq;
			}
			set
			{
				this._TxFreq = value;
			}
		}
		
		public string TxPow
		{
			get
			{
				return this._TxPow;
			}
			set
			{
				this._TxPow = value;
			}
		}
		
		public string TxSpurFreq
		{
			get
			{
				return this._TxSpurFreq;
			}
			set
			{
			this._TxSpurFreq = value;
			}
		}
		
		public string TxSpurPow
		{
			get
			{
				return this._TxSpurPow;
			}
			set
			{
				this._TxSpurPow = value;
			}
		}

        public System.Nullable<decimal> TxGain
		{
			get
			{
				return this._TxGain;
			}
			set
			{
				this._TxGain = value;
			}
		}
		
		public string RxIFFreq
		{
			get
			{
				return this._RxIFFreq;
			}
			set
			{
				this._RxIFFreq = value;
			}
		}
		
		public string RxIFPow
		{
			get
			{
				return this._RxIFPow;
			}
			set
			{
				this._RxIFPow = value;
			}
		}
		
		public string RxSpurFreq
		{
			get
			{
				return this._RxSpurFreq;
			}
			set
			{
			    this._RxSpurFreq = value;
			}
		}
		
		public string RxSpurPow
		{
			get
			{
				return this._RxSpurPow;
			}
			set
			{
				this._RxSpurPow = value;
			}
		}

        public System.Nullable<decimal> RxIFGain
		{
			get
			{
				return this._RxIFGain;
			}
			set
			{
				this._RxIFGain = value;
			}
		}
    }
}

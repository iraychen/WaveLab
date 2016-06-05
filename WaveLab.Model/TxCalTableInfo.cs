using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class TxCalTableInfo
    {
        private System.Nullable<int> _TxCalId;

        private System.Nullable<int> _TPSTDbm;

        private System.Nullable<int> _TPSTTxPowSetData;

        private string _TPSTAddress;

        private System.Nullable<double> _TPSTControledVoltage;

        private System.Nullable<int> _TPDTVref;

        private System.Nullable<int> _TPDTTxPow;

        private System.Nullable<double> _TPDTVoltage;

        private string _TPDTAddress;

        private System.Nullable<int> _ChannelNo;

        private System.Nullable<int> _ChannelOutData;

        private string _ChannelPower;

        private string _ChannelAddress;

        private System.Nullable<Char> _ChannelImageFlag;

		public System.Nullable<int> TxCalId
		{
			get
			{
				return this._TxCalId;
			}
            set
            {
                this._TxCalId = value;
            }
		}

        public System.Nullable<int> TPSTDbm
		{
			get
			{
				return this._TPSTDbm;
			}
			set
			{
                this._TPSTDbm = value;
			}
		}

        public System.Nullable<int> TPSTTxPowSetData
		{
			get
			{
				return this._TPSTTxPowSetData;
			}
			set
			{
                this._TPSTTxPowSetData = value;
			}
		}
		
		public string TPSTAddress
		{
			get
			{
				return this._TPSTAddress;
			}
			set
			{
                this._TPSTAddress = value;
			}
		}

        public System.Nullable<double> TPSTControledVoltage
		{
			get
			{
				return this._TPSTControledVoltage;
			}
			set
			{
                this._TPSTControledVoltage = value;
			}
		}

        public System.Nullable<int> TPDTVref
		{
			get
			{
				return this._TPDTVref;
			}
			set
			{
                this._TPDTVref = value;
			}
		}

        public System.Nullable<int> TPDTTxPow
		{
			get
			{
				return this._TPDTTxPow;
			}
			set
			{
                this._TPDTTxPow = value;
			}
		}

        public System.Nullable<double> TPDTVoltage
		{
			get
			{
				return this._TPDTVoltage;
			}
			set
			{
                this._TPDTVoltage = value;
			}
		}
		
		public string TPDTAddress
		{
			get
			{
				return this._TPDTAddress;
			}
			set
			{
                this._TPDTAddress = value;
			}
		}

        public System.Nullable<int> ChannelNo
		{
			get
			{
				return this._ChannelNo;
			}
			set
			{
                this._ChannelNo = value;
			}
		}

        public System.Nullable<int> ChannelOutData
		{
			get
			{
				return this._ChannelOutData;
			}
			set
			{
                this._ChannelOutData = value;
			}
		}
		
		public string ChannelPower
		{
			get
			{
				return this._ChannelPower;
			}
			set
			{
                this._ChannelPower = value;
			}
		}
		
		public string ChannelAddress
		{
			get
			{
				return this._ChannelAddress;
			}
			set
			{
                this._ChannelAddress = value;
			}
		}

        public System.Nullable<Char> ChannelImageFlag
        {
            get
            {
                return this._ChannelImageFlag;
            }
            set
            {
                this._ChannelImageFlag = value;
            }
        }
    }

}

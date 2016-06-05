using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SerialNoInfo
    {
		private string _OrderNo;
		
		private string _MeterialCode;
		
		private string _MeterialDesc;
		
		private string _BarCode;
		
		private string _SerialNo;

        public string OrderNo
		{
			get
			{
                return this._OrderNo;
			}
			set
			{
				this._OrderNo= value;
			}
		}

        public string MeterialCode
		{
			get
			{
                return this._MeterialCode;
			}
			set
			{
                this._MeterialCode = value;
			}
		}

        public string MeterialDesc
		{
			get
			{
                return this._MeterialDesc;
			}
			set
			{
                this._MeterialDesc = value;
			}
		}

        public string BarCode
		{
			get
			{
                return this._BarCode;
			}
			set
			{
                this._BarCode = value;	
			}
		}

        public string SerialNo
		{
			get
			{
                return this._SerialNo;
			}
			set
			{
                this._SerialNo = value;
			}
		}
    }
}

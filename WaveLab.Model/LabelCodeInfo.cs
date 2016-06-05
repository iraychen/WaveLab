using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class LabelCodeInfo
    {
		private string _Code;
		
		private string _Model;
		
		private string _Freq;
		
		private string _Type;
		
		private string _TRM;
		
		private double _MinFreq;

        private double _MaxFreq;

        private string _HiLow;

        private string _TR;

        private string _Customer;

        private string _Antenna;

        private string _BW;

        private string _BoxType;

        private string _HWLabelModel;

        private string _HWLabelFreq;

        private string _Description;

        private DateTime _Date;

        private string _MaterielDesc;

        public string Code
		{
			get
			{
                return this._Code;
			}
			set
			{
                this._Code = value;
			}
		}

        public string Model
		{
			get
			{
                return this._Model;
			}
			set
			{
                this._Model = value;
			}
		}

        public string Freq
		{
			get
			{
                return this._Freq;
			}
			set
			{
                this._Freq = value;
			}
		}

        public string Type
		{
			get
			{
                return this._Type;
			}
			set
			{
                this._Type = value;
			}
		}

        public string TRM
		{
			get
			{
                return this._TRM;
			}
			set
			{
                this._TRM = value;
			}
		}

        public double MinFreq
		{
			get
			{
                return this._MinFreq;
			}
			set
			{
                this._MinFreq = value;
			}
		}

        public double MaxFreq
		{
			get
			{
                return this._MaxFreq;
			}
			set
			{
                this._MaxFreq = value;	
			}
		}

        public string HiLow
		{
			get
			{
                return this._HiLow;
			}
			set
			{
                this._HiLow = value;
			}
		}

        public string TR
		{
			get
			{
                return this._TR;
			}
			set
			{
                this._TR = value;					
			}
		}

        public string Customer
        {
            get
            {
                return this._Customer;
            }
            set
            {
                this._Customer = value;
            }
        }

        public string Antenna
        {
            get
            {
                return this._Antenna;
            }
            set
            {
                this._Antenna = value;
            }
        }

        public string BW
        {
            get
            {
                return this._BW;
            }
            set
            {
                this._BW = value;
            }
        }

        public string BoxType
        {
            get
            {
                return this._BoxType;
            }
            set
            {
                this._BoxType = value;
            }
        }

        public string HWLabelModel
        {
            get
            {
                return this._HWLabelModel;
            }
            set
            {
                this._HWLabelModel = value;
            }
        }

        public string HWLabelFreq
        {
            get
            {
                return this._HWLabelFreq;
            }
            set
            {
                this._HWLabelFreq = value;
            }
        }

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this._Date;
            }
            set
            {
                this._Date = value;
            }
        }

        public string MaterielDesc
        {
            get
            {
                return this._MaterielDesc;
            }
            set
            {
                this._MaterielDesc = value;
            }
        }
    }
}

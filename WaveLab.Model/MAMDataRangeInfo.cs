using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class MAMDataRangeInfo
    {
        private int _MAMDataRangeID;

        private string _MAMType;

        private string _MAMTypeDesc;

        private string _Frequency;

        private string _Data;

        private string _Description;

        private string _Unit;

        private string _LowerBound;

        private string _UpperBound;

        private string _Target;

        private System.Nullable<System.DateTime> _LastUpdateDate;

        private string _LastUpdatedBy;

        public int MAMDataRangeID
        {
            get
            {
                return this._MAMDataRangeID;
            }
            set
            {
                this._MAMDataRangeID = value;
            }
        }

        public string MAMType
        {
            get
            {
                return this._MAMType;
            }
            set
            {
                this._MAMType = value;
            }
        }

        public string MAMTypeDesc
        {
            get
            {
                return this._MAMTypeDesc;
            }
            set
            {
                this._MAMTypeDesc = value;
            }
        }

        public string Frequency
        {
            get
            {
                return this._Frequency;
            }
            set
            {
                this._Frequency = value;
            }
        }

        public string Data
        {
            get
            {
                return this._Data;
            }
            set
            {
                this._Data = value;
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

        public string Unit
        {
            get
            {
                return this._Unit;
            }
            set
            {
                this._Unit = value;
            }
        }

        public string LowerBound
        {
            get
            {
                return this._LowerBound;
            }
            set
            {
                this._LowerBound = value;
            }
        }

        public string UpperBound
        {
            get
            {
                return this._UpperBound;
            }
            set
            {
                this._UpperBound = value;
            }
        }

        public string Target
        {
            get
            {
                return this._Target;
            }
            set
            {
                this._Target = value;
            }
        }

        public System.Nullable<System.DateTime> LastUpdateDate
        {
            get
            {
                return this._LastUpdateDate;
            }
            set
            {
                this._LastUpdateDate = value;
            }
        }

        public string LastUpdatedBy
        {
            get
            {
                return this._LastUpdatedBy;
            }
            set
            {
                this._LastUpdatedBy = value;
            }
        }
    }
}

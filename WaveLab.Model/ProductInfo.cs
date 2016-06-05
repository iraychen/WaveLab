using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class ProductInfo
    {
        private int _ProductId;

        private System.Nullable<System.DateTime> _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        private string _ProductDesc;

        private System.Nullable<char> _Audited;

        public int ProductId
        {
            get
            {
                return this._ProductId;
            }
            set
            {
                this._ProductId = value;
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

        public System.Nullable<System.DateTime> CreationDate
        {
            get
            {
                return this._CreationDate;
            }
            set
            {
                this._CreationDate = value;
            }
        }

        public string CreatedBy
        {
            get
            {
                return this._CreatedBy;
            }
            set
            {
                this._CreatedBy = value;
            }
        }

        public string ProductDesc
        {
            get
            {
                return this._ProductDesc;
            }
            set
            {
                this._ProductDesc = value;
            }
        }

        public System.Nullable<char> Audited
        {
            get
            {
                return this._Audited;
            }
            set
            {
                this._Audited = value;
            }
        }
		
    }
}

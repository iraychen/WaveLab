using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class MaterialTypeInfo
    {
        private int _MaterialTypeId;

        private string _MaterialTypeDesc;

        private System.Nullable<System.DateTime> _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        private System.Nullable<char> _CalByQuantity;

        public int MaterialTypeId
        {
            get
            {
                return this._MaterialTypeId;
            }
            set
            {
                this._MaterialTypeId = value;
            }
        }

        public string MaterialTypeDesc
        {
            get
            {
                return this._MaterialTypeDesc;
            }
            set
            {
                this._MaterialTypeDesc = value;
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

        public System.Nullable<char> CalByQuantity
        {
            get
            {
                return this._CalByQuantity;
            }
            set
            {
                this._CalByQuantity = value;
            }
        }
    }
}

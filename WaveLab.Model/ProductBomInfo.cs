using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class ProductBomInfo
    {
        private int _ProductBomId;

        private System.Nullable<System.DateTime> _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        private ProductInfo _ProductItem;

        private string _MaterialCode;

        private MaterialTypeInfo _MaterialTypeItem;

        private string _MaterialDesc;

        private string _SupplierName;

        private System.Nullable<double> _Amount;

        private SYSModuleTypeInfo  _ModuleTypeItem;

        private string _Comment;

        public int ProductBomId
        {
            get
            {
                return this._ProductBomId;
            }
            set
            {
                this._ProductBomId = value;
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

        public ProductInfo ProductItem
        {
            get
            {
                return this._ProductItem;
            }
            set
            {
                this._ProductItem = value;
            }
        }

        public string MaterialCode
        {
            get
            {
                return this._MaterialCode;
            }
            set
            {
                this._MaterialCode = value;
            }
        }

        public MaterialTypeInfo MaterialTypeItem
        {
            get
            {
                return this._MaterialTypeItem;
            }
            set
            {
                this._MaterialTypeItem = value;
            }
        }

        public string MaterialDesc
        {
            get
            {
                return this._MaterialDesc;
            }
            set
            {
                this._MaterialDesc = value;
            }
        }

        public string SupplierName
        {
            get
            {
                return this._SupplierName;
            }
            set
            {
                this._SupplierName = value;
            }
        }

        public System.Nullable<double> Amount
        {
            get
            {
                return this._Amount;
            }
            set
            {
                this._Amount = value;
            }
        }

        public SYSModuleTypeInfo ModuleTypeItem
        {
            get
            {
                return this._ModuleTypeItem;
            }
            set
            {
                this._ModuleTypeItem = value;
            }
        }

        public string Comment
        {
            get
            {
                return this._Comment;
            }
            set
            {
                this._Comment = value;
            }
        }
    }
}

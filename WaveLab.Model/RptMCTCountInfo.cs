using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class RptMCTCountInfo
    {
        private ProductInfo _ProductItem;

        private MaterialTypeInfo _MaterialTypeItem;

        private string _MaterialCode;

        private string _MaterialDesc;

        private string _SupplierName;

        private char _Supplied;

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

        public char Supplied
        {
            get
            {
                return this._Supplied;
            }
            set
            {
                this._Supplied = value;
            }
        }
    }
}

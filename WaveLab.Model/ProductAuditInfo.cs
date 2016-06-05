using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class ProductAuditInfo
    {
        private string _MaterialCode;

        private string _MaterialDesc;

        private string _SupplierName;

        private char _Supplied;

        private Int32 _MCTId;

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

        public Int32 MCTId
        {
            get
            {
                return this._MCTId;
            }
            set
            {
                this._MCTId = value;
            }
        }

    }
}

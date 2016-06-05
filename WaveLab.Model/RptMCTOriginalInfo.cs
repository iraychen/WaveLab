using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class RptMCTOriginalInfo
    {
        private string _ProductDesc;

        private string _MaterialTypeDesc;

        private string _MaterialCode;

        private string _MaterialDesc;

        private string _SupplierName;

        private string _ComponentDesc;

        private string _HomoMaterialName;

        private string _SubstanceName;

        private string _CasNo;

        private double _SubstanceMass;

        private double _ContentRate;

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

        public string ComponentDesc
        {
            get
            {
                return this._ComponentDesc;
            }
            set
            {
                this._ComponentDesc = value;
            }
        }

        public string HomoMaterialName
        {
            get
            {
                return this._HomoMaterialName;
            }
            set
            {
                this._HomoMaterialName = value;
            }
        }

        public string SubstanceName
        {
            get
            {
                return this._SubstanceName;
            }
            set
            {
                this._SubstanceName = value;
            }
        }

        public string CasNo
        {
            get
            {
                return this._CasNo;
            }
            set
            {
                this._CasNo = value;
            }
        }

        public double SubstanceMass
        {
            get
            {
                return this._SubstanceMass;
            }
            set
            {
                this._SubstanceMass = value;
            }
        }

        public double ContentRate
        {
            get
            {
                return this._ContentRate;
            }
            set
            {
                this._ContentRate = value;
            }
        }
    }
}

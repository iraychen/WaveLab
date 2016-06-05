using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class MCTDtlInfo
    {
        private int _MCTId;

        private System.Nullable<System.DateTime> _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        private string _MaterialDesc;

        private string _Model;

        private string _PartNo;

        private string _ComponentDesc;

        private string _HomoMaterialName;

        private string _SubstanceName;

        private string _CASNo;

        private System.Nullable<double> _SubstanceMass;

        private System.Nullable<double> _ContentRate;

        //private string _Comment;

        public int MCTId
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

        public string PartNo
        {
            get
            {
                return this._PartNo;
            }
            set
            {
                this._PartNo = value;
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
                if ((this._ComponentDesc != value))
                {
                    this._ComponentDesc = value;
                }
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

        public string CASNo
        {
            get
            {
                return this._CASNo;
            }
            set
            {
                this._CASNo = value;
            }
        }

        public System.Nullable<double> SubstanceMass
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

        public System.Nullable<double> ContentRate
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

        //public string Comment
        //{
        //    get
        //    {
        //        return this._Comment;
        //    }
        //    set
        //    {
        //        this._Comment = value;
        //    }
        //}
    }
}

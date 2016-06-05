using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    [Serializable]
    public  class SYSModuleTypeInfo
    {
       private string _ModuleTypeId;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        private string _ModuleTypeDesc;

        private char _HasGenBoard;

        private char _HasSpeBoard;

        private char _HasSMTFabrication;

        private char _HasComponentPart;

        private char _HasGroupPart;

        private char _HasBindingFabrication;

        public string ModuleTypeId
        {
            get
            {
                return this._ModuleTypeId;
            }
            set
            {
                this._ModuleTypeId = value;
            }
        }

        public System.DateTime LastUpdateDate
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

        public string ModuleTypeDesc
        {
            get
            {
                return this._ModuleTypeDesc;
            }
            set
            {
                this._ModuleTypeDesc = value;
            }
        }

        public Char HasGenBoard
        {
            get
            {
                return this._HasGenBoard;
            }
            set
            {
                this._HasGenBoard = value;
            }
        }

        public Char HasSpeBoard
        {
            get
            {
                return this._HasSpeBoard;
            }
            set
            {
                this._HasSpeBoard = value;
            }
        }

        public Char HasSMTFabrication
        {
            get
            {
                return this._HasSMTFabrication;
            }
            set
            {
                this._HasSMTFabrication = value;
            }
        }

        public Char HasComponentPart
        {
            get
            {
                return this._HasComponentPart;
            }
            set
            {
                this._HasComponentPart = value;
            }
        }

        public Char HasGroupPart
        {
            get
            {
                return this._HasGroupPart;
            }
            set
            {
                this._HasGroupPart = value;
            }
        }

        public Char HasBondingFabrication
        {
            get
            {
                return this._HasBindingFabrication;
            }
            set
            {
                this._HasBindingFabrication = value;
            }
        }
    }
}

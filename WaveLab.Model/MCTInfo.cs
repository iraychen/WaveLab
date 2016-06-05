using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class MCTInfo
    {
        private int _MCTId;

        private System.Nullable<System.DateTime> _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        private string _SupplierName;

        private System.Nullable<System.DateTime> _CompletedDate;

        private string _Department;

        private string _CompletedBy;

        private string _Email;

        private string _Tel;

        private string _Fax;

        private IList<MCTDtlInfo> _MCTDtlItem;

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

        public System.Nullable<System.DateTime> CompletedDate
        {
            get
            {
                return this._CompletedDate;
            }
            set
            {
                this._CompletedDate = value;
            }
        }

        public string Department
        {
            get
            {
                return this._Department;
            }
            set
            {
                this._Department = value;
            }
        }

        public string CompletedBy
        {
            get
            {
                return this._CompletedBy;
            }
            set
            {
                this._CompletedBy = value;
            }
        }

        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
            }
        }

        public string Tel
        {
            get
            {
                return this._Tel;
            }
            set
            {
               this._Tel = value;
            }
        }

        public string Fax
        {
            get
            {
                return this._Fax;
            }
            set
            {
                this._Fax = value;
            }
        }

        public IList<MCTDtlInfo> MCTDtlItem
        {
            get
            {
                return this._MCTDtlItem;
            }
            set
            {
                this._MCTDtlItem = value;
            }
        }
		
    }
}

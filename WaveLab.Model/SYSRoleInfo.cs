using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    [Serializable]
    public  class SYSRoleInfo
    {
        private int _RoleId;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        private string _RoleDesc;

        public SYSRoleInfo()
        {

        }

        public int RoleId
        {
            get
            {
                return this._RoleId;
            }
            set
            {
                this._RoleId = value;
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

        public string RoleDesc
        {
            get
            {
                return this._RoleDesc;
            }
            set
            {
                this._RoleDesc = value;
            }
        }

    }
}

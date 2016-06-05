using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class InjurantTypeInfo
    {
        private int _InjurantTypeId;

        private System.Nullable<System.DateTime> _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        private string _InjurantTypeDesc;

        public int InjurantTypeId
        {
            get
            {
                return this._InjurantTypeId;
            }
            set
            {
                this._InjurantTypeId = value;
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

        public string InjurantTypeDesc
        {
            get
            {
                return this._InjurantTypeDesc;
            }
            set
            {
               this._InjurantTypeDesc = value;
            }
        }
    }
}

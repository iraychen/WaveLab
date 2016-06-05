using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
   public  class SYSFunctionControlInfo
    {
        private string _FunctionId;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        private System.Nullable<char> _Enable;

        public SYSFunctionControlInfo()
        {

        }

        public string FunctionId
        {
            get
            {
                return this._FunctionId;
            }
            set
            {
                this._FunctionId = value;
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

        public System.Nullable<char> Enable
        {
            get
            {
                return this._Enable;
            }
            set
            {
                this._Enable = value;
            }
        }
    }
}

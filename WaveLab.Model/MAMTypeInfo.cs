using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class MAMTypeInfo
    {
        private string _MAMType;

        private string _MAMTypeDesc;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public string MAMType
        {
            get
            {
                return this._MAMType;
            }
            set
            {
                this._MAMType = value;
            }
        }

        public string MAMTypeDesc
        {
            get
            {
                return this._MAMTypeDesc;
            }
            set
            {
                this._MAMTypeDesc = value;
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

      
    }
}

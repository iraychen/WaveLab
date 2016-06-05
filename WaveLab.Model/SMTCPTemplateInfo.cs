using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
   public class SMTCPTemplateInfo
    {
        private System.DateTime _EffectiveDate;

        private System.Nullable<System.DateTime> _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        private string _DocumentPath;

  
        public System.DateTime EffectiveDate
        {
            get
            {
                return this._EffectiveDate;
            }
            set
            {
                if ((this._EffectiveDate != value))
                {
                    this._EffectiveDate = value;
                }
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
                if ((this._LastUpdateDate != value))
                {
                    this._LastUpdateDate = value;
                }
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
                if ((this._LastUpdatedBy != value))
                {
                    this._LastUpdatedBy = value;
                }
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
                if ((this._CreationDate != value))
                {
                    this._CreationDate = value;
                }
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
                if ((this._CreatedBy != value))
                {
                    this._CreatedBy = value;
                }
            }
        }

        public string DocumentPath
        {
            get
            {
                return this._DocumentPath;
            }
            set
            {
                if ((this._DocumentPath != value))
                {
                    this._DocumentPath = value;
                }
            }
        }

    }
}

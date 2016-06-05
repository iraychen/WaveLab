using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    [Serializable]
    public class SMTBomCoorPatternInfo
    {
        private string _Module;

        private string _BomDN;

        private string _BomDVS;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        private string _CoorPattern;

        private string _Comments;

        public string Module
        {
            get
            {
                return this._Module;
            }
            set
            {
                this._Module = value;
            }
        }

        public string BomDN
        {
            get
            {
                return this._BomDN;
            }
            set
            {
                this._BomDN = value;
            }
        }


        public string BomDVS
        {
            get
            {
                return this._BomDVS;
            }
            set
            {
                this._BomDVS = value;
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

        public string CoorPattern
        {
            get
            {
                return this._CoorPattern;
            }
            set
            {
                 this._CoorPattern = value;
            }
        }

        public string Comments
        {
            get
            {
                return this._Comments;
            }
            set
            {
                this._Comments = value;
            }
        }
    }
}

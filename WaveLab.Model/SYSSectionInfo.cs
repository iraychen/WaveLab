using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    [Serializable]
    public class SYSSectionInfo
    {
        private string _SectionId;

        private string _SectionDesc;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        public  string SectionId
        {
            get
            {
                return this._SectionId;
            }
            set
            {
                this._SectionId = value;
            }
        }

        public  string SectionDesc
        {
            get
            {
                return this._SectionDesc;
            }
            set
            {
                this._SectionDesc = value;
            }
        }

        public  System.DateTime LastUpdateDate
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


        public  string LastUpdatedBy
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

        public  System.Nullable<System.DateTime> CreationDate
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

        public  string CreatedBy
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
		
    }
}

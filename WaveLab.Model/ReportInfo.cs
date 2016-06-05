using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class ReportInfo
    {
        private int _ReportPK;

        private string _Title;

        private string _Url;

        private string _GroupCode;

        private ReportGroupInfo _ReportGroup;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int ReportPK
        {
            get
            {
                return this._ReportPK;
            }
            set
            {
                this._ReportPK = value;
            }
        }

        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }

        public string Url
        {
            get
            {
                return this._Url;
            }
            set
            {
                this._Url = value;
            }
        }

        public string GroupCode
        {
            get
            {
                return this._GroupCode;
            }
            set
            {
                this._GroupCode = value;
            }
        }

        public ReportGroupInfo ReportGroup
        {
            get
            {
                return this._ReportGroup;
            }
            set
            {
                this._ReportGroup = value;
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

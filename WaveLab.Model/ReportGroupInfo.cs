using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class ReportGroupInfo
    {
        private string _GroupCode;

        private string _Descript;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        private IList<ReportInfo> _ReportItems;

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

        public string Descript
        {
            get
            {
                return this._Descript;
            }
            set
            {
                this._Descript = value;
            }
        }

        public IList<ReportInfo> ReportItems
        {
            get
            {
                return this._ReportItems;
            }
            set
            {
                this._ReportItems = value;
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

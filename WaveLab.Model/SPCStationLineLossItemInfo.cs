using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCStationLineLossItemInfo
    {
        private int _LineLossItemPK;

        private string _StationNo;

        private string _CHNo;

        private string _FrequencyBand;

        private string _Item;

        private string _MachineInfo;

        private string _ModifiedLog;


        private System.Nullable<double> _LCL_X;

        private System.Nullable<double> _UCL_X;

        private System.Nullable<double> _LCL_MR;

        private System.Nullable<double> _UCL_MR;


        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int LineLossItemPK
        {
            get
            {
                return this._LineLossItemPK;
            }
            set
            {
                this._LineLossItemPK = value;
            }
        }

        public string StationNo
        {
            get
            {
                return this._StationNo;
            }
            set
            {
                this._StationNo = value;
            }
        }

        public string CHNo
        {
            get
            {
                return this._CHNo;
            }
            set
            {
                this._CHNo = value;
            }
        }

        public string FrequencyBand
        {
            get
            {
                return this._FrequencyBand;
            }
            set
            {
                this._FrequencyBand = value;
            }
        }

        public string Item
        {
            get
            {
                return this._Item;
            }
            set
            {
                this._Item = value;
            }
        }

        public System.Nullable<double> LCL_X
        {
            get
            {
                return this._LCL_X;
            }
            set
            {
                this._LCL_X = value;
            }
        }

        public System.Nullable<double> UCL_X
        {
            get
            {
                return this._UCL_X;
            }
            set
            {
                this._UCL_X = value;
            }
        }

        public System.Nullable<double> LCL_MR
        {
            get
            {
                return this._LCL_MR;
            }
            set
            {
                this._LCL_MR = value;
            }
        }

        public System.Nullable<double> UCL_MR
        {
            get
            {
                return this._UCL_MR;
            }
            set
            {
                this._UCL_MR = value;
            }
        }


        public string MachineInfo
        {
            get
            {
                return this._MachineInfo;
            }
            set
            {
                this._MachineInfo = value;
            }
        }

        public string ModifiedLog
        {
            get
            {
                return this._ModifiedLog;
            }
            set
            {
                this._ModifiedLog = value;
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

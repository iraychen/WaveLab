using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCStationLineLossInfo
    {
        private int _LineLossPK;

        private int _LineLossItemPK;

        private DateTime _DateFrom;

        private DateTime _DateTo;
     
        private double _X;

        private double _R;
     
        private double _LCL_X;

        private double _CL_X;

        private double _UCL_X;

        private double _LCL_R;

        private double _CL_R;

        private double _UCL_R;

        private SPCStationLineLossItemInfo _LineLossItem;

        private IList<SPCStationLineLossDetail> _DetailItems;

        private IList<SPCStationLineLossException> _ExceptionItems;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int LineLossPK
        {
            get
            {
                return this._LineLossPK;
            }
            set
            {
                this._LineLossPK = value;
            }
        }

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
               
        public DateTime DateFrom
        {
            get
            {
                return this._DateFrom;
            }
            set
            {
                this._DateFrom = value;
            }
        }

        public DateTime DateTo
        {
            get
            {
                return this._DateTo;
            }
            set
            {
                this._DateTo = value;
            }
        }
      
        public double X
        {
            get
            {
                return this._X;
            }
            set
            {
                this._X = value;
            }
        }

        public double R
        {
            get
            {
                return this._R;
            }
            set
            {
                this._R = value;
            }
        }

        public double LCL_X
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

        public double CL_X
        {
            get
            {
                return this._CL_X;
            }
            set
            {
                this._CL_X = value;
            }
        }

        public double UCL_X
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

        public double LCL_R
        {
            get
            {
                return this._LCL_R;
            }
            set
            {
                this._LCL_R = value;
            }
        }

        public double CL_R
        {
            get
            {
                return this._CL_R;
            }
            set
            {
                this._CL_R = value;
            }
        }

        public double UCL_R
        {
            get
            {
                return this._UCL_R;
            }
            set
            {
                this._UCL_R = value;
            }
        }

        public SPCStationLineLossItemInfo LineLossItem
        {
            get
            {
                return this._LineLossItem;
            }
            set
            {
                this._LineLossItem = value;
            }
        }
       
        public IList<SPCStationLineLossDetail> DetailItems
        {
            get
            {
                return this._DetailItems;
            }
            set
            {
                this._DetailItems = value;
            }
        }

        public IList<SPCStationLineLossException> ExceptionItems
        {
            get
            {
                return this._ExceptionItems;
            }
            set
            {
                this._ExceptionItems = value;
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

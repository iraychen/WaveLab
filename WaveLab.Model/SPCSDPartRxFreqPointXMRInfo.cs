using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCSDPartRxFreqPointXMRInfo
    {
        private int _XMRPK;

       

        private string _StationNo;

        private char _Divide;

        private string _CHNo;

        private string _Type;

        private string _CH;

        private string _PW;

        private string _SerialNo;

        private DateTime _DateFrom;

        private DateTime _DateTo;
     
        private double _X;

        private double _R;

        private System.Nullable<double> _LSL;

        private System.Nullable<double> _USL;
     
        private double _LCL_X;

        private double _CL_X;

        private double _UCL_X;

        private double _LCL_R;

        private double _CL_R;

        private double _UCL_R;
    
        private IList<SPCSDPartRxFreqPointDetail> _DetailItems;

        private IList<SPCSDPartRxFreqPointException> _ExceptionItems;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int XMRPK
        {
            get
            {
                return this._XMRPK;
            }
            set
            {
                this._XMRPK = value;
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

        public char Divide
        {
            get
            {
                return this._Divide;
            }
            set
            {
                this._Divide = value;
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

        public string Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                this._Type = value;
            }
        }

        public string CH
        {
            get
            {
                return this._CH;
            }
            set
            {
                this._CH = value;
            }
        }

        public string PW
        {
            get
            {
                return this._PW;
            }
            set
            {
                this._PW = value;
            }
        }

        public string SerialNo
        {
            get
            {
                return this._SerialNo;
            }
            set
            {
                this._SerialNo = value;
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
        public System.Nullable<double> LSL
        {
            get
            {
                return this._LSL;
            }
            set
            {
                this._LSL = value;
            }
        }

        public System.Nullable<double> USL
        {
            get
            {
                return this._USL;
            }
            set
            {
                this._USL = value;
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

        public IList<SPCSDPartRxFreqPointDetail> DetailItems
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

        public IList<SPCSDPartRxFreqPointException> ExceptionItems
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

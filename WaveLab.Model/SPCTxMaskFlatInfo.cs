using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCTxMaskFlatInfo
    {
        private int _TxMaskFlatPK;

        private string _Type;

        private string _Mode;

        private string _CH;

        private DateTime _DateFrom;

        private DateTime _DateTo;

        private int _GroupingNo;

        private double _X;

        private double _R;

        private double _S;

        private System.Nullable<double> _USL;

        private System.Nullable<double> _CPU;

        private System.Nullable<double> _CPL;

        private double _CPK;

        private double _LCL_X;

        private double _CL_X;

        private double _UCL_X;

        private double _LCL_R;

        private double _CL_R;

        private double _UCL_R;

        private IList<SPCTxMaskFlatDetail> _OriginalItems;

        private IList<SPCTxMaskFlatGroup> _GroupItems;

        private IList<SPCTxMaskFlatException> _ExceptionItems;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int TxMaskFlatPK
        {
            get
            {
                return this._TxMaskFlatPK;
            }
            set
            {
                this._TxMaskFlatPK = value;
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

        public string Mode
        {
            get
            {
                return this._Mode;
            }
            set
            {
                this._Mode = value;
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

        public int GroupingNo
        {
            get
            {
                return this._GroupingNo;
            }
            set
            {
                this._GroupingNo = value;
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

        public double S
        {
            get
            {
                return this._S;
            }
            set
            {
                this._S= value;
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
       
        public System.Nullable<double> CPL
        {
            get
            {
                return this._CPL;
            }
            set
            {
                this._CPL = value;
            }
        }

        public System.Nullable<double> CPU
        {
            get
            {
                return this._CPU;
            }
            set
            {
                this._CPU = value;
            }
        }

        public double CPK
        {
            get
            {
                return this._CPK;
            }
            set
            {
                this._CPK = value;
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

        public IList<SPCTxMaskFlatDetail> OriginalItems
        {
            get
            {
                return this._OriginalItems;
            }
            set
            {
                this._OriginalItems = value;
            }
        }

        public IList<SPCTxMaskFlatGroup> GroupItems
        {
            get
            {
                return this._GroupItems;
            }
            set
            {
                this._GroupItems = value;
            }
        }

        public IList<SPCTxMaskFlatException> ExceptionItems
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

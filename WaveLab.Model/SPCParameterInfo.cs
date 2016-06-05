using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCParameterInfo
    {
        private int _N;

        private System.Nullable<double> _A2;

        private System.Nullable<double> _D2;

        private System.Nullable<double> _D3;

        private System.Nullable<double> _D4;

        private System.Nullable<double> _A3;

        private System.Nullable<double> _C4;

        private System.Nullable<double> _B3;

        private System.Nullable<double> _B4;

        private System.Nullable<System.DateTime> _LastUpdateDate;

        private string _LastUpdatedBy;

        public int N
        {
            get
            {
                return this._N;
            }
            set
            {
                this._N = value;
            }
        }

        public System.Nullable<double> A2
        {
            get
            {
                return this._A2;
            }
            set
            {
                this._A2 = value;
            }
        }

        public System.Nullable<double> D2
        {
            get
            {
                return this._D2;
            }
            set
            {
                this._D2 = value;
            }
        }

        public System.Nullable<double> D3
        {
            get
            {
                return this._D3;
            }
            set
            {
                this._D3 = value;
            }
        }

        public System.Nullable<double> D4
        {
            get
            {
                return this._D4;
            }
            set
            {
                this._D4 = value;
            }
        }

        public System.Nullable<double> A3
        {
            get
            {
                return this._A3;
            }
            set
            {
                this._A3 = value;
            }
        }

        public System.Nullable<double> C4
        {
            get
            {
                return this._C4;
            }
            set
            {
                this._C4 = value;
            }
        }

        public System.Nullable<double> B3
        {
            get
            {
                return this._B3;
            }
            set
            {
                this._B3 = value;
            }
        }

        public System.Nullable<double> B4
        {
            get
            {
                return this._B4;
            }
            set
            {
                this._B4 = value;
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

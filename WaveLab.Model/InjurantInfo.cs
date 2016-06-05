using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class InjurantInfo
    {
        private int _InjurantId;

        private System.Nullable<System.DateTime> _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        private string _InjurantDescEn;

        private string _InjurantDescCn;

        private string _MolecularFormula;

        private string _CasNo;

        private InjurantTypeInfo _InjurantTypeItem;

        private string _MainPurpose;

        public int InjurantId
        {
            get
            {
                return this._InjurantId;
            }
            set
            {
                this._InjurantId = value;
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
        public string InjurantDescEn
        {
            get
            {
                return this._InjurantDescEn;
            }
            set
            {
                this._InjurantDescEn = value;
            }
        }

        public string InjurantDescCn
        {
            get
            {
                return this._InjurantDescCn;
            }
            set
            {
                    this._InjurantDescCn = value;
            }
        }

        public string MolecularFormula
        {
            get
            {
                return this._MolecularFormula;
            }
            set
            {
                this._MolecularFormula = value;
            }
        }

        public string CasNo
        {
            get
            {
                return this._CasNo;
            }
            set
            {
                this._CasNo = value;
            }
        }

        public InjurantTypeInfo InjurantTypeItem
        {
            get
            {
                return this._InjurantTypeItem;
            }
            set
            {
                this._InjurantTypeItem = value;
            }
        }

        public string MainPurpose
        {
            get
            {
                return this._MainPurpose;
            }
            set
            {
               this._MainPurpose = value;
            }
        }
    }
}

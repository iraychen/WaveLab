using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    [Serializable]
    public class SMTFileInduceInfo
    {
        private string _MaterielCode;

        private string _MaterielDesc;

        private string _PCB;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        private SYSModuleTypeInfo _ModuleTypeItem;

        private string _GenBoard;

        private string _GenBoardDN;

        private string _GenBoardDVS;

        private string _SpeBoard;

        private string _SpeBoardDN;

        private string _SpeBoardDVS;

        private string _SMTFabricationDN;

        private string _SMTFabricationDVS;

        private string _ComponentPart;

        private string _ComponentPartDN;

        private string _ComponentPartDVS;

        private string _GroupPart;

        private string _GroupPartDN;

        private string _GroupPartDVS;

        private string _BondingFabricationDN;

        private string _BondingFabricationDVS;

        private string _Comments;

        private string _Explanation;

        public string MaterialCode
        {
            get
            {
                return this._MaterielCode;
            }
            set
            {
                this._MaterielCode = value;
            }
        }

        public string MaterialDesc
        {
            get
            {
                return this._MaterielDesc;
            }
            set
            {
                this._MaterielDesc = value;
            }
        }

        public string PCB
        {
            get
            {
                return this._PCB;
            }
            set
            {
                this._PCB = value;
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

        public SYSModuleTypeInfo ModuleTypeItem
        {
            get
            {
                return this._ModuleTypeItem;
            }
            set
            {
                this._ModuleTypeItem = value;
            }
        }

        public string GenBoard
        {
            get
            {
                return this._GenBoard;
            }
            set
            {
                this._GenBoard = value;
            }
        }

        public string GenBoardDN
        {
            get
            {
                return this._GenBoardDN;
            }
            set
            {
                this._GenBoardDN = value;
            }
        }

        public string GenBoardDVS
        {
            get
            {
                return this._GenBoardDVS;
            }
            set
            {
                this._GenBoardDVS = value;
            }
        }

        public string SpeBoard
        {
            get
            {
                return this._SpeBoard;
            }
            set
            {
                this._SpeBoard = value;
            }
        }

        public string SpeBoardDN
        {
            get
            {
                return this._SpeBoardDN;
            }
            set
            {
                this._SpeBoardDN = value;
            }
        }

        public string SpeBoardDVS
        {
            get
            {
                return this._SpeBoardDVS;
            }
            set
            {
                this._SpeBoardDVS = value;
            }
        }

        public string SMTFabricationDN
        {
            get
            {
                return this._SMTFabricationDN;
            }
            set
            {
                this._SMTFabricationDN = value;
            }
        }

        public string SMTFabricationDVS
        {
            get
            {
                return this._SMTFabricationDVS;
            }
            set
            {
                this._SMTFabricationDVS = value;
            }
        }

        public string ComponentPart
        {
            get
            {
                return this._ComponentPart;
            }
            set
            {
                this._ComponentPart = value;
            }
        }

        public string ComponentPartDN
        {
            get
            {
                return this._ComponentPartDN;
            }
            set
            {
                this._ComponentPartDN = value;
            }
        }

        public string ComponentPartDVS
        {
            get
            {
                return this._ComponentPartDVS;
            }
            set
            {
                this._ComponentPartDVS = value;
            }
        }

        public string GroupPart
        {
            get
            {
                return this._GroupPart;
            }
            set
            {
                this._GroupPart = value;
            }
        }

        public string GroupPartDN
        {
            get
            {
                return this._GroupPartDN;
            }
            set
            {
                this._GroupPartDN = value;
            }
        }

        public string GroupPartDVS
        {
            get
            {
                return this._GroupPartDVS;
            }
            set
            {
                this._GroupPartDVS = value;
            }
        }

        public string BondingFabricationDN
        {
            get
            {
                return this._BondingFabricationDN;
            }
            set
            {
                this._BondingFabricationDN = value;
            }
        }

        public string BondingFabricationDVS
        {
            get
            {
                return this._BondingFabricationDVS;
            }
            set
            {
                this._BondingFabricationDVS = value;
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

        public string Explanation
        {
            get
            {
                return this._Explanation;
            }
            set
            {
                this._Explanation = value;
            }
        }
    }
}

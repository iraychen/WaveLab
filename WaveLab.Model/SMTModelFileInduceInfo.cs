using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
  
    public class SMTModelFileInduceInfo
    {
        private int _FileInducePK;

        private string _ModuleTypeId;

        private string _BillSerialNumber;

        private string _ModuleDesc;

        private string _PCB;

        private string _SerialNumber;

        private string _Version;

        private string _SpeBoard;

        private string _SpeBoardDN;

        private string _SpeBoardDVS;

        private string _FabricationDN;

        private string _FabricationDVS;

        private string _SteelMesh;

        private string _CoorPattern;

        private string _Comments;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        private SYSModuleTypeInfo _ModuleTypeItem;
      
        public int FileInducePK
        {
            get
            {
                return this._FileInducePK;
            }
            set
            {
                this._FileInducePK = value;
            }
        }

        public string ModuleTypeId
        {
            get
            {
                return this._ModuleTypeId;
            }
            set
            {
                this._ModuleTypeId = value;
            }
        }

        public string BillSerialNumber
        {
            get
            {
                return this._BillSerialNumber;
            }
            set
            {
                this._BillSerialNumber = value;
            }
        }

        public string ModuleDesc
        {
            get
            {
                return this._ModuleDesc;
            }
            set
            {
                this._ModuleDesc = value;
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

        public string SerialNumber
        {
            get
            {
                return this._SerialNumber;
            }
            set
            {
                this._SerialNumber = value;
            }
        }

        public string Version
        {
            get
            {
                return this._Version;
            }
            set
            {
                this._Version = value;
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

        public string FabricationDN
        {
            get
            {
                return this._FabricationDN;
            }
            set
            {
                this._FabricationDN = value;
            }
        }

        public string FabricationDVS
        {
            get
            {
                return this._FabricationDVS;
            }
            set
            {
                this._FabricationDVS = value;
            }
        }

        public string SteelMesh
        {
            get
            {
                return this._SteelMesh;
            }
            set
            {
                this._SteelMesh = value;
            }
        }

        public string CoorPattern
        {
            get
            {
                return this._CoorPattern;
            }
            set
            {
                this._CoorPattern = value;
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
    }
}

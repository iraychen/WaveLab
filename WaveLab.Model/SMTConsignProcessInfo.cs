using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SMTConsignProcessInfo
    {
        private string _MaterialCode;

        private string _MaterialDesc;

        private string _PCB;

        private string _GenBoard;

        private string _GenBoardDN;

        private string _GenBoardDVS;

        private string _SpeBoard;

        private string _SpeBoardDN;

        private string _SpeBoardDVS;

        private string _SMTFabricationDN;

        private string _SMTFabricationDVS;

        private string _SteelMesh;

        private string _CoorPattern;

        private string _Comments;

        public string MaterialCode
        {
            get
            {
                return this._MaterialCode;
            }
            set
            {
                this._MaterialCode = value;
            }
        }

        public string MaterialDesc
        {
            get
            {
                return this._MaterialDesc;
            }
            set
            {
                this._MaterialDesc = value;
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
    }
}

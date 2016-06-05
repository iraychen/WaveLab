using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    [Serializable]
    public  class SMTPCBSteelMeshInfo
    {
        private  string  _PCB;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        private string _SteelMesh;

        private System.Nullable<System.DateTime> _FactureDate;

        private string _SerialNo;

        private string _DocumentNo;

        private string _Comments;

        private string _Defect;

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

        public System.Nullable<System.DateTime> FactureDate
        {
            get
            {
                return this._FactureDate;
            }
            set
            {
                this._FactureDate = value;
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

        public string DocumentNo
        {
            get
            {
                return this._DocumentNo;
            }
            set
            {
                this._DocumentNo = value;
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

        public string Defect
        {
            get
            {
                return this._Defect;
            }
            set
            {
                this._Defect = value;
            }
        }
		
    }
}

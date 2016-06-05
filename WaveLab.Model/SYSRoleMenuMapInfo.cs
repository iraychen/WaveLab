using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
   [Serializable]
   public class SYSRoleMenuMapInfo
    {
        private string _RoleId;

        private int _MenuId;

        private System.Nullable<System.DateTime> _CreationDate;

        private string _CreatedBy;

        public SYSRoleMenuMapInfo()
		{
		}
		
		public string RoleId
		{
			get
			{
				return this._RoleId;
			}
			set
			{
				this._RoleId = value;

			}
		}

        public int MenuId
		{
			get
			{
				return this._MenuId;
			}
			set
			{
				this._MenuId = value;
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
    }
}

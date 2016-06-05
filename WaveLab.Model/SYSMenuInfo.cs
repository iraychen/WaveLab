using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
   public class SYSMenuInfo
    {
		private int _MenuId;
		
		private System.DateTime _LastUpdateDate;
		
		private string _LastUpdatedBy;
		
		private System.Nullable<System.DateTime> _CreationDate;
		
		private string _CreatedBy;
		
		private string _MenuDesc;
		
		private int _ParentId;
		
		private char _MenuItem;
		
		private string _Url;
		
		private System.Nullable<char> _Enabled;
		
		private System.Nullable<int> _Sequence;

        private string _ImageUrl;

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
		
		public string MenuDesc
		{
			get
			{
				return this._MenuDesc;
			}
			set
			{
			    this._MenuDesc = value;
			}
		}
		
		public int ParentId
		{
			get
			{
				return this._ParentId;
			}
			set
			{
				this._ParentId = value;
			}
		}

		public char MenuItem
		{
			get
			{
				return this._MenuItem;
			}
			set
			{
				this._MenuItem = value;

			}
		}
		
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
                this._Url = value;
			}
		}

        public System.Nullable<char> Enabled
		{
			get
			{
                return this._Enabled;
			}
			set
			{
                this._Enabled = value;
			}
		}
		
		public System.Nullable<int> Sequence
		{
			get
			{
				return this._Sequence;
			}
			set
			{
				this._Sequence = value;
			}
		}

        public string ImageUrl
        {
            get
            {
                return this._ImageUrl;
            }
            set
            {
                this._ImageUrl = value;
            }
        }
    }
}

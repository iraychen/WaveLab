using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SYSActionInfo
    {
        
		private int _ActionId;
		
		private string _Action;
		
		private string _ActionName;
		
		private System.Nullable<System.DateTime> _LastUpdateDate;
		
		private string _LastUpdatedBy;
		
		private System.Nullable<System.DateTime> _CreationDate;
		
		private string _CreatedBy;

        private SYSMenuInfo _ModuleItem;
		
		public int ActionId
		{
			get
			{
				return this._ActionId;
			}
			set
			{
                this._ActionId = value;
			}
		}
		
		public string Action
		{
			get
			{
				return this._Action;
			}
			set
			{
                this._Action = value;
			}
		}
		
		public string ActionName
		{
			get
			{
				return this._ActionName;
			}
			set
			{
                this._ActionName = value;
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

        public SYSMenuInfo ModuleItem
        {
            get
            {
                return this._ModuleItem;
            }
            set
            {
                this._ModuleItem = value;
            }
        }
    }
}

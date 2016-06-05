using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
   [Serializable]
   public class AdLogInfo
    {	
		private int _LogId;
		
		private System.DateTime _LastUpdateDate;
		
		private string _LastUpdatedBy;
		
		private string _AuditCategory;
		
		private string _LogMode;
		
		private string _LogDesc;
		
		private string _TableName;
		
		private string _ColumnName;
		
		private string _LogKey;
		
 
		public AdLogInfo()
		{
			
		}
		
		
		public int LogId
		{
			get
			{
				return this._LogId;
			}
			set
			{
				this._LogId = value;
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
		
		public string AuditCategory
		{
			get
			{
				return this._AuditCategory;
			}
			set
			{
				this._AuditCategory = value;
			}
		}
		
		public string LogMode
		{
			get
			{
				return this._LogMode;
			}
			set
			{
			    this._LogMode = value;
			}
		}
		
		public string LogDesc
		{
			get
			{
				return this._LogDesc;
			}
			set
			{
				this._LogDesc = value;
			}
		}

		public string TableName
		{
			get
			{
				return this._TableName;
			}
			set
			{
				this._TableName = value;	
			}
		}
		
		public string ColumnName
		{
			get
			{
				return this._ColumnName;
			}
			set
			{
				this._ColumnName = value;
			}
		}
		

		public string LogKey
		{
			get
			{
				return this._LogKey;
			}
			set
			{
				this._LogKey = value;					
			}
		}
    }
}

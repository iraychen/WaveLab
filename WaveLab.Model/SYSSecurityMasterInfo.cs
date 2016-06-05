using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
   [Serializable]
   public class SYSSecurityMasterInfo 
    {
        private string _UserId;

		private System.DateTime _LastUpdateDate;
		
		private string _LastUpdatedBy;
		
		private System.Nullable<System.DateTime> _CreationDate;
		
		private string _CreatedBy;
		
		private string _PassWord;
		
		private string _UserName;

        private string _Admin;
		
		private string _Active;
		
		private SYSSectionInfo _SectionItem;

        public string UserId
        {
	        get
	        {
		        return this._UserId;
	        }
	        set
	        {
		        this._UserId = value;
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
    	
        public string PassWord
        {
	        get
	        {
		        return this._PassWord;
	        }
	        set
	        {
		        this._PassWord = value;
	        }
        }

        public string UserName
        {
	        get
	        {
		        return this._UserName;
	        }
	        set
	        {
		        this._UserName = value;
	        }
        }

        public string Admin
        {
	        get
	        {
		        return this._Admin;
	        }
	        set
	        {
	            this._Admin = value;
	        }
        }
    	
        public string Active
        {
	        get
	        {
		        return this._Active;
	        }
	        set
	        {
	            this._Active = value;
	        }
        }
    	
        public SYSSectionInfo SectionItem
        {
	        get
	        {
		        return this._SectionItem;
	        }
	        set
	        {
	            this._SectionItem = value;
	        }
        }
    }
}

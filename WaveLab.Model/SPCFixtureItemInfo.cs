using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCFixtureItemInfo
    {
        private int _FixtureItemPK;

        private string _Fixture;

        private string _FrequencyBand;

        private string _CH;

        private System.DateTime _LastUpdateDate;

        private string _LastUpdatedBy;

        public int FixtureItemPK
        {
            get
            {
                return this._FixtureItemPK;
            }
            set
            {
                this._FixtureItemPK = value;
            }
        }

        public string Fixture
        {
            get
            {
                return this._Fixture;
            }
            set
            {
                this._Fixture = value;
            }
        }

        public string FrequencyBand
        {
            get
            {
                return this._FrequencyBand;
            }
            set
            {
                this._FrequencyBand = value;
            }
        }

        public string CH
        {
            get
            {
                return this._CH;
            }
            set
            {
                this._CH = value;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCProjectInfo
    {
        public string ProjectCode { get; set; }
        public string ProjectDesc { get; set; }
        public string ProjectType { get; set; }
        public int MinTimes { get; set; }
        public int MaxTimes { get; set; }
        public System.Nullable<int> GroupingNo { get; set; }
        public string Receiver { get; set; }
        public string CC { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}

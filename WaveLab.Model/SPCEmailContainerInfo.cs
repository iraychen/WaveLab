using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    public class SPCEmailContainerInfo
    {
        public string ProjectCode{ get; set; }
        public int ErrorPK { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public System.DateTime LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.DAL
{
    public abstract class  Convertor
    {
        public static string Format(TimeSpan timespan)
        {
            int hours=timespan.Hours;
            int minutes=timespan.Minutes;
            int seconds=timespan.Seconds;

            return String.Format("{0:D2}", hours) + ":" + String.Format("{0:D2}", minutes) + ":" + String.Format("{0:D2}", seconds);
        }
    }
}

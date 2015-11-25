using System;
using System.Collections.Generic;
using System.Text;

namespace BMSP.DBAccesser.DBScript
{
    public class TimeValue
    {
        public DateTime ExpiredOn;
        public object Value;

        public TimeValue(DateTime ExpiredOn, object Value)
        {
            this.ExpiredOn = ExpiredOn;
            this.Value = Value;
        }

        public static DateTime GetExpiredOn()
        {
            return DateTime.Now.AddMinutes(30);
        }

        public static TimeValue CreateTimeValue(object Value)
        {
            return new TimeValue(GetExpiredOn(), Value);
        }
    }
}

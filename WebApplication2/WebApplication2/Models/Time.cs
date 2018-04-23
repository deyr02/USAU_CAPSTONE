using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Time
    {
        public int TimeID { get; set; }
        public DateTime Time_Description { get; set; }

        public ICollection<Temperature_Time> Temperature_Times { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Daily_Temperature
    {
        public int Daily_TemperatureID { get; set;  }
        public DateTime Reproting_Date { get; set; }
        public double Temperature { get; set; }
        public int Temperature_TimeID { get; set; }

        public Temperature_Time Teperature_Time { get; set; }
    }
}
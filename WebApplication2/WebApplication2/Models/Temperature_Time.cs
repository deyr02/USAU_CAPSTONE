using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Temperature_Time
    {
        public int Temperature_TimeID { get; set; }

        public int EnclosureID { get; set; }
        public int TimeID { get; set; }
        public Enclosure Enclsoure { get; set; }
        public Time Time { get; set; }

        public ICollection<Daily_Temperature> Daily_Temperatures { get; set; }

    }
}
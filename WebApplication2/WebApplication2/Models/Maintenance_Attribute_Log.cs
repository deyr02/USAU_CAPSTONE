using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Maintenance_Attribute_Log
    {
        public int Maintenance_Attribute_LogID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        public String Log_Details { get; set; }
        public int Enclosure_Maintenance_AttributeID { get; set; }
        public int EnclosureID { get; set; }

        public Enclosure_Maintenance_Attribute Maintenance_Attribute { get; set; }
        public Enclosure EnclosureRecord { get; set; }

    }
}
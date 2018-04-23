using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Assign_Maintenance
    {
        public int EnclosureID { get; set; }
        public int Enclosure_Maintenance_TypeID { get; set; }
        public Enclosure Enclosure { get; set; }
        public Enclosure_Maintenance_Type Enclosure_Maintenance_Type { get; set; }
                                                           
    }
} 
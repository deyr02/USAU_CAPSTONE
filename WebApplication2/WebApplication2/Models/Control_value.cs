using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Control_value
    {
        public int Control_ValueID { get; set; }
        public string Control_Value_Description { get; set; }
        public int Enclosure_Maintenance_AttributeID { get; set; }
        public Enclosure_Maintenance_Attribute Enclosure_Maintenance_Attribute { get; set; }
    }
}

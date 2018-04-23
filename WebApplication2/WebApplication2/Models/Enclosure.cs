using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public enum Enclosure_Status
    {
        Active,
        Inactive,
    }
    public class Enclosure
    {
        public int EnclosureID { get; set; }
        public string Enclosure_Description { get; set; }
        public string Location { get; set; }
        public string Size { get; set; }
        public string Layout_Path { get; set; }
        public string Material_Used { get; set;  }
        public string Physical_photo { get; set; }
        public Enclosure_Status? Enclosure_Status { get; set; }
        public int EnclosureTypeID { get; set; }

        public EnclosureType EnclosureType { get; set; }
        public ICollection <Maintenance_Attribute_Log> Maintenance_Attribute_Log { get; set; }
        public ICollection <Temperature_Time> Temperature_Time { get; set; }
        public ICollection<Assign_Maintenance> Assign_Maintenances { get; set; }

    }
}
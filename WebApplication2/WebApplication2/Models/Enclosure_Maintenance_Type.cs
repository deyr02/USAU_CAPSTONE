using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Enclosure_Maintenance_Type
    {
        public int Enclosure_Maintenance_TypeID { get; set; }
        public string Maintenacne_Description { get; set; }
        public int Days { get; set; }

        public ICollection <Enclosure_Maintenance_Attribute> Enclosure_Maintenance_Attributes { get; set; }

        public ICollection<Assign_Maintenance> Assign_Maintenances { get; set; }

    }
}
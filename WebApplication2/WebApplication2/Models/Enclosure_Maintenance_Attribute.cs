using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2
{
    public class Enclosure_Maintenance_Attribute
    {
        public int Enclosure_Maintenance_AttributeID { get; set; }
        public string Attribute_Name { get; set; }
        public string Unit { get; set; }
        public int Max_value { get; set; }
        public int Min_value { get; set; }
        public string Error_Message { get; set; }

        public int ControlTypeID { get; set; }
        public int Data_TypeID { get; set; }
        public int Enclosure_Maintenance_TypeID { get; set; }
        public Enclosure_Maintenance_Type Enclosure_Maintenance_Type { get; set; }

        public Control_Type ControlType { get; set; }
        public Data_Type Data_Type { get; set; }
        public ICollection<Maintenance_Attribute_Log> Maintenance_Attribute_Logs { get; set; }
        public ICollection<Control_value> Control_Values { get; set; }
        
    }
}
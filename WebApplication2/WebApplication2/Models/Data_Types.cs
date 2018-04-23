using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Data_Type
    {
        public int Data_TypeID { get; set; }
        public string Data_Type_Descripton { get; set; }

        public ICollection<Enclosure_Maintenance_Attribute> Enclosure_Maintenance_Attributes { get; set; }

       

    }
}
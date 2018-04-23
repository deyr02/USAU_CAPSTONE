using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class EnclosureType
    {
        public int EnclosureTypeID { get; set; }
        public string Description { get; set; }

        public ICollection<Enclosure> Enclosures { get; set; }
        

    }
}
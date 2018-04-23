using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Data;

namespace WebApplication2.Models
{
    public static class DbInitializer
    {
        public static void Initialize(USAU_Context context)
        {
            context.Database.EnsureCreated();

            if (context.EnclosureTypes.Any())
            {
                return;
            }

            var EnclosureTypes = new EnclosureType[]
            {
                new EnclosureType {  EnclosureTypeID = 101, Description = "Ground"},
                new EnclosureType{EnclosureTypeID = 102,  Description = "Tank"}
            };

            foreach (EnclosureType ET in EnclosureTypes)
            {
                context.EnclosureTypes.Add(ET);
            }
            context.SaveChanges();
            var Enclosures = new Enclosure[]
            {
                new Enclosure { EnclosureTypeID =101, EnclosureID = 1001, Layout_Path = "", Enclosure_Description= "AAAAAAAA", Location = "Building 35", Material_Used = "adfasdfawsfdlasfdasdf", Physical_photo = "", Size = "250 sft"  },
                 new Enclosure { EnclosureTypeID =101, EnclosureID = 1002, Layout_Path = "", Enclosure_Description= "AAAAAAAA", Location = "Building 35", Material_Used = "adfasdfawsfdlasfdasdf", Physical_photo = "", Size = "250 sft"  },
                  new Enclosure { EnclosureTypeID =101, EnclosureID = 1003, Layout_Path = "", Enclosure_Description= "AAAAAAAA", Location = "Building 35", Material_Used = "adfasdfawsfdlasfdasdf", Physical_photo = "", Size = "250 sft"  },
                   new Enclosure { EnclosureTypeID =101, EnclosureID = 1004, Layout_Path = "", Enclosure_Description= "AAAAAAAA", Location = "Building 35", Material_Used = "adfasdfawsfdlasfdasdf", Physical_photo = "", Size = "250 sft"  },
                    new Enclosure { EnclosureTypeID =101, EnclosureID = 1005, Layout_Path = "", Enclosure_Description= "AAAAAAAA", Location = "Building 35", Material_Used = "adfasdfawsfdlasfdasdf", Physical_photo = "", Size = "250 sft"  },
                     new Enclosure { EnclosureTypeID =102, EnclosureID = 1006, Layout_Path = "", Enclosure_Description= "AAAAAAAA", Location = "Building 35", Material_Used = "adfasdfawsfdlasfdasdf", Physical_photo = "", Size = "250 sft"  },
                      new Enclosure { EnclosureTypeID =102, EnclosureID = 1007, Layout_Path = "", Enclosure_Description= "AAAAAAAA", Location = "Building 35", Material_Used = "adfasdfawsfdlasfdasdf", Physical_photo = "", Size = "250 sft"  }
            };

            foreach (Enclosure E in Enclosures)
            {
                context.Enclosures.Add(E);
            }
            context.SaveChanges();
            var ControlTypes = new Control_Type[]
            {
                new Control_Type { Control_TypeID = 1, Control_Description = "TextBox"},
                new Control_Type { Control_TypeID = 2, Control_Description= " CheckBox"},
                new Control_Type { Control_TypeID = 3, Control_Description = " CheckBox & TextBox"},
                  new Control_Type { Control_TypeID = 4, Control_Description = "Radio Button" },
                    new Control_Type { Control_TypeID = 5, Control_Description = "Combobox"}

            };


            foreach (Control_Type CT in ControlTypes)
            {
                context.ControlTypes.Add(CT);
            }
            context.SaveChanges();
            var DataTypes = new Data_Type[]
            {
                new Data_Type{ Data_TypeID =100001, Data_Type_Descripton= "Integer"},
                new Data_Type{ Data_TypeID =100002, Data_Type_Descripton= "Character"},
                new Data_Type{ Data_TypeID =100003, Data_Type_Descripton= "Double"},
                new Data_Type{ Data_TypeID =100004, Data_Type_Descripton= "Date and Time"}

            };

            foreach (Data_Type DT in DataTypes)
            {
                context.DataTypes.Add(DT);
            }
            context.SaveChanges();

            var Times = new Time[]
            {
                new Time { TimeID = 1},
                 new Time { TimeID = 2}
            };

            foreach (Time T in Times)
            {
                context.Times.Add(T);
            }
            context.SaveChanges();


            var Temperature_Times = new Temperature_Time[]
            {
                new Temperature_Time { Temperature_TimeID= 101, EnclosureID = 101, TimeID = 1},
                 new Temperature_Time { Temperature_TimeID= 102, EnclosureID = 101, TimeID = 2},

                  new Temperature_Time { Temperature_TimeID= 103, EnclosureID = 102, TimeID = 1},
                 new Temperature_Time { Temperature_TimeID= 104, EnclosureID = 103, TimeID = 2},
            };

            foreach (Temperature_Time TT in Temperature_Times)
            {
                context.Temperature_Times.Add(TT);

            }
            context.SaveChanges();

            var Enclosur_Maintenance_Types = new Enclosure_Maintenance_Type[]
            {
                new Enclosure_Maintenance_Type { Enclosure_Maintenance_TypeID= 1001, Maintenacne_Description = "Daily Maintenacne", Days= 1},
                new Enclosure_Maintenance_Type { Enclosure_Maintenance_TypeID= 1002, Maintenacne_Description = "Weekly Maintenacne", Days= 7},
                new Enclosure_Maintenance_Type { Enclosure_Maintenance_TypeID= 1003, Maintenacne_Description = "Fortnightly Maintenacne", Days= 15}

            };

            foreach (Enclosure_Maintenance_Type EMT in Enclosur_Maintenance_Types)
            {
                context.Enclosure_Maintenance_Types.Add(EMT);
            }

            context.SaveChanges();


            var Enclosure_Maintenance_Attributes = new Enclosure_Maintenance_Attribute[]
            {
                new Enclosure_Maintenance_Attribute { Enclosure_Maintenance_AttributeID =1, Attribute_Name = "PH", ControlTypeID = 1, Data_TypeID = 100003, Unit = "", Max_value= 50, Min_value = 0, Error_Message = "Ph value should be between  0 and 50", Enclosure_Maintenance_TypeID = 1001},
                new Enclosure_Maintenance_Attribute {Enclosure_Maintenance_AttributeID = 2, Attribute_Name = "Fileter Check", ControlTypeID = 3, Data_TypeID = 100003, Unit = "", Max_value= 50, Min_value = 0, Error_Message = "Ph value should be between  0 and 50", Enclosure_Maintenance_TypeID = 1001},
                new Enclosure_Maintenance_Attribute {Enclosure_Maintenance_AttributeID = 3, Attribute_Name = "Fileter Status", ControlTypeID = 4, Data_TypeID = 100003, Unit = "", Max_value= 50, Min_value = 0, Error_Message = "Ph value should be between  0 and 50", Enclosure_Maintenance_TypeID = 1001}
            };

            foreach (Enclosure_Maintenance_Attribute EMA in Enclosure_Maintenance_Attributes)
            {
                context.Enclosure_Maintenance_Attributes.Add(EMA);
            }
            context.SaveChanges();

            var Control_Values = new Control_value[]
            {
                new Control_value { Control_ValueID = 101, Control_Value_Description= "Yes", Enclosure_Maintenance_AttributeID = 3},
                 new Control_value { Control_ValueID = 102, Control_Value_Description= "NO", Enclosure_Maintenance_AttributeID = 3},

            };

            foreach (Control_value CV in Control_Values)
            {
                context.Control_Values.Add(CV);
            }
            context.SaveChanges();

            var Maintenance_Attribut4e_Logs = new Maintenance_Attribute_Log[]
            {
                new Maintenance_Attribute_Log { Maintenance_Attribute_LogID = 1, Date = System.DateTime.Now, Time = System.DateTime.Now, Enclosure_Maintenance_AttributeID = 1, Log_Details = 7.5.ToString(), EnclosureID = 101}
            };

            foreach (Maintenance_Attribute_Log MAL in Maintenance_Attribut4e_Logs)
            {
                context.Maintenance_Attribute_Logs.Add(MAL);
            }
            context.SaveChanges();

            var Assign_Maintenances = new Assign_Maintenance[]
            {
                new Assign_Maintenance { EnclosureID = 101, Enclosure_Maintenance_TypeID = 1001 }
            };

            foreach (Assign_Maintenance AM in Assign_Maintenances)
            {
                context.Assign_Maintenances.Add(AM);
            }
            context.SaveChanges();
        }
    }
}

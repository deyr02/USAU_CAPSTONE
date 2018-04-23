using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data
{
    public class USAU_Context: DbContext
    {
        public USAU_Context (DbContextOptions<USAU_Context> options) : base (options)
        {

        
        }

        public DbSet<EnclosureType> EnclosureTypes { get; set; }
        public DbSet<Enclosure> Enclosures { get; set;  }
        public DbSet <Control_Type> ControlTypes { get; set; }
        public DbSet<Data_Type> DataTypes { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Temperature_Time> Temperature_Times { get; set; }
        public DbSet <Daily_Temperature> Daily_Temperatures { get; set; }
        public DbSet<Enclosure_Maintenance_Type> Enclosure_Maintenance_Types { get; set; }
        public DbSet<Enclosure_Maintenance_Attribute> Enclosure_Maintenance_Attributes { get; set; }
        public DbSet<Maintenance_Attribute_Log> Maintenance_Attribute_Logs { get; set; }
        public DbSet<Assign_Maintenance> Assign_Maintenances { get; set; }
        public DbSet<Control_value> Control_Values { get; set; }



        protected override void OnModelCreating ( ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<EnclosureType>().ToTable("EnclosureType");
            modelbuilder.Entity<Enclosure>().ToTable("Enclosure");
            modelbuilder.Entity<Control_Type>().ToTable("ControlType");
            modelbuilder.Entity<Data_Type>().ToTable("DataType");
            modelbuilder.Entity<Time>().ToTable("Time");
            modelbuilder.Entity<Temperature_Time>().ToTable("Temperature_Time");
            modelbuilder.Entity<Daily_Temperature>().ToTable("Daily_Temperature");
            modelbuilder.Entity<Enclosure_Maintenance_Type>().ToTable("Enclosure_Maintenance_Type");
            modelbuilder.Entity<Enclosure_Maintenance_Attribute>().ToTable("Enclosure_Maintenance_Attribute");
            modelbuilder.Entity<Control_value>().ToTable("Contrl_value");
            modelbuilder.Entity<Maintenance_Attribute_Log>().ToTable("Maintenance_Attribute_Log");
            modelbuilder.Entity<Assign_Maintenance>().ToTable("Assign_Maintenance");

            modelbuilder.Entity<Assign_Maintenance>()
                .HasKey(AM => new { AM.EnclosureID, AM.Enclosure_Maintenance_TypeID });
            modelbuilder.Entity<Assign_Maintenance>()
                .HasOne(AM => AM.Enclosure)
                .WithMany(EMT => EMT.Assign_Maintenances)
                .HasForeignKey(AM => AM.EnclosureID);
            modelbuilder.Entity<Assign_Maintenance>()
                .HasOne(EMT => EMT.Enclosure_Maintenance_Type)
                .WithMany(E => E.Assign_Maintenances)
                .HasForeignKey(EMT => EMT.EnclosureID);

        }

    }
}

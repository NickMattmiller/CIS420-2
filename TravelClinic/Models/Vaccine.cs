using System;
using System.Data.Entity;
using System.Collections.Generic;

namespace asp.netmvc5.Models
{
   public class Vaccine
    {
       //public Vaccine()
       //{
       //    this.Refugees = new HashSet<Refugee>();
       //}
    

        public int Id { get; set; }
        public string Description { get; set; }
        public Int64 Barcode_NDC { get; set; }
        public decimal Dose { get; set; }
        public DateTime Date_Added { get; set; }
        public DateTime Date_Expire { get; set; }
        public decimal Price { get; set; }
        public bool Administered { get; set; }
        //NDC relationship
        public virtual NDC_Lookup NDC_Lookup { get; set; }
        //public virtual ICollection<Refugee> Refugees { get; set; }
        
        
    }



    public class VaccineDBContext : DbContext
    {
        public DbSet<Vaccine> Vaccines { get; set; }
        public System.Data.Entity.DbSet<asp.netmvc5.Models.NDC_Lookup> NDC_Lookup { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<GrantManagerModel> GrantManagers { get; set; }
	    public DbSet<Patient_Vaccination> Patient_Vaccinations { get; set; }
        public DbSet<Refugee> Refugees { get; set; }
        public DbSet<FAQ> FAQs { get; set; }

    }
}
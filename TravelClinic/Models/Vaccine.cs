using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.netmvc5.Models
{
   public class Vaccine
    {
       //public Vaccine()
       //{
       //    this.Refugees = new HashSet<Refugee>();
       //}

        [Display(Name = "Inventory ID")]
        public int Id { get; set; }
        [Display(Name = "Box 2D Bar")]
        public string Two_Dim_Barcode { get; set; }
        [Display(Name = "Vial Bar")]
        public string Unit_Use_Barcode_NDC { get; set; }
        public DateTime Date_Expire { get; set; }
        public string Lot_Number { get; set; }
        [Display(Name = "Box 1D Bar")]
        public Int64 Barcode_NDC { get; set; }
        public string Description { get; set; }
        [Display(Name = "Brand")]
        public string Brand_Name { get; set; }
        public string Package_Name { get; set; }

        public decimal Dose { get; set; }
        public DateTime Date_Added { get; set; }

       

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
        //public System.Data.Entity.DbSet<asp.netmvc5.Models.NDC_Lookup_Unit_Use> NDC_Lookup_Unit_Use { get; set; }

        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<GrantManagerModel> GrantManagers { get; set; }
	    public DbSet<Patient_Vaccination> Patient_Vaccinations { get; set; }
        public DbSet<Refugee> Refugees { get; set; }
        public DbSet<FAQ> FAQs { get; set; }

    }
}
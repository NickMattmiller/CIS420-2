using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetRoleBasedSecurity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using AspNetRoleBasedSecurity.Models;

namespace asp.netmvc5.Models
{
    public class Patient_Vaccination
    {
            [Key]
            public int AdministeredID { get; set; }
            public Int64 Barcode_NDC { get; set; }
            [ForeignKey("Vaccine")]
            public int VaccineID { get; set; }
            [ForeignKey("Refugees")]
            public int RefugeeId { get; set; }
            public int Patient_Num { get; set; }
            [Display(Name = "Employee")]
            [ForeignKey("User")]
            public string UserName { get; set; }
            public decimal Price_Paid { get; set; }
            public string Site_Administered { get; set; }
            public DateTime Date_Administered { get; set; }

        
       
            public virtual Vaccine Vaccine { get; set; }
            public virtual Refugee Refugees { get; set; }
            public virtual LoginViewModel User { get; set; }
            //public virtual ApplicationUser ApplicationUser { get; set; }


    }
}
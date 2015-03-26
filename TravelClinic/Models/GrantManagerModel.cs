using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace asp.netmvc5.Models
{
    public class GrantManagerModel
    {
        [Key]
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Grant_ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Grant_Name")]
        public string Grant_Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name= "Grant_Description")]
        public string Grant_Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Grant_Type")]
        public string Type { get; set; }
    }
}
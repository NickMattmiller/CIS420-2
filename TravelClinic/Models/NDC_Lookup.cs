using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.netmvc5.Models
{
    public class NDC_Lookup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 Barcode_NDC { get; set; }
        public string QRCode { get; set; }
        public string Route { get; set; }
        public string Brand_Name { get; set; }
        public int Code_CVX { get; set; }
        public string Description_CVX { get; set; }
        public string Description_Generic { get; set; }
        public string Package_Name { get; set; }
        public string Package_Type { get; set; }
        public DateTime Date_Updated { get; set; }



       


    }
}
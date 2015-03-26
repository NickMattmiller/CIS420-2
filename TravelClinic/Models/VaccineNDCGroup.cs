using System;
using System.ComponentModel.DataAnnotations;


namespace asp.netmvc5.Models
{
    public class VaccineNDCGroup
    {
        public Int64? Barcode_NDC { get; set; }
        public int VaccineCount { get; set; }
        public string Description { get; set; }


    }

}
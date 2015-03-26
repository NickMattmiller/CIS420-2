using System;
using System.ComponentModel.DataAnnotations;


namespace asp.netmvc5.Models
{
    public class Sales
    {
        public string Description { get; set; }
        public decimal SumOfPrice { get; set; } 
    }
}
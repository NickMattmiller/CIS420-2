using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp.netmvc5.Models
{
    public class FAQ
    {
        public int ID { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string Question { get; set; }
        [DataType(DataType.MultilineText)]
        public string Solution { get; set; }
        public DateTime Submitted { get; set; }
    }
}
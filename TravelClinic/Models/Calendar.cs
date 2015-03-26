using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace asp.netmvc5.Models
{
    public class Calendar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RequestDate { get; set; }
        public bool NewUser { get; set; }
    }


}
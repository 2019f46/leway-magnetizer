using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Magnetizer.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string x { get; set; }
        public string y { get; set; }
    }
}

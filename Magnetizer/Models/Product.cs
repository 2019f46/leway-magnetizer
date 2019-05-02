using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnetizer.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public bool IsMagnetized { get; set; }
        public virtual Location Location{get; set; }
        public double Weight { get; set; }
    }
}

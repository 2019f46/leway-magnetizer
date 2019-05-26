using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnetizer.Models
{
    /// <summary>
    /// Product model class
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ID used by Entity framework
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Reference to the products ID from the other database
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Whether the product is currently magnitized or not
        /// </summary>
        public bool IsMagnetized { get; set; }
        /// <summary>
        /// The product location
        /// </summary>
        public virtual Location Location{get; set; }
        /// <summary>
        /// Weight of the magnetizaition, how far it may deviate from the optimal path.
        /// </summary>
        public double Weight { get; set; }
    }
}

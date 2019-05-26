using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Magnetizer.Models
{
    /// <summary>
    /// Location model class
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Id used by Entity framework
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// X coordinate
        /// </summary>
        public string x { get; set; }
        /// <summary>
        /// Y coordinate
        /// </summary>
        public string y { get; set; }
    }
}

using Isima.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Isima.API.Models
{
    /// <summary>
    /// Student render to client 
    /// </summary>
    public class MapViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the Configuration.
        /// </summary>
        /// <value>
        /// The Configuration.
        /// </value>
        public string Configuration { get; set; }
       
    }
}
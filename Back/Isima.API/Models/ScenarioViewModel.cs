using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Isima.API.Models
{
    /// <summary>
    /// Student render to client 
    /// </summary>
    public class ScenarioViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the Chaine.
        /// </summary>
        /// <value>
        /// The Chaine.
        /// </value>
        public string Chaine { get; set; }
    }
}
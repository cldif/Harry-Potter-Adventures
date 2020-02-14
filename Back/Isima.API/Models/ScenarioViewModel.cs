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
        /// Gets or sets the Chaine.
        /// </summary>
        /// <value>
        /// The Chaine.
        /// </value>
        public string Text { get; set; }
        /// <summary>
        /// Get if this is game over
        /// </summary>
        /// <value>
        /// Get if this is game over
        /// </value>
        public byte GameOver { get; set; }

        /// <summary>
        /// the choice 1
        /// </summary>
        /// <value>
        /// the choice 1
        /// </value>
        public ChoiceViewModel Choice1 { get; set; }
        /// <summary>
        /// the choice 2
        /// </summary>
        /// <value>
        /// the choice 2
        /// </value>
        public ChoiceViewModel Choice2 { get; set; }
        /// <summary>
        /// the choice 3
        /// </summary>
        /// <value>
        /// the choice 3
        /// </value>
        public ChoiceViewModel Choice3 { get; set; }
        /// <summary>
        /// the choice 4
        /// </summary>
        /// <value>
        /// the choice 4
        /// </value>
        public ChoiceViewModel Choice4 { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Isima.API.Models
{
    public class ChoiceViewModel
    {
        /// <summary>
        /// The id of the scenario
        /// </summary>
        /// <value>
        /// The id of the scenario
        /// </value>
        public int ScenarioId { get; set; }
        /// <summary>
        /// The option text
        /// </summary>
        /// <value>
        /// The option text
        /// </value>
        public string Text { get; set; }
    }
}
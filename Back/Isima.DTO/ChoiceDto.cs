using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.DTO
{
    public class ChoiceDto
    {
        /// <summary>
        /// the id scenario
        /// </summary>
        /// <value>
        /// the id scenario
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// the curet id scenario
        /// </summary>
        /// <value>
        /// the id current scenario
        /// </value>
        public int? CurrentScenarioId { get; set; }
        /// <summary>
        /// the next id scenario
        /// </summary>
        /// <value>
        /// the next id scenario
        /// </value>
        public int? NextScenarioId { get; set; }
        /// <summary>
        /// the text of the choice
        /// </summary>
        /// <value>
        /// the text of the choice
        /// </value>
        public string Text { get; set; }
    }
}

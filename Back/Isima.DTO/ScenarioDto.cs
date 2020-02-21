using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Isima.DTO
{
    public class ScenarioDto
    {
        /// <summary>
        /// the id
        /// </summary>
        /// <value>
        /// the id
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// the label
        /// </summary>
        /// <value>
        /// the label
        /// </value>
        public string Label { get; set; }
        /// <summary>
        /// the text
        /// </summary>
        /// <value>
        /// the text
        /// </value>
        public string Text { get; set; }
        /// <summary>
        /// the game over
        /// </summary>
        /// <value>
        /// the game over
        /// </value>
        public byte GameOver { get; set; }
        /// <summary>
        /// the list of choices
        /// </summary>
        /// <value>
        /// the list of choices
        /// </value>
        public List<ChoiceDto> Choices { get; set; }
    }
}

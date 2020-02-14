using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.DTO
{
    public class ScenarioDto
    {
        public string Text { get; set; }
        public byte GameOver { get; set; }
        public ChoiceDto Choice1 { get; set; }
        public ChoiceDto Choice2 { get; set; }
        public ChoiceDto Choice3 { get; set; }
        public ChoiceDto Choice4 { get; set; }
    }
}

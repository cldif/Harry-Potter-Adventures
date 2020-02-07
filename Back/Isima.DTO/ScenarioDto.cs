using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.DTO
{
    public class ScenarioDto
    {
        public int Id { get; set; }
        public string Chaine { get; set; }
        public int? Choix1 { get; set; }
        public int? Choix2 { get; set; }
        public int? Choix3 { get; set; }
        public int? Choix4 { get; set; }
    }
}

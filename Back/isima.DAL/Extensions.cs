using isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.DAL
{
    public static class Extensions
    {
        public static Scenario ToEntity(this ScenarioDto dto)
        {
            return new Scenario
            {
                Chaine = dto.Chaine
            };
        }

        public static ScenarioDto ToDto(this Scenario entity)
        {
            if(entity != null)
            {
                return new ScenarioDto
                {
                    Chaine = entity.Chaine
                };
            }
            return null;
     
        }
    }
}

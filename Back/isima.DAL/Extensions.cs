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
                Chaine = dto.Chaine,
                Choix1 = dto.Choix1,
                Choix2 = dto.Choix2,
                Choix3 = dto.Choix3,
                Choix4 = dto.Choix4,
            };
        }

        public static ScenarioDto ToDto(this Scenario entity)
        {
            if(entity != null)
            {
                return new ScenarioDto
                {
                    Chaine = entity.Chaine,
                    Choix1 = entity.Choix1,
                    Choix2 = entity.Choix2,
                    Choix3 = entity.Choix3,
                    Choix4 = entity.Choix4,
                };
            }
            return null;
     
        }
    }
}

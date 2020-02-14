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
                Text = dto.Text,
                GameOver = dto.GameOver
            };
        }

        public static ScenarioDto ToDto(this Scenario entity)
        {
            if(entity != null)
            {

                return new ScenarioDto
                {
                    Text = entity.Text,
                    GameOver = entity.GameOver,
                    Choice1 = new ChoiceDto
                    {
                        ScenarioId = entity.ChoiceList.Choice.ScenarioId,
                        Text = entity.ChoiceList.Choice.Text,
                    },
                    Choice2 = new ChoiceDto
                    {
                        ScenarioId = entity.ChoiceList.Choice1.ScenarioId,
                        Text = entity.ChoiceList.Choice1.Text,
                    },
                    Choice3 = new ChoiceDto
                    {
                        //ScenarioId = Choix3Id,
                        //Text = Choix3Text,
                    },
                    Choice4 = new ChoiceDto
                    {
                        //ScenarioId = entity.ChoiceList.Choice3.ScenarioId,
                        //Text = entity.ChoiceList.Choice3.Text,
                    },
                };
            }
            return null;
        }
    }
}

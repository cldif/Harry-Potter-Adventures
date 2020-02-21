using isima.DAL;
using Isima.DTO;
using System;
using System.Collections;
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
                Label = dto.Label,
                Text = dto.Text,
                GameOver = dto.GameOver
            };
        }

        public static ScenarioDto ToDto(this Scenario entity, List<ChoiceDto> choices)
        {
            if(entity != null)
            {
                return new ScenarioDto
                {
                    Id = entity.Id,
                    Label = entity.Label,
                    Text = entity.Text,
                    GameOver = entity.GameOver,
                    Choices = choices
                };
            }
            return null;
        }

        public static Choice ToEntity(this ChoiceDto dto)
        {
            return new Choice
            {
                CurrentScenarioId = dto.CurrentScenarioId,
                NextScenarioId = dto.NextScenarioId,
                Text = dto.Text
            };
        }
        public static ChoiceDto ToDto(this Choice entity)
        {
            if (entity != null)
            {
                return new ChoiceDto
                {
                    CurrentScenarioId = entity.CurrentScenarioId,
                    NextScenarioId = entity.NextScenarioId,
                    Text = entity.Text
                };
            }
            return null;
        }
    }
}

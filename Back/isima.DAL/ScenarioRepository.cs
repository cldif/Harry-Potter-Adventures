using isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.DAL
{
    public class ScenarioRepository : IDisposable
    {

        private readonly IsimaEntities _dbcontext = null;

        public ScenarioRepository() 
            {
            _dbcontext = new IsimaEntities();
            }

        public ScenarioRepository(IsimaEntities context)
        {
            _dbcontext = context;
        }

        public ScenarioDto GetScenario(int id)
        {
            try
            {
                List<Choice> choiceList = _dbcontext.Choice.ToList();

                //transform to DTO, and send to upper layer
                List<ChoiceDto> choices = choiceList.Where(x => x.CurrentScenarioId == id).
                                                    Select(x => new ChoiceDto
                {
                    CurrentScenarioId = x.CurrentScenarioId,
                    NextScenarioId = x.NextScenarioId,
                    Text = x.Text,
                }).ToList();

                ScenarioDto scenarioEntities = _dbcontext.Scenario.Find(id).ToDto(choices);
                return scenarioEntities;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<ScenarioDto> GetAllScenario()
        {
            try
            {
                //Get all scenario data line from database 
                List<Scenario> scenarioEntities = _dbcontext.Scenario.ToList();
                //transform to DTO, and send to upper layer
                return scenarioEntities.Select(x => new ScenarioDto
                {
                    Id = x.Id,
                    Label = x.Label,
                    Text = x.Text,
                    GameOver = x.GameOver,
                }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public ScenarioDto AddScenario(ScenarioDto scenario)
        {
            Scenario newScenario = scenario.ToEntity();
            var scenarioCreated = _dbcontext.Scenario.Add(newScenario);
            _dbcontext.SaveChanges();
            return scenarioCreated.ToDto(scenario.Choices);
        }

        public void DeleteScenario(int id)
        {
            try
            {
                //Get all scenario data line from database 
                List<Scenario> scenarioEntities = _dbcontext.Scenario.ToList();
                _dbcontext.Scenario.Remove(scenarioEntities.Find(x => x.Id == id));
                _dbcontext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}

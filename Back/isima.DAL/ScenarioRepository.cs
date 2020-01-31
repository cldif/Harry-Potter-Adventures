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
                    Chaine = x.Chaine
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
            return scenarioCreated.ToDto();
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}

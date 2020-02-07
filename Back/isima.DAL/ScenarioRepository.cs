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
                    Chaine = x.Chaine,
                    Choix1 = x.Choix1,
                    Choix2 = x.Choix2,
                    Choix3 = x.Choix3,
                    Choix4 = x.Choix4
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

        
        public void DeleteAllScenario()
        {
            try
            {
                //Get all scenario data line from database 
                List<Scenario> scenarioEntities = _dbcontext.Scenario.ToList();
                //transform to DTO, and send to upper layer
                /*scenarioEntities.ToList().ForEach(item => {
                    _dbcontext.Scenario.Remove(item);
                });*/

                _dbcontext.Scenario.RemoveRange(scenarioEntities);
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

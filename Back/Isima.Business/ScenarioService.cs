using Isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;

namespace Isima.Business
{
    public class ScenarioService
    {

        public IList<ScenarioDto> GetAllScenario()
        {
            using(ScenarioRepository _scenarioRepo = new ScenarioRepository())
            {
                return _scenarioRepo.GetAllScenario();
            }
        }

        public ScenarioDto AddScenario(ScenarioDto scenario)
        {
            if(scenario !=null)
            {
                using (ScenarioRepository _scenarioRepo = new ScenarioRepository())
                {
                    return _scenarioRepo.AddScenario(scenario);
                }
            }
           else
            {
                throw new ArgumentNullException(nameof(scenario), "Scenario can't be null");
            }
        }

        public void DeleteAllScenario()
        {
            using (ScenarioRepository _scenarioRepo = new ScenarioRepository())
            {
                _scenarioRepo.DeleteAllScenario();
            }
        }
    }
}

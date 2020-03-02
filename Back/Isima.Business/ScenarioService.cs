using Isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;

namespace Isima.Business
{
    public class ScenarioService
    {
        public ScenarioDto GetScenario(int id)
        {
            using (ScenarioRepository _scenarioRepo = new ScenarioRepository())
            {
                return _scenarioRepo.GetScenario(id);
            }
        }
        public List<ScenarioDto> GetAllScenario()
        {
            using (ScenarioRepository _scenarioRepo = new ScenarioRepository())
            {
                return _scenarioRepo.GetAllScenario();
            }
        }
        public ScenarioDto AddScenario(ScenarioDto scenario)
        {
            using (ScenarioRepository _scenarioRepo = new ScenarioRepository())
            {
               return _scenarioRepo.AddScenario(scenario);
            }
        }

        public void DeleteScenario(int id)
        {
            using (ScenarioRepository _scenarioRepo = new ScenarioRepository())
            {
                _scenarioRepo.DeleteScenario(id);
            }
        }
    }
}

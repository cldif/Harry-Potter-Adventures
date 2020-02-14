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
    }
}

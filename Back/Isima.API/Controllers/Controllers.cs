using Isima.Business;
using Isima.DTO;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using System;

namespace Isima.API.Controllers
{
    /// <summary>
    /// Scenario Endpoint
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    /// 
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ScenarioController : ApiController
    {
        private readonly ScenarioService _scenarioService = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioController"/> class.
        /// </summary>
        public ScenarioController()
        {
            _scenarioService = new ScenarioService();
        }

        /// <summary>
        /// Get a scenario
        /// </summary>
        /// <remarks>
        /// Get a scenario
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">A scenario</response>
        [ResponseType(typeof(IEnumerable<ScenarioDto>))]
        public IHttpActionResult Get(int id)
        {
            ScenarioDto scenario = _scenarioService.GetScenario(id);
            return Ok(scenario);
        }

        /// <summary>
        /// Get a list of scenarios
        /// </summary>
        /// <remarks>
        /// Get a list of scenarios
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">A scenario</response>
        [ResponseType(typeof(IEnumerable<ScenarioDto>))]
        public IHttpActionResult Get()
        {
            List<ScenarioDto> scenarios = _scenarioService.GetAllScenario();
            return Ok(scenarios);
        }

        //public IHttpActionResult Get(int id)
        //{
        //   if(id <= 0)
        //    {
        //        return BadRequest("Scenario Id is required");
        //    }
        //   var scenario = _scenarioService.Gets
        //}


        /// <summary>
        /// Posts the specified scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <response code="200"> Created</response>
        /// <response code="400"> parameter issue</response>
        /// <response code="500">Other issues, see message included</response>
        public IHttpActionResult Post([FromBody]ScenarioDto scenario)
        {
            if (scenario == null)
            {
                return BadRequest("Scenario Id is required");
            }

            try
            {
                ScenarioDto scenarioDto = _scenarioService.AddScenario(
                    new ScenarioDto
                    {
                        Label = scenario.Label,
                        Text = scenario.Text,
                        GameOver = scenario.GameOver
                    }
                );

                return Ok(scenarioDto);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

    }

    /// <summary>
    /// Scenario Endpoint
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    /// 
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ChoiceController : ApiController
    {
        private readonly ChoiceService _choiceService = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="ChoiceController"/> class.
        /// </summary>
        public ChoiceController()
        {
            _choiceService = new ChoiceService();
        }
        /// <summary>
        /// Posts the choice
        /// </summary>
        /// <param name="scenario">The choice.</param>
        /// <response code="200"> Created</response>
        /// <response code="400"> parameter issue</response>
        /// <response code="500">Other issues, see message included</response>
        public IHttpActionResult PostChoice([FromBody]ChoiceDto choice)
        {
            if (choice == null)
            {
                return BadRequest("Choice Id is required");
            }

            try
            {
                ChoiceDto choiceDto = _choiceService.AddChoice(
                    new ChoiceDto
                    {
                        CurrentScenarioId = choice.CurrentScenarioId,
                        NextScenarioId = choice.NextScenarioId,
                        Text = choice.Text,
                    }
                );

                return Ok(choiceDto);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}

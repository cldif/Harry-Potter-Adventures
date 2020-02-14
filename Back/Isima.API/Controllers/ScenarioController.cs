using Isima.API.Models;
using Isima.Business;
using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;

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
        [ResponseType(typeof(IEnumerable<ScenarioViewModel>))]
        public IHttpActionResult Get(int id)
        {
            ScenarioDto scenarios = _scenarioService.GetScenario(id);
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

        /*
        /// <summary>
        /// Posts the specified scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <response code="200"> Created</response>
        /// <response code="400"> parameter issue</response>
        /// <response code="500">Other issues, see message included</response>
        public IHttpActionResult Post([FromBody]ScenarioViewModel scenario)
        {
            if(scenario == null)
            {
                return BadRequest("Scenario Id is required");
            }

            try
            {
                _scenarioService.AddScenario(new ScenarioDto
                {
                    Chaine = scenario.Chaine,
                    Choix1 = scenario.Choix1,
                    Choix2 = scenario.Choix2,
                    Choix3 = scenario.Choix3,
                    Choix4 = scenario.Choix4
                });

                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }*/
    }
}

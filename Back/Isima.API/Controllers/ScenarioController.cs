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
        /// Get list of all scenarios 
        /// </summary>
        /// <remarks>
        /// Get list of all scenarios from the database no filtered
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"> List of scenario</response>
        [ResponseType(typeof(IEnumerable<ScenarioViewModel>))]
        public IHttpActionResult Get()
        {
            IList<ScenarioDto> scenarios = _scenarioService.GetAllScenario();
            IEnumerable<ScenarioViewModel> scenarioList = scenarios.Select(st => new ScenarioViewModel
            {
                Id = st.Id,
                Chaine = st.Chaine,
                Choix1 = st.Choix1,
                Choix2 = st.Choix2,
                Choix3 = st.Choix3,
                Choix4 = st.Choix4
            });

            return Ok(scenarioList);

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

        }

        /// <summary>
        /// Delete all
        /// </summary>
        /// <remarks>
        /// delete all scenario
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"> delete successfully</response>
        public IHttpActionResult DeleteAll()
        {
            _scenarioService.DeleteAllScenario();

            return Ok();
        }

        //// PUT: api/Scenario/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Scenario/5
        //public void Delete(int id)
        //{
        //}
    }
}

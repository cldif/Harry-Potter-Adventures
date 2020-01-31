using Isima.API.Models;
using Isima.Business;
using Isima.DTO;
using Isima.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Isima.API.Controllers
{
    /// <summary>
    /// Map Endpoint
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class MapController : ApiController
    {
        private readonly MapService _MapService = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="MapController"/> class.
        /// </summary>
        public MapController()
        {
            _MapService = new MapService();
        }


        /// <summary>
        /// Get list of all Maps 
        /// </summary>
        /// <remarks>
        /// Get list of all Maps from the database no filtered
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"> List of Map</response>
        [ResponseType(typeof(IEnumerable<MapViewModel>))]
        public IHttpActionResult Get()
        {
            IList<MapDto> Maps = _MapService.GetAllMap();
            IEnumerable<MapViewModel> MapList = Maps.Select(st => new MapViewModel
            {
                Id = st.Id,
                Configuration = st.Configuration
            });

            return Ok(MapList);

        }

        //public IHttpActionResult Get(int id)
        //{
        //   if(id <= 0)
        //    {
        //        return BadRequest("Map Id is required");
        //    }
        //   var Map = _MapService.Gets
        //}

        /// <summary>
        /// Posts the specified Map.
        /// </summary>
        /// <param name="Map">The Map.</param>
        /// <response code="200"> Created</response>
        /// <response code="400"> parameter issue</response>
        /// <response code="500">Other issues, see message included</response>
        public IHttpActionResult Post([FromBody]MapViewModel Map)
        {
            if(Map == null)
            {
                return BadRequest("Map Id is required");
            }

            try
            {
                _MapService.AddMap(new MapDto
                {
                    Configuration = Map.Configuration
                });

                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        //// PUT: api/Map/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Map/5
        //public void Delete(int id)
        //{
        //}
    }
}

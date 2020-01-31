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
        private readonly MapService _mapService = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="MapController"/> class.
        /// </summary>
        public MapController()
        {
            _mapService = new MapService();
        }


        /// <summary>
        /// Get list of all maps 
        /// </summary>
        /// <remarks>
        /// Get list of all maps from the database no filtered
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"> List of map</response>
        [ResponseType(typeof(IEnumerable<MapViewModel>))]
        public IHttpActionResult Get()
        {
            IList<MapDto> maps = _mapService.GetAllMap();
            IEnumerable<MapViewModel> mapList = maps.Select(st => new MapViewModel
            {
                Id = st.Id,
                Configuration = st.Configuration
            });

            return Ok(mapList);

        }

        //public IHttpActionResult Get(int id)
        //{
        //   if(id <= 0)
        //    {
        //        return BadRequest("Map Id is required");
        //    }
        //   var map = _mapService.Gets
        //}

        /// <summary>
        /// Posts the specified map.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <response code="200"> Created</response>
        /// <response code="400"> parameter issue</response>
        /// <response code="500">Other issues, see message included</response>
        public IHttpActionResult Post([FromBody]MapViewModel map)
        {
            if(map == null)
            {
                return BadRequest("Map Id is required");
            }

            try
            {
                _mapService.AddMap(new MapDto
                {
                    Configuration = map.Configuration
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

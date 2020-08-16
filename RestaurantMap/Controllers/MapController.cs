using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantMap.Model;
using RestaurantMap.Services;

namespace RestaurantMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MapController : ControllerBase
    {
        private IGoogleMapService googleMapService;

        public MapController(IGoogleMapService googleMapService)
        {
            this.googleMapService = googleMapService;
        }

        
        [HttpGet, Route("Healthcheck")]
        public IActionResult Healthcheck()
        {
            return StatusCode(200,"API IS Okey");
        }

        /// <summary>
        /// get nearby place where 
        /// </summary>
        /// <returns> PlaceResponse </returns>
        [HttpPost, Route("FindNearbyPlaceByLocation")]
        public async Task<ActionResult<PlaceResponse>> FindNearbyPlaceByLocation(string place = "Bang%20sue")
        {
            var result = googleMapService.FindNearbySearchByPlace(place);

            if (!result.status.Equals("OK", StringComparison.OrdinalIgnoreCase))
                return StatusCode(500, result);

            return result;
        }

        [HttpPost,Route("FindPlace")]
        public async Task<ActionResult<PlaceResponse>> FindPlace(string place = "Bang%20sue")
        {
            var result = googleMapService.FindPlace(place);

            if (!result.status.Equals("OK", StringComparison.OrdinalIgnoreCase))
                return StatusCode(500, result);

            return result;
        }
    }
}
using ASP_Project.Entities;
using ASP_Project.Managers;
using ASP_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        private readonly ILocationManager manager;
        public LocationController(ILocationManager location)
        {
            this.manager = location;
        }

        [HttpGet("get_ordered_streets")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetOrderedStreets()
        {
            var streets = manager
                .GetOrderedLocations()
                .Select(x => new { Id = x.Id, Street = x.Street });

            return Ok(streets);
        }

        [HttpGet("")]
        public List<Location> GetStreets()
        {
            var streets = manager.GetOrderedLocations();

            return streets;
        }

        [HttpPost("create_location")]
        public async Task<IActionResult> Create([FromBody] locationModel locationModel)
        {
            manager.Create(locationModel);

            return Ok();
        }

        [HttpPut("update_location")]
        public async Task<IActionResult> Update([FromBody] locationModel locationModel)
        {
            manager.Update(locationModel);

            return Ok();
        }

        [HttpDelete("delete_location/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            manager.Delete(id);

            return Ok();
        }
    }
}

using ASP_Project.Entities;
using ASP_Project.Managers;
using ASP_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantManager manager;

        public RestaurantController(IRestaurantManager restaurantManager)
        {
            this.manager = restaurantManager;
        }


        [HttpGet]
        //[Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetRestaurants()
        {
            // db in an instance of our context(where we have the tables)

            var restaurants = manager.GetRestaurants();

            // the equivalent of SELECT * FROM RESTAURANTS

            return Ok(restaurants);
        }


        [HttpGet("{id}")]
        //[Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetRestaurantById([FromRoute] string id)
        {
            // db in an instance of our context(where we have the tables)

            var restaurant = manager.GetRestaurantById(id);

            // the equivalent of SELECT * FROM RESTAURANTS
            return Ok(restaurant);
        }
        /*

        // eager-loading
        [HttpGet("select-restaurant-id")]
        public async Task<IActionResult> GetRestaurantsIds()
        {
            //var db = new ASP_ProjectContext();

            var idList = db.Restaurants.Select(x => x.Id).ToList();     // the query happens instantly, after the info from the db is loaded into the memory, we don't have anything to do with it anymore

            // the equivalent of SELECT ID FROM RESTAURANTS
            return Ok(idList);
        }

        //lazy-loading
        [HttpGet("select-restaurant-name")]
        public async Task<IActionResult> GetRestaurantsNames()
        {
            //var db = new ASP_ProjectContext();

            var NameList = db.Restaurants.Select(x => x.Name).AsQueryable();        // we'll have in our memory the query, not the information

            return Ok(NameList);      // only when vs needs NameList is the information loaded into the memory
        }*/

        [HttpPost()]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] restaurantModel restaurantModel)
        {
            manager.Create(restaurantModel);

            return Ok();
        }

        [HttpPut()]
        //[Authorize(Policy = "Admin")]

        public async Task<IActionResult> Update([FromBody] restaurantModel restaurantModel)
        {
            manager.Update(restaurantModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]

        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            manager.Delete(id);

            return Ok();
        }
    }
}

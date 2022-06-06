using ASP_Project.Entities;
using ASP_Project.Managers;
using ASP_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishManager manager;

        public DishController(IDishManager dishManager)
        {
            this.manager = dishManager;
        }

        [HttpGet("filter_dishes/{restaurant_name}")]
        public async Task<IActionResult> GetFilteredDishes([FromRoute] string restaurant_name)
        {
            var dishesFiltered = manager.GetFilteredDishes(restaurant_name);

            return Ok(dishesFiltered);
        }


        [HttpPost("create_dish")]
        [Authorize(Policy = "Chef")]
        public async Task<IActionResult> Create([FromBody] dishModel dishModel)     // all endpoints except GET have FromBody
        {
            manager.Create(dishModel);

            return Ok();
        }


        [HttpPut("update_dish")]
        [Authorize(Policy = "Chef")]
        public async Task<IActionResult> Update([FromBody] dishModel dishModel)
        {
            manager.Update(dishModel);

            return Ok();
        }

        [HttpDelete("delete_dish/{id}")]
        [Authorize(Policy = "Chef")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            manager.Delete(id);

            return Ok();
        }
    }
}

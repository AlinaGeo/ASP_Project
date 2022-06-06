using ASP_Project.Entities;
using ASP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASP_Project.Managers
{
    public interface IRestaurantManager
    {
        List<Restaurant> GetRestaurants();
        void Create(restaurantModel model);
        Restaurant GetRestaurantById(string id);
        //void Create(string name);
        void Update(restaurantModel model);
        void Delete(string id);
    }
}

using ASP_Project.Entities;
using ASP_Project.Models;
using ASP_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASP_Project.Managers

{
    public class RestaurantManager : IRestaurantManager
    {
        private readonly IRestaurantRepository restaurantRepository;
        public RestaurantManager(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        /*        public void Create(string name)
                {
                    var newRestaurant = new Restaurant
                    {
                        Id = "7",
                        Name = name
                    };

                    restaurantRepository.Create(newRestaurant);
                }*/
        public List<Restaurant> GetRestaurants()
        {
            return restaurantRepository.GetRestaurantsIQueryable().ToList();
        }

        public void Create(restaurantModel model)
        {
            var newRestaurant = new Restaurant
            {
                Id = model.Id,
                Name = model.Name
            };

            restaurantRepository.Create(newRestaurant);
        }

        public void Update(restaurantModel model)
        {
            var restaurant = GetRestaurantById(model.Id);

            restaurant.Name = model.Name;
            restaurantRepository.Update(restaurant);
        }

        public void Delete(string id)
        {
            var restaurant = GetRestaurantById(id);
            restaurantRepository.Delete(restaurant);
        }

        public Restaurant GetRestaurantById(string id)
        {
            var restaurant = restaurantRepository.GetRestaurantsIQueryable()
                .FirstOrDefault(x => x.Id == id);

            return restaurant;
        }
    }
}

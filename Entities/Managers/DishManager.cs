using ASP_Project.Entities;
using ASP_Project.Models;
using ASP_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASP_Project.Managers
{
    public class DishManager : IDishManager
    {
        private readonly IDishRepository dishRepository;
        public DishManager(IDishRepository dishRepository)
        {
            this.dishRepository = dishRepository;
        }

        public List<string> GetFilteredDishes(string name)
        {
            var dishes = dishRepository.GetDishes();

            var filteredDishes = dishes
                .Where(x => x.Restaurant.Name == name)
                .Select(x => x.Name)
                .ToList();

            return filteredDishes;
        }

        public void Create(dishModel model)
        {
            var newDish = new Dish
            {
                Id = model.Id,
                Name = model.Name,
                RestaurantId = model.RestaurantId
            };

            dishRepository.Create(newDish);
        }

        public void Update(dishModel model)
        {
            var dish = GetDishById(model.Id);
            dish.Name = model.Name;
            dish.RestaurantId = model.RestaurantId;
            dishRepository.Update(dish);
        }

        public void Delete(string id)
        {
            var dish = GetDishById(id);
            dishRepository.Delete(dish);
        }

        public Dish GetDishById(string id)
        {
            var dish = dishRepository.GetDishes()
                .FirstOrDefault(x => x.Id == id);

            return dish;
        }
    }
}

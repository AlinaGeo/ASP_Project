using ASP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASP_Project.Repositories

{
    public interface IDishRepository
    {
        IQueryable<Dish> GetDishes();
        IQueryable<Dish> GetDishesJoinRestaurants();
        void Create(Dish dish);
        void Update(Dish dish);
        void Delete(Dish dish);
    }
}

using ASP_Project.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASP_Project.Repositories
{
    public class DishRepository : IDishRepository
    {
        private ASP_ProjectContext db;
        public DishRepository(ASP_ProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Dish> GetDishes()
        {
            var dishes = db.Dishes;

            return dishes;
        }



        public IQueryable<Dish> GetDishesJoinRestaurants()
        {
            var dishes = GetDishes().Include(x => x.RestaurantId);

            return dishes;
        }

        public void Create(Dish dish)
        {
            db.Dishes.Add(dish);

            db.SaveChanges();
        }

        public void Update(Dish dish)
        {
            db.Dishes.Update(dish);

            db.SaveChanges();
        }

        public void Delete(Dish dish)
        {
            db.Dishes.Remove(dish);

            db.SaveChanges();
        }
    }
}

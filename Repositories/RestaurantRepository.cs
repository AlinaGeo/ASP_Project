using ASP_Project.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASP_Project.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private ASP_ProjectContext db;
        public RestaurantRepository(ASP_ProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Restaurant> GetRestaurantsIQueryable()
        {
            var restaurant = db.Restaurants
                                .Include(x => x.Location)
                                .Include(x => x.Dishes)
                                .Include(x => x.Beverages)
                                .Include(x => x.RestaurantPartnerships); ;

            return restaurant;
        }

        public void Create(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);

            db.SaveChanges();
        }

        public void Update(Restaurant restaurant)
        {
            db.Restaurants.Update(restaurant);

            db.SaveChanges();
        }

        public void Delete(Restaurant restaurant)
        {
            db.Restaurants.Remove(restaurant);

            db.SaveChanges();
        }
    }
}

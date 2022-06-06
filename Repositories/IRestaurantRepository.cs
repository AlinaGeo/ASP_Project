using ASP_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASP_Project.Repositories

{
    public interface IRestaurantRepository
    {
        IQueryable<Restaurant> GetRestaurantsIQueryable();
        void Create(Restaurant restaurant);
        void Update(Restaurant restaurant);
        void Delete(Restaurant restaurant);
    }
}

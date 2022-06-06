/*using ASP_Project.Entities;
using ASP_Project.Models;
using ASP_Project.Repositories;
using System.Collections.Generic;

namespace ASP_Project.Managers
{
    public class BeverageManager : IBeverageManager
    {
        private readonly IBeverageRepository beverageRepository;
        public BeverageManager(IBeverageRepository beverageRepository)
        {
            this.beverageRepository = beverageRepository;
        }

        public List<string> GetBeverages(string name)
        {
            throw new System.NotImplementedException();
        }

        public void Create(beverageModel model)
        {
            var newBeverage = new Beverage
            {
                Id = model.Id,
                Name = model.Name,
                RestaurantId = model.RestaurantId
            };

            beverageRepository.Create(newBeverage);
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Beverage GetBeverageById(string id)
        {
             var beverage = beverageRepository.GetBeverages()
            //var beverage = beverageRepository.GetBeveragesIQueryable()
               .FirstOrDefault(x => x.Id == id);

            return beverage;
        }

        public void Update(beverageModel model)
        {
            var dish = GetDishById(model.Id);
            dish.Name = model.Name;
            dish.RestaurantId = model.RestaurantId;
            dishRepository.Update(dish);
        }
    }
}
*/
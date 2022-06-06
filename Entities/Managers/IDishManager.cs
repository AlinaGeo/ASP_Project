using ASP_Project.Entities;
using ASP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASP_Project.Managers
{
    public interface IDishManager
    {
        List<string> GetFilteredDishes(string name);
        Dish GetDishById(string id);
        void Create(dishModel model);
        void Update(dishModel model);
        void Delete(string id);
    }
}

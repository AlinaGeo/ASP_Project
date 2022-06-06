using ASP_Project.Entities;
using ASP_Project.Models;
using System.Collections.Generic;

namespace ASP_Project.Managers
{
    public interface IBeverageManager
    {
        List<string> GetBeverages(string name);
        Beverage GetBeverageById(string id);
        void Create(beverageModel model);
        void Update(beverageModel model);
        void Delete(string id);
    }
}

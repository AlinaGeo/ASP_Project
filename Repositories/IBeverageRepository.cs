using ASP_Project.Entities;
using System.Linq;

namespace ASP_Project.Repositories
{
    public interface IBeverageRepository
    {
        IQueryable<Beverage> GetBeveragesIQueryable();
        void Create(Beverage beverage);
        void Update(Beverage beverage);
        void Delete(Beverage beverage);
    }
}

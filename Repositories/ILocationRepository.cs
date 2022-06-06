using ASP_Project.Entities;
using System.Linq;

namespace ASP_Project.Repositories
{
    public interface ILocationRepository
    {
        IQueryable<Location> GetOrderedLocationsIQueryable();
        IQueryable<Location> GetLocationsIQueryable();
        void Create(Location location);
        void Update(Location location);
        void Delete(Location location);
    }
}

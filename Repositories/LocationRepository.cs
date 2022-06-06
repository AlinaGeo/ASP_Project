using ASP_Project.Entities;
using System.Linq;

namespace ASP_Project.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private ASP_ProjectContext db;
        public LocationRepository(ASP_ProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Location> GetOrderedLocationsIQueryable()
        {
            var locations = db.Locations
                // we can also return a new object, eg.
                //.Select(x => new { Id = x.Id, FirstDishName = x.Restaurant.FirstOrDefault().Id})
                //.Select(x => new { Id = x.Id, Street = x.Street })
                .OrderBy(x => x.Street);

            return locations;
        }

        public IQueryable<Location> GetLocationsIQueryable()
        {
            var locations = db.Locations;

            return locations;
        }

        public void Create(Location location)
        {
            db.Locations.Add(location);

            db.SaveChanges();
        }

        public void Update(Location location)
        {
            db.Locations.Update(location);

            db.SaveChanges();
        }

        public void Delete(Location location)
        {
            db.Locations.Remove(location);

            db.SaveChanges();
        }
    }
}

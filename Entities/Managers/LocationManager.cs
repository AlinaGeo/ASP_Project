using ASP_Project.Entities;
using ASP_Project.Models;
using ASP_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASP_Project.Managers
{
    public class LocationManager : ILocationManager
    {
        private readonly ILocationRepository locationRepository;

        public LocationManager(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public List<Location> GetOrderedLocations()
        {
            return locationRepository.GetOrderedLocationsIQueryable().ToList();
        }

        public void Create(locationModel model)
        {
            var newLocation = new Location
            {
                Id = model.Id,
                Street = model.Street
            };

            locationRepository.Create(newLocation);
        }

        public void Update(locationModel model)
        {
            var location = GetLocationById(model.Id);

            location.Street = model.Street;
            locationRepository.Update(location);
        }

        public void Delete(string id)
        {
            var location = GetLocationById(id);
            locationRepository.Delete(location);
        }

        public Location GetLocationById(string id)
        {
            var location = locationRepository.GetLocationsIQueryable()
                .FirstOrDefault(x => x.Id == id);

            return location;
        }

    }
}

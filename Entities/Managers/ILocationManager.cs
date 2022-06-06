using ASP_Project.Entities;
using ASP_Project.Models;
using System.Collections.Generic;

namespace ASP_Project.Managers
{
    public interface ILocationManager
    {
        List<Location> GetOrderedLocations();
        void Create(locationModel model);
        void Update(locationModel model);
        void Delete(string id);
        Location GetLocationById(string id);
    }
}

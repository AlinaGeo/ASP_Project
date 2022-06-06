using System.Collections.Generic;

namespace ASP_Project.Entities
{
    public class Restaurant
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual Location Location { get; set; }      // a restaurant can be in a single location
        public virtual ICollection<Dish> Dishes { get; set; }       // a restaurant can have multiple dishes
        public virtual ICollection<Beverage> Beverages { get; set; }        // a restaurant can have multiple beverages
        public virtual ICollection<RestaurantPartnership> RestaurantPartnerships { get; set; }
    }
}

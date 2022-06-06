using System.Collections.Generic;

namespace ASP_Project.Entities
{
    public class Partnership
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RestaurantPartnership> RestaurantPartnerships { get; set; }
    }
}
